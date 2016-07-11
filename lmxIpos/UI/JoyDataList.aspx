<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="JoyDataList.aspx.cs" Inherits="lmxIpos.UI.JoyDataList" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="False">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Joy Data List<span>Created Data For Joy</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>Acura</span><i>/</i></li>
                        <li><a href="Default.aspx">Dashboard</a></li>
                    </ul>--%>
                </div>
            </div>
            <div class="data">
                <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                    <button type="button" class="close" data-dismiss="alert">
                        &times;</button>
                    <h4>
                        <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                    </h4>
                    <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="widget">
                    <header class="widget-header">
                        <div class="widget-header-icon">
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">Joy Data List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="grid-12">
                            
                            <div id="productListGridContainer">
                                <asp:GridView ID="productListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                        <asp:BoundField DataField="Institute" HeaderText="Institute" />
                                        <asp:BoundField DataField="InstituteName" HeaderText="Institute Name" />
                                        <asp:BoundField DataField="InstitueContact" HeaderText="Institue Contact" />
                                        <asp:BoundField DataField="LocationArea" HeaderText="Location Area" />
                                        <asp:BoundField DataField="Lat" HeaderText="Latitude"/>
                                        <asp:BoundField DataField="lang" HeaderText="Langitude" />
                                      
                                       
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="productListGridView" EventName="RowDataBound" />
           
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#productListGridView").dataTable({
                    "bProcessing": true,
                    "bStateSave": true,
                    "sPaginationType": "full_numbers",
                    "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                    //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7, 8, 9] }]
            });
        }
    </script>
   
</asp:Content>
