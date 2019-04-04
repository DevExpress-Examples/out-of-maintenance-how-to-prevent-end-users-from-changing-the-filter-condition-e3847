<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/DXPivotGrid_CancelFilterChanging/MainPage.xaml) (VB: [MainPage.xaml](./VB/DXPivotGrid_CancelFilterChanging/MainPage.xaml))
* [MainPage.xaml.cs](./CS/DXPivotGrid_CancelFilterChanging/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/DXPivotGrid_CancelFilterChanging/MainPage.xaml.vb))
<!-- default file list end -->
# How to prevent end-users from changing the filter condition


<p>The following example shows how to prevent end-users from changing the filter condition.</p><p>In this example, the FieldFilterChanging event is handled to prevent an end-user from hiding the 'UK' field value. If an end-user tries to hide the 'UK' field value, the event handler sets the event parameter's Cancel property to <strong>true</strong> to cancel changing the filter condition.</p><br />


<br/>


