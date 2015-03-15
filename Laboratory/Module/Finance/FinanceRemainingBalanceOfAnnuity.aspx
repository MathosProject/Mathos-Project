<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinanceRemainingBalanceOfAnnuity.aspx.cs" Inherits="Laboratory.Module.Finance.FinanceRemainingBalanceOfAnnuity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <div class="pageTitle">
    Remaining Balance Of Annuity
  </div>

  <p>
    This application allows you to calculate the remaining balance at a given time(time n), whether at a future date or at present. 
    <a href="http://mathosproject.com/wiki/mathos-core-library/finance/remaining-balance-of-annuity/">Read the wiki here.</a>
  </p>

  <table class="moduleForm">
    <tr>
      <td>
        Original value
      </td>
      <td>
        <asp:TextBox ID="OriginalValueText" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td>
        Payment
      </td>
      <td>
        <asp:TextBox ID="PaymentText" runat="server"></asp:TextBox>
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
    <asp:Button ID="CalculateButton" runat="server" Text="Get Remaining Balance Of Annuity" 
                CssClass="button" OnClick="CalculateButton_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <asp:Label ID="ResultLabel" runat="server" CssClass="result"></asp:Label>
  </p>

</asp:Content>