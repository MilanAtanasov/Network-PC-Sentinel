using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Network_PC_Sentinel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            updateComboBoxRechner();
        }

        private void updateComboBoxRechner()
        {
            Data data;
            data = Data.Instance;
            List<Computer> computers = data.getComputers();
            foreach (Computer computer in computers)
            {
                Debug.WriteLine(computer.getName());
                cbRechner.Items.Add(computer.getName());
            }


        }

        private void cbRechner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data data = Data.Instance;
            List<Computer> computers = data.getComputers();
            foreach (Computer computer in computers)
            {
                if (computer.getName().Equals(cbRechner.SelectedItem.ToString()))
                {

                    // Software
                    List<Software> software = computer.getSoftware();

                    dataGridSoftware.Items.Clear();
                    dataGridSoftware.Columns.Clear();
                    DataGridTextColumn col1 = new DataGridTextColumn();
                    col1.Header = "Name";
                    col1.Binding = new System.Windows.Data.Binding("Name");
                    dataGridSoftware.Columns.Add(col1);

                    DataGridTextColumn col2 = new DataGridTextColumn();
                    col2.Header = "Version";
                    col2.Binding = new System.Windows.Data.Binding("Version");
                    dataGridSoftware.Columns.Add(col2);

                    DataGridTextColumn col3 = new DataGridTextColumn();
                    col3.Header = "Publisher";
                    col3.Binding = new System.Windows.Data.Binding("Publisher");
                    dataGridSoftware.Columns.Add(col3);

                    // resizes the columns to fit the content
                    dataGridSoftware.Columns[0].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    dataGridSoftware.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    dataGridSoftware.Columns[2].Width = new DataGridLength(1, DataGridLengthUnitType.Star);

                    foreach (Software software1 in software)
                    {
                        dataGridSoftware.Items.Add(new { Name = software1.getName(), Version = software1.getVersion(), Publisher = software1.getPublisher() });

                    }

                    // IP-Adressen
                    List<String> ips = computer.getIPs();
                    listBoxIPs.Items.Clear();
                    foreach (String ip in ips)
                    {
                        listBoxIPs.Items.Add(ip);
                    }


                }


            }
        }

        private String pathDialog(object sender, RoutedEventArgs e)
        {
            String path = "Pfad";
            // Create a FolderBrowserDialog
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the description
            folderBrowserDialog.Description = "Select the path where the data should be stored";

            // Show the FolderBrowserDialog
            DialogResult result = folderBrowserDialog.ShowDialog();

            // If the result is OK then set the path
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // Set the path
                path = folderBrowserDialog.SelectedPath;
            }
            return path;
        }

        private void clickButtonPathChange(object sender, RoutedEventArgs e)
        {
            // Get the path
            String path = pathDialog(sender, e);

            // Set the path
            Data data = Data.Instance;
            data.setPath(path);

            Data.Instance.updateData();


        }

    }
}