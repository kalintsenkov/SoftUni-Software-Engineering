namespace _11FindLatest10Projects
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using SoftUni.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var result = GetLatestProjects(context);

                Console.WriteLine(result);
            }
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var project in lastProjects)
            {
                result.AppendLine(project.Name);
                result.AppendLine(project.Description);
                result.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return result.ToString().TrimEnd();
        }
    }
}
