using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BetterEtch_O_Sketch_Fall26
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            UpdateLabel();
        }

        void UpdateLabel()
        {
            AboutLabel.Text =
                $"Etch-O-Sketch\n" +
                $"ACME Inc.\n" +
                $"Version 2.0.0\n" +
                $"123Wabbit Woad\n" +
                $"Your Mother's House";
        }

        private void AboutOkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
