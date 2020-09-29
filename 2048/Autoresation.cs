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
    public partial class Aauthorization : Form
    {
        

        public Aauthorization()
        {
            InitializeComponent();
        }
        Form1 gameform = new Form1();
        public int record;
        
        public void Button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection DB1 = new SQLiteConnection("Data source=DB\\2048Users.db");
            DB1.Open();
            SQLiteCommand command = DB1.CreateCommand();
            command.CommandText = "select Record from Users where Name like @name";
            command.Parameters.Add("@name", DbType.String).Value = textBox1.Text;
            SQLiteDataReader SQL = command.ExecuteReader();
            if(SQL.HasRows)
            {
                SQLiteCommand command2 = DB1.CreateCommand();
                command2.CommandText = "select Record from Users where Password like @pass";
                command2.Parameters.Add("@pass", DbType.String).Value = textBox2.Text;
                SQLiteDataReader SQL2 = command2.ExecuteReader();
                if(SQL2.HasRows)
                {
                    while(SQL2.Read())
                    {
                        int rows = dataGridView1.Rows.Add();
                        dataGridView1.Rows[0].Cells[0].Value = SQL2[0];
                    }
                    SQL.Close();
                    SQL2.Close();
                    DB1.Close();
                    
                    record = Convert.ToInt32(dataGridView1[0, 0].Value);
                    gameform.rec = record;
                    gameform.nam = textBox1.Text;
                    gameform.Show();

                    

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            
        }
        Point lastPoint;
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X,e.Y);
        }
        
        private void Label4_Click(object sender, EventArgs e)
        {
            Mail mail = new Mail();
            mail.Show();
        }
        
        private void Label3_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }
    }
}
