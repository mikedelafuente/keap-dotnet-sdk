using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Keap.Sdk.Clients
{
    internal static class CustomExtensionMethods
    {
        /// <summary>
        /// A shallow clone
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<T> GetClone<T>(this List<T> source)
        {
            return source.GetRange(0, source.Count);
        }

        public static string GetJsonPropertyName<T, TProp>(this T o, Expression<Func<T, TProp>> propertySelector)
        {
            MemberExpression body = (MemberExpression)propertySelector.Body;
            var customAttribute = body.Member.GetCustomAttributesData().SingleOrDefault(x => x.AttributeType == typeof(JsonPropertyNameAttribute));
            var result = body.Member.Name;
            if (customAttribute != null)
            {
                var constructorArgument = customAttribute.ConstructorArguments.FirstOrDefault();
                if (constructorArgument.ArgumentType == typeof(string))
                {
                    result = constructorArgument.Value?.ToString() ?? body.Member.Name;
                }
            }

            return result;
        }
    }
}