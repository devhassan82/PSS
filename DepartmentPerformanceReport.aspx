<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentPerformanceReport.aspx.cs" Inherits="PSS.DepartmentPerformanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <style>
                .radio label {
                    position: relative;
                    padding-left: 20px;
                    padding-right: 10px;
                }

                table.table-bordered.dataTable th, table.table-bordered.dataTable td {
                    border-left-width: 1px;
                }
            </style>
            <script>
                function fnConfirm() {
                    if (confirm("Please Confirm, Do you want to Upload the marks?") == true)
                        return true;
                    else
                        return false;
                }
            </script>

            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Department Performance Report</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <%--<li class="breadcrumb-item"><a href="javascript: void(0);">List of Vacancies</a></li>--%>
                                <li class="breadcrumb-item active">Department Performance</li>
                            </ol>
                        </div>

                    </div>
                </div>
            </div>
            <!-- end page title -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Department Performance Reprot</h4>
                        </div>
                        <!-- end card header -->
                        <div class="card-body">
                            <div class="live-preview">
                                <div class="row mb-2">
                                    <div class="col-lg-2">
                                        <asp:Label ID="lblDepartment" runat="server" Text="Department" CssClass="form-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="ddlDepartment" runat="server" class="form-select">
                                            <asp:ListItem Value="1" Text="IT"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Finance"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="HR"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-lg-2">
                                        <asp:Label ID="lblYear" runat="server" Text="Year" CssClass="form-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="ddlYear" runat="server" class="form-select">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-lg-2">
                                        <asp:Label ID="lblMonth" runat="server" Text="Month" CssClass="form-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="ddlMonth" runat="server" class="form-select">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-lg-2">
                                        <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="form-label"></asp:Label>
                                    </div>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-select">
                                            <asp:ListItem Value="1" Text="Promoted employee"></asp:ListItem>
<asp:ListItem Value="2" Text="Needs training"></asp:ListItem>
<asp:ListItem Value="3" Text="Needs replacement"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="hstack gap-2 mt-3">
                                    <asp:Button ID="btnSearch" runat="server" CssClass="js-programmatic-enable btn btn-primary" Text="Search" OnClick="btnSearch_Click" />

                                    <asp:Button ID="btnClose" runat="server" CssClass="js-programmatic-disable btn btn-danger" Text="Close" OnClick="btnCancel_Click" />
                                </div>

                                <div class="mt-4">


                                    <div class="row pt-3">
                                        <div class="col-lg-12">
                                            <div class="ctable-responsive">
                                                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
                                                    GridLines="None" CssClass="table table-striped table-bordered display" EmptyDataText="No records found" OnPreRender="gvList_PreRender">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Employee Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Eval("EmployeeCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Score">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblScore" runat="server" Text='<%# Eval("Score") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Promotion Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPromotionStatus" runat="server" Text='<%# Eval("PromotionStatus") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="alert hidden divider" id="alertBar">
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <script src="//cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
            <link href="assets/plugin/jqueryui/jquery-ui.css" rel="stylesheet" />
            <script src="assets/plugin/jqueryui/jquery-ui.js"></script>
            <script src="assets/plugin/jquery-autocomplete/jquery.autocomplete.min.js"></script>
            <link href="assets/plugin/bootstrap-datepicker/css/bootstrap-datepicker3.css" rel="stylesheet">
            <script src="assets/plugin/bootstrap-datepicker/js/bootstrap-datepicker.min.js"></script>
            <link href="assets/plugin/timepicker/bootstrap-timepicker.min.css" rel="stylesheet">
            <script src="assets/plugin/timepicker/bootstrap-timepicker.min.js"></script>
            <script src="Scripts/DisplayMessages.js"></script>

        </ContentTemplate>

    </asp:UpdatePanel>
    <script>
        function pageLoad() {
            BindEvents();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(BindEvents);
        }
        function BindEvents() {
            var gridViewID = document.getElementById("<%=gvList.ClientID%>");

            if (gridViewID != null) {
                BindGrid(gridViewID.id);
            }
        }
        function ClearGrid() {
            var table = $('#gvList').DataTable();
            table.clear();
            table.destroy();
        }

        function BindGrid(GridId) {
            $('#' + GridId).DataTable({
                "bPaginate": false,
                "bLengthChange": true,
                "bFilter": false,
                "bSort": true,
                "bInfo": false,
                "bAutoWidth": true,
                "iDisplayLength": 100,
                "destroy": true
            });
        }
    </script>
</asp:Content>
