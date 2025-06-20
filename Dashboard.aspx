<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PSS.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Layout config Js -->
    <script src="Velzon/assets/js/layout.js"></script>
    <!-- Bootstrap Css -->
    <link href="Velzon/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Icons Css -->
    <link href="Velzon/assets/css/icons.min.css" rel="stylesheet" type="text/css" />
    <!-- App Css-->
    <link href="Velzon/assets/css/app.min.css" rel="stylesheet" type="text/css" />
    <!-- custom Css-->
    <link href="Velzon/assets/css/custom.min.css" rel="stylesheet" type="text/css" />

    <script src="Velzon/assets/libs/chart.js/chart.min.js"></script>

    <!-- chartjs init -->
    <script src="Velzon/assets/js/pages/chartjs.init.js"></script>
    <div class="row">
        <div class="col-xl-12">
            <div class="card">
                <div class="card-header border-0 align-items-center d-flex">
                    <h4 class="card-title mb-0 flex-grow-1">Progress Overview</h4>

                </div>
                <!-- end card header -->

                <div class="card-body">
                    <div class="card-header p-0 border-0 bg-soft-light" runat="server" id="divAllDeptStatus">
                        <div class="row g-0 text-center">
                            <div class="col-6 col-sm-3">
                                <div class="p-3 border border-dashed border-start-0">
                                    <h5 class="mb-1"><span class="counter-value" data-target="500">0</span></h5>
                                    <p class="text-muted mb-0">Number of Employee</p>
                                </div>
                            </div>
                            <!--end col-->
                            <div class="col-6 col-sm-3">
                                <div class="p-3 border border-dashed border-start-0">
                                    <h5 class="mb-1"><span class="counter-value" data-target="5">0</span>%</h5>
                                    <p class="text-muted mb-0">Promoted Employee</p>
                                </div>
                            </div>
                            <!--end col-->
                            <div class="col-6 col-sm-3">
                                <div class="p-3 border border-dashed border-start-0">
                                    <h5 class="mb-1"><span class="counter-value" data-target="50">0</span>%</h5>
                                    <p class="text-muted mb-0">Needs training</p>
                                </div>
                            </div>

                            <!--end col-->
                            <div class="col-6 col-sm-3">
                                <div class="p-3 border border-dashed border-start-0 border-end-0">
                                    <h5 class="mb-1 text-success"><span class="counter-value" data-target="10">0</span>%</h5>
                                    <p class="text-muted mb-0">Needs replacement</p>
                                </div>
                            </div>
                            <!--end col-->
                        </div>
                    </div>
                </div>
                <!-- end card header -->
                <div class="card-body">


                    <div class="row  mb-2">
                        <div class="col-xxl-12 col-xl-6">
                            <div class="card card-height-100">
                                <div class="card-header align-items-center d-flex">
                                    <h3 class="card-title mb-0 flex-grow-1">Progress Data term 1 2025-2026 </h3>
                                    <div class="flex-shrink-0">
                                    </div>
                                </div>
                                <!-- end card header -->

                                <!-- card body -->
                                <div class="card-body">

                                    <canvas id="myChart" style="width: 100%; max-width: 600px" class="chartjs-chart" data-colors='["--vz-danger", "--vz-success", "--vz-warning", "--vz-primary"]'></canvas>

                                    <script>
                                        new Chart("myChart", {
                                            type: "bar",
                                            data: {
                                                labels: ['Promoted Employee', 'Needs training', 'Needs replacement'], // Academic year labels
                                                datasets: [{
                                                    backgroundColor: ['#3577f1', '#7c7f90', '#f06548', '#6559cc'], // Colors for each bar
                                                    data: [
                <%= AllDepartment.ContainsKey("Promoted Employee") ? AllDepartment["Promoted Employee"] : 0 %>,
                <%= AllDepartment.ContainsKey("Needs training") ? AllDepartment["Needs training"] : 0 %>,
                <%= AllDepartment.ContainsKey("Needs replacement") ? AllDepartment["Needs replacement"] : 0 %>
                                                ] // Data for each academic year
                                            }]
                                        },
                                        options: {
                                            title: {
                                                display: true,
                                                text: "Progress Data term 1 2025-2026"
                                            },
                                            plugins: {
                                                legend: {
                                                    display: false // Hide the legend
                                                }
                                            },
                                            scales: {
                                                y: {
                                                    beginAtZero: true
                                                }
                                            }
                                        }
                                    });
                                    </script>



                                </div>
                                <!-- end card body -->
                            </div>
                            <!-- end card -->
                        </div>
                        <!-- end col -->


                    </div>

                    <div class="row  mb-2">
                        <div class="col-xxl-6 col-xl-6">
                            <div class="card card-height-100">
                                <div class="card-header align-items-center d-flex">
                                    <h3 class="card-title mb-0 flex-grow-1">Finance Department </h3>
                                    <div class="flex-shrink-0">
                                    </div>
                                </div>
                                <!-- end card header -->
                                <div class="card-body">
                                    <div class="card-header p-0 border-0 bg-soft-light" runat="server" id="divDeptStatus">
                                        <div class="row g-0 text-center">
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="15">0</span></h5>
                                                    <p class="text-muted mb-0">Number of Employee</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="4">0</span>%</h5>
                                                    <p class="text-muted mb-0">Promoted Employee</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="9">0</span>%</h5>
                                                    <p class="text-muted mb-0">Needs training</p>
                                                </div>
                                            </div>

                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0 border-end-0">
                                                    <h5 class="mb-1 text-success"><span class="counter-value" data-target="1">0</span>%</h5>
                                                    <p class="text-muted mb-0">Needs replacement</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                        </div>
                                    </div>
                                </div>
                                <!-- card body -->
                                <div class="card-body">

                                    <canvas id="Finance" style="width: 100%; max-width: 100%" class="chartjs-chart" data-colors='["--vz-danger", "--vz-success", "--vz-warning", "--vz-primary"]'></canvas>

                                    <script>
                                        new Chart("Finance", {
                                            type: "doughnut",
                                            data: {
                                                labels: [<%=string.Join(",",FinanceDepartment.Keys.Select(x=>"'"+x+"'").ToArray())%>],
                                    datasets: [{

                                        backgroundColor: ['#3577f1', '#7c7f90', '#f06548', '#6559cc', '#f672a7', '#405189'],
                                        data: [<%=string.Join(",",FinanceDepartment.Values.Select(x=>x).ToArray())%>]
                                    }]
                                },
                                options: {
                                    title: {
                                        display: true,

                                        text: "Finance"
                                    }
                                }
                            });
                                    </script>

                                </div>
                                <!-- end card body -->
                            </div>
                            <!-- end card -->
                        </div>
                        <!-- end col -->
                        <div class="col-xxl-6 col-xl-6">
                            <div class="card card-height-100">
                                <div class="card-header align-items-center d-flex">
                                    <h3 class="card-title mb-0 flex-grow-1">IT Department </h3>
                                    <div class="flex-shrink-0">
                                    </div>
                                </div>
                                <!-- end card header -->
                                <div class="card-body">
                                    <div class="card-header p-0 border-0 bg-soft-light" runat="server" id="div1">
                                        <div class="row g-0 text-center">
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="20">0</span></h5>
                                                    <p class="text-muted mb-0">Number of Employee</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="3">0</span>%</h5>
                                                    <p class="text-muted mb-0">Promoted Employee</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="15">0</span>%</h5>
                                                    <p class="text-muted mb-0">Needs training</p>
                                                </div>
                                            </div>

                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0 border-end-0">
                                                    <h5 class="mb-1 text-success"><span class="counter-value" data-target="2">0</span>%</h5>
                                                    <p class="text-muted mb-0">Needs replacement</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                        </div>
                                    </div>
                                </div>
                                <!-- card body -->
                                <div class="card-body">

                                    <canvas id="IT" style="width: 100%; max-width: 100%" class="chartjs-chart" data-colors='["--vz-danger", "--vz-success", "--vz-warning", "--vz-primary"]'></canvas>

                                    <script>
                                        new Chart("IT", {
                                            type: "doughnut",
                                            data: {
                                                labels: [<%=string.Join(",",ITDepartment.Keys.Select(x=>"'"+x+"'").ToArray())%>],
                                    datasets: [{

                                        backgroundColor: ['#3577f1', '#7c7f90', '#f06548', '#6559cc', '#f672a7', '#405189'],
                                        data: [<%=string.Join(",",ITDepartment.Values.Select(x=>x).ToArray())%>]
                                    }]
                                },
                                options: {
                                    title: {
                                        display: true,

                                        text: "IT"
                                    }
                                }
                            });
                                    </script>

                                </div>
                                <!-- end card body -->
                            </div>
                            <!-- end card -->
                        </div>

                    </div>

                                        <div class="row  mb-2">
                        <div class="col-xxl-6 col-xl-6">
                            <div class="card card-height-100">
                                <div class="card-header align-items-center d-flex">
                                    <h3 class="card-title mb-0 flex-grow-1">HR Department </h3>
                                    <div class="flex-shrink-0">
                                    </div>
                                </div>
                                <!-- end card header -->
                                <div class="card-body">
                                    <div class="card-header p-0 border-0 bg-soft-light" runat="server" id="div2">
                                        <div class="row g-0 text-center">
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="10">0</span></h5>
                                                    <p class="text-muted mb-0">Number of Employee</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="1">0</span>%</h5>
                                                    <p class="text-muted mb-0">Promoted Employee</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="8">0</span>%</h5>
                                                    <p class="text-muted mb-0">Needs training</p>
                                                </div>
                                            </div>

                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0 border-end-0">
                                                    <h5 class="mb-1 text-success"><span class="counter-value" data-target="1">0</span>%</h5>
                                                    <p class="text-muted mb-0">Needs replacement</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                        </div>
                                    </div>
                                </div>
                                <!-- card body -->
                                <div class="card-body">

                                    <canvas id="HR" style="width: 100%; max-width: 100%" class="chartjs-chart" data-colors='["--vz-danger", "--vz-success", "--vz-warning", "--vz-primary"]'></canvas>

                                    <script>
                                        new Chart("HR", {
                                            type: "doughnut",
                                            data: {
                                                labels: [<%=string.Join(",",HRDepartment.Keys.Select(x=>"'"+x+"'").ToArray())%>],
                                                datasets: [{

                                                    backgroundColor: ['#3577f1', '#7c7f90', '#f06548', '#6559cc', '#f672a7', '#405189'],
                                                    data: [<%=string.Join(",",HRDepartment.Values.Select(x=>x).ToArray())%>]
                                                }]
                                            },
                                            options: {
                                                title: {
                                                    display: true,

                                                    text: "HR"
                                                }
                                            }
                                        });
                                    </script>

                                </div>
                                <!-- end card body -->
                            </div>
                            <!-- end card -->
                        </div>
                        <!-- end col -->
                        <div class="col-xxl-6 col-xl-6">
                            <div class="card card-height-100">
                                <div class="card-header align-items-center d-flex">
                                    <h3 class="card-title mb-0 flex-grow-1">Admin Department </h3>
                                    <div class="flex-shrink-0">
                                    </div>
                                </div>
                                <!-- end card header -->
                                <div class="card-body">
                                    <div class="card-header p-0 border-0 bg-soft-light" runat="server" id="div3">
                                        <div class="row g-0 text-center">
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="25">0</span></h5>
                                                    <p class="text-muted mb-0">Number of Employee</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="5">0</span>%</h5>
                                                    <p class="text-muted mb-0">Promoted Employee</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value" data-target="18">0</span>%</h5>
                                                    <p class="text-muted mb-0">Needs training</p>
                                                </div>
                                            </div>

                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0 border-end-0">
                                                    <h5 class="mb-1 text-success"><span class="counter-value" data-target="2">0</span>%</h5>
                                                    <p class="text-muted mb-0">Needs replacement</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                        </div>
                                    </div>
                                </div>
                                <!-- card body -->
                                <div class="card-body">

                                    <canvas id="Admin" style="width: 100%; max-width: 100%" class="chartjs-chart" data-colors='["--vz-danger", "--vz-success", "--vz-warning", "--vz-primary"]'></canvas>

                                    <script>
                                        new Chart("Admin", {
                                            type: "doughnut",
                                            data: {
                                                labels: [<%=string.Join(",",AdminDepartment.Keys.Select(x=>"'"+x+"'").ToArray())%>],
                                    datasets: [{

                                        backgroundColor: ['#3577f1', '#7c7f90', '#f06548', '#6559cc', '#f672a7', '#405189'],
                                        data: [<%=string.Join(",",AdminDepartment.Values.Select(x=>x).ToArray())%>]
                                                }]
                                            },
                                            options: {
                                                title: {
                                                    display: true,

                                                    text: "Admin"
                                                }
                                            }
                                        });
                                    </script>

                                </div>
                                <!-- end card body -->
                            </div>
                            <!-- end card -->
                        </div>

                    </div>
                </div>
            </div>
            <!-- end card -->
        </div>
        <!-- end col -->
    </div>
    <!-- end row -->





    <script src="Velzon/assets/libs/bootstrap/js/bootstrap.bundle.min.js"></script>

    <script src="Velzon/assets/libs/simplebar/simplebar.min.js"></script>
    <script src="Velzon/assets/libs/node-waves/waves.min.js"></script>
    <script src="Velzon/assets/libs/feather-icons/feather.min.js"></script>
    <script src="Velzon/assets/js/pages/plugins/lord-icon-2.1.0.js"></script>
    <script src="Velzon/assets/js/plugins.js"></script>

    <!-- apexcharts -->
    <script src="Velzon/assets/libs/apexcharts/apexcharts.min.js"></script>

    <!-- Dashboard init -->
    <script src="Velzon/assets/js/pages/dashboard-crm.init.js"></script>

    <!-- App js -->
    <script src="Velzon/assets/js/app.js"></script>

</asp:Content>
