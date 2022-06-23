using System;
using SalesWeb.Models.Enums;
using System.ComponentModel.DataAnnotations;


namespace SalesWeb.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        [Range(0.0, 999999999.0, ErrorMessage = "{0} must be betweent {1} and {2}")]
        public double Amount { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus saleStatus, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            SaleStatus = saleStatus;
            Seller = seller;
        }
    }
}
