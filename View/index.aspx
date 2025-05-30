<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="View.WebApp_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Layer Programming</title>
</head>
<body>
  <h1>Hi! Welcome to my Web!</h1>
  <form id="form1" runat="server">
    <%-- ADD CATEGORY --%>
    <h3>Add a Category</h3>
    <div class="addCategorias">
      <span class="addCategorias__texto">Name Category</span>
      <asp:TextBox ID="txtAddCategorias" runat="server" CssClass="addCategorias__input"></asp:TextBox>
      <asp:Button ID="btnAddCategorias" runat="server" Text="Agregar" CssClass="addCategorias__btn" OnClick="BtnAddCategorias_Click" />
      <%-- VALIDADORES --%>
      <%--<asp:RegularExpressionValidator ID="regexOnlyCharacter" runat="server" ControlToValidate="txtSucursales" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>--%>
      <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
    <%-- GRID-VIEW --%>
    <div>
      <asp:GridView ID="gridCategorias" runat="server"></asp:GridView>
    </div>
    <br />
    <%--LOOKUP CATEGORY --%>
    <h3>Lookup Category by Id</h3>
    <div class="lookupCategoty">
      <span class="lookupCategoty__text">Lookup Category</span>
      <asp:TextBox ID="TxtLookupCategory" runat="server" CssClass="lookupCategoty__input"></asp:TextBox>
      <asp:Button ID="BtnLookupCategory" runat="server" Text="Buscar" CssClass="lookupCategoty__btn" OnClick="BtnLookupCategory_Click"/>
      <%-- VALIDADORES --%>
      <%--<asp:RegularExpressionValidator ID="regexOnlyCharacter" runat="server" ControlToValidate="txtSucursales" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>--%>
      <asp:Label ID="lblLookupCategoryMsg" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <%-- GRID-VIEW --%>
    <div>
      <asp:Label ID="lblLookupCategoryId" runat="server" Text=""></asp:Label>
      <br />
      <asp:Label ID="lblLookupCategoryName" runat="server" Text=""></asp:Label>
      <br />
      <asp:Label ID="lblLookupCategoryDescription" runat="server" Text=""></asp:Label>
    </div>

    <%-- DELETE CATEGORY --%>
    <h3>Delete category by ID</h3>

  </form>
</body>
</html>
