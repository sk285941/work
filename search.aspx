<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
            DataFile="~/App_Data/Database3.mdb" 
            
            SelectCommand=""></asp:AccessDataSource>
        
        
        <asp:GridView ID="GridView1" runat="server" DataSourceID="AccessDataSource1">
        </asp:GridView>
        
        
    </div>
    </form>
</body>
</html>
