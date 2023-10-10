using VirtualCompany.Models.Employee;

namespace VirtualCompany.Buisness_Layer.Interfaces
{
    public interface IEmployeeRep
    {
        Task<IQueryable<Employee>> Get();
        Task AddEmployee(EmployeeFileVM employeeVM);
        Task<EmployeePhotoNameVM> EditAsync(EmployeeFileVM employeeVM);
        Task<EmployeeVM> getByEmployeeId(int id);
        Task<EmployeePhotoNameVM> CheckIdAsync(int id);
        Task<IQueryable<Depender>> GetAnyEqualId(int id);
        Task Delete(int id);

    }
}
