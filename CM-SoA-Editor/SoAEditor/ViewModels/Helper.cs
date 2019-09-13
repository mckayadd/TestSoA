using SOA_DataAccessLibrary;
using SoAEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAEditor.ViewModels
{
    public static class Helper
    {

        public static void LoadCompanyInfoToSoaObjectToSave(Soa SampleSoA, CompanyModel CompanyM)
        {
            SampleSoA.CapabilityScope.Locations[0].Address.Street = CompanyM.CompanyInfo.Street;
            SampleSoA.CapabilityScope.Locations[0].Address.City = CompanyM.CompanyInfo.City;
            SampleSoA.CapabilityScope.Locations[0].Address.State = CompanyM.CompanyInfo.State;
            SampleSoA.CapabilityScope.Locations[0].Address.Zip = CompanyM.CompanyInfo.Zip;

            SampleSoA.Ab_ID = "a";
            SampleSoA.Ab_Logo_Signature = "a";
            SampleSoA.Scope_ID_Number = "a";
            SampleSoA.Criteria = "a";
            SampleSoA.EffectiveDate = "a";
            SampleSoA.ExpirationDate = "a";
            SampleSoA.Statement = "a";
            SampleSoA.CapabilityScope.MeasuringEntity = "a";
            SampleSoA.CapabilityScope.Locations[0].id = "a";
            SampleSoA.CapabilityScope.Locations[0].ContactName = "a";
            //SampleSoA.CapabilityScope.Locations[0].ContactInfo = Contact_info;
        }

        public static void LoadCompanyInfoFromSoaObjectToOpen(Soa SampleSoA, CompanyModel CompanyM)
        {
            //SampleSoA = aSampleSoA;

            /*
            AB_ID = SampleSoA.Ab_ID;
            AB_logo_sign = SampleSoA.Ab_Logo_Signature;
            Scope_ID = SampleSoA.Scope_ID_Number;
            Criteria = SampleSoA.Criteria;
            Effective_date = SampleSoA.EffectiveDate;
            Expiration_date = SampleSoA.ExpirationDate;
            //Statement = SampleSoA.Statement;
            Name = SampleSOA.CapabilityScope.MeasuringEntity.ToString();
            Location_ID = SampleSoA.CapabilityScope.Locations[0].id;
            Contact_name = SampleSoA.CapabilityScope.Locations[0].ContactName;
            Contact_info = SampleSoA.CapabilityScope.Locations[0].ContactInfo.ToString(); */

            CompanyM.CompanyInfo.Street = SampleSoA.CapabilityScope.Locations[0].Address.Street;
            CompanyM.CompanyInfo.City = SampleSoA.CapabilityScope.Locations[0].Address.City;
            CompanyM.CompanyInfo.State = SampleSoA.CapabilityScope.Locations[0].Address.State;
            CompanyM.CompanyInfo.Zip = SampleSoA.CapabilityScope.Locations[0].Address.Zip;
        }

    }
}
