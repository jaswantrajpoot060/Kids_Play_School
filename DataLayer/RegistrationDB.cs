using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;
using System.Configuration;

namespace DataLayer
{
   public class RegistrationDB
   {
       public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

       public static void Add(Registration registration)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand("Usp_Registration_Insert", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("Id", registration.Id);
           cmd.Parameters.AddWithValue("@Role", registration.Role);
           cmd.Parameters.AddWithValue("@RollNo", registration.RollNo);
           cmd.Parameters.AddWithValue("@RegDate", registration.RegDate);
           cmd.Parameters.AddWithValue("@ApplicationDate", registration.ApplicationDate);
           cmd.Parameters.AddWithValue("@ApplicationNo", registration.ApplicationNo);
           cmd.Parameters.AddWithValue("@StudentNo", registration.StudentNo);
           cmd.Parameters.AddWithValue("@Course", registration.Course);
           cmd.Parameters.AddWithValue("@Name", registration.Name);
           cmd.Parameters.AddWithValue("@FatherName", registration.FatherName);
           cmd.Parameters.AddWithValue("@MotherName", registration.MotherName);
           cmd.Parameters.AddWithValue("@Gender", registration.Gender);
           cmd.Parameters.AddWithValue("@Catagery", registration.Catagery);
           cmd.Parameters.AddWithValue("@DOB", registration.DOB);
           cmd.Parameters.AddWithValue("@Occupation", registration.Occupation);
           cmd.Parameters.AddWithValue("@AddharCardNo", registration.AddharCardNo);
           cmd.Parameters.AddWithValue("@MobileNo", registration.MobileNo);
           cmd.Parameters.AddWithValue("@EmailId", registration.EmailId);
           cmd.Parameters.AddWithValue("@Address1", registration.Address1);
           cmd.Parameters.AddWithValue("@Address2", registration.Address2);
           cmd.Parameters.AddWithValue("@City", registration.City);
           cmd.Parameters.AddWithValue("@Distict", registration.Distict);
           cmd.Parameters.AddWithValue("@State", registration.State);
           cmd.Parameters.AddWithValue("@PinCode", registration.PinCode);
           cmd.Parameters.AddWithValue("@PassingYear", registration.PassingYear);
           cmd.Parameters.AddWithValue("@Qualification", registration.Qualification);
           cmd.Parameters.AddWithValue("@Status", registration.Status);
           cmd.Parameters.AddWithValue("@Img", registration.Img);
           cmd.Parameters.AddWithValue("@Signature", registration.Signature);
           cmd.Parameters.AddWithValue("@LastQulificationImg", registration.LastQulificationImg);
           cmd.Parameters.AddWithValue("@Extra1", registration.Extra1);
           cmd.Parameters.AddWithValue("@Extra2", registration.Extra2);
           cmd.Parameters.AddWithValue("@Extra3", registration.Extra3);
           cmd.Parameters.AddWithValue("@Extra4", registration.Extra4);
           cmd.Parameters.AddWithValue("@Extra5", registration.Extra5);
           cmd.Parameters.AddWithValue("@Extra6", registration.Extra6);
           cmd.Parameters.AddWithValue("@CreatedBy", registration.CreatedBy);
           cmd.Parameters.AddWithValue("@CreatedOn", registration.CreatedOn);
           cmd.Parameters.AddWithValue("@UpdatedBy", registration.UpdatedBy);
           cmd.Parameters.AddWithValue("@UpdatedOn", registration.UpdatedOn);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
       }

