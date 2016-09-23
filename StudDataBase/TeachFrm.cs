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
    public partial class TeachFrm : Form
    {
        StudyContext db;
        public TeachFrm()
        {
            InitializeComponent();
            db = new StudyContext();
        }

        private void update()
        {
            db.Teachers.Load();
            dataGridView1.DataSource = db.Teachers.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeachAdd tForm = new TeachAdd();
            List<Subject> subjects = db.Subjects.ToList();
            tForm.comboBox1.DataSource = subjects;
            tForm.comboBox1.ValueMember = "Id";
            tForm.comboBox1.DisplayMember = "Name";

            DialogResult result = tForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            Teacher teacher = new Teacher();
            teacher.Name = tForm.textBox1.Text;
            teacher.Surname = tForm.textBox2.Text;
            teacher.Salary = Convert.ToInt32(tForm.textBox3.Text);
            teacher.Subject = (Subject)tForm.comboBox1.SelectedItem;

            db.Teachers.Add(teacher);
            db.SaveChanges();

            MessageBox.Show("Учитель добавлен");
            update();
        }

        private void TeachFrm_Activated(object sender, EventArgs e)
        {
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

                Teacher teacher = db.Teachers.Find(id);

                TeachAdd tForm = new TeachAdd();
                tForm.textBox1.Text = teacher.Name;
                tForm.textBox2.Text = teacher.Surname;
                tForm.textBox3.Text = teacher.Salary.ToString();

                List<Subject> subjects = db.Subjects.ToList();
                tForm.comboBox1.DataSource = subjects;
                tForm.comboBox1.ValueMember = "Id";
                tForm.comboBox1.DisplayMember = "Name";

                if (teacher.Subject != null)
                    tForm.comboBox1.SelectedValue = teacher.Subject.Id;

                DialogResult result = tForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                teacher.Name = tForm.textBox1.Text;
                teacher.Surname = tForm.textBox2.Text;
                teacher.Salary = Convert.ToInt32(tForm.textBox3.Text);
                teacher.Subject = (Subject)tForm.comboBox1.SelectedItem;

                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Учитель " + tForm.textBox2.Text + " обновлен");
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

                    Teacher teacher = db.Teachers.Find(id);
                    db.Teachers.Remove(teacher);
                    db.SaveChanges();

                    MessageBox.Show("Учитель удален");
                    update();
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка при удалении"); };
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TeachFrm_Load(object sender, EventArgs e)
        {
            update();
        }
    }
}
