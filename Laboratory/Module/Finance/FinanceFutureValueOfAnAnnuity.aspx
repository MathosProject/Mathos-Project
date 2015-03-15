<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinanceFutureValueOfAnAnnuity.aspx.cs" Inherits="Laboratory.Module.Finance.FinanceFutureValueOfAnAnnuity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <div class="pageTitle">
    Future Value Of An Annuity
  </div>

  <p>
    This application allows you to calculate the value of a group of payments at a specified date in the future.
    <a href="http://mathosproject.com/wiki/mathos-core-library/finance/future-value-of-an-annuity/">Read the wiki here.</a>
  </p>

  <table class="moduleForm">
    <tr>
      <td>
        Periodic payment
      </td>
      <td>
        <asp:TextBox ID="PeriodicPaymentText" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td>
        Rate per period (%)
      </td>
      <td>
        <asp:TextBox ID="RatePerPeriodText" runat="server"></asp:TextBox>
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
    <asp:Button ID="CalculateButton" runat="server" Text="Get Future Value Of An Annuity" 
                CssClass="button" OnClick="CalculateButton_Click" />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <br />
    <br />
    <asp:Label ID="ResultLabel" runat="server" CssClass="result"></asp:Label>
  </p>

</asp:Content>