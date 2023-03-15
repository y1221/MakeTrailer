﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeTrailer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Trailer.Get(textBoxA.Text, textBoxB.Text, textBoxC.Text), "結果");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit();
            formEdit.ShowDialog();
            formEdit.Dispose();
        }
    }
}
