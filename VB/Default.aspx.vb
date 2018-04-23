Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Partial Public Class _Default
    Inherits System.Web.UI.Page


    Private session_Renamed As Session = XpoHelper.GetNewSession()

    Protected Sub cmb_ItemRequestedByValue(ByVal source As Object, ByVal e As DevExpress.Web.ListEditItemRequestedByValueEventArgs)
        Dim obj As MyObject = session_Renamed.GetObjectByKey(Of MyObject)(e.Value)

        If obj IsNot Nothing Then
            cmb.DataSource = New MyObject() { obj }
            cmb.DataBindItems()
        End If
    End Sub

    Protected Sub cmb_ItemsRequestedByFilterCondition(ByVal source As Object, ByVal e As DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs)
        Dim collection As New XPCollection(Of MyObject)(session_Renamed)
        collection.SkipReturnedObjects = e.BeginIndex
        collection.TopReturnedObjects = e.EndIndex - e.BeginIndex + 1
        collection.Criteria = New FunctionOperator("Like", New OperandProperty("Title"), New OperandValue(String.Format("%{0}%", e.Filter)))
        collection.Sorting.Add(New SortProperty("Oid", DevExpress.Xpo.DB.SortingDirection.Ascending))

        cmb.DataSource = collection
        cmb.DataBindItems()
    End Sub
End Class