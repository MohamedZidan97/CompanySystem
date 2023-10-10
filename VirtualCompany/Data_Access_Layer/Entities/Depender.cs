namespace VirtualCompany.Data_Access_Layer.Entities
{
    public class Depender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
    }
}
