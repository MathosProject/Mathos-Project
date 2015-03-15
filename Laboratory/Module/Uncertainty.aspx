<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Uncertainty.aspx.cs" Inherits="Laboratory.Module.Uncertainty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
  <div class="pageTitle">
    Uncertainty Calculator
  </div>

  <p>
    This application allows you to work with uncertainty calcuations. <a href="http://support.mathosproject.com/tutorials/uncertainty-calculator/">Read the tutorial here.</a>
  </p>
    
  <p>
    <span class="index">1</span>. Copy and paste the desired table in the text area below (for example from Microsoft Excel). Do not include the table headings!
  
    <br />
    <br />

    <textarea id="tableInput" name="S1" rows="5" cols="20" runat="server"></textarea>
  
    <br />
    <br />

    <span class="index">2</span>. Enter the operation you want to perform on the values in the table (for example &quot;x^2&quot;).
 
    <br />
    <br />

    <asp:TextBox style="font-family: Consolas; font-size: 20px;" ID="functionInput" runat="server"></asp:TextBox>

    <br />
    <br />

    <span class="index">3</span>. When you are ready, press the button!
  </p>
  
  <p>
    <asp:Button ID="CalculateButton" runat="server" CssClass="button" 
                Text="Calculate" OnClick="CalculateButton_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorLabel" runat="server" CssClass="error"></asp:Label>
    <textarea id="TableOutput" name="S2" rows="5" cols="20" runat="server"></textarea>
    <br />
    <asp:Label ID="ElapsedTimeLabel" runat="server" CssClass="elapsedTime"></asp:Label>
  </p>

</asp:Content>