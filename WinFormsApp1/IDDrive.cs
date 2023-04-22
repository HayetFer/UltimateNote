using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class IDDrive
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string IdDB { get; set; }


        public IDDrive() { }
        public IDDrive(string t)
        {
            IdDB=t;
        }
        public string GetFirstElement()
        {
            using (var connection = new SQLiteConnection("Data Source=yourdatabase.db"))
            {
                using (var command = new SQLiteCommand("SELECT * FROM IDDrive LIMIT 1", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetString(reader.GetOrdinal("IdDB"));
                        }
                    }
                }
            }

            return null;
        }

        public void UpdateById(int id, string newIdDB)
        {
            using (var db = new SQLiteConnection(@"D:\\UltimateNote\\UltimateNote\mydatabase.db3"))
            {
                var recordToUpdate = db.Table<IDDrive>().FirstOrDefault(x => x.ID == id);
                if (recordToUpdate != null)
                {
                    recordToUpdate.IdDB = newIdDB;
                    db.Update(recordToUpdate);
                }
            }
        }
    }
}

