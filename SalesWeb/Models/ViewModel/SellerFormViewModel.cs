using System.Collections.Generic;

namespace SalesWeb.Models.ViewModel
{
    public class SellerFormViewModel
    {
                public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }

        public SellerFormViewModel()
        {
        }

        public SellerFormViewModel(Seller seller, ICollection<Department> departments)
        {
            Seller = seller;
            Departments = departments;
        }


    }
}
