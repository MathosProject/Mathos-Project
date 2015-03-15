<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modules.aspx.cs" Inherits="Laboratory.Modules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <div class="pageTitle">
    Modules
  </div>

  <p>
    Please select the specific feature you want to try out!
  </p>

  <asp:Table ID="Table1" runat="server" CssClass="modules">

    <asp:TableRow runat="server" CssClass="groupRow">
      <asp:TableCell runat="server" Wrap="False" ColumnSpan="2">Data Analysis</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="groupSeparatorRow" />
          <asp:TableRow runat="server" CssClass="dataRow ">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/DataAnalysis/LinearRegression.aspx">Linear regression</a></asp:TableCell>
      <asp:TableCell runat="server">Finds the linear relationship between two sets of data.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow ">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/DataAnalysis/PolynomSeq.aspx">Polynomial sequence analysis</a></asp:TableCell>
      <asp:TableCell runat="server">Finds the expression for the nth term and the expression closed form of a sum.</asp:TableCell>
    </asp:TableRow>



    <asp:TableRow runat="server" CssClass="groupRow">
      <asp:TableCell runat="server" Wrap="False" ColumnSpan="2">Group 1</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="groupSeparatorRow" />
    <asp:TableRow runat="server" CssClass="dataRow ">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Converter.aspx">Converter</a></asp:TableCell>
      <asp:TableCell runat="server">Includes the unit converter(length, speed, mass, 
        area, volyme) and numerical system converter (base2 - base 64)</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow alternateDataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/EquationSolver.aspx">Equation Solver</a></asp:TableCell>
      <asp:TableCell runat="server">This will solve all kinds of equations</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Factorial.aspx">Factorial</a></asp:TableCell>
      <asp:TableCell runat="server">Can calculate &#39;really&#39; big factorials</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow alternateDataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/IntegralApproximation.aspx">Integral Approximation</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to view how integrals can be approximated using different techniques.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/NumberChecker.aspx">Number Checker</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to check if a number follows a certain 
        rule (is positive, is prime, etc)</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow alternateDataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Triangle.aspx">Triangle Solver</a></asp:TableCell>
      <asp:TableCell runat="server">Given some information about a triangle, this app will fill out the gaps</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Uncertainty.aspx">Uncertainty Calculator</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to work with uncertainty calcuations. </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow runat="server" CssClass="groupSeparatorRow" />
    <asp:TableRow runat="server" CssClass="groupRow">
      <asp:TableCell runat="server" Wrap="False"  ColumnSpan="2">Finance</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="groupSeparatorRow" />
    <asp:TableRow runat="server" CssClass="dataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Finance/FinanceAnnuityPaymentFutureValue.aspx">Annuity Payment (Future Value)</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to calculate the cash flows of an annuity when future value is known.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow alternateDataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Finance/FinanceAnnuityPaymentPresentValue.aspx">Annuity Payment (Present Value)</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to calculate the periodic payment on an annuity.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Finance/FinanceFutureValue.aspx">Future Value</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to calculate the value of an asset at a specific date.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow alternateDataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Finance/FinanceFutureValueOfAnAnnuity.aspx">Future Value Of An Annuity</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to calculate the value of a group of payments at a specified date in the future.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Finance/FinanceNetPresentValue.aspx">Net Present Value</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to calculate the sum of the present values of the individual cash flows of the same entity.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow alternateDataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Finance/FinancePresentValue.aspx">Present Value</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to calculate the future amount of money that has been discounted to reflect its current value, as if it existed today.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Finance/FinancePresentValueOfAnAnnuity.aspx">Present Value Of An Annuity</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to calculate the current value of a set of cash flows in the future, given a specified rate of return or discount rate.</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" CssClass="dataRow alternateDataRow">
      <asp:TableCell runat="server" Wrap="False"><a href="Module/Finance/FinanceRemainingBalanceOfAnnuity.aspx">Remaining Balance Of Annuity</a></asp:TableCell>
      <asp:TableCell runat="server">Allows you to calculate the remaining balance at a given time(time n), whether at a future date or at present.</asp:TableCell>
    </asp:TableRow>
  </asp:Table>
</asp:Content>