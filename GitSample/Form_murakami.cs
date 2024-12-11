using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitSample
{
    public partial class Form_murakami : Form
    {
        public Form_murakami()
        {
            InitializeComponent();
        }

        private void Form_murakami_Load(object sender, EventArgs e)
        {
            string message = "Good morning";

            MessageBox.Show(message);
        }
    }
}
