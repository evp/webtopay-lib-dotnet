<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EVP.WebToPay.ClientAPIExample.DefaultPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="ButtonCreateMacroPayment" runat="server" Text="Create Macro Payment"
            OnClick="ButtonCreateMacroPayment_Click" />
    </div>
    <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red" 
        Visible="False">An error occurred! Please try again later!</asp:Label>
    </form>
</body>
</html>
