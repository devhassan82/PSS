using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS.App_Code
{
    public class clsMenu
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuPath { get; set; }
        public int Menu_Level { get; set; }
        public int MenuGroup { get; set; }
        public string DisplayMenuName { get; set; }
        public int ParentID { get; set; }
        public int SortOrder { get; set; }
        public string ImgClassName { get; set; }
        public List<clsMenu> List { get; set; }
    }
}