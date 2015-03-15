<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NumberChecker.aspx.cs" Inherits="Laboratory.Module.NumberChecker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  <div class="pageTitle">
    Number checker
  </div>
  
  <table class="moduleForm">
    <tr>
      <td>
        <asp:DropDownList ID="DropDownList1" runat="server">
          <asp:ListItem>Is Positive</asp:ListItem>
          <asp:ListItem>Is Negative</asp:ListItem>
          <asp:ListItem>Is Even</asp:ListItem>
          <asp:ListItem>Is Odd</asp:ListItem>
          <asp:ListItem>Is Prime</asp:ListItem>
        </asp:DropDownList>
      </td>
      <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      </td>
    </tr>
  </table>
  
  <p>
    <asp:Button ID="CalculateButton" runat="server" CssClass="button"
                Text="Check" OnClick="CalculateButton_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <asp:Label ID="ResultLabel" runat="server" CssClass="result"></asp:Label>
    <br />
    <asp:Label ID="ElapsedTimeLabel" runat="server" CssClass="elapsedTime"></asp:Label>
  </p>
  
</asp:Content>