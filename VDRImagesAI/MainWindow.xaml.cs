using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
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
using VDRImagesAI.Classes;

namespace VDRImagesAI
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            const string suportedImageFile = "Image files (*.png; *.jpg)|*.png; *.jpg; *.jpeg";
            const string allFiles = "All Files (*.*)|*.*";
            dialog.Filter = $"{suportedImageFile}|{allFiles}";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileName));

                MakePrediction(fileName);
            }
        }

        private async void MakePrediction(string fileName)
        {
            string apiUrl = "https://southcentralus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/1928485f-1a28-415e-a284-80f2f53c10b4/classify/iterations/VDA/image";
            string predictionKey = "da574cb79cf142568031139e34bb4f12";
            string contentType = "application/octet-stream";
            var file = File.ReadAllBytes(fileName);

            using (HttpClient client = new HttpClient()) 
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);
                using ( var content = new ByteArrayContent(file))
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    var response = await client.PostAsync(apiUrl, content);     
                    
                    var responseString = await response.Content.ReadAsStringAsync();

                    List<Prediction> predictions = JsonConvert.DeserializeObject<CustomVision>(responseString).predictions;

                    predictionsListView.ItemsSource = predictions;
                }
            };
        }
    }
}
