using System.Linq;
using System.Collections.Generic;
using SalesWeb.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWeb.Services
    {
    public class DepartmentService
    {
        private readonly SalesWebContext _context;

        public DepartmentService(SalesWebContext salesWebContext)
        {
            _context = salesWebContext;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }


    }
}
