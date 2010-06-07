<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About MvcJqGrid
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    
        
    <div id="about">
        <h2>About MvcJqGrid</h2>
        <p>All source code is licensed under the <a href="http://www.gnu.org/licenses/lgpl.html" target="_blank">GNU Lesser General Public License.</a></p>
        <p>Additional information can be found in <a href="http://webpirates.nl/webpirates/robin-van-der-knaap/47-fluent-jqgrid-html-helper-for-aspnet-mvc" target="_blank">this</a> blogarticle.</p>
        <p>Source is hosted on <a href="http://github.com/robinvanderknaap/MvcJqGrid" target="_blank">github</a>.</p>
    </div>

    <div id="logo">
        <a href="http://webpirates.nl" target="_blank"><img src="<%= VirtualPathUtility.ToAbsolute("~/Content/WP-logo-oomph.jpg")%>" alt="Webpirates Logo" /></a>
    </div>
</asp:Content>
