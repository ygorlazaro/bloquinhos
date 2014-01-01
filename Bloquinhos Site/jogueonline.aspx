<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jogueonline.aspx.cs" Inherits="Bloquinhos_Site.jogueonline"
    MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="silverlightcontainer">
	<object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="640" height="480">
		<param name="source" value="Bloquinhos.xap"/>
		<param name="background" value="white" />
		<param name="minRuntimeVersion" value="2.0.31005.0" />
		<param name="autoUpgrade" value="true" />
		<a href="http://go.microsoft.com/fwlink/?LinkID=124807" style="text-decoration: none;">
			<img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style: none;"/>
		</a>
	</object>
	<iframe id="_sl_historyFrame" style='visibility:hidden;height:0;width:0;border:0px;'></iframe>
</div>
</asp:Content>
