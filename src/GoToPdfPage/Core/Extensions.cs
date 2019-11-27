using System;
using System.Linq;
using System.Reflection;

namespace GoToPdfPage
{
    public static class Extensions
    {
        public static B GetProperty<T, B>(this T obj, string name, BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) where T : class where B : class
        {
            var type = obj.GetType();
            var propertyInfos = type.GetProperties(flags);
            var propertyInfo = propertyInfos.FirstOrDefault(prop => prop.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (propertyInfo == null) return null;

            return propertyInfo.GetValue(obj) as B;

        }
    }
}
