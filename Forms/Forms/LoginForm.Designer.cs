namespace WinForms.Forms
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            nameTxtBx = new TextBox();
            passTxtBx = new TextBox();
            panel1 = new Panel();
            loginBtn = new Button();
            panel2 = new Panel();
            label3 = new Label();
            label4 = new Label();
            passportTxtBx = new TextBox();
            SearchBtn = new Button();
            panel3 = new Panel();
            label5 = new Label();
            LastNameLbl = new Label();
            FirstNameLbl = new Label();
            label8 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold);
            label1.Location = new Point(38, 88);
            label1.Name = "label1";
            label1.Size = new Size(255, 40);
            label1.TabIndex = 0;
            label1.Text = "Хэрэглэгчийн нэр";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold);
            label2.Location = new Point(38, 160);
            label2.Name = "label2";
            label2.Size = new Size(120, 40);
            label2.TabIndex = 1;
            label2.Text = "Нууц үг";
            // 
            // nameTxtBx
            // 
            nameTxtBx.Location = new Point(370, 91);
            nameTxtBx.Name = "nameTxtBx";
            nameTxtBx.Size = new Size(258, 39);
            nameTxtBx.TabIndex = 2;
            // 
            // passTxtBx
            // 
            passTxtBx.Location = new Point(370, 163);
            passTxtBx.Name = "passTxtBx";
            passTxtBx.Size = new Size(261, 39);
            passTxtBx.TabIndex = 3;
            passTxtBx.TextChanged += textBox2_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(loginBtn);
            panel1.Controls.Add(passTxtBx);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(nameTxtBx);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(176, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(682, 378);
            panel1.TabIndex = 4;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(246, 277);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(178, 64);
            loginBtn.TabIndex = 4;
            loginBtn.Text = "Нэвтрэх";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(SearchBtn);
            panel2.Controls.Add(passportTxtBx);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(1059, 76);
            panel2.Name = "panel2";
            panel2.Size = new Size(629, 931);
            panel2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 27);
            label3.Name = "label3";
            label3.Size = new Size(171, 32);
            label3.TabIndex = 0;
            label3.Text = "Зорчигч хайх";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 79);
            label4.Name = "label4";
            label4.Size = new Size(232, 32);
            label4.TabIndex = 1;
            label4.Text = "Пасспортын дугаар:";
            // 
            // passportTxtBx
            // 
            passportTxtBx.Location = new Point(34, 139);
            passportTxtBx.Name = "passportTxtBx";
            passportTxtBx.Size = new Size(332, 39);
            passportTxtBx.TabIndex = 2;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(393, 135);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(150, 46);
            SearchBtn.TabIndex = 3;
            SearchBtn.Text = "Хайх";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(FirstNameLbl);
            panel3.Controls.Add(LastNameLbl);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(28, 212);
            panel3.Name = "panel3";
            panel3.Size = new Size(566, 391);
            panel3.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 27);
            label5.Name = "label5";
            label5.Size = new Size(78, 32);
            label5.TabIndex = 0;
            label5.Text = "label5";
            label5.Click += label5_Click;
            // 
            // LastNameLbl
            // 
            LastNameLbl.AutoSize = true;
            LastNameLbl.Location = new Point(179, 81);
            LastNameLbl.Name = "LastNameLbl";
            LastNameLbl.Size = new Size(148, 32);
            LastNameLbl.TabIndex = 1;
            LastNameLbl.Text = "Otgonbaatar";
            // 
            // FirstNameLbl
            // 
            FirstNameLbl.AutoSize = true;
            FirstNameLbl.Location = new Point(217, 134);
            FirstNameLbl.Name = "FirstNameLbl";
            FirstNameLbl.Size = new Size(135, 32);
            FirstNameLbl.TabIndex = 2;
            FirstNameLbl.Text = "Saruulgerel";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(160, 190);
            label8.Name = "label8";
            label8.Size = new Size(78, 32);
            label8.TabIndex = 3;
            label8.Text = "label8";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(24, 224);
            label9.Name = "label9";
            label9.Size = new Size(78, 32);
            label9.TabIndex = 4;
            label9.Text = "label9";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1918, 1059);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

      

        #endregion

        private Label label1;
        private Label label2;
        private TextBox nameTxtBx;
        private TextBox passTxtBx;
        private Panel panel1;
        private Button loginBtn;
        private Panel panel2;
        private Button SearchBtn;
        private TextBox passportTxtBx;
        private Label label4;
        private Label label3;
        private Panel panel3;
        private Label label5;
        private Label label9;
        private Label label8;
        private Label FirstNameLbl;
        private Label LastNameLbl;
    }
}