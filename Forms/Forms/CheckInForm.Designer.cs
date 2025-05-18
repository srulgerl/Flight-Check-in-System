namespace WinForms.Forms
{
    partial class CheckInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            appbar = new Label();
            lblNislegNumber = new Label();
            lbldate = new Label();
            lblEmployee = new Label();
            btnexit = new Button();
            label1 = new Label();
            lblUserSearch = new Label();
            LblPasswordNumber = new Label();
            labelBG4 = new Label();
            labelback3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnPasswordSearch = new Button();
            btnSeatA1 = new Button();
            BtnSeatC1 = new Button();
            BtnSeatB2 = new Button();
            BtnSeatA2 = new Button();
            BtnSeatB1 = new Button();
            BtnSeatB4 = new Button();
            BtnSeatA4 = new Button();
            BtnSeatB3 = new Button();
            BtnSeatA3 = new Button();
            BtnSeatD2 = new Button();
            BtnSeatC2 = new Button();
            BtnSeatD1 = new Button();
            BtnSeatB6 = new Button();
            BtnSeatA6 = new Button();
            BtnSeatB5 = new Button();
            BtnSeatA5 = new Button();
            BtnSeatC4 = new Button();
            BtnSeatD4 = new Button();
            BtnSeatD3 = new Button();
            BtnSeatC3 = new Button();
            BtnSeatC6 = new Button();
            BtnSeatC5 = new Button();
            BtnSeatD5 = new Button();
            BtnSeatD6 = new Button();
            LabelSeatsLoc = new Label();
            lblbusinessSeats = new Label();
            lblEngiinSeats = new Label();
            lblSuudalBatlah = new Label();
            label2 = new Label();
            btnSuudalConfirm = new Button();
            HereglegchiinMedeelelHaruulah = new DataGridView();
            lblUserInfo = new Label();
            dataGridView1 = new DataGridView();
            btnSuudalCancel = new Button();
            label3 = new Label();
            comboBox1 = new ComboBox();
            btnChangeTolow = new Button();
            btnPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)HereglegchiinMedeelelHaruulah).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // appbar
            // 
            appbar.BackColor = SystemColors.ControlLight;
            appbar.Location = new Point(0, -2);
            appbar.Name = "appbar";
            appbar.Size = new Size(1005, 81);
            appbar.TabIndex = 0;
            appbar.Click += appbar_Click;
            // 
            // lblNislegNumber
            // 
            lblNislegNumber.AutoSize = true;
            lblNislegNumber.BackColor = SystemColors.ControlLight;
            lblNislegNumber.Location = new Point(0, 24);
            lblNislegNumber.Name = "lblNislegNumber";
            lblNislegNumber.Size = new Size(134, 20);
            lblNislegNumber.TabIndex = 1;
            lblNislegNumber.Text = "Нислэгийн дугаар";
            // 
            // lbldate
            // 
            lbldate.AutoSize = true;
            lbldate.BackColor = SystemColors.ControlLight;
            lbldate.Location = new Point(292, 24);
            lbldate.Name = "lbldate";
            lbldate.Size = new Size(53, 20);
            lbldate.TabIndex = 2;
            lbldate.Text = "Огноо";
            lbldate.Click += lbldate_Click;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.BackColor = SystemColors.ControlLight;
            lblEmployee.Location = new Point(527, 24);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(180, 20);
            lblEmployee.TabIndex = 3;
            lblEmployee.Text = "Ажилтан: А.Мөнгөнтулга";
            // 
            // btnexit
            // 
            btnexit.Location = new Point(805, 20);
            btnexit.Name = "btnexit";
            btnexit.Size = new Size(94, 29);
            btnexit.TabIndex = 4;
            btnexit.Text = "Гарах";
            btnexit.UseVisualStyleBackColor = true;
            btnexit.Click += btnexit_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.Location = new Point(0, 89);
            label1.Name = "label1";
            label1.Size = new Size(307, 302);
            label1.TabIndex = 5;
            label1.Click += label1_Click;
            // 
            // lblUserSearch
            // 
            lblUserSearch.AutoSize = true;
            lblUserSearch.BackColor = SystemColors.ControlLight;
            lblUserSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserSearch.Location = new Point(78, 89);
            lblUserSearch.Name = "lblUserSearch";
            lblUserSearch.Size = new Size(105, 20);
            lblUserSearch.TabIndex = 6;
            lblUserSearch.Text = "Зорчигч хайх";
            // 
            // LblPasswordNumber
            // 
            LblPasswordNumber.AutoSize = true;
            LblPasswordNumber.BackColor = SystemColors.ControlLight;
            LblPasswordNumber.Location = new Point(0, 125);
            LblPasswordNumber.Name = "LblPasswordNumber";
            LblPasswordNumber.Size = new Size(138, 20);
            LblPasswordNumber.TabIndex = 7;
            LblPasswordNumber.Text = "Паспортын дугаар";
            // 
            // labelBG4
            // 
            labelBG4.BackColor = SystemColors.ControlLight;
            labelBG4.Location = new Point(721, 89);
            labelBG4.Name = "labelBG4";
            labelBG4.Size = new Size(284, 302);
            labelBG4.TabIndex = 9;
            // 
            // labelback3
            // 
            labelback3.BackColor = SystemColors.ControlLight;
            labelback3.Location = new Point(313, 89);
            labelback3.Name = "labelback3";
            labelback3.Size = new Size(402, 487);
            labelback3.TabIndex = 10;
            labelback3.Click += label3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(96, 27);
            textBox1.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(9, 148);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 12;
            // 
            // btnPasswordSearch
            // 
            btnPasswordSearch.Location = new Point(140, 147);
            btnPasswordSearch.Name = "btnPasswordSearch";
            btnPasswordSearch.Size = new Size(66, 29);
            btnPasswordSearch.TabIndex = 13;
            btnPasswordSearch.Text = "Хайх";
            btnPasswordSearch.UseVisualStyleBackColor = true;
            // 
            // btnSeatA1
            // 
            btnSeatA1.Location = new Point(410, 146);
            btnSeatA1.Name = "btnSeatA1";
            btnSeatA1.Size = new Size(37, 29);
            btnSeatA1.TabIndex = 19;
            btnSeatA1.Text = "A1";
            btnSeatA1.UseVisualStyleBackColor = true;
            btnSeatA1.Click += btnSeatA1_Click;
            // 
            // BtnSeatC1
            // 
            BtnSeatC1.Location = new Point(536, 146);
            BtnSeatC1.Name = "BtnSeatC1";
            BtnSeatC1.Size = new Size(37, 29);
            BtnSeatC1.TabIndex = 20;
            BtnSeatC1.Text = "C1";
            BtnSeatC1.UseVisualStyleBackColor = true;
            // 
            // BtnSeatB2
            // 
            BtnSeatB2.Location = new Point(453, 181);
            BtnSeatB2.Name = "BtnSeatB2";
            BtnSeatB2.Size = new Size(37, 29);
            BtnSeatB2.TabIndex = 21;
            BtnSeatB2.Text = "B2";
            BtnSeatB2.UseVisualStyleBackColor = true;
            BtnSeatB2.Click += btnSeatA1_Click;
            // 
            // BtnSeatA2
            // 
            BtnSeatA2.Location = new Point(410, 181);
            BtnSeatA2.Name = "BtnSeatA2";
            BtnSeatA2.Size = new Size(37, 29);
            BtnSeatA2.TabIndex = 22;
            BtnSeatA2.Text = "A2";
            BtnSeatA2.UseVisualStyleBackColor = true;
            BtnSeatA2.Click += btnSeatA1_Click;
            // 
            // BtnSeatB1
            // 
            BtnSeatB1.Location = new Point(453, 146);
            BtnSeatB1.Name = "BtnSeatB1";
            BtnSeatB1.Size = new Size(37, 29);
            BtnSeatB1.TabIndex = 23;
            BtnSeatB1.Text = "B1";
            BtnSeatB1.UseVisualStyleBackColor = true;
            BtnSeatB1.Click += btnSeatA1_Click;
            // 
            // BtnSeatB4
            // 
            BtnSeatB4.Location = new Point(453, 270);
            BtnSeatB4.Name = "BtnSeatB4";
            BtnSeatB4.Size = new Size(37, 29);
            BtnSeatB4.TabIndex = 24;
            BtnSeatB4.Text = "B4";
            BtnSeatB4.UseVisualStyleBackColor = true;
            BtnSeatB4.Click += btnSeatA1_Click;
            // 
            // BtnSeatA4
            // 
            BtnSeatA4.Location = new Point(410, 270);
            BtnSeatA4.Name = "BtnSeatA4";
            BtnSeatA4.Size = new Size(37, 29);
            BtnSeatA4.TabIndex = 25;
            BtnSeatA4.Text = "A4";
            BtnSeatA4.UseVisualStyleBackColor = true;
            BtnSeatA4.Click += btnSeatA1_Click;
            // 
            // BtnSeatB3
            // 
            BtnSeatB3.Location = new Point(453, 236);
            BtnSeatB3.Name = "BtnSeatB3";
            BtnSeatB3.Size = new Size(37, 29);
            BtnSeatB3.TabIndex = 26;
            BtnSeatB3.Text = "B3";
            BtnSeatB3.UseVisualStyleBackColor = true;
            BtnSeatB3.Click += btnSeatA1_Click;
            // 
            // BtnSeatA3
            // 
            BtnSeatA3.Location = new Point(410, 236);
            BtnSeatA3.Name = "BtnSeatA3";
            BtnSeatA3.Size = new Size(37, 29);
            BtnSeatA3.TabIndex = 27;
            BtnSeatA3.Text = "A3";
            BtnSeatA3.UseVisualStyleBackColor = true;
            BtnSeatA3.Click += btnSeatA1_Click;
            // 
            // BtnSeatD2
            // 
            BtnSeatD2.Location = new Point(579, 181);
            BtnSeatD2.Name = "BtnSeatD2";
            BtnSeatD2.Size = new Size(37, 29);
            BtnSeatD2.TabIndex = 28;
            BtnSeatD2.Text = "D2";
            BtnSeatD2.UseVisualStyleBackColor = true;
            // 
            // BtnSeatC2
            // 
            BtnSeatC2.Location = new Point(536, 181);
            BtnSeatC2.Name = "BtnSeatC2";
            BtnSeatC2.Size = new Size(37, 29);
            BtnSeatC2.TabIndex = 29;
            BtnSeatC2.Text = "C2";
            BtnSeatC2.UseVisualStyleBackColor = true;
            // 
            // BtnSeatD1
            // 
            BtnSeatD1.Location = new Point(579, 148);
            BtnSeatD1.Name = "BtnSeatD1";
            BtnSeatD1.Size = new Size(37, 29);
            BtnSeatD1.TabIndex = 30;
            BtnSeatD1.Text = "D1";
            BtnSeatD1.UseVisualStyleBackColor = true;
            // 
            // BtnSeatB6
            // 
            BtnSeatB6.Location = new Point(453, 340);
            BtnSeatB6.Name = "BtnSeatB6";
            BtnSeatB6.Size = new Size(37, 29);
            BtnSeatB6.TabIndex = 31;
            BtnSeatB6.Text = "B6";
            BtnSeatB6.UseVisualStyleBackColor = true;
            BtnSeatB6.Click += btnSeatA1_Click;
            // 
            // BtnSeatA6
            // 
            BtnSeatA6.Location = new Point(410, 340);
            BtnSeatA6.Name = "BtnSeatA6";
            BtnSeatA6.Size = new Size(37, 29);
            BtnSeatA6.TabIndex = 32;
            BtnSeatA6.Text = "A6";
            BtnSeatA6.UseVisualStyleBackColor = true;
            BtnSeatA6.Click += btnSeatA1_Click;
            // 
            // BtnSeatB5
            // 
            BtnSeatB5.Location = new Point(453, 305);
            BtnSeatB5.Name = "BtnSeatB5";
            BtnSeatB5.Size = new Size(37, 29);
            BtnSeatB5.TabIndex = 33;
            BtnSeatB5.Text = "B5";
            BtnSeatB5.UseVisualStyleBackColor = true;
            BtnSeatB5.Click += btnSeatA1_Click;
            // 
            // BtnSeatA5
            // 
            BtnSeatA5.Location = new Point(410, 305);
            BtnSeatA5.Name = "BtnSeatA5";
            BtnSeatA5.Size = new Size(37, 29);
            BtnSeatA5.TabIndex = 34;
            BtnSeatA5.Text = "A5";
            BtnSeatA5.UseVisualStyleBackColor = true;
            BtnSeatA5.Click += btnSeatA1_Click;
            // 
            // BtnSeatC4
            // 
            BtnSeatC4.Location = new Point(536, 270);
            BtnSeatC4.Name = "BtnSeatC4";
            BtnSeatC4.Size = new Size(37, 29);
            BtnSeatC4.TabIndex = 35;
            BtnSeatC4.Text = "C4";
            BtnSeatC4.UseVisualStyleBackColor = true;
            // 
            // BtnSeatD4
            // 
            BtnSeatD4.Location = new Point(579, 270);
            BtnSeatD4.Name = "BtnSeatD4";
            BtnSeatD4.Size = new Size(37, 29);
            BtnSeatD4.TabIndex = 36;
            BtnSeatD4.Text = "D4";
            BtnSeatD4.UseVisualStyleBackColor = true;
            // 
            // BtnSeatD3
            // 
            BtnSeatD3.Location = new Point(579, 236);
            BtnSeatD3.Name = "BtnSeatD3";
            BtnSeatD3.Size = new Size(37, 29);
            BtnSeatD3.TabIndex = 37;
            BtnSeatD3.Text = "D3";
            BtnSeatD3.UseVisualStyleBackColor = true;
            // 
            // BtnSeatC3
            // 
            BtnSeatC3.Location = new Point(536, 236);
            BtnSeatC3.Name = "BtnSeatC3";
            BtnSeatC3.Size = new Size(37, 29);
            BtnSeatC3.TabIndex = 38;
            BtnSeatC3.Text = "C3";
            BtnSeatC3.UseVisualStyleBackColor = true;
            // 
            // BtnSeatC6
            // 
            BtnSeatC6.Location = new Point(536, 340);
            BtnSeatC6.Name = "BtnSeatC6";
            BtnSeatC6.Size = new Size(37, 29);
            BtnSeatC6.TabIndex = 39;
            BtnSeatC6.Text = "C6";
            BtnSeatC6.UseVisualStyleBackColor = true;
            // 
            // BtnSeatC5
            // 
            BtnSeatC5.Location = new Point(536, 305);
            BtnSeatC5.Name = "BtnSeatC5";
            BtnSeatC5.Size = new Size(37, 29);
            BtnSeatC5.TabIndex = 40;
            BtnSeatC5.Text = "C5";
            BtnSeatC5.UseVisualStyleBackColor = true;
            // 
            // BtnSeatD5
            // 
            BtnSeatD5.Location = new Point(579, 305);
            BtnSeatD5.Name = "BtnSeatD5";
            BtnSeatD5.Size = new Size(37, 29);
            BtnSeatD5.TabIndex = 41;
            BtnSeatD5.Text = "D5";
            BtnSeatD5.UseVisualStyleBackColor = true;
            // 
            // BtnSeatD6
            // 
            BtnSeatD6.Location = new Point(579, 340);
            BtnSeatD6.Name = "BtnSeatD6";
            BtnSeatD6.Size = new Size(37, 29);
            BtnSeatD6.TabIndex = 42;
            BtnSeatD6.Text = "D6";
            BtnSeatD6.UseVisualStyleBackColor = true;
            // 
            // LabelSeatsLoc
            // 
            LabelSeatsLoc.AutoSize = true;
            LabelSeatsLoc.BackColor = SystemColors.ControlLight;
            LabelSeatsLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelSeatsLoc.Location = new Point(431, 89);
            LabelSeatsLoc.Name = "LabelSeatsLoc";
            LabelSeatsLoc.Size = new Size(142, 20);
            LabelSeatsLoc.TabIndex = 43;
            LabelSeatsLoc.Text = "Суудлын байршил";
            LabelSeatsLoc.Click += LabelSeatsLoc_Click;
            // 
            // lblbusinessSeats
            // 
            lblbusinessSeats.AutoSize = true;
            lblbusinessSeats.BackColor = SystemColors.ControlLight;
            lblbusinessSeats.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblbusinessSeats.Location = new Point(485, 125);
            lblbusinessSeats.Name = "lblbusinessSeats";
            lblbusinessSeats.Size = new Size(48, 17);
            lblbusinessSeats.TabIndex = 44;
            lblbusinessSeats.Text = "Бизнес";
            // 
            // lblEngiinSeats
            // 
            lblEngiinSeats.AutoSize = true;
            lblEngiinSeats.BackColor = SystemColors.ControlLight;
            lblEngiinSeats.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEngiinSeats.Location = new Point(485, 216);
            lblEngiinSeats.Name = "lblEngiinSeats";
            lblEngiinSeats.Size = new Size(49, 17);
            lblEngiinSeats.TabIndex = 45;
            lblEngiinSeats.Text = "Энгийн";
            // 
            // lblSuudalBatlah
            // 
            lblSuudalBatlah.AutoSize = true;
            lblSuudalBatlah.BackColor = SystemColors.ControlLight;
            lblSuudalBatlah.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSuudalBatlah.Location = new Point(783, 89);
            lblSuudalBatlah.Name = "lblSuudalBatlah";
            lblSuudalBatlah.Size = new Size(179, 20);
            lblSuudalBatlah.TabIndex = 46;
            lblSuudalBatlah.Text = "Суудал баталгаажуулах";
            // 
            // label2
            // 
            label2.Location = new Point(366, 123);
            label2.Name = "label2";
            label2.Size = new Size(280, 313);
            label2.TabIndex = 47;
            // 
            // btnSuudalConfirm
            // 
            btnSuudalConfirm.BackColor = SystemColors.InactiveCaption;
            btnSuudalConfirm.Location = new Point(736, 348);
            btnSuudalConfirm.Name = "btnSuudalConfirm";
            btnSuudalConfirm.Size = new Size(134, 29);
            btnSuudalConfirm.TabIndex = 48;
            btnSuudalConfirm.Text = "Баталгаажуулах";
            btnSuudalConfirm.UseVisualStyleBackColor = false;
            // 
            // HereglegchiinMedeelelHaruulah
            // 
            HereglegchiinMedeelelHaruulah.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HereglegchiinMedeelelHaruulah.Location = new Point(0, 202);
            HereglegchiinMedeelelHaruulah.Name = "HereglegchiinMedeelelHaruulah";
            HereglegchiinMedeelelHaruulah.RowHeadersWidth = 51;
            HereglegchiinMedeelelHaruulah.Size = new Size(307, 175);
            HereglegchiinMedeelelHaruulah.TabIndex = 49;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.BackColor = SystemColors.ControlLight;
            lblUserInfo.Location = new Point(0, 178);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(160, 20);
            lblUserInfo.TabIndex = 50;
            lblUserInfo.Text = "Зорчигчийн мэдээлэл";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(736, 123);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(254, 211);
            dataGridView1.TabIndex = 51;
            // 
            // btnSuudalCancel
            // 
            btnSuudalCancel.BackColor = SystemColors.InactiveCaption;
            btnSuudalCancel.Location = new Point(891, 348);
            btnSuudalCancel.Name = "btnSuudalCancel";
            btnSuudalCancel.Size = new Size(99, 29);
            btnSuudalCancel.TabIndex = 52;
            btnSuudalCancel.Text = "Цуцлах";
            btnSuudalCancel.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ControlLight;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(721, 397);
            label3.Name = "label3";
            label3.Size = new Size(284, 91);
            label3.TabIndex = 53;
            label3.Text = "   Нислэгийн төлөв";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Бүртгэж байна", "Онгоцонд сууж байна", "Ниссэн", "Хойшилсон", "Цуцалсан" });
            comboBox1.Location = new Point(736, 430);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 54;
            // 
            // btnChangeTolow
            // 
            btnChangeTolow.Location = new Point(893, 430);
            btnChangeTolow.Name = "btnChangeTolow";
            btnChangeTolow.Size = new Size(94, 29);
            btnChangeTolow.TabIndex = 55;
            btnChangeTolow.Text = "Солих";
            btnChangeTolow.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = SystemColors.ActiveCaptionText;
            btnPrint.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = SystemColors.ControlLightLight;
            btnPrint.Location = new Point(736, 500);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(251, 76);
            btnPrint.TabIndex = 56;
            btnPrint.Text = "Тасалбар хэвлэх";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // CheckInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 648);
            Controls.Add(btnPrint);
            Controls.Add(btnChangeTolow);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(btnSuudalCancel);
            Controls.Add(dataGridView1);
            Controls.Add(lblUserInfo);
            Controls.Add(HereglegchiinMedeelelHaruulah);
            Controls.Add(btnSuudalConfirm);
            Controls.Add(lblSuudalBatlah);
            Controls.Add(lblEngiinSeats);
            Controls.Add(lblbusinessSeats);
            Controls.Add(LabelSeatsLoc);
            Controls.Add(BtnSeatD6);
            Controls.Add(BtnSeatD5);
            Controls.Add(BtnSeatC5);
            Controls.Add(BtnSeatC6);
            Controls.Add(BtnSeatC3);
            Controls.Add(BtnSeatD3);
            Controls.Add(BtnSeatD4);
            Controls.Add(BtnSeatC4);
            Controls.Add(BtnSeatA5);
            Controls.Add(BtnSeatB5);
            Controls.Add(BtnSeatA6);
            Controls.Add(BtnSeatB6);
            Controls.Add(BtnSeatD1);
            Controls.Add(BtnSeatC2);
            Controls.Add(BtnSeatD2);
            Controls.Add(BtnSeatA3);
            Controls.Add(BtnSeatB3);
            Controls.Add(BtnSeatA4);
            Controls.Add(BtnSeatB4);
            Controls.Add(BtnSeatB1);
            Controls.Add(BtnSeatA2);
            Controls.Add(BtnSeatB2);
            Controls.Add(BtnSeatC1);
            Controls.Add(btnSeatA1);
            Controls.Add(btnPasswordSearch);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(labelBG4);
            Controls.Add(LblPasswordNumber);
            Controls.Add(lblUserSearch);
            Controls.Add(label1);
            Controls.Add(btnexit);
            Controls.Add(lblEmployee);
            Controls.Add(lbldate);
            Controls.Add(lblNislegNumber);
            Controls.Add(appbar);
            Controls.Add(label2);
            Controls.Add(labelback3);
            Name = "CheckInForm";
            Text = "CheckInForm";
            Load += CheckInForm_Load;
            ((System.ComponentModel.ISupportInitialize)HereglegchiinMedeelelHaruulah).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appbar;
        private Label lblNislegNumber;
        private Label lbldate;
        private Label lblEmployee;
        private Button btnexit;
        private Label label1;
        private Label lblUserSearch;
        private Label LblPasswordNumber;
        private Label labelBG4;
        private Label labelback3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnPasswordSearch;
        private Button btnSeatA1;
        private Button BtnSeatC1;
        private Button BtnSeatB2;
        private Button BtnSeatA2;
        private Button BtnSeatB1;
        private Button BtnSeatB4;
        private Button BtnSeatA4;
        private Button BtnSeatB3;
        private Button BtnSeatA3;
        private Button BtnSeatD2;
        private Button BtnSeatC2;
        private Button BtnSeatD1;
        private Button BtnSeatB6;
        private Button BtnSeatA6;
        private Button BtnSeatB5;
        private Button BtnSeatA5;
        private Button BtnSeatC4;
        private Button BtnSeatD4;
        private Button BtnSeatD3;
        private Button BtnSeatC3;
        private Button BtnSeatC6;
        private Button BtnSeatC5;
        private Button BtnSeatD5;
        private Button BtnSeatD6;
        private Label LabelSeatsLoc;
        private Label lblbusinessSeats;
        private Label lblEngiinSeats;
        private Label lblSuudalBatlah;
        private Label label2;
        private Button btnSuudalConfirm;
        private DataGridView HereglegchiinMedeelelHaruulah;
        private Label lblUserInfo;
        private DataGridView dataGridView1;
        private Button btnSuudalCancel;
        private Label label3;
        private ComboBox comboBox1;
        private Button btnChangeTolow;
        private Button btnPrint;
    }
}