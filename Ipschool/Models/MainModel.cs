using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ipschool.Models
{
    public class MainModel
    {
        public MainModel()
        {
           
            this.Registration = new Registration();
            this.RegistrationList = new List<Registration>();

            this.User = new User();
            this.UserList = new List<User>();

        }


        public User User { get; set; }
        public List<User> UserList { get; set; }

        public Registration Registration { get; set; }
        public List<Registration> RegistrationList { get; set; }

    }
}