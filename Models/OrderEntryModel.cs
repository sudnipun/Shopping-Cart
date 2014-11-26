using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class OrderEntryModel
    {
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _productName;
        private decimal _productPrice;
        private DateTime _datePurchased;


        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }


        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }


        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }


        public decimal ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }


        public DateTime PurchaseDate
        {
            get { return _datePurchased; }
            set { _datePurchased = value; }
        }
        
        
        
        
        
        
    }
}