
namespace ooproj_lab4
{
    partial class VozacForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dozvolaDoPicker = new System.Windows.Forms.DateTimePicker();
            this.dozvolaOdpicker = new System.Windows.Forms.DateTimePicker();
            this.datumRodjenjaPicker = new System.Windows.Forms.DateTimePicker();
            this.txtMestoIzdavanja = new System.Windows.Forms.TextBox();
            this.txtBrojDozvole = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataKategorija = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataZabrana = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataKategorija)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataZabrana)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.dozvolaDoPicker);
            this.groupBox1.Controls.Add(this.dozvolaOdpicker);
            this.groupBox1.Controls.Add(this.datumRodjenjaPicker);
            this.groupBox1.Controls.Add(this.txtMestoIzdavanja);
            this.groupBox1.Controls.Add(this.txtBrojDozvole);
            this.groupBox1.Controls.Add(this.txtPrezime);
            this.groupBox1.Controls.Add(this.txtIme);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 382);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Osnovni podaci";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Dodaj sliku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(407, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 164);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "M",
            "Ž"});
            this.comboBox1.Location = new System.Drawing.Point(188, 293);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 28);
            this.comboBox1.TabIndex = 7;
            // 
            // dozvolaDoPicker
            // 
            this.dozvolaDoPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dozvolaDoPicker.Location = new System.Drawing.Point(188, 185);
            this.dozvolaDoPicker.Name = "dozvolaDoPicker";
            this.dozvolaDoPicker.Size = new System.Drawing.Size(125, 27);
            this.dozvolaDoPicker.TabIndex = 4;
            // 
            // dozvolaOdpicker
            // 
            this.dozvolaOdpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dozvolaOdpicker.Location = new System.Drawing.Point(188, 146);
            this.dozvolaOdpicker.Name = "dozvolaOdpicker";
            this.dozvolaOdpicker.Size = new System.Drawing.Size(125, 27);
            this.dozvolaOdpicker.TabIndex = 3;
            // 
            // datumRodjenjaPicker
            // 
            this.datumRodjenjaPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumRodjenjaPicker.Location = new System.Drawing.Point(188, 113);
            this.datumRodjenjaPicker.Name = "datumRodjenjaPicker";
            this.datumRodjenjaPicker.Size = new System.Drawing.Size(125, 27);
            this.datumRodjenjaPicker.TabIndex = 2;
            // 
            // txtMestoIzdavanja
            // 
            this.txtMestoIzdavanja.Location = new System.Drawing.Point(188, 254);
            this.txtMestoIzdavanja.Name = "txtMestoIzdavanja";
            this.txtMestoIzdavanja.Size = new System.Drawing.Size(125, 27);
            this.txtMestoIzdavanja.TabIndex = 6;
            this.txtMestoIzdavanja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIme_KeyPress);
            // 
            // txtBrojDozvole
            // 
            this.txtBrojDozvole.Location = new System.Drawing.Point(188, 218);
            this.txtBrojDozvole.Name = "txtBrojDozvole";
            this.txtBrojDozvole.Size = new System.Drawing.Size(125, 27);
            this.txtBrojDozvole.TabIndex = 5;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(188, 74);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(125, 27);
            this.txtPrezime.TabIndex = 1;
            this.txtPrezime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIme_KeyPress);
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(188, 38);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(125, 27);
            this.txtIme.TabIndex = 0;
            this.txtIme.TextChanged += new System.EventHandler(this.txtIme_TextChanged);
            this.txtIme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIme_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Pol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Važenje dozvole od";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Broj vozačke dozvole";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mesto izdavanja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Prezime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Važenje dozvole do";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Datum rođenja";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.dataKategorija);
            this.groupBox2.Location = new System.Drawing.Point(12, 413);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 233);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kategorija";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(461, 163);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 48);
            this.button3.TabIndex = 10;
            this.button3.Text = "Obriši \r\nkategoriju\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 48);
            this.button2.TabIndex = 9;
            this.button2.Text = "Dodaj novu \r\nkategoriju\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataKategorija
            // 
            this.dataKategorija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataKategorija.Location = new System.Drawing.Point(0, 26);
            this.dataKategorija.Name = "dataKategorija";
            this.dataKategorija.RowHeadersWidth = 51;
            this.dataKategorija.RowTemplate.Height = 29;
            this.dataKategorija.Size = new System.Drawing.Size(604, 120);
            this.dataKategorija.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.dataZabrana);
            this.groupBox3.Location = new System.Drawing.Point(12, 683);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 233);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zabrana upravljanja";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(461, 170);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 57);
            this.button4.TabIndex = 12;
            this.button4.Text = "Obriši \r\nzabranu\r\n";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 170);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 57);
            this.button5.TabIndex = 11;
            this.button5.Text = "Dodaj novu \r\nzabranu\r\n\r\n";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataZabrana
            // 
            this.dataZabrana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataZabrana.Location = new System.Drawing.Point(0, 26);
            this.dataZabrana.Name = "dataZabrana";
            this.dataZabrana.RowHeadersWidth = 51;
            this.dataZabrana.RowTemplate.Height = 29;
            this.dataZabrana.Size = new System.Drawing.Size(604, 120);
            this.dataZabrana.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(200, 939);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 29);
            this.button6.TabIndex = 13;
            this.button6.Text = "Prosledi";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(317, 939);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 29);
            this.button7.TabIndex = 14;
            this.button7.Text = "Zatvori";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // VozacForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 989);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VozacForm";
            this.Text = "VozacForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VozacForm_FormClosing);
            this.Load += new System.EventHandler(this.VozacForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataKategorija)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataZabrana)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dozvolaDoPicker;
        private System.Windows.Forms.DateTimePicker dozvolaOdpicker;
        private System.Windows.Forms.DateTimePicker datumRodjenjaPicker;
        private System.Windows.Forms.TextBox txtMestoIzdavanja;
        private System.Windows.Forms.TextBox txtBrojDozvole;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataKategorija;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataZabrana;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}