<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="Footer" %>
<asp:Label ID="Label1" runat="server" Text="Label">©2020 by Raj<br>
    
        <section id="footer">
        <script >
            var d = new Date();
            document.getElementById("footer").innerHTML = "last Modified On: "+d.toLocaleString();
        </script>
        </section></asp:Label>