using Microsoft.EntityFrameworkCore.Metadata;
using Phonebook.model;
using System.Collections;
using System.Data.Common;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string queryString = "SELECT * FROM name_tab";
            ArrayList reader = SQLQuery.readQuery(queryString);
            foreach (DbDataRecord record in reader)
                richTextBox1.AppendText(record[0] + " " + record[1] + "\n");
            richTextBox1.AppendText("\n");
            if (richTextBox1 is not null)
            {
                toolStripStatusLabel1.Text = "Соединение с базой установлено";
            } else
            {
                toolStripStatusLabel1.Text = "Соединение с базой отсутствует!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryJoinmail = "SELECT name_tab_id, name, phone_number FROM name_tab RIGHT JOIN phone_tab ON name_tab_id = phone_name_fk ";
            ArrayList readerJoinmail = SQLQuery.readQuery(queryJoinmail);
            foreach (DbDataRecord recordAll in readerJoinmail)
                richTextBox1.AppendText(recordAll[0] + " " + recordAll[1] + " " + recordAll[2] + "\n");
            richTextBox1.AppendText("\n");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NoteSQL note = new NoteSQL();
            note.contactNname = textBox2.Text;
            note.phoneNumber = textBox3.Text;
            note.email_address = textBox4.Text;
            note.addInfo = textBox5.Text;
            note.noteSQL();

            richTextBox1.Clear();
            string queryString = "SELECT * FROM name_tab";
            ArrayList reader = SQLQuery.readQuery(queryString);
            foreach (DbDataRecord record in reader)
                richTextBox1.AppendText(record[0] + " " + record[1] + "\n");
            richTextBox1.AppendText("\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int deleteSQLid = 0;

            try
            {
                deleteSQLid = int.Parse(textBox1.Text);
            }
            catch
            {
                textBox1.Text = "Неверный ввод! Введите целое число.";
            }
            String deleteSQLPhone = string.Format("DELETE FROM phone_tab WHERE \"phone_name_fk\" = {0}", deleteSQLid);
            SQLQuery.writeQuery(deleteSQLPhone);
            String deleteSQLMail = string.Format("DELETE FROM email_tab WHERE \"email_name_fk\" = {0}", deleteSQLid);
            SQLQuery.writeQuery(deleteSQLMail);
            String deleteSQLInfo = string.Format("DELETE FROM comment_tab WHERE \"comment_name_fk\" = {0}", deleteSQLid);
            SQLQuery.writeQuery(deleteSQLInfo);
            String deleteSQLContact = string.Format("DELETE FROM name_tab WHERE \"name_tab_id\" = {0}", deleteSQLid);
            SQLQuery.writeQuery(deleteSQLContact);

            richTextBox1.Clear();
            string queryString = "SELECT * FROM name_tab";
            ArrayList reader = SQLQuery.readQuery(queryString);
            foreach (DbDataRecord record in reader)
                richTextBox1.AppendText(record[0] + " " + record[1] + "\n");
            richTextBox1.AppendText("\n");         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string queryJoinmail = "SELECT name_tab_id, name, email_address FROM name_tab RIGHT JOIN email_tab ON name_tab_id = email_name_fk ";
            ArrayList readerJoinmail = SQLQuery.readQuery(queryJoinmail);
            foreach (DbDataRecord recordAll in readerJoinmail)
                richTextBox1.AppendText(recordAll[0] + " " + recordAll[1] + " " + recordAll[2] + "\n");
            richTextBox1.AppendText("\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string queryJoininfo = "SELECT name_tab_id, name, comment FROM name_tab RIGHT JOIN comment_tab ON name_tab_id = comment_name_fk ";
            ArrayList readerJoinInfo = SQLQuery.readQuery(queryJoininfo);
            foreach (DbDataRecord recordAll in readerJoinInfo)
                richTextBox1.AppendText(recordAll[0] + " " + recordAll[1] + " " + recordAll[2] + "\n");
            richTextBox1.AppendText("\n");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM name_tab";
            ArrayList reader = SQLQuery.readQuery(queryString);
            foreach (DbDataRecord record in reader)
                richTextBox1.AppendText(record[0] + " " + record[1] + "\n");
            richTextBox1.AppendText("\n");

            string queryJoinname = "SELECT name_tab_id, name, phone_number FROM name_tab RIGHT JOIN phone_tab ON name_tab_id = phone_name_fk ";
            ArrayList readerJoinname = SQLQuery.readQuery(queryJoinname);
            foreach (DbDataRecord recordAll in readerJoinname)
                richTextBox1.AppendText(recordAll[0] + " " + recordAll[1] + " " + recordAll[2] + "\n");
            richTextBox1.AppendText("\n");

            string queryJoinmail = "SELECT name_tab_id, name, email_address FROM name_tab RIGHT JOIN email_tab ON name_tab_id = email_name_fk ";
            ArrayList readerJoinmail = SQLQuery.readQuery(queryJoinmail);
            foreach (DbDataRecord recordAll in readerJoinmail)
                richTextBox1.AppendText(recordAll[0] + " " + recordAll[1] + " " + recordAll[2] + "\n");
            richTextBox1.AppendText("\n");

            string queryJoininfo = "SELECT name_tab_id, name, comment FROM name_tab RIGHT JOIN comment_tab ON name_tab_id = comment_name_fk ";
            ArrayList readerJoinInfo = SQLQuery.readQuery(queryJoininfo);
            foreach (DbDataRecord recordAll in readerJoinInfo)
                richTextBox1.AppendText(recordAll[0] + " " + recordAll[1] + " " + recordAll[2] + "\n");
            richTextBox1.AppendText("\n");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            int contactID = 0;

            try
            {
                contactID = int.Parse(textBox1.Text);
            }
            catch
            {
                textBox1.Text = "Неверный ввод! Введите целое число.";
            }
            string sqlphonebyID = string.Format("SELECT name_tab_id, name, phone_number FROM name_tab RIGHT JOIN phone_tab ON name_tab_id = phone_name_fk  WHERE name_tab_id = '{0}'", contactID);
            ArrayList readerJoinInfo = SQLQuery.readQuery(sqlphonebyID);
            foreach (DbDataRecord recordAll in readerJoinInfo)
                richTextBox1.AppendText(recordAll[0] + " " + recordAll[1] + " " + recordAll[2] + "\n");
            richTextBox1.AppendText("\n");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string queryString = "SELECT * FROM name_tab";
            ArrayList reader = SQLQuery.readQuery(queryString);
            foreach (DbDataRecord record in reader)
                richTextBox1.AppendText(record[0] + " " + record[1] + "\n");
            richTextBox1.AppendText("\n");
        }

        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Documents|*.txt|Word Documents|*.doc";
            saveFileDialog1.ShowDialog(this);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(fileName, richTextBox1.Text);
            MessageBox.Show("         Файл сохранен         ");
        }


        private string strToPrint = String.Empty;
        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();

            this.strToPrint = richTextBox1.Text;
           
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int linesPerPage = 0;
            int charsOnPage = 0;
            e.Graphics.MeasureString(this.strToPrint, this.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charsOnPage, out linesPerPage);
            e.Graphics.DrawString(this.strToPrint, this.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);
            this.strToPrint = this.strToPrint.Substring(charsOnPage);
            e.HasMorePages = (this.strToPrint.Length > 0);
        }            

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("https://github.com/unnamemik");
        }
    }    
}