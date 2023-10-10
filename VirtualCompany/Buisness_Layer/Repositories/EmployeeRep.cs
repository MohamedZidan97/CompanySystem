using Microsoft.AspNetCore.Http.HttpResults;
using VirtualCompany.Buisness_Layer.Interfaces;
using VirtualCompany.Data_Access_Layer;
using VirtualCompany.Data_Access_Layer.Entities;
using VirtualCompany.Models.Employee;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VirtualCompany.Buisness_Layer.Repositories
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly ApplicationDbContext db;

        public EmployeeRep(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IQueryable<Depender>> GetAnyEqualId(int id)
        {
            var DependersOfEachEmployee= db.dependers.Where(e=>e.EmployeeId==id);

            return DependersOfEachEmployee;
        }
        public async Task AddEmployee(EmployeeFileVM employee)
        {
            Employee emp = new Employee();
            emp.Name = employee.Name;
            emp.Notes = employee.Notes;
            emp.IsActive = employee.IsActive;
            emp.PhotoName = employee.PhotoUrl.FileName;
            emp.ComeDate = employee.ComeDate;
            db.Add(emp);
            db.SaveChanges();
        }

        public async Task Delete(int id)
        {
            db.employees.Remove(db.employees.Find(id));
            db.SaveChanges();

        }

        public async Task<IQueryable<Employee>> Get()
        {

            var data = db.employees.Select(a => a).OrderBy(e => e.Name);
            return data;
        }
        public async Task<EmployeeVM> getByEmployeeId(int id)
        {
            var data = db.employees.Find(id);
            EmployeeVM emp = new EmployeeVM()
            {
                ComeDate = data.ComeDate,
                IsActive = data.IsActive,
                Name = data.Name,
                Notes = data.Notes,
            };

            return emp;

        }
        public async Task<EmployeePhotoNameVM> CheckIdAsync(int id)
        {
            var emp = db.employees.Where(e => e.Id == id).Select(e => new EmployeePhotoNameVM
            {
                Name = e.Name,
                Notes = e.Notes,
                ComeDate = e.ComeDate,
                PhotoName=e.PhotoName,
                IsActive = e.IsActive
            }).FirstOrDefault();

            return emp;

        }


        public async Task<EmployeePhotoNameVM> EditAsync(EmployeeFileVM employee)
        {
            var Newemp = db.employees.Find(employee.Id);

            Newemp.Name = employee.Name;
            Newemp.Notes = employee.Notes;
            Newemp.ComeDate = employee.ComeDate;
            Newemp.IsActive = employee.IsActive;
            Newemp.PhotoName = employee.PhotoUrl.FileName;



            db.SaveChanges();

            var emp = await CheckIdAsync(employee.Id);

            return emp;

        }
    }
}
