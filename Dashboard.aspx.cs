using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSS
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private Dictionary<string, int> allDepartment;
        public Dictionary<string, int> AllDepartment { get { return allDepartment; } }

        private Dictionary<string, int>itDepartment;
        public Dictionary<string, int> ITDepartment { get { return itDepartment; } }

        private Dictionary<string, int> financeDepartment;
        public Dictionary<string, int> FinanceDepartment { get { return financeDepartment; } }

        private Dictionary<string, int> hrDepartment;
        public Dictionary<string, int> HRDepartment { get { return hrDepartment; } }

        private Dictionary<string, int> planningDepartment;
        public Dictionary<string, int> PlanningDepartment { get { return planningDepartment; } }

        private Dictionary<string, int> budgetDepartment;
        public Dictionary<string, int> BudgetDepartment { get { return budgetDepartment; } }

        private Dictionary<string, int> adminDepartment;
        public Dictionary<string, int> AdminDepartment { get { return adminDepartment; } }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

              string  Code = "";
              int  Result = 0;
                allDepartment = new Dictionary<string, int>();
                itDepartment = new Dictionary<string, int>();
                financeDepartment = new Dictionary<string, int>();
                hrDepartment = new Dictionary<string, int>();
                planningDepartment = new Dictionary<string, int>();
                budgetDepartment = new Dictionary<string, int>();
                adminDepartment = new Dictionary<string, int>();

                btnSearch_Click(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Code = "";
            int Result = 0;
            allDepartment = new Dictionary<string, int>();
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            DataSet ds = (DataSet)obj.GetData("7", "0", "");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Code = row.Field<string>("Code");
                Result = row.Field<int>("Result");
                allDepartment.Add(Code, Result);
            }

            ds = (DataSet)obj.GetData("7", "1", "");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Code = row.Field<string>("Code");
                Result = row.Field<int>("Result");
                financeDepartment.Add(Code, Result);
            }

            ds = (DataSet)obj.GetData("7", "2", "");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Code = row.Field<string>("Code");
                Result = row.Field<int>("Result");
                itDepartment.Add(Code, Result);
            }

            ds = (DataSet)obj.GetData("7", "3", "");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Code = row.Field<string>("Code");
                Result = row.Field<int>("Result");
                hrDepartment.Add(Code, Result);
            }
            ds = (DataSet)obj.GetData("7", "4", "");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Code = row.Field<string>("Code");
                Result = row.Field<int>("Result");
                adminDepartment.Add(Code, Result);
            }

            ds = (DataSet)obj.GetData("7", "5", "");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Code = row.Field<string>("Code");
                Result = row.Field<int>("Result");
                planningDepartment.Add(Code, Result);
            }
            ds = (DataSet)obj.GetData("7", "6", "");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Code = row.Field<string>("Code");
                Result = row.Field<int>("Result");
                budgetDepartment.Add(Code, Result);
            }

        }
    
    }
}