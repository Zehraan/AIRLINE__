using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Timer t = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            t.Interval = 3000;
            t.Tick += new EventHandler(OnTimerTicked);
            t.Start();
        }
        public void OnTimerTicked(object sender, EventArgs e)
        {
            t.Stop();
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
