using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parse.Models
{
    public class CpvProduct : Product
    {

        public string Code { get; set; }
        public string TitleEngl { get; set; }

        public CpvProduct ()
            :base()
        {
            NameSite="http://search.ligazakon.ua/l_doc2.nsf/link1/ST002368.html";
            ParseSite = "ligazakon.ua";
        }
    }
}