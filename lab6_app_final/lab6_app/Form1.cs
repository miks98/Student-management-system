using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6_app
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();
        private int current = 0;
        public Form1()
        {
            
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            students.Add(new Student("1", "asad", 20, 2.5m, true));
            students.Add(new Student("2", "asma", 18, 2.5m, false));
            students.Add(new Student("3", "arif", 16, 2.5m, true));
            students.Add(new Student("4", "sadaf", 30, 2.5m, false));
                this.refresh();
        }

        private void refresh()
        {
            Student s;
            if (students.Count==0)
            {
                s = new Student("", "", 0, 0.0m, true);
                return;
            }
             s = students[current];
            this.s_name.Text = s.name;
            this.s_age.Text = s.age.ToString();
            this.s_id.Text = s.id;
            this.s_marks.Text = s.cgpa.ToString();
            this.Male.Checked = s.gender;
            this.Female.Checked = !s.gender;

        }
        //previous
        private void Prev_Click(object sender, EventArgs e)
        {
            if (current == 0)
            {
                return;
               
            }
            this.current--;
            this.refresh();
        }
        //next
        private void next_Click(object sender, EventArgs e)
        {
            if (current == students.Count - 1)
            {
                return;
               
            }
            this.current++;
            this.refresh();
        }

        private void button1_Click(object sender, EventArgs e) //update
        {
            try
            {
                Student s = students[current];
            s.id = this.s_id.Text;
            s.name = this.s_name.Text;
            s.gender = this.Male.Checked;
            s.age = int.Parse(this.s_age.Text);
            s.cgpa = decimal.Parse(this.s_marks.Text);
            MessageBox.Show("Record has been Updated");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e) //delete
        {
            if (current==students.Count-1)
            {
                this.students.RemoveAt(current);
                current = 0;
            }
            else
            {
                this.students.RemoveAt(current);
            }
           
            MessageBox.Show("Record Deleted");
            this.refresh();
        }

        private void button3_Click(object sender, EventArgs e) //new
        {
            this.students.Add(new Student("", "", 0, 0.0m, true));
            this.current = this.students.Count - 1;
            this.refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "lab Files  (*.lab)| All files()*.*|*.";
            if (this.openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;// Console.WriteLine("sakkar mukayif");
            }
            //DeSerialization
            Stream fs = File.Open(saveFileDialog1.FileName, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            this.students = (List<Student>)bin.Deserialize(fs);
            this.current = 0;
            this.refresh();
            fs.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "lab Files  (*.lab)| All files()*.*|*.*";
            if (this.saveFileDialog1.ShowDialog()== DialogResult.Cancel)
            {
                return;
            }
            //Serialization
            Stream fs = File.Open(saveFileDialog1.FileName, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(fs, this.students);
            fs.Close();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Control.ModifierKeys==Keys.Alt)
            {
                Prev_Click(null, null);
            }
            else if (e.KeyCode == Keys.Right && Control.ModifierKeys == Keys.Alt)
            {
                next_Click(null, null);
            }
        }
    }
}