using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace WinFormsApp1
{
    [Table("DbInfo")]
    public class DBInfo
    {
        [PrimaryKey,AutoIncrement]
        [Column("id")]
        public int ID { get; set; }
        [Column("titledb")]
        public string titleDB { get; set; }
        [Column ("entrydb")]
        public string entryDB { get; set; }
        [Column("datedb")]
        public string dateDB { get; set; }
        [Column("mooddb")]
        public string moodDB { get; set; }
        [Column("weatherdb")]
        public string weatherDB { get; set; }
        [Column("synced")]
        public string synced { get; set; }

        

    }
}
