using Microsoft.Win32;
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

namespace Week_9_Enumerables_and_images
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboBox();


            imgDisplay.Source = ConvertToImage(@"C:\Users\tropi\Downloads\Week-9-Enumerables-and-images-master\Week-9-Enumerables-and-images-master\images\1000_F_568258887_Gh10ohzSEtKv4jhABCzqHd7kFpJiVKnF.jpg");

        }//MainWindow

        public BitmapImage ConvertToImage(string filePath)
        {

            string imgPath = @filePath;

            Uri convertPath = new Uri(imgPath);

            BitmapImage bitmap = new BitmapImage(new Uri(imgPath));

            return bitmap;
        }
        public void FillComboBox()
        {
            Art nighthawks = new Art("Nighthawks", Art.STYLE.Impressionism);


            runDisplay.Text = nighthawks.ToString();

            cmbStyles.ItemsSource = Enum.GetValues<Art.STYLE>().Cast<Art.STYLE>().ToList();



            //controlName.ItemsSource = Enum.GetValues(typeof(enumName)).Cast<enumName>().ToList();

            cmbStyles.ItemsSource =
                Enum.GetValues<Art.STYLE>().Cast<Art.STYLE>().ToList();
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            //Step 1 this is a built in tool in c#
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Filter
            //What displays in drop down box
            string displayFilter = "Image files (*png;*.jpeg;*.jpg)";
            //Used to filter results in the fike explorer
            string filterBy = "*png;*.jpeg;*.jpg";//Star indicates wildcard in programming
            //Fulll string needed
            //Must have a pipe between display and filter
            string fullFilter = $"{displayFilter} | {filterBy}";
            //pass to filter
            openFileDialog.Filter = fullFilter;
            //openFileDialog.Filter = "Image files (*png;*.jpeg;*.jpg)|*png;*.jpeg;*.jpg";

            //opens the dialog and returns true if a image is selected
            if(openFileDialog.ShowDialog() == true)
            {
                string reutnedFilePath =openFileDialog.FileName;
                imgDisplay.Source = ConvertToImage(reutnedFilePath);
            }
        }
    }
}