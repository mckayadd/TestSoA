using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVVM
{
    public class Taxonomy
    {
        private string _processType;

        public string ProcessType
        {
            get
            {
                return _processType;
            }

            set
            {
                _processType = value;
            }
        }
    }
}
