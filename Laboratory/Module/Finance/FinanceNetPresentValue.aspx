<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FinanceNetPresentValue.aspx.cs" Inherits="Laboratory.Module.Finance.FinanceNetPresentValue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
    .auto-style1 { height: 29px; }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <div class="pageTitle">
    Net Present Value
  </div>

  <p>
    This application allows you to calculate the sum of the present values (PVs) of the individual cash flows of the same entity. 
    <a href="http://mathosproject.com/wiki/mathos-core-library/finance/net-present-value/">Read the wiki here.</a>
  </p>

  <table class="moduleForm">
    <tr>
      <td>
        Initial invenstment
      </td>
      <td>
        <asp:TextBox ID="InitialInvestmentValueText" runat="server" Width="150px"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td class="auto-style1">
        Cash flow
      </td>
      <td class="auto-style1">
        <asp:TextBox ID="CashFlowValueText" runat="server" Width="250px"></asp:TextBox>
        &nbsp;
        Insert values separated by space (ex 200 100 300)
      </td>
    </tr>
    <tr>
      <td>
        Rate of return (%)
      </td>
      <td>
        <asp:TextBox ID="RateOfReturnText" runat="server" Width="150px"></asp:TextBox>
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
    <asp:Button ID="CalculateButton" runat="server" Text="Get Net Present Value" 
                CssClass="button" OnClick="CalculateButton_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <asp:Label ID="ResultLabel" runat="server" CssClass="result"></asp:Label>
  </p>

</asp:Content>