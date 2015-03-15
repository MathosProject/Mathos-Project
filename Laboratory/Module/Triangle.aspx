<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Triangle.aspx.cs" Inherits="Laboratory.Module.Triangle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  <div class="pageTitle">
    Triangle Solver
  </div>

  <p>
    Please provide any information about the triangle:
    <img alt="500px-Triangle_with_notations_2.svg" 
         src="http://mathosproject.com/wp-content/uploads/2012/10/500px-Triangle_with_notations_2.svg_.png" 
         style="float: right; height: 177px; width: 307px;" />
  </p>

  <table class="moduleForm">
    <tr>
      <th>a</th>
      <th>b</th>
      <th>c</th>
    </tr>
    <tr>
      <td>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      </td>
      <td>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
      </td>
      <td>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <th>A</th>
      <th>B</th>
      <th>C</th>
    </tr>
    <tr>
      <td>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
      <td>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
      </td>
      <td>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
      </td>
    </tr>
  </table>
  
  <p>
    <asp:Button ID="CalculateButton" runat="server" CssClass="button"
                Text="Check" OnClick="CalculateButton_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <br />
    <asp:Label ID="ElapsedTimeLabel" runat="server" CssClass="elapsedTime"></asp:Label>
  </p>

</asp:Content>