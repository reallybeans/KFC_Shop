using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KFC_Food.Data;
using KFC_Food.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace KFC_Food.Controllers
{
    public class LoginController : Controller
    {

        private readonly KFC_DATAContext _context;

        public LoginController(KFC_DATAContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(IFormCollection form )
        {
            string action = form["btnAction"];
            if (action.Equals("Register")){
                return RedirectToAction("RegisterForm", "Login");
            }
            string userName = form["userName"];
            string password = form["password"];
            password = MD5_Encryption(password);
            TblUser user = _context.TblUsers.SingleOrDefault(s => s.UserName == userName && s.Password == password);
            if (user != null)
            {
                if (user.RoleId.Equals("CT"))
                {
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                    return RedirectToAction("Index", "TblProducts");
                }                            
           }
            TempData["Message"] = "Incorect username or password";
            return RedirectToAction("Login", "ShoppingCart");
        }



        public IActionResult ErrorLogin()
        {
            return View();
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Remove("User");
                HttpContext.Session.Remove("Cart");
            }
            catch
            {

            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegisterForm()
        {
            ViewData["Message"] = TempData["Message"];
            return View();
        }

        public async Task<IActionResult> Register(IFormCollection form)
        {
            string userName = form[ "userName"];
            string name = form["name"];
            string password = form[ "password"];
            string roleID = "CT";
            string confirm = form["confirm"];
            if (!password.Equals(confirm))
            {
                TempData["Message"] = "Password not match!";
                return RedirectToAction("RegisterForm", "Login");
            }
            if(_context.TblUsers.SingleOrDefault(s => s.UserName == userName) == null){
                TblUser user = new TblUser();
                user.UserName = userName;
                user.Password = MD5_Encryption(password);
                user.Name = name;
                user.RoleId = roleID;
                _context.TblUsers.Add(user);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Create account success!";
                return RedirectToAction("Login", "ShoppingCart");
            }
            TempData["Message"] = "Username had existed!";
            return RedirectToAction("RegisterForm", "Login");
        }

        public IActionResult RegisterError()
        {
            return View();
        }


        public string MD5_Encryption(string password)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
            //nếu bạn muốn các chữ cái in thường thay vì in hoa thì bạn thay chữ "X" in hoa trong "X2" thành "x"


        }
    }
}
