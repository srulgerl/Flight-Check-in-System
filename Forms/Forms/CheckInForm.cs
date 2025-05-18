using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinForms.Forms
{
    public partial class CheckInForm : Form
    {
        public CheckInForm()
        {
            InitializeComponent();
        }

        private void appbar_Click(object sender, EventArgs e)
        {

        }

        private void lbldate_Click(object sender, EventArgs e)
        {

        }

        private void CheckInForm_Load(object sender, EventArgs e)
        {
            lbldate.Text = $"Огноо:{DateTime.Now:dd/MM/yyyy}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelback_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {

        }

        private void LabelSeatsLoc_Click(object sender, EventArgs e)
        {

        }

        private void btnSeatA1_Click(object sender, EventArgs e)
        {
            Button clickedSeat = sender as Button;

            if (clickedSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Энэ суудал аль хэдийн захиалагдсан байна.");
                return;
            }

            // Өнгө өөрчлөх
            clickedSeat.BackColor = Color.Red;
        }
    }
}
