using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class UserModel
    {
        private string _firstName;
        private string _lastName;
        private string _email;


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


        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        
        
        
    }
}