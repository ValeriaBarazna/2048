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
    public partial class Registration : Form
    {
        private SQLiteConnection DB;
        public Registration()
        {
            InitializeComponent();
        }
        Point lastPoint;
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data source=DB\\2048Users.db");
            DB.Open();
            if(textBox1.Text =="" && textBox2.Text == "" && textBox3.Text =="")
            {
                MessageBox.Show("Поля не могут быть пустыми!","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
            }
            else
            {
                if(textBox2.Text ==  textBox3.Text)
                {
                    SQLiteCommand command2 = DB.CreateCommand();
                    command2.CommandText = "select * from Users where Name like @name";
                    command2.Parameters.Add("@name", DbType.String).Value = textBox1.Text;
                    SQLiteDataReader SQL2 = command2.ExecuteReader();
                    if (SQL2.HasRows)
                    {
                        MessageBox.Show("Имя пользователя занято.","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SQLiteCommand command = DB.CreateCommand();
                        command.CommandText = "INSERT INTO Users(Name,Record,Password) VALUES(@name,0,@password)";
                        command.Parameters.Add("@name", System.Data.DbType.String).Value = textBox1.Text;
                        command.Parameters.Add("@password", System.Data.DbType.String).Value = textBox2.Text;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Аккаунт успешно создан!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DB.Close();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                                             
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
