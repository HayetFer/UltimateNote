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
        public static string weatherDescription;
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
                using (var stream = new FileStream(@"D:\\UltimateNote\\UltimateNote\\credentials.json", FileMode.Open, FileAccess.Read))
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
                using (var stream = new FileStream(@"D:\\UltimateNote\\UltimateNote\\credentials.json", FileMode.Open, FileAccess.Read))
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
                var dbHandler = new DatabaseHandler();
                dbHandler.AddId(document.DocumentId);
                await service.Documents.BatchUpdate(batchUpdateRequest, document.DocumentId).ExecuteAsync();

            }
        }

        private async void synch_Click(object sender, EventArgs e)
        {
            var idDrive = new IDDrive();
            var dbHandler = new DatabaseHandler();
            myID = dbHandler.selectID();
            var dbHandler2 = new DatabaseHandler2();
            // Retrieve all unsynced entries from the database
            var unsyncedEntries = dbHandler2.GetUnsyncedEntries();

            // Loop through each unsynced entry and process it
            foreach (var entry in unsyncedEntries)
            {
                // Append the entry's title and content to the text variable
                var textToInsert = entry.titleDB + " | " + entry.entryDB + " | " + entry.moodDB + " | " + entry.weatherDB + "|" + entry.dateDB + "\n";

                // Update the entry's synced status to "true"
                entry.synced = "true";
                dbHandler2.UpdateEntry(entry);

                // Call the function to update the Google Doc
                await UpdateGoogleDoc(myID, textToInsert);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            var dbHandler = new DatabaseHandler2();
            if (title.Text != null && entry.Text != null && weatherDescription != null && mood != "")
            {
                dbHandler.Add(title.Text, entry.Text, DateTime.Now.ToString(), mood, weatherDescription, "false");
            }
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
                    weatherDescription = weatherMain;
                    label1.Text = weatherMain;

                }
            }
        }
    }

}