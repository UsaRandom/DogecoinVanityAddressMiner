namespace DogecoinAddressMiner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mineButton = new Button();
            pictureBox1 = new PictureBox();
            startChar0 = new TextBox();
            startChar1 = new TextBox();
            startChar2 = new TextBox();
            startChar3 = new TextBox();
            startChar4 = new TextBox();
            dLabel = new Label();
            endChar3 = new TextBox();
            endChar2 = new TextBox();
            endChar1 = new TextBox();
            endChar0 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            speedLabel = new Label();
            outputBox = new TextBox();
            matchLabel = new Label();
            matchTextBox = new TextBox();
            matchQRPicture = new PictureBox();
            titleLabel = new Label();
            labelDifficulty = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matchQRPicture).BeginInit();
            SuspendLayout();
            // 
            // mineButton
            // 
            mineButton.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            mineButton.Location = new Point(574, 73);
            mineButton.Name = "mineButton";
            mineButton.Size = new Size(95, 33);
            mineButton.TabIndex = 99;
            mineButton.Text = "Mine";
            mineButton.UseVisualStyleBackColor = true;
            mineButton.Click += mineButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.dogecoinvanity2;
            pictureBox1.Location = new Point(47, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // startChar0
            // 
            startChar0.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            startChar0.Location = new Point(229, 74);
            startChar0.MaxLength = 1;
            startChar0.Name = "startChar0";
            startChar0.Size = new Size(26, 34);
            startChar0.TabIndex = 0;
            startChar0.TextAlign = HorizontalAlignment.Center;
            startChar0.TextChanged += InputTextChanged;
            // 
            // startChar1
            // 
            startChar1.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            startChar1.Location = new Point(261, 74);
            startChar1.MaxLength = 1;
            startChar1.Name = "startChar1";
            startChar1.Size = new Size(26, 34);
            startChar1.TabIndex = 1;
            startChar1.TextAlign = HorizontalAlignment.Center;
            startChar1.TextChanged += InputTextChanged;
            // 
            // startChar2
            // 
            startChar2.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            startChar2.Location = new Point(293, 74);
            startChar2.MaxLength = 1;
            startChar2.Name = "startChar2";
            startChar2.Size = new Size(26, 34);
            startChar2.TabIndex = 2;
            startChar2.TextAlign = HorizontalAlignment.Center;
            startChar2.TextChanged += InputTextChanged;
            // 
            // startChar3
            // 
            startChar3.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            startChar3.Location = new Point(325, 74);
            startChar3.MaxLength = 1;
            startChar3.Name = "startChar3";
            startChar3.Size = new Size(26, 34);
            startChar3.TabIndex = 3;
            startChar3.TextAlign = HorizontalAlignment.Center;
            startChar3.TextChanged += InputTextChanged;
            // 
            // startChar4
            // 
            startChar4.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            startChar4.Location = new Point(357, 74);
            startChar4.MaxLength = 1;
            startChar4.Name = "startChar4";
            startChar4.Size = new Size(26, 34);
            startChar4.TabIndex = 4;
            startChar4.TextAlign = HorizontalAlignment.Center;
            startChar4.TextChanged += InputTextChanged;
            // 
            // dLabel
            // 
            dLabel.AutoSize = true;
            dLabel.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dLabel.ForeColor = Color.White;
            dLabel.Location = new Point(206, 77);
            dLabel.Name = "dLabel";
            dLabel.Size = new Size(26, 26);
            dLabel.TabIndex = 104;
            dLabel.Text = "D";
            // 
            // endChar3
            // 
            endChar3.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            endChar3.Location = new Point(514, 74);
            endChar3.MaxLength = 1;
            endChar3.Name = "endChar3";
            endChar3.Size = new Size(26, 34);
            endChar3.TabIndex = 8;
            endChar3.TextAlign = HorizontalAlignment.Center;
            endChar3.TextChanged += InputTextChanged;
            // 
            // endChar2
            // 
            endChar2.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            endChar2.Location = new Point(482, 74);
            endChar2.MaxLength = 1;
            endChar2.Name = "endChar2";
            endChar2.Size = new Size(26, 34);
            endChar2.TabIndex = 7;
            endChar2.TextAlign = HorizontalAlignment.Center;
            endChar2.TextChanged += InputTextChanged;
            // 
            // endChar1
            // 
            endChar1.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            endChar1.Location = new Point(450, 74);
            endChar1.MaxLength = 1;
            endChar1.Name = "endChar1";
            endChar1.Size = new Size(26, 34);
            endChar1.TabIndex = 6;
            endChar1.TextAlign = HorizontalAlignment.Center;
            endChar1.TextChanged += InputTextChanged;
            // 
            // endChar0
            // 
            endChar0.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            endChar0.Location = new Point(418, 74);
            endChar0.MaxLength = 1;
            endChar0.Name = "endChar0";
            endChar0.Size = new Size(26, 34);
            endChar0.TabIndex = 5;
            endChar0.TextAlign = HorizontalAlignment.Center;
            endChar0.TextChanged += InputTextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(389, 77);
            label2.Name = "label2";
            label2.Size = new Size(24, 26);
            label2.TabIndex = 109;
            label2.Text = "...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(24, 24, 24);
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(239, 56);
            label3.Name = "label3";
            label3.Size = new Size(82, 17);
            label3.TabIndex = 110;
            label3.Text = "Starts With:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(24, 24, 24);
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(430, 56);
            label4.Name = "label4";
            label4.Size = new Size(70, 17);
            label4.TabIndex = 111;
            label4.Text = "Ends With:";
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            speedLabel.ForeColor = Color.White;
            speedLabel.Location = new Point(206, 145);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(131, 23);
            speedLabel.TabIndex = 112;
            speedLabel.Text = "Addresses/Sec: ";
            // 
            // outputBox
            // 
            outputBox.BackColor = SystemColors.WindowFrame;
            outputBox.BorderStyle = BorderStyle.FixedSingle;
            outputBox.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            outputBox.ForeColor = Color.WhiteSmoke;
            outputBox.Location = new Point(12, 180);
            outputBox.Multiline = true;
            outputBox.Name = "outputBox";
            outputBox.ReadOnly = true;
            outputBox.Size = new Size(371, 276);
            outputBox.TabIndex = 113;
            outputBox.TabStop = false;
            // 
            // matchLabel
            // 
            matchLabel.AutoSize = true;
            matchLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            matchLabel.ForeColor = Color.White;
            matchLabel.Location = new Point(480, 147);
            matchLabel.Name = "matchLabel";
            matchLabel.Size = new Size(0, 23);
            matchLabel.TabIndex = 114;
            matchLabel.Tag = "";
            // 
            // matchTextBox
            // 
            matchTextBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            matchTextBox.Location = new Point(395, 180);
            matchTextBox.Name = "matchTextBox";
            matchTextBox.Size = new Size(294, 24);
            matchTextBox.TabIndex = 115;
            matchTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // matchQRPicture
            // 
            matchQRPicture.Location = new Point(426, 216);
            matchQRPicture.Name = "matchQRPicture";
            matchQRPicture.Size = new Size(235, 235);
            matchQRPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            matchQRPicture.TabIndex = 116;
            matchQRPicture.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(281, 19);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(301, 27);
            titleLabel.TabIndex = 117;
            titleLabel.Text = "Dogecoin Vanity Address Miner";
            // 
            // labelDifficulty
            // 
            labelDifficulty.AutoSize = true;
            labelDifficulty.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDifficulty.ForeColor = Color.White;
            labelDifficulty.Location = new Point(206, 122);
            labelDifficulty.Name = "labelDifficulty";
            labelDifficulty.Size = new Size(90, 23);
            labelDifficulty.TabIndex = 118;
            labelDifficulty.Text = "Difficulty:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(695, 468);
            Controls.Add(labelDifficulty);
            Controls.Add(titleLabel);
            Controls.Add(matchQRPicture);
            Controls.Add(matchTextBox);
            Controls.Add(matchLabel);
            Controls.Add(outputBox);
            Controls.Add(speedLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(endChar3);
            Controls.Add(endChar2);
            Controls.Add(endChar1);
            Controls.Add(endChar0);
            Controls.Add(startChar0);
            Controls.Add(dLabel);
            Controls.Add(startChar4);
            Controls.Add(startChar3);
            Controls.Add(startChar2);
            Controls.Add(startChar1);
            Controls.Add(pictureBox1);
            Controls.Add(mineButton);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Dogecoin Vanity Address Miner";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)matchQRPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button mineButton;
        private PictureBox pictureBox1;
        private TextBox startChar0;
        private TextBox startChar1;
        private TextBox startChar2;
        private TextBox startChar3;
        private TextBox startChar4;
        private Label dLabel;
        private TextBox endChar3;
        private TextBox endChar2;
        private TextBox endChar1;
        private TextBox endChar0;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label speedLabel;
        private TextBox outputBox;
        private Label matchLabel;
        private TextBox matchTextBox;
        private PictureBox matchQRPicture;
        private Label titleLabel;
        private Label labelDifficulty;
    }
}
