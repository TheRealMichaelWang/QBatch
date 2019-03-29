using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDE
{
    public partial class Prompt : Form
    {
        public bool Canceled = true;
        public string Output = null;

        public Prompt(string prompt,string defaultinput)
        {
            InitializeComponent();
            this.Text = prompt;
            this.Input.Text = defaultinput;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ShowDialog();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Canceled = false;
                Output = this.Input.Text;
                this.Close();
            }
        }
    }
}
