namespace Forms
{
    partial class burtgeh
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
            tsipr = new TextBox();
            useg2 = new ComboBox();
            useg1 = new ComboBox();
            newtreh = new Button();
            SuspendLayout();
            // 
            // tsipr
            // 
            tsipr.Location = new Point(352, 194);
            tsipr.Name = "tsipr";
            tsipr.Size = new Size(171, 27);
            tsipr.TabIndex = 0;
            tsipr.TextChanged += tsipr_TextChanged;
            // 
            // useg2
            // 
            useg2.FormattingEnabled = true;
            useg2.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
            useg2.Location = new Point(309, 193);
            useg2.Name = "useg2";
            useg2.Size = new Size(37, 28);
            useg2.TabIndex = 1;
            // 
            // useg1
            // 
            useg1.FormattingEnabled = true;
            useg1.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
            useg1.Location = new Point(264, 193);
            useg1.Name = "useg1";
            useg1.Size = new Size(39, 28);
            useg1.TabIndex = 2;
            useg1.SelectedIndexChanged += useg1_SelectedIndexChanged;
            // 
            // newtreh
            // 
            newtreh.Location = new Point(291, 236);
            newtreh.Name = "newtreh";
            newtreh.Size = new Size(190, 45);
            newtreh.TabIndex = 3;
            newtreh.Text = "Нэвтрэх";
            newtreh.UseVisualStyleBackColor = true;
            // 
            // burtgeh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newtreh);
            Controls.Add(useg1);
            Controls.Add(useg2);
            Controls.Add(tsipr);
            Name = "burtgeh";
            Text = "burtgeh";
            Load += burtgeh_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tsipr;
        private ComboBox useg2;
        private ComboBox useg1;
        private Button newtreh;
    }
}