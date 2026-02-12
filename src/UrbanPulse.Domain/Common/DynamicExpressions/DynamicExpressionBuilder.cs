using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace UrbanPulse.Domain.Common.DynamicExpressions;

public static class DynamicExpressionBuilder
{
    public static Expression<Func<T, bool>>? BuildFilter<T>(string propertyName, string operation, string value)
    {
        MethodInfo _startsWithMethod = typeof(string).GetMethod(nameof(string.StartsWith), [typeof(string)])!;
        MethodInfo _endsWithMethod = typeof(string).GetMethod(nameof(string.EndsWith), [typeof(string)])!;
        MethodInfo _containsMethod = typeof(string).GetMethod(nameof(string.Contains), [typeof(string)])!;

        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");

        PropertyInfo? propertyInfo = typeof(T).GetProperty(propertyName,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        if (propertyInfo is null) return null;

        MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, propertyInfo);

        TypeConverter converter = TypeDescriptor.GetConverter(propertyInfo.PropertyType);
        if (!converter.CanConvertFrom(typeof(string))) return null;

        object? propertyValue = converter.ConvertFromInvariantString(value);
        ConstantExpression constant = Expression.Constant(propertyValue);

        // 3. Construir la expresión según el operador
        Expression body = operation.ToLower() switch
        {
            "eq" => Expression.Equal(propertyAccess, constant),
            "neq" => Expression.NotEqual(propertyAccess, constant),
            "gt" => Expression.GreaterThan(propertyAccess, constant),
            "gte" => Expression.GreaterThanOrEqual(propertyAccess, constant),
            "lt" => Expression.LessThan(propertyAccess, constant),
            "lte" => Expression.LessThanOrEqual(propertyAccess, constant),
            "sw" => Expression.Call(propertyAccess, _startsWithMethod, constant),
            "ew" => Expression.Call(propertyAccess, _endsWithMethod, constant),
            "cont" => Expression.Call(propertyAccess, _containsMethod, constant),
            _ => throw new InvalidOperationException($"Unsupported operation '{operation}' for dynamic filtering")
        };

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }

    public static Expression<Func<T, object>>? BuildSort<T>(string propertyName)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
        PropertyInfo? propertyInfo = typeof(T).GetProperty(propertyName,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        if (propertyInfo is null) return null;

        MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, propertyInfo);
        UnaryExpression conversion = Expression.Convert(propertyAccess, typeof(object));

        return Expression.Lambda<Func<T, object>>(conversion, parameter);
    }
}
