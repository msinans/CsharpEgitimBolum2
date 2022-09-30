<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationEgitimi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Burası web form ön yüzü 
    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Burası web form ön yüzü. HTML: web sitelerinin ortak dili html'dir denebilir.
        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Onaylıyorum" />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Elektronik</asp:ListItem>
            <asp:ListItem>Bilgisayar</asp:ListItem>
            <asp:ListItem>Play Station</asp:ListItem>
            <asp:ListItem>Kitap</asp:ListItem>
            <asp:ListItem>Monitör</asp:ListItem>
        </asp:DropDownList>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" Value="Gizli Değer" />
        <asp:HyperLink ID="HyperLink1" runat="server"> Site Bağlantısı</asp:HyperLink>
        <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl="~/Images/Zühal nut.jpg" />
        <asp:Label ID="Label1" runat="server" Text="Label ile ekranda yazı gözteriyoruz"></asp:Label></form>
    <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
    <asp:RadioButton ID="RadioButton1" runat="server" Text="Onaylıyorum" OnCheckedChanged="RadioButton1_CheckedChanged" /></body>

<asp:TextBox runat="server"></asp:TextBox>
</html>
