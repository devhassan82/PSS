using PSS.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSS.UC
{
    public partial class ucMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    BindMenu();
            }
            catch (Exception ex)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx", false);
            }
        }

        public void BindMenu()
        {

            List<clsMenu> MenuList = new List<clsMenu>();
            MenuList = (List<clsMenu>)Session["_MenuList"];

            DataSet ds = new DataSet();
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();


            StringBuilder objstr = new StringBuilder();
            objstr.Append("<ul class=\"navbar-nav\" id=\"navbar-nav\"  >");
            //objstr.Append("<ul class=\"nav nav-pills nav-stacked main-menu\" id=\"drop-nav\" style=\"padding-right: 10px\" >");
            var Parentitem = MenuList.Where(m => (m.ParentID == 0)).ToList(); /*&& (m.Menu_Level == 0) */

            if (Parentitem.Count > 0)
            {
                int _Menu_Level = 0;
                int _MenuID = 0;
                string filter = "";
                foreach (var _item in Parentitem)
                {
                    _Menu_Level = _item.Menu_Level;
                    _MenuID = _item.MenuID;
                    if (_Menu_Level == 0)
                    {
                        // objstr.Append("<li class=\"\"><a href='" + _item.MenuPath + "'>" + _item.DisplayMenuName + "</a> </li>");
                        objstr.Append("<li class=\"nav-item \" style=\"\"><a  id=" + "Row" + _MenuID.ToString() + "  class=\"nav-link menu-link\" href='" + _item.MenuPath + "'> <i class= '" + _item.ImgClassName + "'></i>  <span class=\"\"> " + _item.DisplayMenuName + "</span>   </a>  </li>");
                        // objstr.Append("<li id=" + "Row" + _MenuID.ToString() + " class=\"waves-effect \" style=\"\"><a  href='" + _item.MenuPath + "'>  <span>" + _item.DisplayMenuName + " </span> <i class= '" + _item.ImgClassName + "'></i>  </a> </li>");
                    }

                    else
                    {
                        objstr.Append("<li style=\"\"><a  id=" + "Row" + _MenuID.ToString() + "  class=\"waves-effect parent-item js__control\" href='#'> <i class= '" + _item.ImgClassName + "'></i>  <span > " + _item.DisplayMenuName + "</span>  <span  class=\"menu-arrow fa fa-angle-down\"></span> </a>");
                        objstr.Append("<ul class=\"sub-menu js__content\" >");
                        var Childitem = MenuList.Where(c => (c.ParentID == _MenuID)).ToList(); /*&& (m.Menu_Level == 0) */
                        foreach (var _citem in Childitem)
                        {
                            if (_citem.MenuID == 199 || _citem.MenuID == 147 || _citem.MenuID == 94 || _citem.MenuID == 126 || _citem.MenuID == 127 || _citem.MenuID == 133 || _citem.MenuID == 32 || _citem.MenuID == 33 || _citem.MenuID == 56 || _citem.MenuID == 156)
                            {


                                objstr.Append("<li ><a id=" + "subMenu" + _citem.MenuID.ToString() + "  class=\"waves-effect\" href='" + _citem.MenuPath + "'>" + _citem.DisplayMenuName + "</a></li>");
                            }
                            else
                            {
                                // objstr.Append("<li class=\"\"><a href='" + _citem.MenuPath + "'>" + _citem.DisplayMenuName + "</a></li>");
                                objstr.Append("<li ><a id=" + "subMenu" + _citem.MenuID.ToString() + "  class=\"waves-effect\" href='" + _citem.MenuPath + "'>" + _citem.DisplayMenuName + "</a></li>");
                            }
                        }
                        objstr.Append("</ul> </li>");
                    }
                }
            }
            objstr.Append("</ul>");
            divmenu.InnerHtml = objstr.ToString();
        }
    }
}