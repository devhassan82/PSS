using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web.UI.WebControls;
namespace PSS
{
    public partial class EmployeePerformanceReport : System.Web.UI.Page
    {
        #region Property Declaration
        public DataTable dtPerformance
        {
            set
            {
                this.ViewState["dtPerformance"] = value;
            }
            get
            {
                return (DataTable)this.ViewState["dtPerformance"];
            }
        }
        public DataTable GetPerformanceTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("EmployeeCode", typeof(string), null);
            table.Columns.Add("ProjectCode", typeof(string), null);
            table.Columns.Add("NoOfTasks", typeof(int), null);
            table.Columns.Add("RelatedObjective", typeof(string), null);
            table.Columns.Add("ProjectCompletion", typeof(int), null);
            table.Columns.Add("EfficiencyPerformance", typeof(int), null);
            table.Columns.Add("AttendancePercentage", typeof(int), null);
            table.Columns.Add("OverallPerformance", typeof(int), null);
            table.Columns["id"].AutoIncrement = true;
            table.Columns["id"].AutoIncrementSeed = 1;
            table.Columns["id"].AutoIncrementStep = 1;
            table.AcceptChanges();
            return table;
        }

        public DataTable getXmlTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("GradeUploadID", typeof(string));
            table.Columns.Add("RefNo", typeof(string));
            table.Columns.Add("Programme", typeof(string));
            table.Columns.Add("OverAllMark", typeof(string));
            table.Columns.Add("AlertFlag", typeof(string));
            table.Columns.Add("AlertIndicator", typeof(string));
            table.AcceptChanges();
            return table;
        }
        private int MonthID
        {
            set { this.ViewState["MonthID"] = value; }
            get { return (int)this.ViewState["MonthID"]; }
        }
        private int YearID
        {
            set { this.ViewState["YearID"] = value; }
            get { return (int)this.ViewState["YearID"]; }
        }

        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
                    DataSet ds = (DataSet)obj.GetData("1", "", "");
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Util.FillDropdown(ref ddlMonth, ds.Tables[0].Copy(), "MonthNameEn", "MonthID", 1);
                            Util.FillDropdown(ref ddlYear, ds.Tables[1].Copy(), "YearEn", "YearID", 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(this.GetType().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message.ToString());
            }
        }
        #endregion

        #region Methods


        private void BindData(string strConn)
        {
            OleDbConnection objConn = new OleDbConnection(strConn);
            objConn.Open();
            string _Sub = "";
            // Get the data table containg the schema guid.  
            DataTable dt = null;
            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            objConn.Close();

            DataTable dtEmpPerformance = GetPerformanceTable();

            if (dt.Rows.Count > 0)
            {
                int i = 0;

                // Bind the sheets to the Grids  
                foreach (DataRow row in dt.Rows)
                {
                    _Sub = "";
                    DataTable dt_sheet = null;
                    _Sub = row["TABLE_NAME"].ToString().Trim().ToLower();
                    dt_sheet = getSheetData(strConn, row["TABLE_NAME"].ToString().Trim().ToLower());

                    switch (_Sub)
                    {
                        case "empdata$":
                            BindEmpDataTable(dt_sheet, "EmpData", ref dtEmpPerformance);
                            break;
                    }
                    i++;
                }
            }
            dtPerformance = dtEmpPerformance.Copy();
            gvList.DataSource = dtEmpPerformance.Copy();
            gvList.DataBind();
        }
        private void BindEmpDataTable(DataTable dtPerformance, string subject, ref DataTable _dtperformance)
        {
            int count = 0;
            if (_dtperformance.Rows.Count > 0)
                count = _dtperformance.Rows.Count;
            foreach (DataRow dr in dtPerformance.Rows)
            {
                count = count + 1;
                if (!string.IsNullOrEmpty(dr["EmployeeCode"].ToString()))
                {
                    //FillRow(count, dr["EmployeeCode"].ToString(), dr["ProjectCode"].ToString(), Convert.ToInt32(dr["NoOfTasks"].ToString()), dr["RelatedObjective"].ToString(), Convert.ToInt32(dr["ProjectCompletion"].ToString()), Convert.ToInt32(dr["EfficiencyPerformance"].ToString()), ref _dtperformance);
                }
            }
        }

        private DataTable getSheetData(string strConn, string sheet)
        {
            string query = "select * from [" + sheet + "]";
            OleDbConnection objConn;
            OleDbDataAdapter oleDA;
            DataTable dt = new DataTable();
            objConn = new OleDbConnection(strConn);
            objConn.Open();
            oleDA = new OleDbDataAdapter(query, objConn);
            oleDA.Fill(dt);
            objConn.Close();
            oleDA.Dispose();
            objConn.Dispose();
            return dt;
        }

        private void FillRow(int count, string EmployeeCode, string ProjectCode, int NoOfTasks, string RelatedObjective, int ProjectCompletion, int EfficiencyPerformance, int Attendance,int overallPerformance, ref DataTable dt)
        {


            DataRow dr = dt.NewRow();
            dr[0] = count;
            dr[1] = EmployeeCode.ToString();
            dr[2] = ProjectCode.ToString();
            dr[3] = NoOfTasks.ToString();
            dr[4] = RelatedObjective.ToString();
            dr[5] = ProjectCompletion.ToString();
            dr[6] = EfficiencyPerformance.ToString();
            dr[7] = Attendance.ToString();
            dr[8] = overallPerformance.ToString();
            dt.Rows.Add(dr);
        }
        private void BindModule()
        {
            //DataSet ds = new DataSet();
            //Service.Service obj = new Service.Service();
            //ds = obj.GetModuleForTimeTable(ddlDepartment.SelectedValue.ToString(), ddlSemester.SelectedValue.ToString(), ddlYear.SelectedValue.ToString());
            //if (ds != null && ds.Tables.Count > 0)
            //{
            //    Util.FillDropdown(ref ddlModule, ds.Tables[0].Copy(), "ModuleName", "ModuleID", 1);
            //}
            //dtModule = ds.Tables[0].Copy();
        }


        private void Fillxml(string GradeUploadID, string RefNo, string Programme, string OverAllMark, string AlertFlag, string AlertIndicator, ref DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr[0] = GradeUploadID;
            dr[1] = RefNo.ToString();
            dr[2] = Programme;
            dr[3] = OverAllMark.ToString();
            dr[4] = AlertFlag.ToString();
            dr[5] = AlertIndicator.ToString();

            dt.Rows.Add(dr);
        }
        private void FoundationGradeUploadIU(string Programme, string ModuleName, ref string _success)
        {
            //string _success = string.Empty;
            //string _msg = string.Empty;
            //string _mID = string.Empty;
            //DataTable dtResult = new DataTable();
            //dtResult = dtModule.Copy();
            //DataView dvResult = new DataView();

            //dvResult = dtResult.Copy().DefaultView;
            //dvResult.RowFilter = "ModuleName like '%" + ModuleName.ToString() + "%'";
            //dtResult = dvResult.ToTable();
            //if (dtResult.Rows.Count > 0)
            //{
            //    _mID = dtResult.Rows[0][0].ToString();

            //    DataTable dtRes = new DataTable();
            //    dtRes = dtGrade.Copy();
            //    DataView dvRes = new DataView();
            //    dvRes = dtRes.Copy().DefaultView;
            //    dvRes.RowFilter = "Programme like '" + Programme.ToString() + "'";
            //    dtRes = dvRes.ToTable();

            //    DataTable dtFGrade = getXmlTable();
            //    foreach (DataRow dr in dtRes.Rows)
            //    {
            //        Fillxml("0", dr["RegNo"].ToString(), _mID, dr["OverAllMark"].ToString(), dr["AlertFlag"].ToString(), dr["AlertIndicator"].ToString(), ref dtFGrade);
            //    }

            //    string _xmlFile;
            //    DataSet ds = new DataSet();
            //    ds.Tables.Add(dtFGrade);
            //    _xmlFile = ds.GetXml();
            //    int _resit = 0;
            //    if (chkResit.Checked)
            //        _resit = 1;
            //    else if (chkResitSecondSheet.Checked)
            //        _resit = 2;

            //Service.Service obj = new Service.Service();
            //obj.GradeUploadIU(ddlAcademicYear.SelectedValue.ToString(), ddlDepartment.SelectedValue.ToString(), _mID, ddlYear.SelectedValue.ToString(), ddlSemester.SelectedValue.ToString(), _xmlFile, Session["UserID"].ToString(), _resit.ToString(), ref _success, ref _msg);
            //}
        }

        private void ErrorMessage(string _Class, string _function, String _errorMsg)
        {
            //string message = string.Empty;
            //message = _errorMsg; // "Error: Please contact IT department";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Error + "');", true);
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Error + "');", true);
            //Service.Service obj = new Service.Service();
            //obj.ErrorLogIU(1, _Class, _function, _errorMsg);
        }

        private bool finalvalidation(ref string msg)
        {
            bool retval = true;
            if (ddlYear.SelectedValue == "0")
            {
                msg = "Please select Year";
                retval = false;
            }



            return retval;
        }
        #endregion
        #region Events
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
            DataSet ds = (DataSet)obj.GetData("4", "", "");
            gvList.DataSource = ds.Tables[0];
            gvList.DataBind();
            gvPerfotmance.DataSource = ds.Tables[1];
            gvPerfotmance.DataBind();
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.ddlModule.SelectedValue = _ModuleID.ToString(); //Request.Form[this.ddlModule.UniqueID];
            //    string message = string.Empty;
            //    if (!finalvalidation(ref message))
            //    {
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Warning + "');", true);
            //        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Warning + "');", true);
            //        return;
            //    }
            //    string _success = "";
            //    string _msg = "";
            //    if (ddlDepartment.SelectedValue == "5")
            //    {
            //        FoundationGradeUploadIU("English", "ENG", ref _success);
            //        FoundationGradeUploadIU("Math", "Math", ref _success);
            //        FoundationGradeUploadIU("Science", "SCI", ref _success);
            //        FoundationGradeUploadIU("IT", "IT", ref _success);
            //    }
            //    else
            //    {
            //        DataTable dt = getXmlTable();

            //        foreach (DataRow dr in this.dtGrade.Rows)
            //        {
            //            Fillxml("0", dr["RegNo"].ToString(), dr["Programme"].ToString(), dr["OverAllMark"].ToString(), dr["AlertFlag"].ToString(), dr["AlertIndicator"].ToString(), ref dt);
            //        }

            //        string _xmlFile;
            //        DataSet ds = new DataSet();
            //        ds.Tables.Add(dt);
            //        _xmlFile = ds.GetXml();
            //        int _resit = 0;
            //        if (chkResit.Checked)
            //            _resit = 1;
            //        else if (chkResitSecondSheet.Checked)
            //            _resit = 2;
            //        //Service.Service obj = new Service.Service();
            //        //obj.GradeUploadIU(ddlAcademicYear.SelectedValue.ToString(), ddlDepartment.SelectedValue.ToString(), ddlModule.SelectedValue.ToString(), ddlYear.SelectedValue.ToString(), ddlSemester.SelectedValue.ToString(), _xmlFile, Session["UserID"].ToString(), _resit.ToString(), ref _success, ref _msg);
            //    }
            //    if (_success == "1")
            //    {
            //        message = "Grades uploaded successfully.";
            //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Success + "');", true);
            //        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Success + "');", true);
            //    }
            //    else if (_success == "2")
            //    {
            //        message = "Unable to upload grades. Marks have already uploaded";
            //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Warning + "');", true);
            //        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Warning + "');", true);
            //    }
            //    else
            //    {
            //        message = "Unable to upload grades.";
            //        //Page.ClientScript.RegisterStartupScript(this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Warning + "');", true);
            //        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DisplayCustomMessage", "DisplayCustomMessage('#alertBar','" + message + "','" + Constants.AlertType.Warning + "');", true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ErrorMessage(this.GetType().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message.ToString());
            //}
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //if (Navigation == (int)Constants.FormNavigation.UploadGradesList)
            //{
            //    Response.Redirect("/UploadGradesList.aspx", false);
            //}
            //else if (Navigation == (int)Constants.FormNavigation.GradesEntryByTeacher)
            //{
            //    if (vTypeID == 1)
            //    {
            //        Response.Redirect("~/Grades/GradesEntryByTeacher.aspx?_ID=" + Util.LocalEncrypt(_ModuleID.ToString()) + "&AyID=" + Util.LocalEncrypt(ExamMasterID.ToString()) + "&TID=" + Util.LocalEncrypt(Session["UserID"].ToString()) + "&VtypeID=" + Util.LocalEncrypt("1") + "&ExamYearID=" + Util.LocalEncrypt(ExamYearID.ToString()), false);

            //    }
            //    else if (vTypeID == 2)
            //    {
            //        Response.Redirect("~/Grades/GradesEntryByTeacher.aspx?_ID=" + Util.LocalEncrypt(_ModuleID.ToString()) + "&AyID=" + Util.LocalEncrypt(ExamMasterID.ToString()) + "&TID=" + Util.LocalEncrypt(Session["UserID"].ToString()) + "&VtypeID=" + Util.LocalEncrypt("2") + "&ExamYearID=" + Util.LocalEncrypt(ExamYearID.ToString()), false);
            //    }
            //}
            //else if (Navigation == (int)Constants.FormNavigation.GradesEntryByHOD)
            //{
            //    if (vTypeID == 1)
            //    {
            //       /* Response.Redirect("~/Grades/GradesEntry.aspx?_ID=" + Util.LocalEncrypt(_ModuleID.ToString()) + "&AyID=" + Util.LocalEncrypt(ExamYearID.ToString()) + "&VtypeID=" + Util.LocalEncrypt("1") + "&ExamMasterID*/=" + Util.LocalEncrypt(ExamMasterID.ToString()), false);

            //    }
            //    else if (vTypeID == 2)
            //    {
            //       /* Response.Redirect("~/Grades/GradesEntry.aspx?_ID=" + Util.LocalEncrypt(_ModuleID.ToString()) + "&AyID=" + Util.LocalEncrypt(ExamYearID.ToString()) + "&VtypeID=" + Util.LocalEncrypt("2") + "&ExamMasterID="*/ + Util.LocalEncrypt(ExamMasterID.ToString()), false);
            //    }
            //}
            //else
            //{
            //    Response.Redirect("/Dashboard.aspx", false);
            //}
        }
      
        protected void gvList_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvList.Rows.Count > 0)
                {
                    //Replace the <td> with <th> and adds the scope attribute
                    gvList.UseAccessibleHeader = true;
                    //Adds the <thead> and <tbody> elements required for DataTables to work
                    gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //Adds the <tfoot> element required for DataTables to work
                    if (gvList.ShowFooter)
                    {
                        gvList.FooterRow.TableSection = TableRowSection.TableFooter;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(this.GetType().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ex.Message.ToString());
            }
        }
        #endregion



    }
}