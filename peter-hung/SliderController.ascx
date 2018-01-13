<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SliderController.ascx.cs" Inherits="peter_hung_SliderController" %>
<header>
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        
        <asp:Literal ID="ltSlider" runat="server"></asp:Literal>

        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
</header>
