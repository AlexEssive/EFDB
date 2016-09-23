using StudDataBase.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudDataBase
{
    public partial class ChooseStudent : Form
    {
        public ChooseStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (comboBox1.Text == "") richTextBox1.Text = "Не получено данных";
            else
            {
                using (StudyContext db = new StudyContext())
                {
                    var marks = db.Marks.Where(m => m.Student.Surname == comboBox1.Text);
                    foreach (Mark m in marks)
                        richTextBox1.Text += m.Subject.ToString() + " "+ m.Smark + Environment.NewLine;
                }
                if (richTextBox1.Text == "") richTextBox1.Text = "У этого студента пока нету оценок";
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ChooseStudent_Activated(object sender, EventArgs e)
        {
            using (StudyContext db = new StudyContext())
            {
                List<Student> students = db.Students.ToList();
                comboBox1.DataSource = students;
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "Surname";
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
