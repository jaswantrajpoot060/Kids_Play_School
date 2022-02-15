using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
   public class Registration : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public string Role { get; set; }

        public string RollNo { get; set; }

        public string RegDate { get; set; }

        public string ApplicationDate { get; set; }

        public string ApplicationNo { get; set; }

        public string StudentNo { get; set; }

        public string Course { get; set; }

        public string Name { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string Gender { get; set; }

        public string Catagery { get; set; }

        public string DOB { get; set; }

        public string Occupation { get; set; }

        public string AddharCardNo { get; set; }

        public string MobileNo { get; set; }

        public string EmailId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Distict { get; set; }

        public string State { get; set; }

        public string PinCode { get; set; }

        public string PassingYear { get; set; }

        public string Qualification { get; set; }

        public string Status { get; set; }

        public string Img { get; set; }

        public string Signature { get; set; }

        public string LastQulificationImg { get; set; }

        public string Extra1 { get; set; }

        public string Extra2 { get; set; }

        public string Extra3 { get; set; }

        public string Extra4 { get; set; }

        public string Extra5 { get; set; }

        public string Extra6 { get; set; }
        public int Code { get; set; }

        #endregion


        #region Method
        public Registration()
            : base()
        {
        }

        public Registration(Guid id)
            : base(id)
        {

        }

        public Registration(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default(Guid);
            Role = DBNull.Value != reader["Role"] ? (string)reader["Role"] : default(string);
            RollNo = DBNull.Value != reader["RollNo"] ? (string)reader["RollNo"] : default(string);
            RegDate = DBNull.Value != reader["RegDate"] ? (string)reader["RegDate"] : default(string);
            ApplicationDate = DBNull.Value != reader["ApplicationDate"] ? (string)reader["ApplicationDate"] : default(string);
            ApplicationNo = DBNull.Value != reader["ApplicationNo"] ? (string)reader["ApplicationNo"] : default(string);
            StudentNo = DBNull.Value != reader["StudentNo"] ? (string)reader["StudentNo"] : default(string);
            Course = DBNull.Value != reader["Course"] ? (string)reader["Course"] : default(string);
            Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
            FatherName = DBNull.Value != reader["FatherName"] ? (string)reader["FatherName"] : default(string);
            MotherName = DBNull.Value != reader["MotherName"] ? (string)reader["MotherName"] : default(string);
            Gender = DBNull.Value != reader["Gender"] ? (string)reader["Gender"] : default(string);
            Catagery = DBNull.Value != reader["Catagery"] ? (string)reader["Catagery"] : default(string);
            DOB = DBNull.Value != reader["DOB"] ? (string)reader["DOB"] : default(string);
            Occupation = DBNull.Value != reader["Occupation"] ? (string)reader["Occupation"] : default(string);
            AddharCardNo = DBNull.Value != reader["AddharCardNo"] ? (string)reader["AddharCardNo"] : default(string);
            MobileNo = DBNull.Value != reader["MobileNo"] ? (string)reader["MobileNo"] : default(string);
            EmailId = DBNull.Value != reader["EmailId"] ? (string)reader["EmailId"] : default(string);
            Extra1 = DBNull.Value != reader["Extra1"] ? (string)reader["Extra1"] : default(string);
            Address1 = DBNull.Value != reader["Address1"] ? (string)reader["Address1"] : default(string);
            Address2 = DBNull.Value != reader["Address2"] ? (string)reader["Address2"] : default(string);
            City = DBNull.Value != reader["City"] ? (string)reader["City"] : default(string);
            Distict = DBNull.Value != reader["Distict"] ? (string)reader["Distict"] : default(string);
            State = DBNull.Value != reader["State"] ? (string)reader["State"] : default(string);
            PinCode = DBNull.Value != reader["PinCode"] ? (string)reader["PinCode"] : default(string);
            PassingYear = DBNull.Value != reader["PassingYear"] ? (string)reader["PassingYear"] : default(string);
            Qualification = DBNull.Value != reader["Qualification"] ? (string)reader["Qualification"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            Img = DBNull.Value != reader["Img"] ? (string)reader["Img"] : default(string);
            Signature = DBNull.Value != reader["Signature"] ? (string)reader["Signature"] : default(string);
            LastQulificationImg = DBNull.Value != reader["LastQulificationImg"] ? (string)reader["LastQulificationImg"] : default(string);
            Extra1 = DBNull.Value != reader["Extra1"] ? (string)reader["Extra1"] : default(string);
            Extra2 = DBNull.Value != reader["Extra2"] ? (string)reader["Extra2"] : default(string);
            Extra3 = DBNull.Value != reader["Extra3"] ? (string)reader["Extra3"] : default(string);
            Extra4 = DBNull.Value != reader["Extra4"] ? (string)reader["Extra4"] : default(string);
            Extra5 = DBNull.Value != reader["Extra5"] ? (string)reader["Extra5"] : default(string);
            Extra6 = DBNull.Value != reader["Extra6"] ? (string)reader["Extra6"] : default(string);
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default(int);
        }
        #endregion
    }
}