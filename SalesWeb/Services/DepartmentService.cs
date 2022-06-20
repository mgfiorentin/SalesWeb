using System.Linq;
using System.Collections.Generic;
using SalesWeb.Models;


namespace SalesWeb.Services
    {
    public class DepartmentService
    {
        private readonly SalesWebContext _context;

        public DepartmentService(SalesWebContext salesWebContext)
        {
            _context = salesWebContext;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }


    }
}
