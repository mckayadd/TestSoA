using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAEditor.Models
{
    public class ProcessType
    {
        public string Action;
        public string Taxonomy;
        public List<string> RequiredParameters = new List<string>();
        public List<string> OptionalParameters = new List<string>();
    }
}
