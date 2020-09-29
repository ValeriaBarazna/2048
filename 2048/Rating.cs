using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace _2048
{
    public partial class Rating : Form
    {
        public Rating()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public SQLiteConnection DB;
        private void Rating_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data source=DB\\2048Users.db");
            
            SQLiteCommand command = new SQLiteCommand("select Name,Record from Users order by Record DESC",DB);
            DB.Open();
            SQLiteDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
            ratingView.DataSource = dt;
            

        }
    }
}
