using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Projet.DAL;
using Projet.Models;

namespace Projet.Controllers
{
    public class AdminsController : Controller
    {
        private F1Context db = new F1Context();

        public ActionResult Index()
        {
            if (Session["AdminID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            ViewBag.error = TempData["erreur"];

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string pseudo, string mdp)
        {
            if (ModelState.IsValid)
            {

                var f_password = GetMD5(mdp);
                var data = db.Admins.Where(s => s.pseudo.Equals(pseudo) && s.mdp.Equals(f_password)).FirstOrDefault();
                if (data != null)
                {

                    Session["pseudo"] = data.pseudo;
                    Session["AdminID"] = data.AdminID;


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["erreur"] = "Erreur, login ou mot de passe incorect";

                    return RedirectToAction("Login");
                }
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
