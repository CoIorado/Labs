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
    public partial class MainForm : Form
    {
        public bool isShowButtonPressed = false;
        private static readonly string path = "DataBase.dat";
        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ToolWindow tWindow = new ToolWindow(path, this);
            tWindow.Size = new Size(424, 530);
            (tWindow.Controls["addeditPanel"] as Panel).BringToFront();
            tWindow.ShowDialog();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить все данные из базы данных без возможности восстановления?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                outputField.Text = "";
                tip2.Visible = false;
                panel1.Visible = false;
                using (FileStream fstream = new FileStream(path, FileMode.Create))
                    MessageBox.Show("База данных успешно очищена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            Month month = Helper.Deserialize(path);

            if (month.Days.Count != 0)
            {
                Helper.PrintDataBase(path, outputField);
                tip1.Visible = true;
            }
            else
                MessageBox.Show("База данных пуста!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            isShowButtonPressed = true;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Month month = Helper.Deserialize(path);

            if (month.Days.Count != 0)
            {
                ToolWindow tWindow = new ToolWindow(path, this);
                tWindow.Size = new Size(424, 283);
                (tWindow.Controls["deletePanel"] as Panel).BringToFront();
                Helper.AddDaysToComboBox(path, (tWindow.Controls["deletePanel"].Controls["dayBox"] as ComboBox));
                Helper.AddTempToComboBox(path, (tWindow.Controls["deletePanel"].Controls["tempBox"] as ComboBox));
                tWindow.ShowDialog();
            }
            else
                MessageBox.Show("База данных пуста!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OutputField_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputField.Text))
            {
                infoLabel3.Text = "";
                panel1.Visible = false;
                tip2.Visible = false;

                string text = outputField.Text;
                text = text.Trim();

                string[] rows = text.Split('\n');

                List<int> temps = new List<int>();
                int negativeTempCount = 0;
                int indexOfNegative = -1;
                int maxLength = 0;

                foreach (string row in rows)
                {
                    Match match = Regex.Match(row, @"\t(.*)$");
                    int temp = int.Parse(match.Groups[1].Value);
                    temps.Add(temp);

                    if (temp < 0)
                        negativeTempCount++;
                }

                if (negativeTempCount < 2)
                    return;
                
                for (int i = 0; i < temps.Count; i++)
                    if (temps[i] < 0)
                    {
                        indexOfNegative = i;
                        break;
                    }

                for (int i = indexOfNegative + 1; i < temps.Count; i++)
                {
                    if (temps[i] < 0 && (i - indexOfNegative) > maxLength)
                        maxLength = i - indexOfNegative;
                }

                if (maxLength < 10)
                    infoLabel3.Text = " " + maxLength.ToString();
                else
                    infoLabel3.Text = maxLength.ToString();
                tip2.Visible = true;
                tip1.Visible = true;
                panel1.Visible = true;
            }
        }
    }
}