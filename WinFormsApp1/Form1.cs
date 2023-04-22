using SQLite;
using System;
using System.Windows.Forms;
using OpenWeatherMapDemo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Docs.v1.Data;
using Google.Apis.Docs.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public string mood;
        public static string myID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mood = "";
            //Load the database
            if (System.IO.File.Exists(@"D:\\UltimateNote\\UltimateNote\entriesdatabase.db3"))
            {
                //Do Nothing
            }
            else
            {
                var db = new SQLiteConnection(@"D:\\UltimateNote\\UltimateNote\mydatabase.db3");
                db.CreateTable<DBInfo>();
                db.Close();
            }
            if (System.IO.File.Exists(@"D:\\UltimateNote\\UltimateNote\IDdatabase.db3"))
            {
                //Do Nothing
            }
            else
            {
                var db = new SQLiteConnection(@"D:\\UltimateNote\\UltimateNote\IDdatabase.db3");
                db.CreateTable<IDDrive>();
                db.Close();
            }

            string filePath = "D:\\UltimateNote\\UltimateNote\\WinFormsApp1\\cities.csv";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string city = parts[0];
                string countryCode = parts[1];

                string itemText = $"{city},{countryCode}";
                comboBox1.Items.Add(itemText);
            }

        }

        private void title_TextChanged(object sender, EventArgs e)
        {

        }

        private void entry_TextChanged(object sender, EventArgs e)
        {

        }
        public static async Task UpdateGoogleDoc(string docId, string textToInsert)
        {
            try
            {
                
                UserCredential credential;
                using (var stream = new FileStream(@"D:\\UltimateNote\\UltimateNote\\.gitignore\\credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { DocsService.Scope.Documents },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true));
                }

                var service = new DocsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "UltimateNote",
                });

                // Retrieve the existing document.
                var document = await service.Documents.Get(docId).ExecuteAsync();
                // Insert the text at the end of the existing text.
                var requests = new List<Request>();
                var insertTextRequest = new InsertTextRequest()
                {
                    Text = textToInsert,
                    EndOfSegmentLocation = new EndOfSegmentLocation()
                };
                requests.Add(new Request()
                {
                    InsertText = insertTextRequest
                });
                var batchUpdateRequest = new BatchUpdateDocumentRequest()
                {
                    Requests = requests
                };
                await service.Documents.BatchUpdate(batchUpdateRequest, docId).ExecuteAsync();
            }
            catch (Google.GoogleApiException e)
            {
                UserCredential credential;
                using (var stream = new FileStream(@"D:\\UltimateNote\\UltimateNote\\.gitignore\\credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { DocsService.Scope.Documents },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true));
                }

                var service = new DocsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "UltimateNote",
                });

                // Create the document.
                var document = new Document()
                {
                    Title = "MyUltimateNote"
                };
                document = await service.Documents.Create(document).ExecuteAsync();

                // Insert the text.
                var requests = new List<Request>();
                var insertTextRequest = new InsertTextRequest()
                {
                    Text = textToInsert,
                    EndOfSegmentLocation = new EndOfSegmentLocation()
                };
                requests.Add(new Request()
                {
                    InsertText = insertTextRequest
                });
                var batchUpdateRequest = new BatchUpdateDocumentRequest()
                {
                    Requests = requests
                };
                IDDrive temp = new IDDrive(document.DocumentId);
                await service.Documents.BatchUpdate(batchUpdateRequest, document.DocumentId).ExecuteAsync();
                var db = new IDDrive();
                db.UpdateById(1, document.DocumentId);
            }
        }

        private async void synch_Click(object sender, EventArgs e)
        {
            var idDrive = new IDDrive();
            if (idDrive.GetFirstElement().ToString() != null)
            {
                myID = idDrive.GetFirstElement().ToString();
            }
            var textToInsert = title.Text + "\n";

            await UpdateGoogleDoc(myID, textToInsert);
        }

        private void save_Click(object sender, EventArgs e)
        {
            DBInfo temp = new DBInfo(title.Text, entry.Text, DateTime.Now.ToString("dd-MM-yyyyy"), mood);
            var db = new SQLiteConnection(@"D:\\UltimateNote\\UltimateNote\mydatabase.db3");
            db.Insert(temp);
            db.Close();
            mood = "";
        }

        private void weather_TextChanged(object sender, EventArgs e)
        {

        }

        private async void test_ClickAsync(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedItemText = comboBox1.SelectedItem.ToString();
                string[] parts = selectedItemText.Split(',');
                string cityName = parts[0];
                string countryCode = parts[1];
                Weather weather = new Weather();
                string city = "London"; // replace with the desired city
                string weatherMain = await weather.GetWeatherMainAsync(parts[0], parts[1]);

                if (weatherMain != null)
                {
                    label1.Text = weatherMain;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mood = "Neutral";
        }

        private void one_Click(object sender, EventArgs e)
        {
            mood = "Very Sad";
        }

        private void two_Click(object sender, EventArgs e)
        {
            mood = "Sad";
        }

        private void four_Click(object sender, EventArgs e)
        {
            mood = "Happy";
        }

        private void five_Click(object sender, EventArgs e)
        {
            mood = "Very Happy";
        }

        private void load_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            Form2 newForm = new Form2();

            // Show the new form
            newForm.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addTODOLIst_Click(object sender, EventArgs e)
        {
            string item = todoText.Text;
            checkedListBox1.Items.Add(item);
            todoText.Clear();
        }

        private void todoText_TextChanged(object sender, EventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedItemText = comboBox1.SelectedItem.ToString();
                string[] parts = selectedItemText.Split(',');
                string cityName = parts[0];
                string countryCode = parts[1];
                Weather weather = new Weather();
                string city = "London"; // replace with the desired city
                string weatherMain = await weather.GetWeatherMainAsync(parts[0], parts[1]);

                if (weatherMain != null)
                {
                    label1.Text = weatherMain;
                }
            }
        }
    }
    
}