<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PolynomSeq.aspx.cs" Inherits="Laboratory.Module.DataAnalysis.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">Polynomial Sequences
    </div>
    <p>
This application allows you to find a polynomial that generated a specific sequence and the closed form of the sum of that polynomial.</p>

    <p><b>Find the nth term or the expression for the sum</b><br />
    Enter the sequence below. Separate each term by a comma. For example, enter 1,2,3,4,5.<br /></p>

    <asp:TextBox ID="TextBox1" runat="server" Width="446px"></asp:TextBox><br />
    <br />
    <br />
    <b style="color:blue;"><asp:Label ID="Label1" runat="server" Text="Result is shown here"></asp:Label></b>
    <br />
    <br />
    <asp:Button ID="FindNthTerm" runat="server" Text="Get the Nth term expression!" OnClick="FindNthTerm_Click" CssClass="button"  /><br />
    <asp:Button ID="Button1" runat="server" Text="Get expression for sum!" OnClick="Button1_Click" CssClass="button"  />

    
    <br />
    <br />

    <p><i>You can access FiniteCalculus class by including Mathos.Calculus.</i></p>
    
   


    
</asp:Content>
