using System.Reflection;

namespace SupMark.Core.Extensions
{
    public static class BaseExtensions
    {
        public static PropertyInfo[] GetProperties<T>(this T model)
        {
            return model?.GetType().GetProperties();
        }

        public static bool AllPropertiesAreNull<T>(this T model)
        {
            var attributes = model.GetProperties();

            foreach (var attribute in attributes)
            {
                if (attribute.PropertyType == typeof(int))
                {
                    if ((int)attribute.GetValue(model) != 0) return false;
                }
                else
                {
                    if (attribute.GetValue(model) != null) return false;
                }
            }

            return true;
        }
    }
}
