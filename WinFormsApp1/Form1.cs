using SQLite;
using System;
using System.Windows.Forms;
using OpenWeatherAPI;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public string mood;
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
        }

        private void title_TextChanged(object sender, EventArgs e)
        {

        }

        private void entry_TextChanged(object sender, EventArgs e)
        {

        }

        private void synch_Click(object sender, EventArgs e)
        {

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

            var openWeatherAPI = new OpenWeatherAPI.OpenWeatherApiClient("bd6f9728cfe7ba2d24531e4e6c684a93");
            // Use async version wherever possible
            var query = await openWeatherAPI.QueryAsync("Washington, USA");

            Console.Write(string.Format("The temperature in {0}, {1} is currently {2} °F", query.Name, query.Sys.Country, query.Main.Temperature.CelsiusCurrent));
            label1.Text = (string.Format("The temperature in {0}, {1} is currently {2} °F", query.Name, query.Sys.Country, query.Main.Temperature.CelsiusCurrent)); ;
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
    }
}