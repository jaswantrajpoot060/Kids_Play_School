using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  BusinessObject;
using  DataLayer;
using System.Data;

namespace BusinessManager
{
    public class UserManager
    {
        public static void Add(User user)
        {
            if (user == null)
                throw new ArgumentException("user is null.");
            UserDB.Add(user);
        }

        public static void Update(User user)
        {
            if (user == null)
                throw new ArgumentException("rresult is null.");
            if (user.Id == null || user.Id == default(Guid))
                throw new ArgumentException("user.Id value not set.");
            UserDB.Update(user);
        }

        public static void Delete(User user)
        {
            if (user == null)
                throw new ArgumentException("user is null.");
            if (user.Id == null || user.Id == default(Guid))
                throw new ArgumentException("rresult.Id value not set.");
            UserDB.Delete(user);
        }
        public static User GetById(Guid id)
        {
            User user = null;
            user = UserDB.GetById(id);
            return user;
        }

        public static List<User> GetAll()
        {
            return UserDB.GetAll();
        }

        public static System.Data.DataSet getdataset()
        {
            return UserDB.getdataset();
        }

        public static List<User> Search(string word)
        {
            return UserDB.Search(word);
        }

        public static List<User> Login(string Email, string Password)
        {
            return UserDB.Login(Email, Password);
        }
    }
}
