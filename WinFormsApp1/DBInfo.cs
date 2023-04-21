using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace WinFormsApp1
{
    class DBInfo
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string titleDB { get; set; }
        public string entryDB { get; set; }
        public string dateDB { get; set; }
        public string moodDB { get; set; }


        DBInfo() { }
        public DBInfo(string t, string e, string date, string m) {
            titleDB = t;    
            entryDB = e;
            dateDB = date;
            moodDB = m;
        }

    }
}
