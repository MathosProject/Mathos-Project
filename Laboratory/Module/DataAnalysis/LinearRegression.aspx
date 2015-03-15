<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinearRegression.aspx.cs" Inherits="Laboratory.Module.DataAnalysis.LinearRegression" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="pageTitle">Linear Regression
    </div>
    <p>
This application allows you to find a linear relationship between <i>y</i> values and <i>x</i> values.</p>

    <p><b>Enter the <i>x</i> values</b><br />
    Enter the sequence below. Separate each term by a comma. For example, enter 1,2,3,4,5.<br /></p>
    <asp:TextBox ID="TextBox1" runat="server" Width="373px"></asp:TextBox>


    <p><b>Enter the <i>y</i> values</b><br />
    Enter the sequence below. Separate each term by a comma. For example, enter 1,2,3,4,5.<br /></p>
    <asp:TextBox ID="TextBox2" runat="server" Width="370px"></asp:TextBox>
    <br />

    <br />

    <asp:Button ID="Button1" runat="server" Text="Find equation" CssClass="button" OnClick="Button1_Click" />
    <br />
    <br />
            <b style="color:red;"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></b>
    <table>

        <tr>
            <td style="color:blue;">Linear equation</td>
            <td><asp:Label ID="lblLinearEq" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
             <td style="color:blue;">R value</td>
            <td><asp:Label ID="lblRVal" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
             <td style="color:blue;">R squared value</td>
            <td><asp:Label ID="lblRSqVal" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
             <td style="color:blue;">Regression coefficient (&beta;)</td>
            <td><asp:Label ID="lblRegCoeff" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
             <td style="color:blue;">Intercept</td>
            <td><asp:Label ID="lblIntr" runat="server" Text=""></asp:Label></td>
        </tr>

    </table>

</asp:Content>
