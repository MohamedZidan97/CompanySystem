using System;

namespace VirtualCompany.Data_Access_Layer.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ComeDate { get; set; }
        public string PhotoName { get; set; }
        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Depender> Dependers { get; set; }

    }
}
