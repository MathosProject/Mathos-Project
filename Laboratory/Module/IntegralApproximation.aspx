<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IntegralApproximation.aspx.cs" Inherits="Laboratory.Module.IntegralApproximation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <div class="pageTitle">
    Integral Approximation
  </div>

  <p>
    This application allows you to view how integrals can be approximated using different techniques.
    <a href="http://mathosproject.com/wiki/mathos-core-library/calculus/integration/">Read the wiki here.</a>
  </p>

  <table class="moduleForm">
    <tr>
      <td>
        Please enter the function, lower and upper bounds. 
      </td>
      <td>
        No. of intervals.
      </td>
    </tr>
    <tr>
      <td>
        <table>
          <tr>
            <td>
              <asp:Label ID="Label1" runat="server" Text="∫" Font-Size="35px"></asp:Label>
            </td>
            <td>
              <table>
                <tr>
                  <td>
                    <asp:TextBox ID="UpperBoundText" runat="server" Width="30px"></asp:TextBox>
                  </td>
                </tr>
                <tr>
                  <td>
                    <asp:TextBox ID="LowerBoundText" runat="server" Width="30px"></asp:TextBox>
                  </td>
                </tr>
              </table>
            </td>
            <td>
              <asp:TextBox ID="ExpressionText" runat="server" Width="300px"></asp:TextBox>
              &nbsp;
            </td>
            <td style="padding-bottom: 10px;">
              <asp:Label ID="Label2" runat="server" Text="dx" Font-Size="20px" Font-Italic="True"></asp:Label>
            </td>
          </tr>
        </table>
      </td>
      <td>
        <table>
          <tr>
            <td>
              <asp:TextBox ID="NumberOfIntervalsText" runat="server" Width="100px">10000</asp:TextBox>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>

  <p>
    <asp:Button ID="CalculateButton" runat="server" Text="Integrate" 
                CssClass="button" OnClick="CalculateButton_Click" />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="#33CC33"></asp:Label>
  </p>

  <table class="resultTable">
    <tr>
      <th class="label">
        Method
      </th>
      <th class="result">
        Result
      </th>
      <th class="elapsedTime">
        Time [ms]  
      </th>
    </tr>
    <tr>
      <td class="label">
        <asp:Label ID="Label3" runat="server" Text="Rectangle method"></asp:Label>
      </td>
      <td class="result">
        <asp:Label ID="RectangleMethodResultLabel" runat="server" Text="0"></asp:Label>
      </td>
      <td class="elapsedTime">
        <asp:Label ID="RectangleMethodTimeLabel" runat="server" Text="0"></asp:Label>
      </td>
    </tr>
    <tr>
      <td class="label">
        <asp:Label ID="Label4" runat="server" Text="Trapezoidal rule"></asp:Label>
      </td>
      <td class="result">
        <asp:Label ID="TrapezoidalRuleResultLabel" runat="server" Text="0"></asp:Label>
      </td>
      <td class="elapsedTime">
        <asp:Label ID="TrapezoidalRuleTimeLabel" runat="server" Text="0"></asp:Label>
      </td>
    </tr>
    <tr>
      <td class="label">
        <asp:Label ID="Label5" runat="server" Text="Simpsons rule"></asp:Label>
      </td>
      <td class="result">
        <asp:Label ID="SimpsonsRuleResultLabel" runat="server" Text="0"></asp:Label>
      </td>
      <td class="elapsedTime">
        <asp:Label ID="SimpsonsRuleTimeLabel" runat="server" Text="0"></asp:Label>
      </td>
    </tr>
  </table>
</asp:Content>