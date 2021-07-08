<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="K173795_Q4.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pakistan Stock Exchange</title>
    <style>

    </style>
</head>

<body style="margin:20px">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
           <div style="margin-bottom:20px">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="550px" AutoPostBack="True" OnSelectedIndexChanged="onSelect">
                </asp:DropDownList>
               
                <span style="margin:0 20px"></span>
                <asp:Button ID="Button1" runat="server" Height="30px" OnClick="Button1_Click" Text="Refresh" Width="130px" />
                </div>
                <asp:GridView ID="GridView2" runat="server"  Width="458px">
                </asp:GridView>
           </div>
                </ContentTemplate>
        </asp:UpdatePanel>
        
    </form>
</body>
</html>
