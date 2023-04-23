﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    [Table("IDDrive")]
    public class IDDrive
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("IdDB")]
        public string IdDB { get; set; }


        public IDDrive() { }
        public IDDrive(string t)
        {
            IdDB=t;
        }
    }
}

