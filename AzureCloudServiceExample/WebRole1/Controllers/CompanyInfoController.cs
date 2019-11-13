using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;


namespace WebRole1.Controllers
{
    public class CompanyInfoController 
    {
        private string _city;
        private string _street;
        private string _state;
        private string _zip;

        public CompanyInfoModel companyInfoM;

        public CompanyInfoController(CompanyInfoModel companyInfoModel)
        {
            companyInfoM = companyInfoModel;
        }


     


        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                
            }
        }


    }
}