using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Ipschool.Models;
using System.Configuration;
using System.Data.SqlClient;
using Ipschool.AppCode;
using BusinessManager;
using BusinessObject;
using System.IO;

namespace Ipschool.Controllers
{
    public class AdminController : Controller
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        SqlConnection con = new SqlConnection(connection);


        public ActionResult Index()
        {
            if (Request.Cookies["Ipseducation"] != null)
            {
                ViewBag.Msg = "";
                string sid = Request.Cookies["Ipseducation"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.Role = AllArray[1];
                ViewBag.Name = AllArray[2];
                ViewBag.Img = AllArray[3];

                ViewBag.Registration = Constant.totRegistration();

                if (AllArray[1] == "Admin")
                    return View("~/Views/Admin/Index.cshtml");
                else
                    return RedirectToAction("StudentProfile");
            }
            else
                return View("~/Views/Home/Login.cshtml");
        }
        public ActionResult CandyKids()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Franchise()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //User
        public ActionResult AllUser()
        {
            MainModel itemnew = new MainModel();

            if (Request.Cookies["Ipseducation"] != null)
            {
                itemnew.UserList = UserManager.GetAll();

                string sid = Request.Cookies["Ipseducation"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.Role = AllArray[1];
                ViewBag.Name = AllArray[2];
                ViewBag.Img = AllArray[3];

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";

                if (AllArray[1] == "Admin")
                    return View("~/Views/Admin/AllUser.cshtml", itemnew);
                else
                    return RedirectToAction("StudentProfile");
            }
            else
                return RedirectToAction("");
        }

        //Registration
        public ActionResult Registration()
        {
            MainModel itemnew = new MainModel();

            if (Request.Cookies["Ipseducation"] != null)
            {
                itemnew.RegistrationList = RegistrationManager.GetAll();

                string sid = Request.Cookies["Ipseducation"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.Role = AllArray[1];
                ViewBag.Name = AllArray[2];
                ViewBag.Img = AllArray[3];

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";


                if (AllArray[1] == "Admin")
                    return View("~/Views/Admin/Registration.cshtml", itemnew);
                else
                    return RedirectToAction("StudentProfile");
            }
            else
                return RedirectToAction("");
        }
        public ActionResult AddRegistration(Guid Id)
        {
            MainModel itemnew = new MainModel();

            string sid = Request.Cookies["Ipseducation"].Value;
            string[] AllArray = sid.Split(',');
            ViewBag.Role = AllArray[1];
            ViewBag.Name = AllArray[2];
            ViewBag.Img = AllArray[3];

            if (Id != Guid.Empty)
            {
                itemnew.Registration = RegistrationManager.GetById(Id);
                ViewBag.ApplicationNo = itemnew.Registration.ApplicationNo;

                ViewBag.State = new SelectList(Constant.States, "Text", "Value", itemnew.Registration.City);
                ViewBag.City = new SelectList(Constant.City, "Text", "Value", itemnew.Registration.City);
                ViewBag.Class = new SelectList(Constant.ClassList, "Text", "Value", itemnew.Registration.Extra3);
                ViewBag.Category = new SelectList(Constant.CategoryList, "Text", "Value", itemnew.Registration.Catagery);
                ViewBag.Religion = new SelectList(Constant.ReligionList, "Text", "Value", itemnew.Registration.Extra1);
                ViewBag.Gender = new SelectList(Constant.GenderList, "Text", "Value", itemnew.Registration.Gender);
                ViewBag.Marital = new SelectList(Constant.MaritalList, "Text", "Value", itemnew.Registration.Extra2);
                ViewBag.Occupation = new SelectList(Constant.OccupationList, "Text", "Value", itemnew.Registration.Occupation);

            }
            else
            {
                ViewBag.State = new SelectList(Constant.States, "Text", "Value");
                ViewBag.City = new SelectList(Constant.City, "Text", "Value");
                ViewBag.Class = new SelectList(Constant.ClassList, "Text", "Value");
                ViewBag.Category = new SelectList(Constant.CategoryList, "Text", "Value");
                ViewBag.Religion = new SelectList(Constant.ReligionList, "Text", "Value");
                ViewBag.Gender = new SelectList(Constant.GenderList, "Text", "Value");
                ViewBag.Marital = new SelectList(Constant.MaritalList, "Text", "Value");
                ViewBag.Occupation = new SelectList(Constant.OccupationList, "Text", "Value");

                ViewBag.ApplicationNo = "00" + Constant.ApplicationNoauto();
            }

            return View("~/Views/AllForms/AddRegistration.cshtml", itemnew);
        }
        public ActionResult SaveApplyRegistration(FormCollection coll, HttpPostedFileBase fileupload, HttpPostedFileBase fileuploadbc)
        {
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);

            Registration obj = new Registration();
            if (Id != Guid.Empty)
            {
                Registration oldobj = RegistrationManager.GetById(Id);
                if (oldobj != null)
                    obj = oldobj;
            }

            obj.ApplicationDate = coll["ApplicationDate"];
            obj.Name = coll["Name"];
            obj.RollNo = coll["RollNo"];
            obj.DOB = coll["DOB"];
            obj.FatherName = coll["FatherName"];
            obj.MotherName = coll["MotherName"];
            obj.Gender = coll["rbGrp2"];
            obj.Extra1 = coll["drpreligious"];
            obj.EmailId = coll["EmailId"];
            obj.MobileNo = coll["MobileNo"];
            obj.Catagery = coll["drpcatagery"];
            obj.Extra3 = coll["drpclass"];
            obj.Occupation = coll["drpoccupation"];
            obj.Distict = coll["Distict"];
            obj.AddharCardNo = coll["AddharCardNo"];
            obj.PinCode = coll["PinCode"];
            obj.Address1 = coll["Address1"];
            obj.Extra2 = coll["Package"];


            obj.RegDate = "";
            obj.Course = "";
            obj.Qualification = "";
            obj.PassingYear = "";
            obj.State = "";
            obj.City = "";
            obj.Extra4 = "";
            obj.Extra5 = "";
            obj.Address2 = "";
            obj.StudentNo = "";
            obj.LastQulificationImg = "";

            if (obj.Id != Guid.Empty)
            {
                obj.Status = obj.Status;

                obj.ApplicationNo = obj.ApplicationNo;
                obj.Extra6 = obj.Extra6;

                #region Student Photo
                if (Id != Guid.Empty)
                {

                    if (fileupload != null)
                    {
                        if (fileupload.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(fileupload.FileName);
                            string _path = Path.Combine(Server.MapPath("../Student/"), _FileName);
                            fileupload.SaveAs(_path);

                            obj.Img = "../Student/" + _FileName;
                        }
                        else
                            obj.Img = obj.Img;
                    }
                    else
                        obj.Img = obj.Img;
                }
                #endregion
                #region Student Signature
                if (Id != Guid.Empty)
                {
                    if (fileuploadbc != null)
                    {
                        if (fileuploadbc.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(fileuploadbc.FileName);
                            string _path = Path.Combine(Server.MapPath("../Student/"), _FileName);
                            fileuploadbc.SaveAs(_path);

                            obj.Signature = "../Student/" + _FileName;
                        }
                        else
                            obj.Signature = obj.Signature;
                    }
                    else
                        obj.Signature = obj.Signature;
                }
                #endregion
                obj.CreatedBy = obj.UpdatedBy = "Admin";
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

                RegistrationManager.Update(obj);

                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.Id = Guid.NewGuid();
                obj.ApplicationNo = "00" + Constant.ApplicationNoauto();
                obj.Extra6 = Constant.ApplicationNoauto();
                obj.Status = "Pending";
                obj.Role = "Student";

                #region Student Photo

                if (fileupload != null)
                {
                    if (fileupload.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(fileupload.FileName);
                        string _path = Path.Combine(Server.MapPath("../Student/"), _FileName);
                        fileupload.SaveAs(_path);

                        obj.Img = "../Student/" + _FileName;
                    }
                    else
                        obj.Img = "../Student/" + "noimage.png";
                }
                else
                    obj.Img = "../Student/" + "noimage.png";
                #endregion
                #region Student Signature
                if (fileuploadbc != null)
                {
                    if (fileuploadbc.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(fileuploadbc.FileName);
                        string _path = Path.Combine(Server.MapPath("../Student/"), _FileName);
                        fileuploadbc.SaveAs(_path);

                        obj.Signature = "../Student/" + _FileName;
                    }
                    else
                        obj.Signature = "../Student/" + "noimage.png";
                }
                else
                    obj.Signature = "../Student/" + "noimage.png";
                #endregion

                obj.CreatedBy = obj.UpdatedBy = "Admin";
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

                RegistrationManager.Add(obj);


                TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
            }

            return RedirectToAction("Registration");
        }
        public ActionResult RegistrationSearch(string Data)
        {
            MainModel itemnew = new MainModel();

            if (!String.IsNullOrEmpty(Data))
                itemnew.RegistrationList = RegistrationManager.Search(Data);
            else
                itemnew.RegistrationList = RegistrationManager.GetAll();

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";

            return PartialView("~/Views/PartialView/_RegistrationList.cshtml", itemnew);
        }
        public ActionResult UpdateRegistration(Guid Id)
        {
            Registration obj = RegistrationManager.GetById(Id);
            if (obj != null)
            {
                SqlCommand cmd = new SqlCommand("Update Registration set Status=@Status where Id=@Id", con);
                if (obj.Status == "Active")
                    cmd.Parameters.AddWithValue("@Status", "Pending");
                else
                    cmd.Parameters.AddWithValue("@Status", "Active");

                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return RedirectToAction("Registration");
        }
        public ActionResult DeleteRegistration(Guid Id)
        {
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                Registration obj = RegistrationManager.GetById(Id);
                if (obj != null)
                    RegistrationManager.Delete(obj);

                TempData[Constant.INFO_MESSAGE] = "Record Deleted Successfully.";
            }
            else
            {
                TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
            }

            return RedirectToAction("Registration");
        }

        // StudentProfile
        public ActionResult StudentProfile()
        {
            if (Request.Cookies["Ipseducation"] != null)
            {
                MainModel itemnew = new MainModel();

                string sid = Request.Cookies["Ipseducation"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.Role = AllArray[1];
                ViewBag.Name = AllArray[2];
                ViewBag.Img = AllArray[3];

                Guid Id = Guid.Empty;
                Guid.TryParse(AllArray[0], out Id);

                itemnew.Registration = RegistrationManager.GetById(Id);
                //itemnew.ADetail = ADetailManager.GetByUserId(Id);

                if (itemnew.Registration == null)
                    itemnew.Registration = new Registration();

                //if (itemnew.ADetail == null)
                //    itemnew.ADetail = new ADetail();

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";

                if (AllArray[1] == "Admin")
                    return RedirectToAction("Registration");
                else
                return View("~/Views/Admin/StudentProfile.cshtml", new MainModel { Registration = itemnew.Registration });
            }
            else
                return RedirectToAction("");
        }
        public ActionResult CreateProfile(Guid Id)
        {
            if (Request.Cookies["Ipseducation"] != null)
            {
                MainModel itemnew = new MainModel();

                string sid = Request.Cookies["Ipseducation"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.Role = AllArray[1];
                ViewBag.Name = AllArray[2];
                ViewBag.Img = AllArray[3];

                itemnew.Registration = RegistrationManager.GetById(Id);
                //itemnew.ADetail = ADetailManager.GetByUserId(Id);

                if (itemnew.Registration == null)
                    itemnew.Registration = new Registration();

                //if (itemnew.ADetail == null)
                //    itemnew.ADetail = new ADetail();

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";

                return View("~/Views/Admin/StudentProfile.cshtml", new MainModel { Registration = itemnew.Registration });
            }
            else
                return View("~/Views/Account/Login.cshtml");
        }

    }
}