namespace VirtualCompany.Models.Employee
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ComeDate { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }
    }
}
