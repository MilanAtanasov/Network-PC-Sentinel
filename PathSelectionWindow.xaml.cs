using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Network_PC_Sentinel
{
    /// <summary>
    /// Interaction logic for PathSelectionWindow.xaml
    /// </summary>
    public partial class PathSelectionWindow : Window
    {
        public PathSelectionWindow()
        {
            InitializeComponent();
        }

        // This Method is called when the button is pressed to select a path
        private String btnSelectPath_Click(object sender, RoutedEventArgs e)
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Get the path
            String path = btnSelectPath_Click(sender, e);

            // Set the path
            Data data = Data.Instance;
            data.setPath(path);

            // Close the window
            this.Close();
        }
    }
}
