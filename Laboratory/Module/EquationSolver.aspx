<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EquationSolver.aspx.cs" Inherits="Laboratory.Module.EquationSolver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
    .style1 { height: 21px; }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  <div class="pageTitle">
    Equation Solver
  </div>

  <p>
    For the moment, you can choose between the quadratic equation solver, and system 
    of two equation solver. More will come in future! :)
  </p>

  <h3>
    System Of Two Equations Solver
  </h3>

  <p>
    <img alt="" src="http://mathosproject.com/wp-content/uploads/2012/10/SystemOfTwoEquations.png" />
  </p>
        
  <table class="moduleForm">
    <tr>
      <th>Ax</th>
      <th>By</th>
      <th>E</th>
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
      <th>Cx</th>
      <th>Dy</th>
      <th>F</th>
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
    <asp:Button ID="SolveSystemOfTwoEquation" runat="server" CssClass="button" 
                onclick="SolveSystemOfTwoEquation_Click" Text="Solve" EnableViewState="False" />
    <br />
    <br />
    <asp:Label ID="EquationErrorLabel" runat="server" CssClass="error" EnableViewState="False"></asp:Label>
    <asp:Label ID="EquationResultLabel" runat="server" CssClass="result" EnableViewState="False"></asp:Label>
    <br />
    <asp:Label ID="EquationElapsedTimeLabel" runat="server" CssClass="elapsedTime"></asp:Label>
  </p>

  <hr />
  
  <h3>
    Quadratic Equation Solver
  </h3>

  <p>
    <img alt="" src="http://mathosproject.com/wp-content/uploads/2012/10/QuadraticEquation.png" />
  </p>

  <table class="moduleForm">
    <tr>
      <td>Ax²</td>
      <td>Bx</td>
      <td>C</td>
    </tr>
    <tr>
      <td>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
      </td>
      <td>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
      </td>
      <td>
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
      </td>
    </tr>
  </table>

  <p>
    <asp:Button ID="SolveQuadraticEquation" runat="server" CssClass="button"
                onclick="SolveQuadraticEquation_Click" Text="Solve" EnableViewState="False" />
    <br />
    <br />
    <asp:Label ID="QuadraticEquationErrorLabel" runat="server" CssClass="error" EnableViewState="False"></asp:Label>
    <asp:Label ID="QuadraticEquationResultLabel" runat="server" CssClass="result" EnableViewState="False"></asp:Label>
    <br />
    <asp:Label ID="QuadraticEquationElapsedTimeLabel" runat="server" CssClass="elapsedTime"></asp:Label>
  </p>
    
</asp:Content>