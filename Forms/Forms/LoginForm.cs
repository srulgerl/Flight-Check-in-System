using Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IPassengerRepository _passengerRepository;
        public LoginForm(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
            InitializeComponent();
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void SearchBtn_Click(object sender, EventArgs e)
        {
            string passportNum = passportTxtBx.Text.Trim();
            if (string.IsNullOrEmpty(passportNum))
            {
                MessageBox.Show("Please enter a passport number.");
                return;
            }
            var passenger = await _passengerRepository.GetPassengerByPassportAsync(passportNum);

            if (passenger != null)
            {
                MessageBox.Show($"Passenger found: {passenger.FirstName} {passenger.LastName}");
            }
            else
            {
                MessageBox.Show("Passenger not found.");
            }

        }
        
    }
}
