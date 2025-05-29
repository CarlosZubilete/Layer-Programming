<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="View.WebApp_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Layer Programming</title>
</head>
<body>
  <h1>Hi! Welcome to my Web!</h1>
  <form id="form1" runat="server">
    <%-- LOOKUP CATEGORY --%>
    <div class="lookupCategorias">
      <span class="lookupCategorias__texto">Nombre de Categoria</span>
      <asp:TextBox ID="txtCategorias" runat="server" CssClass="lookupCategorias__input"></asp:TextBox>
      <asp:Button ID="btnCategorias" runat="server" Text="Agregar" CssClass="lookupCategorias__btn" OnClick="btnCategorias_Click" />
      <%-- VALIDADORES --%>
      <%--<asp:RegularExpressionValidator ID="regexOnlyCharacter" runat="server" ControlToValidate="txtSucursales" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>--%>
      <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
    <%-- GRID-VIEW --%>
    <div>
      <asp:GridView ID="gridCategorias" runat="server"></asp:GridView>
    </div>
  </form>
</body>
</html>
