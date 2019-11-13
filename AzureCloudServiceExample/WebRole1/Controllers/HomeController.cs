using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;
using SOA_DataAccessLibrary;
using System.Xml.Linq;

namespace WebRole1.Controllers
    
{
    public class HomeController : Controller
    {
        public CompanyInfoModel companyInfoM;

        public HomeController()
        {
            companyInfoM = new CompanyInfoModel();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanyInfo()
        {
            ViewBag.Message = "Company Info.";

            return View();
        }

        public ActionResult SaveCompanyInfo(string Street, string City, string State, string Zip)
        {
            XDocument doc = new XDocument();
            Soa SampleSoA = new Soa();

            companyInfoM.Street = Street;
            companyInfoM.City = City;
            companyInfoM.State = State;
            companyInfoM.Zip = Zip;

            SampleSoA.CapabilityScope.Locations[0].Address.Street = Street;
            SampleSoA.CapabilityScope.Locations[0].Address.City = City;
            SampleSoA.CapabilityScope.Locations[0].Address.State = State;
            SampleSoA.CapabilityScope.Locations[0].Address.Zip = Zip;

            SampleSoA.writeTo(doc);
            doc.Save(@"C:\Temp\sampleMy.xml");

            return Content("Company info saved successfully!");
        }

        public ActionResult TaxonomyInfo()
        {
            ViewBag.Message = "Taxonomy.";

            return View();
        }
    }
}