using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class ProductEntryModel
    {
        private string _name;
        private string _description;
        private decimal _price;



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public decimal Price
        {
            get { return _price; }
            set { _price = Math.Round(value,2); }
        }
        
        
        
    }

}