<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="firebaseTestApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="tf_firstname" runat="server"></asp:TextBox>
        <p>
            <asp:TextBox ID="tf_age" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
        <p>
            <asp:TextBox ID="tf_result" runat="server"></asp:TextBox>
        </p>
    </form>
</body>
</html>
