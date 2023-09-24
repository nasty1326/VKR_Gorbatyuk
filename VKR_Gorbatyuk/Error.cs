using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKR_Gorbatyuk
{
    public partial class FormError : Form
    {
        
        public FormError(string nameError, string errorstring,int razdel)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            lbNameError.Text = nameError;
            lbError.Text = errorstring;
            
        }

        public FormError(string nameError, string errorstring)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            lbNameError.Text = nameError;
            lbError.Text = errorstring;
        }

        private void lbError_Click(object sender, EventArgs e)
        {

        }

        private void lbNameError_Click(object sender, EventArgs e)
        {

        }
    }
}
