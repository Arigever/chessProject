<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gamePage.aspx.cs" Inherits="chessProject.gamePage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chess Game</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="chess-board">
            <asp:Repeater ID="ChessBoardRepeater" runat="server">
                <ItemTemplate>
                    <div class="square <%# (Container.ItemIndex / 8 + Container.ItemIndex % 8) % 2 == 0 ? "white" : "black" %>">
                        <img src='<%# "pictures/" + Container.DataItem %>' alt="" class="piece" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
