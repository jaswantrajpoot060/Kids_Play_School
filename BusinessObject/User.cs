using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace  BusinessObject
{
    public class User : BaseObject
    {

        #region Property

        public Guid Id { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public string Img { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string CPassword { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PinCode { get; set; }

        public string Fathername { get; set; }

        public string Mothername { get; set; }

        public string Status { get; set; }

        public string Extra1 { get; set; }

        public string Extra2 { get; set; }

        public string Extra3 { get; set; }

        public string ExtraColumn { get; set; }

        public int Code { get; set; }

        #endregion

        #region Method

        public User()
            : base()
        {
        }

        public User(Guid id)
            : base(id)
        {

        }


        public User(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default(Guid);
            Role = DBNull.Value != reader["Role"] ? (string)reader["Role"] : default(string);
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
            Img = DBNull.Value != reader["Img"] ? (string)reader["Img"] : default(string);
            MobileNo = DBNull.Value != reader["MobileNo"] ? (string)reader["MobileNo"] : default(string);
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default(string);
            Password = DBNull.Value != reader["Password"] ? (string)reader["Password"] : default(string);
            CPassword = DBNull.Value != reader["CPassword"] ? (string)reader["CPassword"] : default(string);
            Address = DBNull.Value != reader["Address"] ? (string)reader["Address"] : default(string);
            State = DBNull.Value != reader["State"] ? (string)reader["State"] : default(string);
            City = DBNull.Value != reader["City"] ? (string)reader["City"] : default(string);
            PinCode = DBNull.Value != reader["PinCode"] ? (string)reader["PinCode"] : default(string);
            Fathername = DBNull.Value != reader["Fathername"] ? (string)reader["Fathername"] : default(string);
            Mothername = DBNull.Value != reader["Mothername"] ? (string)reader["Mothername"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            Extra1 = DBNull.Value != reader["Extra1"] ? (string)reader["Extra1"] : default(string);
            Extra2 = DBNull.Value != reader["Extra2"] ? (string)reader["Extra2"] : default(string);
            Extra3 = DBNull.Value != reader["Extra3"] ? (string)reader["Extra3"] : default(string);
            ExtraColumn = DBNull.Value != reader["ExtraColumn"] ? (string)reader["ExtraColumn"] : default(string);
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default(int);
        }
        #endregion
    }
}
