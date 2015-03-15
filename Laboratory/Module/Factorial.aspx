<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factorial.aspx.cs" Inherits="Laboratory.Module.Factorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  <div class="pageTitle">
    Factorial
  </div>

  <p>
    Factorial is the product of n terms, which usually is written as n!, which is the same as n! = 1 * 2 * ... * (n-1) * n.
  </p>

  <table class="moduleForm">
    <tr>
      <td>
        Number
      </td>
      <td>
        <asp:TextBox ID="NumberText" runat="server"></asp:TextBox>
      </td>
    </tr>
  </table>

  <p>
    <asp:Button ID="CalculateButton" runat="server" CssClass="button"
                Text="Get Factorial" OnClick="CalculateButton_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <asp:TextBox ID="ResultTextbox" runat="server" TextMode="multiline" ReadOnly="True" CssClass="result"></asp:TextBox>
    <br />
    <asp:Label ID="ElapsedTimeLabel" runat="server" CssClass="elapsedTime"></asp:Label>
  </p>

</asp:Content>