using SalesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SalesWeb.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebContext _context;

        public SalesRecordService(SalesWebContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindLastTenAsync()
        {

            return await _context.SalesRecord.OrderByDescending(s => s.Date)
                .Include(s=>s.Seller).Include(s=>s.Seller.Department)
                .Include(s=>s.Seller).Include(s=>s.Seller.Department)
                .Take(10).ToListAsync();

        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }

        public Seller FindById(int id)
        {


            return _context.Seller.FirstOrDefault(x => x.Id == id);
        }

        public SalesRecord FindSaleById(int saleId)
        {
            return _context.SalesRecord.Include(x => x.Seller).Include(x => x.Seller.Department)
                .FirstOrDefault(s => s.Id == saleId);
        }

        public async Task RegisterSaleAsync(SalesRecord sale)
        {

            _context.Add(sale);
            await _context.SaveChangesAsync();
        }

        public void RemoveSale(int id)
        {
            var obj = _context.SalesRecord.Find(id);
            _context.SalesRecord.Remove(obj);
            _context.SaveChanges();

        }
    }
}



