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
    public partial class SubjFrm : Form
    {
        StudyContext db;
        public SubjFrm()
        {
            InitializeComponent();
            db = new StudyContext();
        }

        private void update()
        {
            db.Subjects.Load();
            dataGridView1.DataSource = db.Subjects.Local.ToBindingList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SubjAdd tForm = new SubjAdd();

            DialogResult result = tForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            Subject subject = new Subject();
            subject.Name = tForm.textBox1.Text;

            db.Subjects.Add(subject);
            db.SaveChanges();

            MessageBox.Show("Предмет добавлен");
            update();
        }

        private void SubjFrm_Activated(object sender, EventArgs e)
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

                Subject subject = db.Subjects.Find(id);

                SubjAdd tForm = new SubjAdd();
                tForm.textBox1.Text = subject.Name;

                DialogResult result = tForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                subject.Name = tForm.textBox1.Text;


                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Предмет обновлен");
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

                    Subject subject = db.Subjects.Find(id);
                    db.Subjects.Remove(subject);
                    db.SaveChanges();

                    MessageBox.Show("Предмет удален");
                    update();
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка при удалении"); };
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubjFrm_Load(object sender, EventArgs e)
        {
            update();
        }
    }
}
