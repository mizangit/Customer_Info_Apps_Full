﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoForm.aspx.cs" Inherits="CustomerInformationWEB.UI.CustomerInfoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            text-align: right;
            height: 26px;
        }
        .auto-style4 {
            text-align: left;
            height: 26px;
        }
        .auto-style5 {
            text-align: left;
            width: 298px;
        }
        .auto-style6 {
            text-align: left;
            height: 26px;
            width: 298px;
        }
        .auto-style7 {
            width: 298px;
        }
        </style>
</head>
<body>

    <form id="form1" runat="server">
        
    <div>
            <table align="center">
                <tr>
                    <td class="auto-style1">Name</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="nameTextBox" runat="server" Width="100%"></asp:TextBox></td>
                    <td class="auto-style2">
                        
                        &nbsp;
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="nameTextBox" ForeColor="Red" ErrorMessage="Please enter Name"></asp:RequiredFieldValidator>
                        
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">Customer ID</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="customreIdTextBox" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="customreIdTextBox" ForeColor="Red" ErrorMessage="Please enter your employee ID "></asp:RequiredFieldValidator>
                    </td>
                    </tr>
                <tr>
                    <td class="auto-style1">Phone</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="phoneTextBox" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="auto-style2"></td>

                </tr>
                <tr>
                    <td class="auto-style1">Email</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="emailTextBox" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="auto-style2"></td>
                      </tr>  
                <tr>
                    <td class="auto-style3">Gender</td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="genderDropDownList" runat="server" Width="100%">
                            <asp:ListItem>Select Gender</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            
                           
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4">
                        &nbsp;
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="genderDropDownList" ErrorMessage="Select Gender" BorderColor="#009900" ForeColor="Red" Operator="NotEqual" ValueToCompare="Select Gender"></asp:CompareValidator>
                    </td>
                      </tr>
                <tr>
                    <td class="auto-style1">Address</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="addressTextBox" runat="server" Width="100%"></asp:TextBox>
                    </td>
                    <td class="auto-style2"></td>
                      </tr>
                <tr>
                    <td class="auto-style1">Date of Birth</td>
                    <td class="auto-style5">
                        <br />
                        <asp:TextBox ID="dobTextBox" runat="server" Width="53%" OnTextChanged="dobTextBox_TextChanged"></asp:TextBox>[Ex-mm-dd-yyyy]<asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/Image/calendar-128.png" OnClick="ImageButton1_Click" Width="20px" />
                        <asp:Calendar ID="CalendarDOB" runat="server" Height="16px" OnSelectionChanged="CalendarDOB_SelectionChanged" Width="93px"></asp:Calendar>
                    </td>
                    <td class="auto-style2">
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dobTextBox" ForeColor="Red"  ErrorMessage="Please enter Date of Birth" style="text-align: left"></asp:RequiredFieldValidator>
                        <br />
                    </td>

                </tr>
                <tr>
                    <td class="auto-style1">Photo</td>
                    <td class="auto-style5">
                        <asp:FileUpload ID="photoFileUpload" runat="server" Width="228px" />
                        <br />
                    </td>
                    <td class="auto-style2">
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="photoFileUpload" ForeColor="Red"  ErrorMessage="Please select your photo"></asp:RequiredFieldValidator>
                    </td>

                </tr>

                <tr>
                    <td></td>
                    <td style="text-align: right" class="auto-style7" >
                        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" Height="26px" style="text-align: right" />
                        &nbsp;&nbsp;
                    </td>
                    <td class="auto-style2"></td>

                </tr>
                </table>



            <br />


            <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" /><br />
        <asp:Label ID="idLabel" runat="server" Text=""></asp:Label>
        <asp:Label ID="nameLabel" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="CustomerIdLabel" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="DateOfBirthLabel" runat="server" Text=""></asp:Label>



    </div>
    </form>
   
</body>
</html>
