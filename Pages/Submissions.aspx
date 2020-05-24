<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Submissions.aspx.cs" Inherits="Pages_Submissions"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Submissions</title>
    <link rel="icon" type="image/png" href="../Images/favicon.ico"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.4.7/webfont.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/JQuery/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/JQUI/jquery-ui.min.js"></script>
    <script src="../Scripts/BootStrap/js/bootstrap.min.js"></script>
    <link href="../Styles/GlobalCSS.css" rel="stylesheet" />
    <link href="../Scripts/BootStrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../Scripts/JQUI/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Scripts/BootStrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="../Scripts/BootStrap/css/demo.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Varela:400%7CMuli:200,200italic,300,300italic,regular,italic,600,600italic,700,700italic,800,800italic,900,900italic%7CLora:regular,italic,700,700italic" />
    <style>
        .divMaster {
            background-color:white;width:1000px;margin:auto;margin-top:2%;height:400px;max-height:400px;overflow-x:hidden;overflow-y:auto;
        }
        .tblSubmissions {
            border-collapse:collapse;
            border:none;
            color:darkslategrey;
            padding:10px;
            width:100%;
        }
        .tblSubmissions th {
                padding:10px;
                border-bottom:2px solid lightgrey;
                text-align: center; 
                letter-spacing: 2px;
                 font-size: 14px;
            }
        .tblSubmissions td {
                padding:10px;
                border-bottom:2px solid lightgrey;
                text-align: center; 
                letter-spacing: 2px;
                 font-size: 14px;
                 color:grey;
            }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //debugger;
            var sbdata = '';
            $.ajax({
                url: '<%=ResolveUrl("../Pages/Submissions.aspx/GetSubmissionData") %>',
                                data: "",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    //alert(data.d); return;
                                    if (data.d != null) {
                                        if (data.d.length > 0) {
                                            $.each(data.d, function (key, value) {
                                                sbdata += '<tr><td>' + value.Id + '</td>'
                                                sbdata += '<td>' + value.Name + '</td>'
                                                sbdata += '<td>' + value.Email + '</td>'
                                                sbdata += '<td>' + value.About + '</td>'
                                                sbdata += '<td style="width: 400px;word-wrap: break-word;">' + value.Description + '</td>'
                                                sbdata += '<td>' + value.Date + '</td></tr>'
                                            });
                                            //alert(sbdata);
                                            $('.tblSubmissions').find('tbody').append(sbdata);
                                        }

                                    }
                                    else {
                                        alert("some error occured");
                                    }
                                },
                                error: function (response) {
                                    alert(response.d);
                                },
                                failure: function (response) {
                                    alert(response.d);
                                    alert('Get Request failed.');
                                }
                            });



        });
    </script>
</head>
<body>
    <form id="form1" runat="server">

    <div data-collapse="none" data-animation="over-right" data-duration="400" data-doc-height="1" id="nav-bar-top" class="navigation-bar dark w-nav">
            <div class="navigation-bar-container w-container">
                <a class="brand-link left-spacing w-nav-brand w--current">
                    <img src="../Images/lgo.jpg" class="brand-image" alt="Brand-Pic Coming soon" />
                </a>
            </div>
            <div style="float: right;">
                <nav class="navigation-menu w-nav-menu" role="navigation">
                    <a href="../Pages/Home.aspx" class="navigation-link w-nav-link" style="max-height: 728px; text-decoration: none; padding: 10px;">Home</a>
                    <%--                <a href="About.aspx" class="navigation-link w-nav-link" style="max-height: 728px; text-decoration: none; padding: 10px;">About</a>--%>
                    <a href="../Pages/HireMe.aspx" class="navigation-link w-nav-link" style="max-height: 728px; text-decoration: none; padding: 10px;">Hire Me</a>
                </nav>
            </div>
            <div class="w-nav-overlay"></div>
        </div>

    <div class="divMaster">
    <table class="tblSubmissions">
        <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Email</th>
            <th>About</th>
            <th>Description</th>
             <th>Date</th>
        </tr>
    </table>
    </div>

    <div class="footer">
            <div class="footer-social-links up-to-down-animation">
                <a href="https://www.linkedin.com/in/chauhanshivendra/" class="w-inline-block" target="_blank">
                    <img class="social-icon" src="../Images/lin.svg" alt="LinkedIn" /></a>
                <a href="https://www.twitter.com/I_m_Shiven" class="w-inline-block" target="_blank">
                    <img class="social-icon" src="../Images/twi.svg" alt="twitter" /></a>
                <a href="https://www.instagram.com/shiven_chauhan/" class="w-inline-block" target="_blank">
                    <img class="social-icon" src="../Images/instagram-logo.svg" alt="Instagram" /></a>
                <a href="https://www.medium.com/@ShivendraChauhan" class="w-inline-block" target="_blank">
                    <img class="social-icon" src="../Images/medium.svg" alt="Medium" /></a>
                <a href="https://www.github.com/ImShiven" class="w-inline-block" target="_blank">
                    <img class="social-icon" src="../Images/git.svg" alt="GitHub" /></a>
            </div>
            <div class="footer-copyright up-to-down-animation">Copyright © 2018 Shivendra Chauhan</div>
        </div>
    </form>
</body>
</html>
