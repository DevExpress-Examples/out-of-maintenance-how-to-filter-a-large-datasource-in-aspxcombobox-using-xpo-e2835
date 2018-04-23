using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

public partial class _Default : System.Web.UI.Page {
    Session session = XpoHelper.GetNewSession();

    protected void cmb_ItemRequestedByValue(object source, DevExpress.Web.ListEditItemRequestedByValueEventArgs e) {
        MyObject obj = session.GetObjectByKey<MyObject>(e.Value);

        if (obj != null) {
            cmb.DataSource = new MyObject[] { obj };
            cmb.DataBindItems();
        }
    }

    protected void cmb_ItemsRequestedByFilterCondition(object source, DevExpress.Web.ListEditItemsRequestedByFilterConditionEventArgs e) {
        XPCollection<MyObject> collection = new XPCollection<MyObject>(session);
        collection.SkipReturnedObjects = e.BeginIndex;
        collection.TopReturnedObjects = e.EndIndex - e.BeginIndex + 1;
        collection.Criteria = new FunctionOperator("Like", new OperandProperty("Title"), new OperandValue(String.Format("%{0}%", e.Filter)));        
        collection.Sorting.Add(new SortProperty("Oid", DevExpress.Xpo.DB.SortingDirection.Ascending));

        cmb.DataSource = collection;
        cmb.DataBindItems();
    }
}