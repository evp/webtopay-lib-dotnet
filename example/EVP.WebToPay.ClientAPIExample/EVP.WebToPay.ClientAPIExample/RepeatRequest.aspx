<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeatRequest.aspx.cs" Inherits="EVP.WebToPay.ClientAPIExample.RepeatRequestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="ButtonRepeatMacroPayment" runat="server" Text="Repeat Macro Payment"
            OnClick="ButtonRepeatMacroPayment_Click" />
    </div>
    
    <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red" Text="An error occurred! Please try again later!" 
        Visible="False"></asp:Label>
    
    </form>
</body>
</html>
