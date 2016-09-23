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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) MessageBox.Show("Таблица не выбрана");
            else
            {
                string a;
                a = listBox1.SelectedIndex.ToString();
                switch (a)
                {
                    case "0": Form frm1 = new StudFrm(); frm1.ShowDialog(); break;
                    case "1": Form frm2 = new MarkFrm(); frm2.ShowDialog(); break;
                    case "2": Form frm3 = new SubjFrm(); frm3.ShowDialog(); break;
                    case "3": Form frm4 = new TeachFrm(); frm4.ShowDialog(); break;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm1 = new ChooseStudent(); frm1.ShowDialog();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm1 = new TeachSalary(); frm1.ShowDialog();
        }
    }
}
