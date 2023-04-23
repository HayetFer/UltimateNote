using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WinFormsApp1
{
    internal class DatabaseHandler2
    {
        private SQLiteConnection _db;
        public DatabaseHandler2()
        {
            _db = new SQLiteConnection(@"D:\\UltimateNote\\UltimateNote\mydatabase.db3");
            _db.CreateTable<DBInfo>();
        }
        public void Add(string t, string e, string date, string m, string w, string s)
        {
            var entries = new DBInfo
            {
                titleDB = t,
                entryDB = e,
                dateDB = date,
                moodDB = m,
                weatherDB = w,
                synced = s,
            };
            _db.Insert(entries);
        }
        public List<DBInfo> GetUnsyncedEntries()
        {
            var query = from entry in _db.Table<DBInfo>()
                        where entry.synced == "false"
                        select entry;
            return query.ToList();
        }
        public void UpdateEntry(DBInfo entry)
        {
            _db.Update(entry);
        }

    }
}
        
            
        