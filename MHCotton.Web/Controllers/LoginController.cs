using MHCotton.Common;
using MHCotton.Common.Entities;
using MHCotton.Common.POCOs;
using MHCotton.Web.Models;
using MHCotton.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MHCotton.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;
        public LoginController(IUserService _userService)
        {
            userService = _userService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new Users(0, registerModel.LoginID, registerModel.Password);
                var employee = new Employees(0, registerModel.FirstName, registerModel.MiddleName, registerModel.LastName, registerModel.EmailID, user.ID);
                var registerPOCO = new RegisterPOCO();
                registerPOCO.Users = user;
                registerPOCO.Employees = employee;
                var success = userService.RegisterUser(registerPOCO);
                if (success)
                    return Json(new { Message = "User registered successfully", isSuccess = true }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Message = "User LoginID already exists", isSuccess = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Message = "Error while saving details", isSuccess = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ForgotPassword(string loginID)
        {
            //Email.SetUserDetails();
            try
            {
                userService.ForgotPassword(loginID);
                return Json(new { Message = "Your password has been sent to Email ID. Please verify.", isSuccess = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Message = "Error while fetching information", isSuccess = true }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Login(LoginModel loginModel)
        {
            var loginPOCO = Translators.MapModelPOCOObjects<LoginPOCO>(loginModel);
            var isSuccess = userService.ValidateUser(loginPOCO);
            if (!isSuccess)
                return Json(new { Message = "Invalid credentials", isSuccess = false }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { url = "/Home/Index", isSuccess = true }, JsonRequestBehavior.AllowGet);
        }
    }
}