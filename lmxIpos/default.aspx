<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" EnableEventValidation="false" Inherits="lmxIpos._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ProductList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="False">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>SMS PUSHPULL<span>Creating Service for SMS PUSHPULL</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">SMS List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="grid-12">
                            
                            <div id="smsListGridContainer">
                                <asp:GridView ID="smsListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                        <asp:BoundField DataField="SERIAL" HeaderText="SERIAL" />
                                        <asp:BoundField DataField="IN_MSG_ID" HeaderText="IN_MSG_ID" />
                                        <asp:BoundField DataField="MOBILENO" HeaderText="MOBILE NO" />
                                        <asp:BoundField DataField="BODY" HeaderText="BODY" />
                                        <asp:BoundField DataField="ORIGIN_PORT" HeaderText="ORIGIN_PORT" />
                                        <asp:BoundField DataField="CREATE_DATE" HeaderText="CREATE DATE" />
                                       <%-- <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="editLinkButton" runat="server"
                                                    OnClick="editLinkButton_Click"><span class="icon icon-2x icon-edit-sign ui-button-text-icon-primary"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="activateLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="activateLinkButton_Click"><span class="icon icon-2x icon-ok-circle text-success"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="deactivateLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="deactivateLinkButton_Click"><span class="icon icon-2x icon-ban-circle text-warning"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="deleteLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="deleteLinkButton_Click"><span class="icon icon-2x icon-trash text-error bolder"></span> </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="productListGridView" EventName="RowDataBound" />--%>

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
<script type="text/javascript">
        function pageLoad(sender, args) {
            $("#smsListGridView").dataTable({
                    "bProcessing": true,
                    "bStateSave": true,
                    "sPaginationType": "full_numbers",
                    "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                    //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7, 8, 9] }]
            });
        }
    </script>
</asp:Content>
