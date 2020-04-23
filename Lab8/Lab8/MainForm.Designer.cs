namespace Lab8
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.tip2 = new System.Windows.Forms.PictureBox();
            this.tip1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.divider1 = new System.Windows.Forms.PictureBox();
            this.divider3 = new System.Windows.Forms.PictureBox();
            this.divider4 = new System.Windows.Forms.Label();
            this.showButton = new ePOSOne.btnProduct.Button_WOC();
            this.clearButton = new ePOSOne.btnProduct.Button_WOC();
            this.deleteButton = new ePOSOne.btnProduct.Button_WOC();
            this.addButton = new ePOSOne.btnProduct.Button_WOC();
            this.outputField = new System.Windows.Forms.RichTextBox();
            this.dayLabel = new System.Windows.Forms.Label();
            this.tempLabel = new System.Windows.Forms.Label();
            this.divider2 = new System.Windows.Forms.PictureBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tip2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tip1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider2)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bodyPanel
            // 
            this.bodyPanel.BackColor = System.Drawing.Color.White;
            this.bodyPanel.BackgroundImage = global::Lab8.Properties.Resources.white;
            this.bodyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bodyPanel.Controls.Add(this.tip2);
            this.bodyPanel.Controls.Add(this.tip1);
            this.bodyPanel.Controls.Add(this.panel1);
            this.bodyPanel.Controls.Add(this.divider1);
            this.bodyPanel.Controls.Add(this.divider3);
            this.bodyPanel.Controls.Add(this.divider4);
            this.bodyPanel.Controls.Add(this.showButton);
            this.bodyPanel.Controls.Add(this.clearButton);
            this.bodyPanel.Controls.Add(this.deleteButton);
            this.bodyPanel.Controls.Add(this.addButton);
            this.bodyPanel.Controls.Add(this.outputField);
            this.bodyPanel.Controls.Add(this.dayLabel);
            this.bodyPanel.Controls.Add(this.tempLabel);
            this.bodyPanel.Controls.Add(this.divider2);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 0);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(913, 546);
            this.bodyPanel.TabIndex = 4;
            // 
            // tip2
            // 
            this.tip2.BackgroundImage = global::Lab8.Properties.Resources.info;
            this.tip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tip2.Cursor = System.Windows.Forms.Cursors.Help;
            this.tip2.Location = new System.Drawing.Point(65, 502);
            this.tip2.Name = "tip2";
            this.tip2.Size = new System.Drawing.Size(20, 23);
            this.tip2.TabIndex = 29;
            this.tip2.TabStop = false;
            this.toolTip1.SetToolTip(this.tip2, "Максимальный отрезок между днями с отрицательной температурой");
            this.tip2.Visible = false;
            // 
            // tip1
            // 
            this.tip1.BackgroundImage = global::Lab8.Properties.Resources.info;
            this.tip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tip1.Cursor = System.Windows.Forms.Cursors.Help;
            this.tip1.Location = new System.Drawing.Point(398, 116);
            this.tip1.Name = "tip1";
            this.tip1.Size = new System.Drawing.Size(20, 23);
            this.tip1.TabIndex = 27;
            this.tip1.TabStop = false;
            this.toolTip1.SetToolTip(this.tip1, "Красным цветом помечаются дни, в которые температура была выше средней");
            this.tip1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.infoLabel3);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(12, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(47, 41);
            this.panel1.TabIndex = 28;
            this.panel1.Visible = false;
            // 
            // infoLabel3
            // 
            this.infoLabel3.AutoSize = true;
            this.infoLabel3.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel3.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel3.ForeColor = System.Drawing.Color.Black;
            this.infoLabel3.Location = new System.Drawing.Point(5, 4);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(0, 30);
            this.infoLabel3.TabIndex = 25;
            // 
            // divider1
            // 
            this.divider1.BackgroundImage = global::Lab8.Properties.Resources.torn_slit_separator;
            this.divider1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.divider1.Location = new System.Drawing.Point(498, 127);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(351, 50);
            this.divider1.TabIndex = 22;
            this.divider1.TabStop = false;
            // 
            // divider3
            // 
            this.divider3.BackgroundImage = global::Lab8.Properties.Resources.torn_slit_separator;
            this.divider3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.divider3.Location = new System.Drawing.Point(498, 367);
            this.divider3.Name = "divider3";
            this.divider3.Size = new System.Drawing.Size(351, 50);
            this.divider3.TabIndex = 21;
            this.divider3.TabStop = false;
            // 
            // divider4
            // 
            this.divider4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider4.Location = new System.Drawing.Point(53, 94);
            this.divider4.Name = "divider4";
            this.divider4.Size = new System.Drawing.Size(355, 2);
            this.divider4.TabIndex = 20;
            // 
            // showButton
            // 
            this.showButton.BackColor = System.Drawing.Color.Transparent;
            this.showButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(90)))), ((int)(((byte)(229)))));
            this.showButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(109)))), ((int)(((byte)(229)))));
            this.showButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showButton.FlatAppearance.BorderSize = 0;
            this.showButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.showButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.showButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showButton.Location = new System.Drawing.Point(535, 303);
            this.showButton.Name = "showButton";
            this.showButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(235)))));
            this.showButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(235)))));
            this.showButton.OnHoverTextColor = System.Drawing.Color.White;
            this.showButton.Size = new System.Drawing.Size(277, 58);
            this.showButton.TabIndex = 12;
            this.showButton.Text = "Show data base";
            this.showButton.TextColor = System.Drawing.Color.White;
            this.showButton.UseVisualStyleBackColor = false;
            this.showButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Transparent;
            this.clearButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(40)))), ((int)(((byte)(82)))));
            this.clearButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.clearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(535, 423);
            this.clearButton.Name = "clearButton";
            this.clearButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(98)))), ((int)(((byte)(117)))));
            this.clearButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(98)))), ((int)(((byte)(117)))));
            this.clearButton.OnHoverTextColor = System.Drawing.Color.White;
            this.clearButton.Size = new System.Drawing.Size(277, 58);
            this.clearButton.TabIndex = 15;
            this.clearButton.Text = "Clear data base";
            this.clearButton.TextColor = System.Drawing.Color.White;
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(90)))), ((int)(((byte)(103)))));
            this.deleteButton.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(535, 183);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(134)))), ((int)(((byte)(133)))));
            this.deleteButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(134)))), ((int)(((byte)(133)))));
            this.deleteButton.OnHoverTextColor = System.Drawing.Color.White;
            this.deleteButton.Size = new System.Drawing.Size(277, 58);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Delete a note";
            this.deleteButton.TextColor = System.Drawing.Color.White;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
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
            this.addButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(535, 63);
            this.addButton.Name = "addButton";
            this.addButton.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(106)))), ((int)(((byte)(135)))));
            this.addButton.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(106)))), ((int)(((byte)(135)))));
            this.addButton.OnHoverTextColor = System.Drawing.Color.White;
            this.addButton.Size = new System.Drawing.Size(277, 58);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "Add / edit a note";
            this.addButton.TextColor = System.Drawing.Color.White;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // outputField
            // 
            this.outputField.BackColor = System.Drawing.Color.White;
            this.outputField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputField.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.outputField.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputField.Location = new System.Drawing.Point(78, 116);
            this.outputField.Name = "outputField";
            this.outputField.ReadOnly = true;
            this.outputField.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.outputField.Size = new System.Drawing.Size(314, 309);
            this.outputField.TabIndex = 11;
            this.outputField.TabStop = false;
            this.outputField.Text = "";
            this.outputField.TextChanged += new System.EventHandler(this.OutputField_TextChanged);
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.BackColor = System.Drawing.Color.Transparent;
            this.dayLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayLabel.Location = new System.Drawing.Point(58, 52);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(56, 31);
            this.dayLabel.TabIndex = 8;
            this.dayLabel.Text = "Day";
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.BackColor = System.Drawing.Color.Transparent;
            this.tempLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempLabel.Location = new System.Drawing.Point(207, 52);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(192, 31);
            this.tempLabel.TabIndex = 10;
            this.tempLabel.Text = "Temperature, ℃";
            // 
            // divider2
            // 
            this.divider2.BackgroundImage = global::Lab8.Properties.Resources.torn_slit_separator;
            this.divider2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.divider2.Location = new System.Drawing.Point(498, 247);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(351, 50);
            this.divider2.TabIndex = 17;
            this.divider2.TabStop = false;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.BackgroundImage = global::Lab8.Properties.Resources.Lawrencium;
            this.bottomPanel.Controls.Add(this.closeButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.ForeColor = System.Drawing.Color.Brown;
            this.bottomPanel.Location = new System.Drawing.Point(0, 546);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(913, 55);
            this.bottomPanel.TabIndex = 6;
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(122)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(122)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.closeButton.Location = new System.Drawing.Point(0, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(913, 55);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 601);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "January temperature";
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tip2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tip1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.divider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.divider2)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Label dayLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ePOSOne.btnProduct.Button_WOC showButton;
        private ePOSOne.btnProduct.Button_WOC deleteButton;
        private ePOSOne.btnProduct.Button_WOC addButton;
        private ePOSOne.btnProduct.Button_WOC clearButton;
        private System.Windows.Forms.RichTextBox outputField;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox divider2;
        private System.Windows.Forms.Label divider4;
        private System.Windows.Forms.PictureBox divider1;
        private System.Windows.Forms.PictureBox divider3;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox tip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox tip2;
    }
}

