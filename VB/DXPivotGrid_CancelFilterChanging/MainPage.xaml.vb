Imports Microsoft.VisualBasic
Imports System.Windows.Controls
Imports System.Reflection
Imports System.IO
Imports System.Xml.Serialization
Imports DevExpress.Xpf.PivotGrid
Imports System.Windows

Namespace DXPivotGrid_CancelFilterChanging
	Partial Public Class MainPage
		Inherits UserControl
		Private dataFileName As String = "nwind.xml"
		Public Sub New()
			InitializeComponent()

			' Parses an XML file and creates a collection of data items.
			Dim [assembly] As System.Reflection.Assembly = _
				System.Reflection.Assembly.GetExecutingAssembly()
			Dim stream As Stream = [assembly].GetManifestResourceStream(dataFileName)
			Dim s As New XmlSerializer(GetType(OrderData))
			Dim dataSource As Object = s.Deserialize(stream)

			' Binds a pivot grid to this collection.
			pivotGridControl1.DataSource = dataSource
		End Sub

		Private Sub pivotGridControl1_FieldFilterChanging(ByVal sender As Object, _
			ByVal e As PivotFieldFilterChangingEventArgs)
				If Equals(e.Field, fieldCountry) Then
                If (e.Field.FilterValues.FilterType = FieldFilterType.Excluded AndAlso _
                            e.Values.Contains("UK")) OrElse _
                            (e.Field.FilterValues.FilterType = FieldFilterType.Included AndAlso _
                            (Not e.Values.Contains("UK"))) Then
                    MessageBox.Show("You are not allowed to hide the 'UK' value.")
                    e.Cancel = True
                End If
				End If
		End Sub
	End Class
End Namespace
