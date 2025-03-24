<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="chessProject.homePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Chess</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome to Chess!</h1>
        <div class="instructions">
            To start the game:
        </div>
        <asp:LinkButton ID="LinkButton1" PostBackUrl="~/gamePage.aspx" runat="server" CssClass="start-button">
            Press Here!
        </asp:LinkButton>
    </form>
</body>
</html>
