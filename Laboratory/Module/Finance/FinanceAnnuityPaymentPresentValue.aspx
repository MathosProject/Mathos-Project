<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinanceAnnuityPaymentPresentValue.aspx.cs" Inherits="Laboratory.Module.Finance.FinanceAnnuityPaymentPresentValue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <div class="pageTitle">
    Annuity Payment (Present Value)
  </div>

  <p>
    This application allows you to calculate the periodic payment on an annuity. An annuity is a series of periodic payments that are received at a future date. 
    <a href="http://mathosproject.com/wiki/mathos-core-library/finance/annuity-payment-present-value/">Read the wiki here.</a>
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
    <asp:Button ID="CalculateButton" runat="server" Text="Get Annuity Payment (Present Value)" 
                CssClass="button" OnClick="CalculateButton_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="#33CC33"></asp:Label>
    <asp:Label ID="ResultLabel" runat="server"></asp:Label>
  </p>

</asp:Content>