<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeBehind="Default.aspx.cs" Inherits="Laboratory.Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

  <div class="pageTitle">
    Welcome to Mathos Laboratory
  </div>

  <p>
    At this page you might try out almost all of the great features built into the 
    Mathos Core library online!
  </p>

  <p>
    Please navigate to
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/Modules.aspx">Modules</asp:HyperLink>
    , to see the new amazing features.
  </p>

  <p class="highlights" >
    Mathos is an open source project, which consists of a core library with many 
    great features to facilitate mathematical calculations. It can be downloaded 
    here: <a href="http://mathos.codeplex.com/">http://mathos.codeplex.com/</a>
  </p>

  <p>
    Would you like to contribute? Great! Please navigate to our contribution page <a href="http://mathosproject.com/about/contribute/">here</a>!
  </p>

  <div class="news">
    <div class="title">
      News
    </div>
    <ul>
        <li><a href="Module/DataAnalysis/LinearRegression.aspx">The linear relationship betwen two sets of data</a></li>
        <li><a href="http://labs.mathosproject.com/Module/DataAnalysis/PolynomSeq.aspx">Expression of the nth term and closed form for the sum (polynomial)</a></li>
      <li><a href="http://labs.mathosproject.com/Module/Finance/FinancePresentValue.aspx">Present value - Finance package</a></li>
      <li><a href="http://support.mathosproject.com/tutorials/uncertainty-calculator/">Tutorial about Uncertainty module</a></li>
      <li><a href="http://mathosproject.com/updates/making-features-of-the-library-available-online/">The role of Manager of Mathos Laboratory is available</a></li>
      <li><a href="http://labs.mathosproject.com/Module/Uncertainty.aspx">Uncertainty Calculator</a></li>
      <li><a href="http://labs.mathosproject.com/Module/Converter.aspx">Updated Converter</a></li>
    </ul>
  </div>


  <p>&nbsp;</p>
</asp:Content>