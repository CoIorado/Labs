using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class AddRowForm : Form
    {
        private int[,] array = null;
        private int index;
        private MainForm mainForm;
        public AddRowForm(MainForm mainForm, int[,] array)
        {
            this.array = array;
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) <= array.GetLength(0) + 1 && int.Parse(textBox1.Text) > 0)
            {
                index = int.Parse(textBox1.Text) - 1;
                panel2.BringToFront();
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            else
            {
                MessageBox.Show("Введенный номер выходит за границы массива! Повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Clear();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //событие считается обработанным, если введена цифра
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                button2.Enabled = true;
            else
                button2.Enabled = false;

            if (textBox1.Text == "0")
                textBox1.Text = null;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            button1.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    TextBox textbox = new TextBox();
                    textbox.Text = "0";
                    textbox.ForeColor = Color.Silver;
                    textbox.KeyPress += SpecialTBox1_KeyPress;
                    textbox.Enter += SpecialTBox1_Enter;
                    textbox.Leave += SpecialTBox1_Leave;
                    textbox.MaxLength = 3;
                    textbox.Width = 40;
                    flowLayoutPanel1.Controls.Add(textbox);
                }
                panel3.BringToFront();
            }
            if (radioButton2.Checked) //рандом
            {
                Random rnd = new Random();
                int[] addRow = new int[array.GetLength(1)];
                for (int i = 0; i < addRow.Length; i++)
                    addRow[i] = rnd.Next(-100, 100);

                int[,] arrayNew = new int[array.GetLength(0) + 1, array.GetLength(1)];

                if (index == array.GetLength(0) + 1)
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                        for (int j = 0; j < array.GetLength(1); j++)
                            arrayNew[i, j] = array[i, j];
                    for (int j = 0; j < addRow.Length; j++)
                        arrayNew[array.GetLength(0), j] = addRow[j];
                }
                else
                {
                    bool flag = false;
                    for (int i = 0; i < arrayNew.GetLength(0); i++)
                    {
                        if (i == index)
                        {
                            flag = true;
                            for (int j = 0; j < arrayNew.GetLength(1); j++)
                                arrayNew[i, j] = addRow[j];
                            continue;
                        }

                        if (!flag)
                            for (int j = 0; j < arrayNew.GetLength(1); j++)
                                arrayNew[i, j] = array[i, j];
                        else
                            for (int j = 0; j < arrayNew.GetLength(1); j++)
                                arrayNew[i, j] = array[i - 1, j];
                    }
                }

                mainForm.array2 = arrayNew;
                PrintArray(arrayNew, mainForm.Controls["matrixActionsPanel"].Controls["outputBox2"] as TextBox);
                mainForm.Controls["matrixActionsPanel"].Controls["label24"].Text = $"В массив добавлена строка под номером: {index+1}";
                this.Close();
            }
        }
        private void PrintArray(int[,] array, TextBox textBox) //вывод двумерного массива в textBox
        {
            textBox.Clear();
            string arrayStr = null;
            int difference, maxLength = -1;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j].ToString().Length > maxLength)
                        maxLength = array[i, j].ToString().Length;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    difference = maxLength - array[i, j].ToString().Length;
                    for (int k = 0; k < difference; k++)
                        arrayStr += " ";
                    arrayStr += array[i, j].ToString() + " ";
                }
                textBox.Text += arrayStr + Environment.NewLine;
                arrayStr = null;
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                button1.Enabled = true;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                button1.Enabled = true;
        }

        private void SpecialTBox1_KeyPress(object sender, KeyPressEventArgs e)  //специальный textbox для установки нужных событий для появляющихся ячеек
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && (sender as TextBox).Text.LastIndexOf('-') != 0)
            {
                (sender as TextBox).Text += " ";
                (sender as TextBox).Text = (sender as TextBox).Text.Replace(" ", "");
            }
        }
        private void SpecialTBox1_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Equals("0"))
            {
                (sender as TextBox).Clear();
                (sender as TextBox).ForeColor = Color.Black;
            }
        }
        private void SpecialTBox1_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Equals(""))
            {
                (sender as TextBox).Text = "0";
                (sender as TextBox).ForeColor = Color.Silver;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int[] addRow = new int[array.GetLength(1)];
            for (int i = 0; i < addRow.Length; i++)
                addRow[i] = int.Parse(flowLayoutPanel1.Controls[i].Text);

            int[,] arrayNew = new int[array.GetLength(0) + 1, array.GetLength(1)];

            if (index == array.GetLength(0) + 1)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        arrayNew[i, j] = array[i, j];
                for (int j = 0; j < addRow.Length; j++)
                    arrayNew[array.GetLength(0), j] = addRow[j];
            }
            else
            {
                bool flag = false;
                for (int i = 0; i < arrayNew.GetLength(0); i++)
                {
                    if (i == index)
                    {
                        flag = true;
                        for (int j = 0; j < arrayNew.GetLength(1); j++)
                            arrayNew[i, j] = addRow[j];
                        continue;
                    }

                    if (!flag)
                        for (int j = 0; j < arrayNew.GetLength(1); j++)
                            arrayNew[i, j] = array[i, j];
                    else
                        for (int j = 0; j < arrayNew.GetLength(1); j++)
                            arrayNew[i, j] = array[i - 1, j];
                }
            }

            mainForm.array2 = arrayNew;
            PrintArray(arrayNew, mainForm.Controls["matrixActionsPanel"].Controls["outputBox2"] as TextBox);
            mainForm.Controls["matrixActionsPanel"].Controls["label24"].Text = $"В массив добавлена строка под номером: {index + 1}";
            this.Close();
        }
    }
}
