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
            Data data;
            data = Data.Instance;
            List<Computer> computers = data.getComputers();
            foreach (Computer computer in computers)
            {
                if (computer.getName().Equals(cbRechner.SelectedItem.ToString()))
                {
                    Debug.WriteLine(computer.getName());
                    List<Software> software = computer.getSoftware();
                    Debug.WriteLine(software.Count);
                    listBoxSoftware.Items.Clear();
                    foreach (Software software1 in software)
                    {
                        Debug.WriteLine(software1.getName());
                        listBoxSoftware.Items.Add(software1.getName());
                    }
                    
                }
            }
        }

    }
}