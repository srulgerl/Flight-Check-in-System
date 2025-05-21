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
using WinForms.Services;


namespace WinForms.Forms
{
    public partial class CheckInForm : Form
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly ICheckInService _checkInService;
        private readonly IFlightRepository _flightRepository;
        //boarding pass hevlegch
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDocument printDocument1;


        private string passengerName;
        private string flightNumber;
        private string seatNumber;
        private int _currentPassengerId;
        // Add a field to track if a passenger is found
        private bool passengerFound = false;
        public CheckInForm(ICheckInService checkInService, IPassengerRepository passengerRepository, IFlightRepository flightRepository)
        {

            _checkInService = checkInService;
            _passengerRepository = passengerRepository;
            _flightRepository = flightRepository;
            _socketClient = new SocketClient();
            InitializeComponent();
            LoadFlightNumbers();

        }

        private async void LoadFlightNumbers()
        {
            var flights = await _flightRepository.GetAllAsync();
            flightNumComboBox.DataSource = flights;
            flightNumComboBox.DisplayMember = "FlightNumber";
            flightNumComboBox.ValueMember = "FlightId";
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
            this.Close();
        }

        //private async Task SeatBtn_Click(object sender, EventArgs e)
        //{

        //    if (sender is not Button btn || _currentPassengerId == null)
        //    {
        //        return;
        //    }

        //    int seatId = (int)btn.Tag;
        //    var passenger = await _passengerRepository.GetPassengerByIdAsync(_currentPassengerId);
        //    if (passenger == null)
        //    {
        //        MessageBox.Show("Passenger not found.");
        //        return;
        //    }
        //    bool success = await _checkInService.CheckInPassengerAsync(passenger.PassportNumber, passenger.PassportNumber, seatId);

        //    MessageBox.Show(success ? "Check-in successful!" : "Check-in failed.");
        //    if (success)
        //    {
        //        btn.Enabled = false;
        //        btn.BackColor = Color.Green;
        //    }
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            printDocument1.PrintPage += printDocument1_PrintPage;

            printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
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
            int flightId = (int)flightNumComboBox.SelectedValue;
            string passportNumber = passportNumTxtBx.Text.Trim();

            if (string.IsNullOrEmpty(passportNumber))
            {
                MessageBox.Show("Паспортын дугаараа оруулна уу.");
                return;
            }

            var passenger = await _passengerRepository.GetPassengerByPassportAndFlightAsync(passportNumber, flightId);

            if (passenger == null)
            {
                MessageBox.Show($"{flightNumber} дугаартай нислэгт {passportNumber} паспортын дугаартай зорчигч олдсонгүй.");
                return;
            }

            // ListView тохиргоо
            listView1.Clear(); // баганууд болон өгөгдлийг бүгдийг цэвэрлэнэ
            listView1.View = View.Details;
            listView1.Columns.Add("Талбар", 120);
            listView1.Columns.Add("Мэдээлэл", 200);

            // Босоо харуулалт хийх мөрүүд нэмэх
            listView1.Items.Add(new ListViewItem(new[] { "Нэр", passenger.FirstName }));
            listView1.Items.Add(new ListViewItem(new[] { "Овог", passenger.LastName }));
            listView1.Items.Add(new ListViewItem(new[] { "Паспорт", passenger.PassportNumber }));
            listView1.Items.Add(new ListViewItem(new[] { "Нислэгийн ID", flightId.ToString() }));

            _currentPassengerId = passenger.PassengerId;
            passengerFound = true;
            // passenger oldoj baij batalgaajuulah panel haragdana
            panelSeatConfirm.Visible = false;

        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void appbar_Click(object sender, EventArgs e)
        {

        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            if (passengerFound)
            {
                // Gather personal info from ListView
                StringBuilder infoBuilder = new StringBuilder();
                foreach (ListViewItem item in listView1.Items)
                {
                    infoBuilder.AppendLine($"{item.SubItems[0].Text}: {item.SubItems[1].Text}");
                }

                // Show seat number and personal info together
                panelSeatConfirm.Visible = true;
                lblSeatConfirm.Text = $"Суудал: {((Button)sender).Text}\n{infoBuilder}";
            }
            else
            {
                MessageBox.Show("Эхлээд зорчигчийг хайна уу.");
            }
        }


        private void panelSeatConfirm_Paint(object sender, PaintEventArgs e)
        {

        }

        private readonly SocketClient _socketClient = new SocketClient();

        private async void btnSuudalConfirm_Click(object sender, EventArgs e)
        {
            if (!passengerFound || _currentPassengerId == 0)
            {
                MessageBox.Show("Зорчигчийг эхлээд сонгоно уу.");
                return;
            }

            string seatText = lblSeatConfirm.Text;
            string seatNumber = seatText.Split('\n')[0].Replace("Суудал: ", "").Trim();
            int flightId = (int)flightNumComboBox.SelectedValue;

            // ✈️ 1. Socket холболт
            bool connected = await _socketClient.ConnectAsync("localhost", 9000);
            if (!connected)
            {
                MessageBox.Show("Сервертэй холбогдож чадсангүй.");
                return;
            }

            // 📨 2. Захиалгын JSON бүрдүүлэлт
            var payload = new
            {
                action = "reserveSeat",
                flightId = flightId,
                passengerId = _currentPassengerId,
                seatNumber = seatNumber
            };

            string json = System.Text.Json.JsonSerializer.Serialize(payload);
            await _socketClient.SendAsync(json);

            // 📥 3. Серверийн хариуг авах
            string? response = await _socketClient.ReceiveAsync();
            if (response == null)
            {
                MessageBox.Show("Серверээс хариу ирсэнгүй.");
                return;
            }

            // 📋 4. Хариуг унших
            var result = System.Text.Json.JsonSerializer.Deserialize<SocketResponse>(response);
            if (result?.status == "success")
            {
                MessageBox.Show(result.message);

                var passenger = await _passengerRepository.GetPassengerByIdAsync(_currentPassengerId);
                var flight = await _flightRepository.GetByIdAsync(flightId);

                passengerName = $"{passenger.LastName} {passenger.FirstName}";
                flightNumber = flight.FlightNumber;
                this.seatNumber = seatNumber;

                btnPrint.Enabled = true;
            }
            else
            {
                MessageBox.Show(result?.message ?? "Алдаа гарлаа.");
            }

            _socketClient.Disconnect();
        }

        // ✅ Дотоод туслах загвар
        public class SocketResponse
        {
            public string status { get; set; } = "";
            public string message { get; set; } = "";
        }

        private void btnSuudalCancel_Click(object sender, EventArgs e)
        {
            // Hide the seat confirmation panel
            panelSeatConfirm.Visible = false;

            // Clear the seat confirmation label
            lblSeatConfirm.Text = string.Empty;

            // Clear the ListView with passenger info
            listView1.Items.Clear();
            listView1.Columns.Clear();

            // Reset state variables
            passengerFound = false;
            _currentPassengerId = 0;
            passengerName = string.Empty;
            flightNumber = string.Empty;
            seatNumber = string.Empty;

            // Optionally, disable the print button
            btnPrint.Enabled = false;
        }



        private void btnChangeTolow_Click(object sender, EventArgs e)
        {

        }

        private void Tolow_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;

        }

        private void lblSeatConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
