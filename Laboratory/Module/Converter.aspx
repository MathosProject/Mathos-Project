<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Converter.aspx.cs" Inherits="Laboratory.Module.Converter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
  <div class="pageTitle">
    Converter [under dev]
  </div>

  <p>
    <asp:DropDownList ID="DropDownList1" runat="server" 
                      onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                      AutoPostBack="True">
      <asp:ListItem>Length</asp:ListItem>
      <asp:ListItem>Speed</asp:ListItem>
      <asp:ListItem>Mass</asp:ListItem>
      <asp:ListItem>Area</asp:ListItem>
      <asp:ListItem>Volume</asp:ListItem>
      <asp:ListItem>Base</asp:ListItem>
      <asp:ListItem>Angle</asp:ListItem>
      <asp:ListItem>Power</asp:ListItem>
      <asp:ListItem>Pressure</asp:ListItem>
      <asp:ListItem>Temperature</asp:ListItem>
    </asp:DropDownList>

    Please provide what you would like to convert (length, speed, mass, area,  volume, base, angle, power, pressure, temperature)</p>
  <hr />
  <asp:Panel ID="Panel1" runat="server">
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="CalculateButton_Click">
      <asp:ListItem>Please select a unit</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="CalculateButton_Click">
      <asp:ListItem>Please select a unit</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />

    <p>
      <asp:Button ID="CalculateButton" runat="server" CssClass="button"
                  Text="Convert" OnClick="CalculateButton_Click" />
      <br />
      <br />
      <asp:Label ID="ErrorLabel" runat="server" CssClass="error" EnableViewState="False"></asp:Label>
      <br />
      <asp:Label ID="ElapsedTimeLabel" runat="server" CssClass="elapsedTime" EnableViewState="False"></asp:Label>
    </p>
  </asp:Panel>
</asp:Content>