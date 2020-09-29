using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Net;
using System.Management;
using System.Net.Mail;
using System.Windows.Forms;

namespace _2048
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }
        private SQLiteConnection DB;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Поля не могут быть пустыми!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DB = new SQLiteConnection("Data source=DB\\2048Users.db");
                DB.Open();
                SQLiteCommand command = DB.CreateCommand();
                command.CommandText = "select Password from Users where Name like @name";
                command.Parameters.Add("@name", DbType.String).Value = textBox1.Text;
                SQLiteDataReader SQL = command.ExecuteReader();
                if (SQL.HasRows)
                {
                    while (SQL.Read())
                    {
                        int rows = dataGridView1.Rows.Add();
                        dataGridView1.Rows[0].Cells[0].Value = SQL[0];
                    }

                    string password = Convert.ToString(dataGridView1[0, 0].Value);

                    ////message sending
                    string email = textBox2.Text;
                    MailAddress from = new MailAddress("komanda2048@yandex.by", "Команда \"2048\"");
                    MailAddress to = new MailAddress(email);
                    MailMessage Mail = new MailMessage(from, to);
                    Mail.Subject = "Команда \"2048\"";
                    Mail.Body = "<h4><center><font face =\"Segoe Print\">Восстановление пароля:</center>"
                        + "Уважаемый игрок " + textBox1.Text + "," + "<br>"
                        + "Ваш пароль: " + password + "<br>"
                        + "Не теряйте больше!" + "<br>"
                        + "<br><center>Команда \"2048\"</font></center></ch4>";
                    Mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.yandex.by");
                    smtp.Credentials = new NetworkCredential("komanda2048@yandex.by", "06122001");
                    smtp.EnableSsl = true;
                    smtp.Send(Mail);
                    MessageBox.Show("Письмо отправлено на почту " + email, "Отправка данных на электронный ящик", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";


                    DB.Close();
                    this.Close();
                }
            }
                                       
        }
        Point lastPoint;
        private void Mail_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Mail_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
