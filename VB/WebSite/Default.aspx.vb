Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private session As Session = XpoHelper.GetNewSession()

	Protected Sub cmb_ItemRequestedByValue(ByVal source As Object, ByVal e As DevExpress.Web.ASPxEditors.ListEditItemRequestedByValueEventArgs)
		Dim obj As MyObject = session.GetObjectByKey(Of MyObject)(e.Value)

		If obj IsNot Nothing Then
			cmb.DataSource = New MyObject() { obj }
			cmb.DataBindItems()
		End If
	End Sub

	Protected Sub cmb_ItemsRequestedByFilterCondition(ByVal source As Object, ByVal e As DevExpress.Web.ASPxEditors.ListEditItemsRequestedByFilterConditionEventArgs)
		Dim collection As New XPCollection(Of MyObject)(session)
		collection.SkipReturnedObjects = e.BeginIndex
		collection.TopReturnedObjects = e.EndIndex - e.BeginIndex + 1
		collection.Criteria = New BinaryOperator("Title", String.Format("%{0}%", e.Filter), BinaryOperatorType.Like)
		collection.Sorting.Add(New SortProperty("Oid", DevExpress.Xpo.DB.SortingDirection.Ascending))

		cmb.DataSource = collection
		cmb.DataBindItems()
	End Sub
End Class