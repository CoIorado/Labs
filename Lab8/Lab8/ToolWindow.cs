using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8
{
    public partial class ToolWindow : Form
    {
        private string DBpath = null;
        MainForm parentForm = null;
        public ToolWindow(string DBpath, MainForm parent)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.DBpath = DBpath;
            parentForm = parent;
            delButton1.Enabled = false;
            delButton2.Enabled = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DateTime time = monthCalendar.SelectionStart.Date;

            int day = time.Date.Day;
            int temperature = (int) tempField.Value;

            Month month = Helper.Deserialize(DBpath);                //

            if (month[day] != null)                                  //если в списке уже есть запись о введенном дне
            {
                DialogResult dialogResult = MessageBox.Show($"Запись о {day} января уже существует. Хотите перезаписать информацию?", "!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.No)
                    return;

                month[day].Temperature = temperature;
            }
            else
            {
                month.Days.Add(new Day(day, temperature));
            }

            month.Sort();
            Helper.Serialize(DBpath, month);

            if (parentForm.isShowButtonPressed)
                Helper.PrintDataBase(DBpath, parentForm.Controls["bodyPanel"].Controls["outputField"] as RichTextBox);

            MessageBox.Show($"Запись о {day} января успешно обновлена.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            (parentForm.Controls["bodyPanel"].Controls["deleteButton"] as Button).Enabled = true;
            (parentForm.Controls["bodyPanel"].Controls["addButton"] as Button).Enabled = true;

        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(dayBox.Text, "[^0-9]"))
            {
                dayBox.Text = dayBox.Text.Remove(dayBox.Text.Length - 1);
                dayBox.SelectionStart = dayBox.Text.Length;
            }

            if (string.IsNullOrEmpty(dayBox.Text))
                delButton1.Enabled = false;
            else
                delButton1.Enabled = true;
        }

        private void TempBox_TextChanged(object sender, EventArgs e)
        {
            if (tempBox.Text.Length > 0 && tempBox.Text.IndexOf('-', 1) >= 1)
                tempBox.Text = tempBox.Text.Remove(tempBox.Text.Length - 1);

            tempBox.SelectionStart = tempBox.Text.Length;

            if (string.IsNullOrEmpty(tempBox.Text))
                delButton2.Enabled = false;
            else
                delButton2.Enabled = true;
        }

        private void DayBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            delButton1.Enabled = true;
        }

        private void TempBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            delButton2.Enabled = true;
        }

        private void TempBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as ComboBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && (sender as ComboBox).Text.LastIndexOf('-') != 0)
            {
                (sender as ComboBox).Text += " ";
                (sender as ComboBox).Text = (sender as ComboBox).Text.Replace(" ", "");
            }

            if (e.KeyChar == (char)13)
                DelButton2_Click(this, e); 
        }

        private void DelButton1_Click(object sender, EventArgs e)
        {
            string inputDay = dayBox.Text.Trim();

            if (int.Parse(inputDay) < 1 || int.Parse(inputDay) > 31)
            {
                MessageBox.Show("Введена некорректная дата. Повторите попытку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Month month = Helper.Deserialize(DBpath);

            if (month[int.Parse(inputDay)] == null)
            {
                MessageBox.Show("В базе данных отсутствует запись с введенным номером дня", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            month.Days.Remove(month[int.Parse(inputDay)]);
            Helper.Serialize(DBpath, month);

            if (parentForm.isShowButtonPressed)
                Helper.PrintDataBase(DBpath, parentForm.Controls["bodyPanel"].Controls["outputField"] as RichTextBox);

            MessageBox.Show($"Запись о {inputDay} января успешно удалена из базы данных.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dayBox.Text = "";
            Helper.AddDaysToComboBox(DBpath, dayBox);
            Helper.AddTempToComboBox(DBpath, tempBox);
        }

        private void DelButton2_Click(object sender, EventArgs e)
        {
            string inputTemp = tempBox.Text.Trim();

            if (int.Parse(inputTemp) < -100 || int.Parse(inputTemp) > 100)
            {
                MessageBox.Show("Введено некорректное значение температуры. Повторите попытку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Month month = Helper.Deserialize(DBpath);

            int tempMatchCount = 0;
            foreach (Day day in month.Days)
                if (day.Temperature == int.Parse(inputTemp))
                    tempMatchCount++;

            if (tempMatchCount == 0)
            {
                MessageBox.Show("В базе данных отсутствуют записи с введенным значением температуры.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            for (int i = 0; i < tempMatchCount; i++)
                month.Days.Remove(month[inputTemp]);

            Helper.Serialize(DBpath, month);

            if (parentForm.isShowButtonPressed)
                Helper.PrintDataBase(DBpath, parentForm.Controls["bodyPanel"].Controls["outputField"] as RichTextBox);

            MessageBox.Show($"{tempMatchCount} записей с температурным значением {inputTemp} были успешно удалены из базы данных.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tempBox.Text = "";
            Helper.AddDaysToComboBox(DBpath, dayBox);
            Helper.AddTempToComboBox(DBpath, tempBox);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DayBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                DelButton1_Click(this, e);
        }
    }
}