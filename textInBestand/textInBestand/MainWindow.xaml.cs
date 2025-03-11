using Microsoft.Win32;
using System.IO;
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

namespace textInBestand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)

        {

            try

            {

                OpenFileDialog ofd = new OpenFileDialog()

                {

                    Filter = "Tekstbestanden|*txt",

                    FileName = "Email.txt",

                    InitialDirectory = Environment.CurrentDirectory

                };

                if (ofd.ShowDialog() == true)

                {

                    string pathAndFileName = ofd.FileName;

                    txtFilePath.Text = pathAndFileName;

                }

            }

            catch (ArgumentException a)

            {

                MessageBox.Show(a.Message);

            }

            catch (FileNotFoundException fnf)

            {

                MessageBox.Show(fnf.Message, "Foutmelding:", MessageBoxButton.OK);

            }

            catch (UnauthorizedAccessException ua)

            {

                MessageBox.Show(ua.Message);

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }



        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)

        {

            string input = txtSearchString.Text;

            StringBuilder sb = new StringBuilder();

            string[] regels = File.ReadAllLines("Email.txt");



            int regelsGevonden = 0;



            for (int i = 0; i < regels.Length; i++)

            {

                if (regels[i].Contains(input, StringComparison.OrdinalIgnoreCase))

                {

                    sb.AppendLine($"Email.txt: regel: {i + 1} - {regels[i]}");

                    regelsGevonden++;

                }

            }

            sb.AppendLine($"\n{input} gevonden in {regelsGevonden} regels (totaal {regels.Length - 1} regels).");

            txtResults.Text = sb.ToString();



        }


    }
}