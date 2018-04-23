using System.Windows.Controls;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using DevExpress.Xpf.PivotGrid;
using System.Windows;

namespace DXPivotGrid_CancelFilterChanging {
    public partial class MainPage : UserControl {
        string dataFileName = "DXPivotGrid_CancelFilterChanging.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));
            object dataSource = s.Deserialize(stream);

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = dataSource;
        }

        private void pivotGridControl1_FieldFilterChanging(object sender, 
            PivotFieldFilterChangingEventArgs e) {
                if (Equals(e.Field, fieldCountry)) {
                    if ((e.Field.FilterValues.FilterType == FieldFilterType.Excluded &&
                            e.Values.Contains("UK")) ||
                        (e.Field.FilterValues.FilterType == FieldFilterType.Included &&
                            !e.Values.Contains("UK"))) {
                        MessageBox.Show("You are not allowed to hide the 'UK' value.");
                        e.Cancel = true;
                    }
                }
        }
    }
}
