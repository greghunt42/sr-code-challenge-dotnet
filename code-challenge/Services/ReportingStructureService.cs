using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;
using challenge.Data;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public ReportingStructureService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public ReportingStructure GetReportingStructureById(string managerId)
        {
            if(!string.IsNullOrWhiteSpace(managerId))
            {
                Employee manager = _employeeRepository.GetById(managerId);
                return new ReportingStructure() {
                    Employee = manager,
                    NumberOfReports = findAllSubordinates(manager).Count
                };
            }

            return new ReportingStructure();
        }

        private List<string> findAllSubordinates(Employee manager)
        {
            List<string> subordinateIds = new List<string>();
            Employee refreshedSubordinate;

            foreach(Employee subordinate in manager.DirectReports)
            {
                refreshedSubordinate = _employeeRepository.GetById(subordinate.EmployeeId);
                subordinateIds.Add(refreshedSubordinate.EmployeeId);

                if (refreshedSubordinate.DirectReports != null && refreshedSubordinate.DirectReports.Count > 0)
                    subordinateIds.AddRange(findAllSubordinates(refreshedSubordinate));
            }

            return subordinateIds;
        }
    }
}
