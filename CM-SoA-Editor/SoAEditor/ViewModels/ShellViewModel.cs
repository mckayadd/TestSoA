using Caliburn.Micro;
using SoAEditor.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;
using SOA_DataAccessLibrary;

namespace SoAEditor.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private CompanyModel _companyM;
        private CompanyInfoModel _companyInfoM;
        private TaxonomyInfoModel _taxonomyInfoM;

        private CompanyInfoViewModel _companyInfoVM = null;
        private TaxonomyInfoViewModel _taxonomyInfoVM = null;

        private string _fullPath = "";
        private bool _isSaveAs = false;

        XDocument doc;
        Soa SampleSOA;
        SOA_DataAccess dao;

        public ShellViewModel()
        {
            CompanyInfoM = new CompanyInfoModel();
            TaxonomyInfoM = new TaxonomyInfoModel();
            CompanyM = new CompanyModel(CompanyInfoM, TaxonomyInfoM);
            CompanyInfoVM = new CompanyInfoViewModel(CompanyInfoM);
            TaxonomyInfoVM = new TaxonomyInfoViewModel();

            SampleSOA = new Soa();
        }

        public void LoadCompanyInfo()
        {
            ActivateItem(CompanyInfoVM);
        }

        public void LoadTaxonomyInfo()
        {
            ActivateItem(TaxonomyInfoVM);
        }

        public void OpenXMLFile()
        {
            dao = new SOA_DataAccess();

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "XML Files (*.xml)|*.xml|All Files(*.*)|*.*";
            dlg.Multiselect = false;
            //string path = dlg.FileName;
            try
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                FullPath = dlg.FileName;
                dao.load(dlg.FileName);
                SampleSOA = dao.SOADataMaster;
                Helper.LoadCompanyInfoFromSoaObjectToOpen(SampleSOA, CompanyM); // assigns info extracted from XML to the Company info form: SoA_DataAccessLibrary Object -> Object of our hierarchy
                CompanyInfoVM.LoadCompanyInfo(); // copies info into local parameters to be shown in the view: Our object -> Local variables
                ActivateItem(CompanyInfoVM);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("The data file is invalid!");
                return;
            }
        }

        public void SaveXML()
        {

            doc = new XDocument();

            Helper.LoadCompanyInfoToSoaObjectToSave(SampleSOA, CompanyM);


            SampleSOA.writeTo(doc);

            if (FullPath.Length == 0 || IsSaveAs == true) // Saving a new file or Save as...
            {
                System.Windows.Forms.SaveFileDialog saveFileDlg = new System.Windows.Forms.SaveFileDialog();

                saveFileDlg.Filter = "XML Files (*.xml)|*.xml|All Files(*.*)|*.*";
                saveFileDlg.FilterIndex = 2;
                saveFileDlg.RestoreDirectory = true;

                if (saveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    // Code to write the stream goes here.
                    FullPath = saveFileDlg.FileName;
                    doc.Save(FullPath);
                    System.Windows.Forms.MessageBox.Show("File saved!");
                    return;
                }
            }
            else if (FullPath.Length != 0)
            {
                doc.Save(FullPath);
                System.Windows.Forms.MessageBox.Show("File saved!");
            }
        }

        public void SaveAsXML()
        {
            IsSaveAs = true;
            SaveXML();
        }

        public void ExitApp()
        {
           //System.Windows.Forms.Application.Current.Shutdown();
        }

        public CompanyModel CompanyM
        {
            get { return _companyM; }
            set { _companyM = value; }
        }

        public CompanyInfoModel CompanyInfoM
        {
            get { return _companyInfoM; }
            set { _companyInfoM = value; }
        }

        public TaxonomyInfoModel TaxonomyInfoM
        {
            get { return _taxonomyInfoM; }
            set { _taxonomyInfoM = value; }
        }

        public CompanyInfoViewModel CompanyInfoVM
        {
            get { return _companyInfoVM; }
            set { _companyInfoVM = value; }
        }

        public TaxonomyInfoViewModel TaxonomyInfoVM
        {
            get { return _taxonomyInfoVM; }
            set { _taxonomyInfoVM = value; }
        }

        public string FullPath
        {
            get { return _fullPath; }
            set { _fullPath = value; }
        }

        public bool IsSaveAs
        {
            get { return _isSaveAs; }
            set
            {
                _isSaveAs = value;
                NotifyOfPropertyChange(() => IsSaveAs);
            }
        }

    }
}
