namespace ValidationAttributes
{
    using System.Linq;
    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var propertyInfos = obj
                .GetType()
                .GetProperties();

            foreach (var property in propertyInfos)
            {
                var attributes = property
                    .GetCustomAttributes(true)
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributes)
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
