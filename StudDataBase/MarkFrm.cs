using StudDataBase.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudDataBase
{
    public partial class MarkFrm : Form
    {
        StudyContext db;
        public MarkFrm()
        {
            InitializeComponent();
            db = new StudyContext();
        }

        private void update()
        {
            db.Marks.Load();
            dataGridView1.DataSource = db.Marks.Local.ToBindingList();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MarkAdd tForm = new MarkAdd();
            List<Student> students = db.Students.ToList();
            List<Subject> subjects = db.Subjects.ToList();
            tForm.comboBox1.DataSource = subjects;
            tForm.comboBox1.ValueMember = "Id";
            tForm.comboBox1.DisplayMember = "Name";
            tForm.comboBox2.DataSource = students;
            tForm.comboBox2.ValueMember = "Id";
            tForm.comboBox2.DisplayMember = "Surname";

            DialogResult result = tForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            Mark mark = new Mark();
            mark.Smark = Convert.ToInt32(tForm.textBox1.Text);
            mark.Subject = (Subject)tForm.comboBox1.SelectedItem;
            mark.Student = (Student)tForm.comboBox2.SelectedItem;

            db.Marks.Add(mark);
            db.SaveChanges();

            MessageBox.Show("Оценка добавлена");
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Mark mark = db.Marks.Find(id);

                MarkAdd tForm = new MarkAdd();
                tForm.textBox1.Text = mark.Smark.ToString();

                List<Subject> subjects = db.Subjects.ToList();
                tForm.comboBox1.DataSource = subjects;
                tForm.comboBox1.ValueMember = "Id";
                tForm.comboBox1.DisplayMember = "Name";
                List<Student> students = db.Students.ToList();
                tForm.comboBox2.DataSource = students;
                tForm.comboBox2.ValueMember = "Id";
                tForm.comboBox2.DisplayMember = "Surname";

                if (mark.Subject != null)
                    tForm.comboBox1.SelectedValue = mark.Subject.Id;
                if (mark.Student != null)
                    tForm.comboBox2.SelectedValue = mark.Student.Id;

                DialogResult result = tForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                mark.Smark = Convert.ToInt32(tForm.textBox1.Text);
                mark.Subject = (Subject)tForm.comboBox1.SelectedItem;
                mark.Student = (Student)tForm.comboBox2.SelectedItem;

                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Оценка обновлена");
                update();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Mark mark = db.Marks.Find(id);
                    db.Marks.Remove(mark);
                    db.SaveChanges();

                    MessageBox.Show("Оценка удалена");
                    update();
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка при удалении"); };
        }

        private void MarkFrm_Load(object sender, EventArgs e)
        {
            update();
        }
    }
}
