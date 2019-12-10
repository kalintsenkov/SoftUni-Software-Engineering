namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
