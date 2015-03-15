<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinanceFutureValue.aspx.cs" Inherits="Laboratory.Module.Finance.FinanceFutureValue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <div class="pageTitle">
    Future Value
  </div>

  <p>
    This application allows you to calculate the value of an asset at a specific date. 
    <a href="http://mathosproject.com/wiki/mathos-core-library/finance/future-value/">Read the wiki here.</a>
  </p>

  <table class="moduleForm">
    <tr>
      <td>
        Present value
      </td>
      <td>
        <asp:TextBox ID="PresentValueText" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td>
        Rate of return (%)
      </td>
      <td>
        <asp:TextBox ID="RateOfReturnText" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td>
        Number of periods
      </td>
      <td>
        <asp:TextBox ID="NumberOfPeriodsText" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td>
        Round to 2 decimal places
      </td>
      <td>
        <asp:CheckBox ID="RoundCheck" runat="server" Checked="True" />
      </td>
    </tr>
  </table>
  
  <p>
    <asp:Button ID="CalculateButton" runat="server" Text="Get Future Value" 
                CssClass="button" OnClick="CalculateButton_Click" />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <br />
    <br />
    <asp:Label ID="ResultLabel" runat="server" CssClass="result"></asp:Label>
  </p>

</asp:Content>