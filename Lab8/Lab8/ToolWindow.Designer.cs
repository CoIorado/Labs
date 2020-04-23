namespace Lab8
{
    partial class ToolWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolWindow));
            this.tempField = new System.Windows.Forms.NumericUpDown();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.addeditPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.divider = new System.Windows.Forms.PictureBox();
            this.addButton = new ePOSOne.btnProduct.Button_WOC();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tip2 = new System.Windows.Forms.PictureBox();
            this.tip1 = new System.Windows.Forms.PictureBox();
            this.tempBox = new System.Windows.Forms.ComboBox();
            this.dayBox = new System.Windows.Forms.ComboBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.deletePanel = new System.Windows.Forms.Panel();
            this.divider2 = new System.Windows.Forms.PictureBox();
            this.delButton2 = new ePOSOne.btnProduct.Button_WOC();
            this.delButton1 = new ePOSOne.btnProduct.Button_WOC();
            this.dayLabel = new System.Windows.Forms.Label();
            this.tempLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tempField)).BeginInit();
            this.addeditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tip2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tip1)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.deletePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider2)).BeginInit();
            this.SuspendLayout();
            // 
            // tempField
            // 
            this.tempField.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tempField.Location = new System.Drawing.Point(256, 261);
            this.tempField.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.tempField.Name = "tempField";
            this.tempField.Size = new System.Drawing.Size(63, 28);
            this.tempField.TabIndex = 2;
            this.tempField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // monthCalendar
            // 
            this.monthCalendar.BackColor = System.Drawing.Color.White;
            this.monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.monthCalendar.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthCalendar.Location = new System.Drawing.Point(92, 61);
            this.monthCalendar.MaxDate = new System.DateTime(2020, 1, 31, 0, 0, 0, 0);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowToday = false;
            this.monthCalendar.ShowTodayCircle = false;
            this.monthCalendar.TabIndex = 0;
            // 
            // addeditPanel
            // 
            this.addeditPanel.Controls.Add(this.label4);
            this.addeditPanel.Controls.Add(this.tempField);
            this.addeditPanel.Controls.Add(this.label5);
            this.addeditPanel.Controls.Add(this.monthCalendar);
            this.addeditPanel.Controls.Add(this.divider);
            this.addeditPanel.Controls.Add(this.addButton);
            this.addeditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addeditPanel.Location = new System.Drawing.Point(0, 0);
            this.addeditPanel.Name = "addeditPanel";
            this.addeditPanel.Size = new System.Drawing.Size(408, 491);
            this.addeditPanel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(88, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Choose a day:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(88, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Enter temperature:";
            // 
            // divider
            // 
            this.divider.BackgroundImage = global::Lab8.Properties.Resources.torn_slit_separator;
            this.divider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.divider.Location = new System.Drawing.Point(38, 216);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(351, 50);
            this.divider.TabIndex = 23;
            this.divider.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.addButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(69)))), ((int)(((byte)(105)))));
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(246, 351);
            this.addButton.Name = "addButton";
            this.addButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(106)))), ((int)(((byte)(135)))));
            this.addButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(106)))), ((int)(((byte)(135)))));
            this.addButton.OnHoverTextColor = System.Drawing.Color.White;
            this.addButton.Size = new System.Drawing.Size(100, 35);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Add";
            this.addButton.TextColor = System.Drawing.Color.White;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // tip2
            // 
            this.tip2.BackgroundImage = global::Lab8.Properties.Resources.info;
            this.tip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tip2.Cursor = System.Windows.Forms.Cursors.Help;
            this.tip2.Location = new System.Drawing.Point(11, 140);
            this.tip2.Name = "tip2";
            this.tip2.Size = new System.Drawing.Size(20, 23);
            this.tip2.TabIndex = 8;
            this.tip2.TabStop = false;
            this.toolTip1.SetToolTip(this.tip2, "Введите или выберите значение температуры. Все записи о днях месяца с данной темп" +
        "ературой будут удалены из базы данных.");
            // 
            // tip1
            // 
            this.tip1.BackgroundImage = global::Lab8.Properties.Resources.info;
            this.tip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tip1.Cursor = System.Windows.Forms.Cursors.Help;
            this.tip1.Location = new System.Drawing.Point(11, 40);
            this.tip1.Name = "tip1";
            this.tip1.Size = new System.Drawing.Size(20, 23);
            this.tip1.TabIndex = 7;
            this.tip1.TabStop = false;
            this.toolTip1.SetToolTip(this.tip1, "Введите или выберите день месяца. Запись об этом дне будет удалена из базы данных" +
        ".");
            // 
            // tempBox
            // 
            this.tempBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tempBox.FormattingEnabled = true;
            this.tempBox.Items.AddRange(new object[] {
            "привет"});
            this.tempBox.Location = new System.Drawing.Point(162, 137);
            this.tempBox.Name = "tempBox";
            this.tempBox.Size = new System.Drawing.Size(108, 29);
            this.tempBox.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tempBox, "Во всплывающем списке представлены значения температур, записи с которыми содержа" +
        "тся в базе данных.");
            this.tempBox.SelectedIndexChanged += new System.EventHandler(this.TempBox_SelectedIndexChanged);
            this.tempBox.TextChanged += new System.EventHandler(this.TempBox_TextChanged);
            this.tempBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TempBox_KeyPress);
            // 
            // dayBox
            // 
            this.dayBox.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dayBox.FormattingEnabled = true;
            this.dayBox.Location = new System.Drawing.Point(162, 38);
            this.dayBox.Name = "dayBox";
            this.dayBox.Size = new System.Drawing.Size(108, 29);
            this.dayBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dayBox, "Во всплывающем списке представлены дни, записи о которых содержатся в базе данных" +
        ".");
            this.dayBox.SelectedIndexChanged += new System.EventHandler(this.DayBox_SelectedIndexChanged);
            this.dayBox.TextChanged += new System.EventHandler(this.ComboBox1_TextChanged);
            this.dayBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DayBox_KeyPress);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackgroundImage = global::Lab8.Properties.Resources.Lawrencium;
            this.bottomPanel.Controls.Add(this.backButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.bottomPanel.Location = new System.Drawing.Point(0, 452);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bottomPanel.Size = new System.Drawing.Size(408, 39);
            this.bottomPanel.TabIndex = 7;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.backButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.backButton.Location = new System.Drawing.Point(0, 0);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(408, 39);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // deletePanel
            // 
            this.deletePanel.BackColor = System.Drawing.Color.White;
            this.deletePanel.Controls.Add(this.divider2);
            this.deletePanel.Controls.Add(this.delButton2);
            this.deletePanel.Controls.Add(this.delButton1);
            this.deletePanel.Controls.Add(this.tip2);
            this.deletePanel.Controls.Add(this.dayLabel);
            this.deletePanel.Controls.Add(this.tip1);
            this.deletePanel.Controls.Add(this.tempBox);
            this.deletePanel.Controls.Add(this.dayBox);
            this.deletePanel.Controls.Add(this.tempLabel);
            this.deletePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deletePanel.Location = new System.Drawing.Point(0, 0);
            this.deletePanel.Name = "deletePanel";
            this.deletePanel.Size = new System.Drawing.Size(408, 491);
            this.deletePanel.TabIndex = 9;
            // 
            // divider2
            // 
            this.divider2.BackgroundImage = global::Lab8.Properties.Resources.torn_slit_separator;
            this.divider2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.divider2.Location = new System.Drawing.Point(26, 73);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(350, 58);
            this.divider2.TabIndex = 24;
            this.divider2.TabStop = false;
            // 
            // delButton2
            // 
            this.delButton2.BackColor = System.Drawing.Color.Transparent;
            this.delButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(103)))));
            this.delButton2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.delButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delButton2.FlatAppearance.BorderSize = 0;
            this.delButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.delButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.delButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton2.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delButton2.Location = new System.Drawing.Point(293, 137);
            this.delButton2.Name = "delButton2";
            this.delButton2.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(134)))), ((int)(((byte)(133)))));
            this.delButton2.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(134)))), ((int)(((byte)(133)))));
            this.delButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.delButton2.Size = new System.Drawing.Size(96, 29);
            this.delButton2.TabIndex = 15;
            this.delButton2.Text = "Delete";
            this.delButton2.TextColor = System.Drawing.Color.White;
            this.delButton2.UseVisualStyleBackColor = false;
            this.delButton2.Click += new System.EventHandler(this.DelButton2_Click);
            // 
            // delButton1
            // 
            this.delButton1.BackColor = System.Drawing.Color.Transparent;
            this.delButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(103)))));
            this.delButton1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.delButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delButton1.FlatAppearance.BorderSize = 0;
            this.delButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.delButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.delButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delButton1.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delButton1.Location = new System.Drawing.Point(293, 38);
            this.delButton1.Name = "delButton1";
            this.delButton1.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(134)))), ((int)(((byte)(133)))));
            this.delButton1.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(134)))), ((int)(((byte)(133)))));
            this.delButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.delButton1.Size = new System.Drawing.Size(96, 29);
            this.delButton1.TabIndex = 14;
            this.delButton1.Text = "Delete";
            this.delButton1.TextColor = System.Drawing.Color.White;
            this.delButton1.UseVisualStyleBackColor = false;
            this.delButton1.Click += new System.EventHandler(this.DelButton1_Click);
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dayLabel.Location = new System.Drawing.Point(37, 40);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(114, 24);
            this.dayLabel.TabIndex = 0;
            this.dayLabel.Text = "Day number:";
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tempLabel.Location = new System.Drawing.Point(34, 140);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(119, 24);
            this.tempLabel.TabIndex = 1;
            this.tempLabel.Text = "Temperature:";
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(408, 491);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.deletePanel);
            this.Controls.Add(this.addeditPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ToolWindow";
            this.Text = "Data base editing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tempField)).EndInit();
            this.addeditPanel.ResumeLayout(false);
            this.addeditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tip2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tip1)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.deletePanel.ResumeLayout(false);
            this.deletePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.NumericUpDown tempField;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Panel addeditPanel;
        private System.Windows.Forms.Panel deletePanel;
        private System.Windows.Forms.ComboBox dayBox;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.ComboBox tempBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox tip1;
        private System.Windows.Forms.PictureBox tip2;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ePOSOne.btnProduct.Button_WOC addButton;
        private System.Windows.Forms.Label tempLabel;
        private ePOSOne.btnProduct.Button_WOC delButton1;
        private ePOSOne.btnProduct.Button_WOC delButton2;
        private System.Windows.Forms.PictureBox divider;
        private System.Windows.Forms.PictureBox divider2;
    }
}