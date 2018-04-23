<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Xpo.v10.1.Web, Version=10.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to filter a large datasource in ASPxComboBox using XPO</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dx:ASPxComboBox ID="cmb" runat="server" ValueType="System.Int32" ValueField="Oid"
			TextField="Title" EnableCallbackMode="true" CallbackPageSize="10" IncrementalFilteringMode="Contains"
			OnItemRequestedByValue="cmb_ItemRequestedByValue" OnItemsRequestedByFilterCondition="cmb_ItemsRequestedByFilterCondition">
		</dx:ASPxComboBox>
	</div>
	</form>
</body>
</html>