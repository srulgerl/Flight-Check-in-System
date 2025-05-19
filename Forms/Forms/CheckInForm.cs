using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.SqlClient; 
using System.Configuration;
using Data.Models;
using Data.Repositories;
using Services.BusinessLogic;


namespace WinForms.Forms
{
    public partial class CheckInForm : Form
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly ICheckInService _checkInService;
        //boarding pass hevlegch
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDocument printDocument1;

        private string passengerName;
        private string flightNumber;
        private string seatNumber;

        public CheckInForm(ICheckInService checkInService, IPassengerRepository passengerRepository)
        {

            _checkInService = checkInService;
            _passengerRepository = passengerRepository;
            InitializeComponent();
            
        }

        private void lbldate_Click(object sender, EventArgs e)
        {

        }

        private void CheckInForm_Load(object sender, EventArgs e)
        {
            lbldate.Text = $"Огноо:{DateTime.Now:dd/MM/yyyy}";
        }

      
       
       
        private void btnexit_Click(object sender, EventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Example: get bookingId from user selection or input
            int bookingId = 1; // Replace with actual logic
            LoadBoardingPassData(bookingId);

            printDocument1 = new PrintDocument();
            printDocument1.PrintPage += printDocument1_PrintPage;

            printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void LoadBoardingPassData(int bookingId)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["Flights"].ConnectionString;
            //string query = "SELECT PassengerName, FlightNumber, SeatNumber FROM Bookings WHERE BookingId = @BookingId";

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //using (SqlCommand cmd = new SqlCommand(query, conn))
            //{
            //    cmd.Parameters.AddWithValue("@BookingId", bookingId);
            //    conn.Open();
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        if (reader.Read())
            //        {
            //            passengerName = reader["PassengerName"].ToString();
            //            flightNumber = reader["FlightNumber"].ToString();
            //            seatNumber = reader["SeatNumber"].ToString();
            //        }
            //    }
            //}
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 16);
            float y = 100;
            e.Graphics.DrawString("Boarding Pass", font, Brushes.Black, 100, y);
            y += 40;
            e.Graphics.DrawString($"Name: {passengerName}", font, Brushes.Black, 100, y);
            y += 30;
            e.Graphics.DrawString($"Flight: {flightNumber}", font, Brushes.Black, 100, y);
            y += 30;
            e.Graphics.DrawString($"Seat: {seatNumber}", font, Brushes.Black, 100, y);
        }

        private async void btnPasswordSearch_Click(object sender, EventArgs e)
        {
            string passportNumber = passportNumTxtBx.Text.Trim();

            if (string.IsNullOrEmpty(passportNumber))
            {
                MessageBox.Show("Паспортын дугаараа оруулна уу.");
                return;
            }
            var passenger = await _passengerRepository.GetPassengerByPassportAsync(passportNumber);

            var displayPassenger =  new List<Passenger>
            { 
                new Passenger
                {
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    PassportNumber = passenger.PassportNumber,
                    FlightId = passenger.FlightId,
                    }
            };
            passengerInfoGridView.DataSource = displayPassenger;
            MessageBox.Show($"{passenger} oldson");
        }
 
 
      
    }
}
