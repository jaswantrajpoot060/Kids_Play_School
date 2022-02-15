using BuisnessManager;
using BusinessManager;
using BusinessObject;
using Ipschool.AppCode;
using Ipschool.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace Ipschool.Controllers
{
    public class HomeController : Controller
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        SqlConnection con = new SqlConnection(connection);

        public ActionResult Index()
        {
            ViewBag.Message = "Index";
            return View("~/Views/Home/Index.cshtml", new MainModel { });
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "About";

            return View("~/Views/Home/About.cshtml");
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";
            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("~/Views/Home/Contact.cshtml");
        }
        
        public ActionResult CandyKids()
        {
            ViewBag.Message = "CandyKids";

            return View("~/Views/Home/CandyKids.cshtml");
        }
        
        public ActionResult Franchise()
        {
            ViewBag.Message = "Franchise";

            return View("~/Views/Home/Franchise.cshtml");
        }
        
        public ActionResult Course()
        {
            ViewBag.Message = "Course";

            return View("~/Views/Home/Course.cshtml");
        }
        //Login
        
        public ActionResult Login()
        {
            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";


            return View("~/Views/Home/Login.cshtml");
        }

        //public JsonResult CheckUser(string Email, string Password)
        //{
        //    int Lcount = 0;
        //    SqlCommand cmd = new SqlCommand("select * from [User] where Email=@Email", con);
        //    cmd.Parameters.AddWithValue("@Email", Email);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //        Lcount++;

        //    if (dt.Rows.Count <= 0)
        //    {
        //        SqlCommand cmd2 = new SqlCommand("select * from Registration where EmailId=@EmailId", con);
        //        cmd2.Parameters.AddWithValue("@EmailId", Email);
        //        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        //        DataTable dt2 = new DataTable();
        //        da2.Fill(dt2);
        //        if (dt2.Rows.Count > 0)
        //            Lcount++;
        //    }

        //    var result = new { Lcount = Lcount };
        //    return (Json(result, JsonRequestBehavior.AllowGet));
        //}

        public ActionResult UserLogin(FormCollection coll)
        {
            MainModel itemnew = new MainModel();
            List<User> UserList = UserManager.Login(coll["email"], coll["password"]);
            if (UserList.Count > 0)
            {

                Session.RemoveAll();
                Response.Cookies["Ipseducation"].Expires = DateTime.Now.AddDays(-1);
                HttpCookie RPCookies = new HttpCookie("Ipseducation");
                RPCookies.Value = UserList[0].Id.ToString() + "," + UserList[0].Role + "," + UserList[0].Name + "," + UserList[0].Img;
                RPCookies.Expires = DateTime.Now.AddMonths(2);
                Response.Cookies.Add(RPCookies);

                return RedirectToAction("Dashboard");
            }

            List<Registration> RegistrationList = RegistrationManager.Login(coll["email"], coll["password"]).Where(s => s.Status == "Active").ToList();
            if (UserList.Count <= 0 && RegistrationList.Count > 0)
            {
                Session.RemoveAll();
                Response.Cookies["Ipseducation"].Expires = DateTime.Now.AddDays(-1);
                HttpCookie RPCookies = new HttpCookie("Ipseducation");
                RPCookies.Value = RegistrationList[0].Id.ToString() + "," + RegistrationList[0].Role + "," + RegistrationList[0].Name + "," + RegistrationList[0].Img;
                RPCookies.Expires = DateTime.Now.AddMonths(2);
                Response.Cookies.Add(RPCookies);

                return RedirectToAction("StudentProfile");
            }
            else
                return View("~/Views/Home/Login_msg.cshtml", itemnew);
        }
        
        public ActionResult Dashboard()
        {
            if (Request.Cookies["Ipseducation"] != null)
            {
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
        
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Response.Cookies["Ipseducation"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index");
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
                //itemnew.DDetail = DDetailManager.GetByUserId(Id.ToString());
                //itemnew.Billing = BillingManager.GetByUserId(Id);
                //itemnew.UserPack = UserPackManager.GetByUserId(Id);

                if (itemnew.Registration == null)
                    itemnew.Registration = new Registration();
                //if (itemnew.ADetail == null)
                //    itemnew.ADetail = new ADetail();

                //if (itemnew.DDetail == null)
                //    itemnew.DDetail = new DDetail();

                //if (itemnew.Billing == null)
                //    itemnew.Billing = new Billing();

                //if (itemnew.UserPack == null)
                //    itemnew.UserPack = new UserPack();

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";

                if (AllArray[1] == "Admin")
                    return View("~/Views/Admin/StudentProfile.cshtml", new MainModel { Registration = itemnew.Registration });
                else
                    return View("~/Views/Admin/StudentProfile.cshtml", new MainModel { Registration = itemnew.Registration });
            }
            else
                return View("~/Views/Account/Login.cshtml");
        }

        //Registration
        public ActionResult StuAdmission()
        {
            MainModel itemnew = new MainModel();
            //itemnew.RegistrationList = RegistrationManager.GetAll();

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            ViewBag.State = new SelectList(Constant.States, "Text", "Value");
            ViewBag.City = new SelectList(Constant.City, "Text", "Value");
            ViewBag.Class = new SelectList(Constant.ClassList, "Text", "Value");
            ViewBag.Category = new SelectList(Constant.CategoryList, "Text", "Value");
            ViewBag.Religion = new SelectList(Constant.ReligionList, "Text", "Value");
            ViewBag.Gender = new SelectList(Constant.GenderList, "Text", "Value");
            ViewBag.Marital = new SelectList(Constant.MaritalList, "Text", "Value");
            ViewBag.Occupation = new SelectList(Constant.OccupationList, "Text", "Value");


            return View("~/Views/Account/StuAdmission.cshtml", itemnew);
        }

        public ActionResult SaveStudent(FormCollection coll, HttpPostedFileBase fileupload, HttpPostedFileBase fileuploadbc)
        {
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);

            Registration obj = new Registration();

            //DateTime ApplicationDate = DateTime.ParseExact(coll["ApplicationDate"], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            obj.ApplicationDate = DateTime.Now.ToString("dd-MM-yyyy");

            obj.Name = coll["Name"];
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


            obj.RollNo = "";
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
            obj.CreatedBy = obj.UpdatedBy = "Student";
            obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

            RegistrationManager.Add(obj);


            TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";

            return RedirectToAction("StuAdmission");
        }

        public ActionResult Mailer(FormCollection coll)
        {
            #region Emaid Send Student Details
            TemplateEngine templateEngine = new TemplateEngine("UserRegistration.htm");

            if (!string.IsNullOrEmpty(coll["name"]))
                templateEngine.Variables.Add("UserName", coll["name"]);
            else
                templateEngine.Variables.Add("UserName", string.Empty);

            if (!string.IsNullOrEmpty(coll["email"]))
                templateEngine.Variables.Add("Email", coll["email"]);
            else
                templateEngine.Variables.Add("Email", string.Empty);

            if (!string.IsNullOrEmpty(coll["subject"]))
                templateEngine.Variables.Add("Subject", coll["subject"]);
            else
                templateEngine.Variables.Add("Subject", string.Empty);

            if (!string.IsNullOrEmpty(coll["mobile"]))
                templateEngine.Variables.Add("Mobile", coll["mobile"]);
            else
                templateEngine.Variables.Add("Mobile", string.Empty);

            if (!string.IsNullOrEmpty(coll["message"]))
                templateEngine.Variables.Add("Message", coll["message"]);
            else
                templateEngine.Variables.Add("Message", string.Empty);


            string CustomerTo = coll["email"];                        // Sender Mail Id 
            string subject = "Contact Us Enquiry Detail";
            string from = "Jaswantrajpoot060@gmail.com";                   //"info@bnbc.in"; // Recive Mail Id

            ConstantEmail.SendMail(CustomerTo, from, subject, templateEngine.GetFileContent());

            TempData[Ipschool.AppCode.Constant.INFO_MESSAGE] = "Your Query Send Successfully";
            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Ipschool.AppCode.Constant.INFO_MESSAGE] != null ? TempData[Ipschool.AppCode.Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Ipschool.AppCode.Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            //lblMessage.Visible = true;
            //lblMessage.Text = "Student Registration Add Successfully !";
            //lblMessage.ForeColor = System.Drawing.Color.White;
            //lblMessage.Text = "";
            return View("~/Views/Home/Contact.cshtml");

            #endregion
        }
    }


}