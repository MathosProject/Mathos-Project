<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinanceAnnuityPaymentFutureValue.aspx.cs" Inherits="Laboratory.Module.Finance.FinanceAnnuityPaymentFutureValue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <div class="pageTitle">
    Annuity Payment (Future Value)
  </div>

  <p>
    This application allows you to calculate the cash flows of an annuity when future value is known. An annuity is denoted as a series of periodic payments.
    <a href="http://mathosproject.com/wiki/mathos-core-library/finance/annuity-payment-future-value/">Read the wiki here.</a>
  </p>

  <table class="moduleForm">
    <tr>
      <td>
        Future value
      </td>
      <td>
        <asp:TextBox ID="FutureValueText" runat="server"></asp:TextBox>
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
    <asp:Button ID="CalculateButton" runat="server" CssClass="button"
                Text="Get Annuity Payment (Future Value)" OnClick="CalculateButton_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <asp:Label ID="ResultLabel" runat="server" CssClass="result"></asp:Label>
  </p>

</asp:Content>