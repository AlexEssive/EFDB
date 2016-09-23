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
    public partial class TeachSalary : Form
    {
        public TeachSalary()
        {
            InitializeComponent();
        }

        private void TeachSalary_Load(object sender, EventArgs e)
        {

        }

        private void TeachSalary_Activated(object sender, EventArgs e)
        {
            using (StudyContext db = new StudyContext())
            {
                int minSalary = db.Teachers.Min(t => t.Salary);
                int maxSalary = db.Teachers.Max(t => t.Salary);
                int sumSalary = db.Teachers.Sum(t => t.Salary);
                double avgSalary = db.Teachers.Average(t => t.Salary);
                richTextBox1.Text += "Минимальная зарплата: " + minSalary + Environment.NewLine + "Максимальная зарплата: " +
                       maxSalary + Environment.NewLine + "Средняя зарплата: " + avgSalary + Environment.NewLine + "Общая зарплата: " + sumSalary;
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
