using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Order
{
    public partial class Order : Form
    {
        string message = "Button Clicked!";

        public Order()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lbl1Output.Text = ""; //Button.btnSubmit;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            lbl1Output.Text = message;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //lblOne.Text = "Changed";
        }
    }
}
