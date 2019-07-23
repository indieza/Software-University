namespace ValidationAttributes.Utilities
{
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Attributes;

    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();

            foreach (PropertyInfo property in propertyInfos)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}