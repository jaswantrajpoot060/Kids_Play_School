using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObject;
using DataLayer;


namespace BusinessManager
{
   public class RegistrationManager
   {
       public static void Add(Registration registration)
       {
           if (registration == null)
               throw new ArgumentException("registration is null.");
           RegistrationDB.Add(registration);
       }

       public static void Update(Registration registration)
       {
           if (registration == null)
               throw new ArgumentException("rresult is null.");
           if (registration.Id == null || registration.Id == default(Guid))
               throw new ArgumentException("registration.Id value not set.");
           RegistrationDB.Update(registration);
       }

       public static void Delete(Registration registration)
       {
           if (registration == null)
               throw new ArgumentException("registration is null.");
           if (registration.Id == null || registration.Id == default(Guid))
               throw new ArgumentException("rresult.Id value not set.");
           RegistrationDB.Delete(registration);
       }


       public static Registration GetById(Guid id)
       {
           Registration registration = null;
           registration = RegistrationDB.GetById(id);
           return registration;
       }

       public static List<Registration> GetAll()
       {
           return RegistrationDB.GetAll();
       }

       public static System.Data.DataSet getdataset()
       {
           return RegistrationDB.getdataset();
       }

       public static List<Registration> Search(string word)
       {
           return RegistrationDB.Search(word);
       }

       public static List<Registration> Login(string EmailId, string Extra5)
       {
           return RegistrationDB.Login(EmailId, Extra5);
       }
   }
}
