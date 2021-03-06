using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rupor.Domain.Doc
{
    public class BaseDocument
    {
        public DateTime CreationDate => DateTime.Now;
        
        public DateTime UpdateDate { get; set; }
        public BaseDocument()
        {
            UpdateDate = CreationDate;
        }
    }
}
