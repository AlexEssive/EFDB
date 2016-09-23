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
    public partial class StudFrm : Form
    {
        StudyContext db;
        public StudFrm()
        {
            InitializeComponent();
            db = new StudyContext();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update()
        {
            db.Students.Load();
            dataGridView1.DataSource = db.Students.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudAdd tForm = new StudAdd();

            DialogResult result = tForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            Student student = new Student();
            student.Name = tForm.textBox1.Text;
            student.Surname = tForm.textBox2.Text;
            student.Course = Convert.ToInt32(tForm.textBox3.Text);

            db.Students.Add(student);
            db.SaveChanges();

            MessageBox.Show("Студент добавлен");
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

                Student student = db.Students.Find(id);

                StudAdd tForm = new StudAdd();
                tForm.textBox1.Text = student.Name;
                tForm.textBox2.Text = student.Surname;
                tForm.textBox3.Text = student.Course.ToString();

                DialogResult result = tForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                student.Name = tForm.textBox1.Text;
                student.Surname = tForm.textBox2.Text;
                student.Course = Convert.ToInt32(tForm.textBox3.Text);

                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Студент обновлен");
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

                    Student student = db.Students.Find(id);
                    db.Students.Remove(student);
                    db.SaveChanges();

                    MessageBox.Show("Студент удален");
                    update();
                }
            }
            catch { MessageBox.Show("Ошибка при удалении"); };
        }

        private void StudFrm_Activated(object sender, EventArgs e)
        {
            
        }

        private void StudFrm_Load(object sender, EventArgs e)
        {
            update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                var students = db.Students.OrderBy(s => s.Surname);
            //foreach (Student p in students)
            //  Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);
            update();
        }
    }
}
