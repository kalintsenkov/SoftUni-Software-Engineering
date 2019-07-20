namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            var classType = Type.GetType($"Stealer.{className}");

            var fields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => fieldNames.Contains(x.Name));

            var classInstance = Activator.CreateInstance(classType);

            var fieldsInfo = new StringBuilder();

            fieldsInfo.AppendLine($"Class under investigation: {className}");

            foreach (var field in fields)
            {
                fieldsInfo.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return fieldsInfo.ToString().TrimEnd();
        }
    }
}