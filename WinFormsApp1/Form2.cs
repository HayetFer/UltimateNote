using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private DatabaseHandler2 _dbHandler;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _dbHandler = new DatabaseHandler2();
            dataGridView1.DataSource = _dbHandler._db.Table<DBInfo>().ToList();
        }
    }
}
