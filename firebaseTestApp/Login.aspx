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
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Find a Rec" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Delete" />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Delete All Recs" />
        <p>
            <asp:TextBox ID="tf_result" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Find All Recs" />
        </p>
        <asp:ListBox ID="lb_records" runat="server" Width="186px"></asp:ListBox>
        <p>
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Search" />
        </p>
    </form>
</body>
</html>
