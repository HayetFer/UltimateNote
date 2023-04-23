using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WinFormsApp1
{
    internal class DatabaseHandler
    {
        private SQLiteConnection _db;
        public DatabaseHandler()
        {
            _db = new SQLiteConnection(@"D:\\UltimateNote\\UltimateNote\IDdatabase.db3");
            _db.CreateTable<IDDrive>();
        }
        public void AddId(string ID)
        {
            var existingId = _db.Table<IDDrive>().FirstOrDefault(x => x.Id == 1);
            if (existingId != null)
            {
                existingId.IdDB = ID;
                _db.Update(existingId);
            }
            else
            {
                var newId = new IDDrive
                {
                    Id = 1,
                    IdDB = ID
                };
                _db.Insert(newId);
            }
        }

        public string selectID()
        {
            var id = _db.Query<IDDrive>("SELECT * FROM IDDrive WHERE Id = 1");
            var myId = id.FirstOrDefault(); 
            if(myId != null)
            {
                return myId.IdDB;
            }
            else return "";
        }
    }
}
