<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="WebApp.Page" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: 0 auto; max-width:1000px;">
    <form id="form1" runat="server" style="margin: 0 auto; max-width:800px; display:block;">
        <table>
            <tr>
                <td>
                    <select id="selectObject" runat="server">
                        <option id="contact" value="Contact">Contact</option>
                        <option id="product" value="Product">Product</option>
                    </select>
                    <select id="selectFunction" runat="server">
                        <option id="name" value="name">Names</option>
                        <option id="SQL" value="SQL">SQL</option>
                        <option id="SQLnames" value="SQLnames">SQLnames</option>
                        <option id="PrintSQLnamesWithType" value="PrintSQLnamesWithType">PrintSQLnamesWithType</option>
                        <option id="PrintSQLProc" value="PrintSQLProc">PrintSQLProc</option>
                        <option id="PrintASPColumn" value="PrintASPColumn">PrintASPColumn</option>
                        <option id="PrintSQLUpdate" value="PrintSQLUpdate">PrintSQLUpdate</option>
                        <option id="PrintASPEdit" value="PrintASPEdit">PrintASPEdit</option>
                        <option id="PrintEditCsharp" value="PrintEditCsharp">PrintEditCsharp</option>
                        <option id="PrintCreate" value="PrintCreate">PrintCreate</option>
                        <option id="PrintSQLReader" value="PrintSQLReader">PrintSQLReader</option>
                    </select>
                    <td style="text-align: center;">
                        <input type="submit" id="submit_btn" />
                    </td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Con_Update_Button" OnClick="Con_UpdateData_Click" runat="server" Text="Update Contact" />
                </td>
                <td>
                    <asp:Button ID="Prod_Update_Button" OnClick="Prod_UpdateData_Click" runat="server" Text="Update Product" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:Button ID="All_Update_Button" OnClick="All_Update_Click" runat="server" Text="Sync" />
                </td>
            </tr>            
            <tr>
                <td colspan="3" style="text-align: center;">
                    <asp:Button ID="All_Button" OnClick="All_Click" runat="server" Text="Print Result" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center;">
                    <asp:Button ID="Con_Push_Btn" OnClick="Push_Contact_Click" runat="server" Text="Push Contact" />
                </td>                
<%--                <td style="text-align: center;">
                    <asp:Button ID="Button1" OnClick="Push_Contact_Click" runat="server" Text="Push Contact" />
                </td>--%>
            </tr>
        </table>
    </form>


    <span id="apiMessage" runat="server"></span>
</body>
</html>
