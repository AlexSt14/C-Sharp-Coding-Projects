using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;
using CarInsurance.ViewModels;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var insurees = db.Insurances;
                var insureeVm = new List<AdminVm>();
                foreach (var insuree in insurees)
                {
                    var adminVm = new AdminVm();
                    adminVm.FirstName = insuree.FirstName;
                    adminVm.LastName = insuree.LastName;
                    adminVm.EmailAddress = insuree.EmailAddress;
                    adminVm.Quote = insuree.Quote;
                    insureeVm.Add(adminVm);
                }
                return View(insureeVm);
            }            
        }
    }
}