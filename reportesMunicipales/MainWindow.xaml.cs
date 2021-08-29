using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace reportesMunicipales
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Municipality> municipalities;

        public MainWindow()
        {
            municipalities = new List<Municipality>();
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String csvPath;
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.DefaultExt = ".csv";
            openFileDlg.Filter = "Archivos csv (.csv)|*.csv";
            if (openFileDlg.ShowDialog() == true)
            {
                csvPath = openFileDlg.FileName;
                readCsvFile(csvPath);

            }

        }

        private void readCsvFile(String csvPath) {
            String[] lines = File.ReadAllLines(csvPath);
            foreach (String line in lines)
            {
                String[] data = line.Split(',');

                int temp;
                if (int.TryParse(data[0], out temp))
                {
                    Municipality m = new Municipality() { depCode = data[0], code = data[1], depName = data[2], name = data[3], type = data[4] };
                    municipalities.Add(m);
                    dataGridOne.Items.Add(m);

                }
            }

        }

        private void loadTableTwo(List<Municipality> filteredMunicipalities)
        {
            foreach (Municipality m in filteredMunicipalities)
            {
                dataGridOne.Items.Add(m);

            }

        }

        private void loadBarsGraph() { 
        
        }

    }

    public class Municipality { 
        
        public String depCode { get; set; }
        public String code { get; set; }
        public String depName { get; set; }
        public String name { get; set; }
        public String type { get; set; }

    }
}
