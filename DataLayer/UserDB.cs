using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using  BusinessObject;
using System.Data;

namespace  DataLayer
{
    public class UserDB
    {

        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        // adding User object
        public static void Add(User user)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_User_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Img", user.Img);
            cmd.Parameters.AddWithValue("@MobileNo", user.MobileNo);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@CPassword", user.CPassword);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@State", user.State);
            cmd.Parameters.AddWithValue("@City", user.City);
            cmd.Parameters.AddWithValue("@PinCode", user.PinCode);
            cmd.Parameters.AddWithValue("@Fathername", user.Fathername);
            cmd.Parameters.AddWithValue("@Mothername", user.Mothername);
            cmd.Parameters.AddWithValue("@Status", user.Status);
            cmd.Parameters.AddWithValue("@Extra1", user.Extra1);
            cmd.Parameters.AddWithValue("@Extra2", user.Extra2);
            cmd.Parameters.AddWithValue("@Extra3", user.Extra3);
            cmd.Parameters.AddWithValue("@ExtraColumn", user.ExtraColumn);
            cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedOn", user.CreatedOn);
            cmd.Parameters.AddWithValue("@UpdatedBy", user.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", user.UpdatedOn);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void Update(User user)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_User_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Img", user.Img);
            cmd.Parameters.AddWithValue("@MobileNo", user.MobileNo);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@CPassword", user.CPassword);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@State", user.State);
            cmd.Parameters.AddWithValue("@City", user.City);
            cmd.Parameters.AddWithValue("@PinCode", user.PinCode);
            cmd.Parameters.AddWithValue("@Fathername", user.Fathername);
            cmd.Parameters.AddWithValue("@Mothername", user.Mothername);
            cmd.Parameters.AddWithValue("@Status", user.Status);
            cmd.Parameters.AddWithValue("@Extra1", user.Extra1);
            cmd.Parameters.AddWithValue("@Extra2", user.Extra2);
            cmd.Parameters.AddWithValue("@Extra3", user.Extra3);
            cmd.Parameters.AddWithValue("@ExtraColumn", user.ExtraColumn);
            cmd.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedOn", user.CreatedOn);
            cmd.Parameters.AddWithValue("@UpdatedBy", user.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", user.UpdatedOn);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Delete(User user)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_User_Delete";
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static User GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_User_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            User user = null;
            while (reader.Read())
            {
                user = new User(reader);
            }
            reader.Close();
            cmd.Connection.Close();

            return user;

        }
        public static DataTable Retrieveetailindatatable(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("Usp_User_GetById", con);
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception x)
            {
                throw x;
            }
            finally
            {

            }
            return dt;
        }

        public static List<User> Search(string word)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_User_Search";
            cmd.Parameters.AddWithValue("@Word", word);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> UserList = new List<User>();
            while (reader.Read())
            {
                User Obj = new User(reader);
                UserList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return UserList;
        }
        public static List<User> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_User_GetAll";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> UserList = new List<User>();
            while (reader.Read())
            {
                User Obj = new User(reader);
                UserList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return UserList;
        }

        public static DataSet getdataset()
        {
            SqlConnection con = new SqlConnection(connection);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("Usp_User_GetAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            return ds;

        }

        public static List<User> Login(string Email, string Password)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_User_Login";
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> UserList = new List<User>();
            while (reader.Read())
            {
                User Obj = new User(reader);
                UserList.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return UserList;
        }


    }
}