       public static void Update(Registration registration)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand("Usp_Registration_Update", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("Id", registration.Id);
           cmd.Parameters.AddWithValue("@Role", registration.Role);
           cmd.Parameters.AddWithValue("@RollNo", registration.RollNo);
           cmd.Parameters.AddWithValue("@RegDate", registration.RegDate);
           cmd.Parameters.AddWithValue("@ApplicationDate", registration.ApplicationDate);
           cmd.Parameters.AddWithValue("@ApplicationNo", registration.ApplicationNo);
           cmd.Parameters.AddWithValue("@StudentNo", registration.StudentNo);
           cmd.Parameters.AddWithValue("@Course", registration.Course);
           cmd.Parameters.AddWithValue("@Name", registration.Name);
           cmd.Parameters.AddWithValue("@FatherName", registration.FatherName);
           cmd.Parameters.AddWithValue("@MotherName", registration.MotherName);
           cmd.Parameters.AddWithValue("@Gender", registration.Gender);
           cmd.Parameters.AddWithValue("@Catagery", registration.Catagery);
           cmd.Parameters.AddWithValue("@DOB", registration.DOB);
           cmd.Parameters.AddWithValue("@Occupation", registration.Occupation);
           cmd.Parameters.AddWithValue("@AddharCardNo", registration.AddharCardNo);
           cmd.Parameters.AddWithValue("@MobileNo", registration.MobileNo);
           cmd.Parameters.AddWithValue("@EmailId", registration.EmailId);
           cmd.Parameters.AddWithValue("@Address1", registration.Address1);
           cmd.Parameters.AddWithValue("@Address2", registration.Address2);
           cmd.Parameters.AddWithValue("@City", registration.City);
           cmd.Parameters.AddWithValue("@Distict", registration.Distict);
           cmd.Parameters.AddWithValue("@State", registration.State);
           cmd.Parameters.AddWithValue("@PinCode", registration.PinCode);
           cmd.Parameters.AddWithValue("@PassingYear", registration.PassingYear);
           cmd.Parameters.AddWithValue("@Qualification", registration.Qualification);
           cmd.Parameters.AddWithValue("@Status", registration.Status);
           cmd.Parameters.AddWithValue("@Img", registration.Img);
           cmd.Parameters.AddWithValue("@Signature", registration.Signature);
           cmd.Parameters.AddWithValue("@LastQulificationImg", registration.LastQulificationImg);
           cmd.Parameters.AddWithValue("@Extra1", registration.Extra1);
           cmd.Parameters.AddWithValue("@Extra2", registration.Extra2);
           cmd.Parameters.AddWithValue("@Extra3", registration.Extra3);
           cmd.Parameters.AddWithValue("@Extra4", registration.Extra4);
           cmd.Parameters.AddWithValue("@Extra5", registration.Extra5);
           cmd.Parameters.AddWithValue("@Extra6", registration.Extra6);
           cmd.Parameters.AddWithValue("@CreatedBy", registration.CreatedBy);
           cmd.Parameters.AddWithValue("@CreatedOn", registration.CreatedOn);
           cmd.Parameters.AddWithValue("@UpdatedBy", registration.UpdatedBy);
           cmd.Parameters.AddWithValue("@UpdatedOn", registration.UpdatedOn);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
       }

       public static void Delete(Registration registration)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_Registration_Delete";
           cmd.Parameters.AddWithValue("@Id", registration.Id);
           cmd.Connection = con;
           cmd.Connection.Open();
           cmd.ExecuteNonQuery();
           cmd.Connection.Close();
       }

       public static List<Registration> Search(string word)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_Registration_Search";
           cmd.Parameters.AddWithValue("@Word", word);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           List<Registration> EmailList = new List<Registration>();
           while (reader.Read())
           {
               Registration Obj = new Registration(reader);
               EmailList.Add(Obj);
           }
           reader.Close();
           cmd.Connection.Close();
           return EmailList;
       }

       public static List<Registration> Login(string Email, string Password)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_Registration_Login";
           cmd.Parameters.AddWithValue("@EmailId", Email);
           cmd.Parameters.AddWithValue("@Extra5", Password);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           List<Registration> RegistrationList = new List<Registration>();
           while (reader.Read())
           {
               Registration Obj = new Registration(reader);
               RegistrationList.Add(Obj);
           }
           reader.Close();
           cmd.Connection.Close();
           return RegistrationList;
       }

       public static List<Registration> GetAll()
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_Registration_GetAll";
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           List<Registration> EmailList = new List<Registration>();
           while (reader.Read())
           {
               Registration Obj = new Registration(reader);
               EmailList.Add(Obj);
           }
           reader.Close();
           cmd.Connection.Close();
           return EmailList;
       }

       public static DataSet getdataset()
       {
           SqlConnection con = new SqlConnection(connection);
           if (con.State == ConnectionState.Closed)
           {
               con.Open();
           }
           DataSet ds = new DataSet();
           SqlCommand cmd = new SqlCommand("Usp_Registration_GetAll", con);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           sda.Fill(ds);
           return ds;
       }
       public static Registration GetById(Guid Id)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_Registration_GetById";
           cmd.Parameters.AddWithValue("@Id", Id);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           Registration registration = null;
           while (reader.Read())
           {
               registration = new Registration(reader);
           }
           reader.Close();
           cmd.Connection.Close();
           return registration;
       }
   }
}
