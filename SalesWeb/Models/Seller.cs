using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWeb.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage ="{0} is not a valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }

        [Range(0.0, 100000.0,ErrorMessage = "{0} must be betweent {1} and {2}")]
        [Required(ErrorMessage ="{0} is required.")]
        [Display(Name = "Base salary")]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;


        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }
    }
}
