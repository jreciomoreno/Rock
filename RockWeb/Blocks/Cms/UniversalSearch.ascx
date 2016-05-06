<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UniversalSearch.ascx.cs" Inherits="RockWeb.Blocks.Cms.UniversalSearch" %>

<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlView" runat="server" CssClass="panel panel-block">
        
            <div class="panel-heading">
                <h1 class="panel-title"><i class="fa fa-search"></i> Universal Search</h1>

                <div class="panel-labels">
                    <Rock:HighlightLabel ID="hlblTest" runat="server" LabelType="Info" Text="Label" />
                </div>
            </div>
            <div class="panel-body">

                <div class="row">
                    <div class="col-md-11">
                        <Rock:RockTextBox id="tbSearch" runat="server" PrependText="<i class='fa fa-search'></i>" Placeholder="Search Rock" />
                    </div>
                    <div class="col-md-1">
                        <asp:LinkButton ID="btnSearch" CssClass="btn btn-primary" runat="server" OnClick="btnSearch_Click">Go</asp:LinkButton>
                    </div>
                </div>
                
                <div class="margin-t-md">
                    <asp:Literal ID="lResults" runat="server" />
                </div>
            </div>
        
        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>
