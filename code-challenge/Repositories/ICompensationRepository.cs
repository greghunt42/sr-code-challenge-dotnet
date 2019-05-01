using challenge.Models;
using System;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation GetByEmployeeId(String employeeId);
        Compensation Add(Compensation employee);
        Compensation Remove(Compensation employee);
        Task SaveAsync();
    }
}