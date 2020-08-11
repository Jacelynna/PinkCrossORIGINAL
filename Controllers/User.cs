using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;   
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PinkCross.Controllers
{
    public class User : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View("Register");
        }
        public IActionResult RegisterDonorProfile()
        {
            return View("RegisterDonorProfile");
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(Models.User rgs)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("Register");
            }
            else
            {
                String insert = @"INSERT INTO [User](Username_id, Password) VALUES ('{0}',HASHBYTES('SHA1','{1}'))";
                if (DBUtl.ExecSQL(insert, rgs.Username_id, rgs.Password) == 1)
                {
                    ViewData["Message"] = "Username ID and Password successfully created";
                    ViewData["MsgType"] = "success";
                }
                else
                {
                    ViewData["Message"] = DBUtl.DB_Message;
                    ViewData["MsgType"] = "danger";
                }
            }
            return View("RegisterDonorProfile");
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterDonorProfile(Models.DonorProfile DP)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("RegisterDonorProfile");
            }
            else
            {
                String insert = @"INSERT INTO DonorProfile(DonorName, Donornric, CompanyName, DonorNumber, DonorAddress) VALUES ('{0}','{1}','{2}','{3}','{4}')";
                if (DBUtl.ExecSQL(insert, DP.DonorName, DP.Donornric, DP.CompanyName, DP.DonorNumber, DP.DonorAddress) == 1)
                {
                    ViewData["Message"] = "Register successfully";
                    ViewData["MsgType"] = "success";
                }
                else
                {
                    ViewData["Message"] = DBUtl.DB_Message;
                    ViewData["MsgType"] = "danger";
                }
            }
            return View("Login");
        }
    }
}
