using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class MainForm : Form
    {
        private int[] array1 = null;
        internal int[,] array2 = null;
        private int[][] array3 = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            fillChoosePanel.BringToFront();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            ConfirmButton1.Enabled = false;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nextButton1.Enabled = true;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            nextButton1.Enabled = true;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            nextButton1.Enabled = true;
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ConfirmButton1.Enabled = true;
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ConfirmButton1.Enabled = true;
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ConfirmButton1.Enabled = true;
        }

        private void NextButton2_Click(object sender, EventArgs e)
        {
            backButton1.Enabled = true;
            if (radioButton1.Checked) //если одномерный массив
            {
                if (radioButton6.Checked)
                    rowPanel1.BringToFront(); //заполнение с помощью ДСЧ   
                if (radioButton5.Checked)
                    rowPanel2.BringToFront(); //заполнение с клавиатуры
                if (radioButton4.Checked)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string name = openFile.FileName;
                            string arrayStr = File.ReadAllText(name);
                            arrayStr = arrayStr.Trim();

                            string[] numbers = arrayStr.Split(' ');
                            int[] arrayNew = new int[numbers.Length];

                            for (int i = 0; i < arrayNew.Length; i++)
                                arrayNew[i] = int.Parse(numbers[i]);

                            array1 = arrayNew;
                            rowActionsPanel.BringToFront();
                            label4.Text = "Ваш массив";
                            PrintArray(array1, outputBox1);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неверный формат входных данных! Повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                    
            }
            if (radioButton2.Checked)
            {
                if (radioButton6.Checked)
                    matrixPanel1.BringToFront();
                if (radioButton5.Checked)
                    matrixPanel2.BringToFront();
                if (radioButton4.Checked)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string name = openFile.FileName;
                            string arrayStr = File.ReadAllText(name);
                            arrayStr = arrayStr.Trim();

                            string[] rows = arrayStr.Split('\n');
                            string[] row = rows[0].Split(' ');
                            int[,] arrayNew = new int[rows.Length, row.Length];

                            for (int i = 0; i < arrayNew.GetLength(0); i++)
                            {
                                row = rows[i].Split(' ');
                                for (int j = 0; j < arrayNew.GetLength(1); j++)
                                {
                                    arrayNew[i, j] = int.Parse(row[j]);
                                }
                            }

                            array2 = arrayNew;
                            PrintArray(array2, outputBox2);
                            label13.Text = "Ваш массив";
                            matrixActionsPanel.BringToFront();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неверный формат входных данных! Повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }
            if (radioButton3.Checked)
            {
                if (radioButton6.Checked)
                    tornPanel12.BringToFront();
                if (radioButton5.Checked)
                    tornPanel12.BringToFront();
                if (radioButton4.Checked)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string name = openFile.FileName;
                            string arrayStr = File.ReadAllText(name);
                            arrayStr = arrayStr.Trim();

                            string[] rows = arrayStr.Split('\n');
                            int[][] arrayNew = new int[rows.Length][];

                            for (int i = 0; i < arrayNew.GetLength(0); i++)
                            {
                                string[] row = rows[i].Split(' ');
                                arrayNew[i] = new int[row.Length];
                                for (int j = 0; j < arrayNew[i].Length; j++)
                                {
                                    arrayNew[i][j] = int.Parse(row[j]);
                                }
                            }

                            array3 = arrayNew;
                            PrintArray(array3, outputBox3);
                            label18.Text = "Ваш массив";
                            tornActionsPanel.BringToFront();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неверный формат входных данных! Повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            infoLabel1.Text = null;
            infoLabel2.Text = null;
            mainPanel.BringToFront();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            ConfirmButton1.Enabled = false;
            nextButton1.Enabled = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            infoLabel2.Text = null;
            infoLabel1.Text = null;
            fillChoosePanel.BringToFront();
            backButton1.Visible = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
        }

        private void ConfirmButton2_Click(object sender, EventArgs e)
        {
            if (int.Parse(lengthBox1.Text) != 0)
            {
                int N = int.Parse(lengthBox1.Text);
                array1 = new int[N];
                Random rnd = new Random();

                for (int i = 0; i < array1.Length; i++)
                    array1[i] = rnd.Next(-100, 100);

                PrintArray(array1, outputBox1);

                label4.ForeColor = Color.Black;
                label4.Text = "Ваш массив";
            }
            else
            {
                array1 = new int[0];
                label4.ForeColor = Color.DarkBlue;
                label4.Text = "Ваш массив пуст!";
                outputBox1.Clear();
            }

            lengthBox1.Text = null;
            rowActionsPanel.BringToFront();
        }

        private void LengthBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //событие считается обработанным, если введена цифра
        }

        private void LengthBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lengthBox1.Text))
                ConfirmButton2.Enabled = false;
            else
                ConfirmButton2.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (array1 == null)
            {
                MessageBox.Show("Массива не существует! Создайте новый и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (array1.Length == 0)
            {
                MessageBox.Show("Ваш массив пуст! Создайте новый и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] arrayNew;
            int index = -1, element = default;

            for (int i = 0; i < array1.Length; i++)
                if (array1[i] % 2 == 0)
                {
                    index = i;
                    element = array1[i];
                    break;
                }

            if (index == -1)
            {
                infoLabel2.Text = null;
                infoLabel1.ForeColor = Color.Red;
                infoLabel1.Text = "В массиве отсутствуют четные элементы.";
                return;
            }

            arrayNew = new int[array1.Length - 1];

            for (int i = 0; i < array1.Length; i++)
                if (i < index) arrayNew[i] = array1[i];
                else if (i > index) arrayNew[i - 1] = array1[i];

            array1 = arrayNew;

            if (array1.Length != 0)
                PrintArray(array1, outputBox1);
            else
            {
                outputBox1.Clear();
                label4.ForeColor = Color.DarkBlue;
                label4.Text = "Ваш массив пуст!";
            }

            infoLabel1.ForeColor = Color.DarkGoldenrod;
            infoLabel1.Text = $"Из массива удален элемент: {element}";

            infoLabel2.ForeColor = Color.DarkGoldenrod;
            infoLabel2.Text = $"Индекс удаленного элемента: {index}";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) != 0)
            {
                label7.Text = "Введите элементы одномерного массива в ячейки:";
                label7.Visible = true;
                button2.Enabled = true;
                arrayCreatePanel1.Controls.Clear();
                int N = int.Parse(textBox1.Text);
                if (N > 44) N = 44;

                for (int i = 0; i < N; i++)
                {
                    TextBox textbox = new TextBox();            //ячейки для ввода одномерного массива
                    textbox.Text = "0";
                    textbox.ForeColor = Color.Silver;
                    textbox.KeyPress += SpecialTBox1_KeyPress;       //
                    textbox.Enter += SpecialTBox1_Enter;             //присвоение каждой события от специального textbox'a
                    textbox.Leave += SpecialTBox1_Leave;             //
                    textbox.MaxLength = 4;
                    textbox.Width = 61;
                    arrayCreatePanel1.Controls.Add(textbox);    //добавление ячейки в flowLayoutPanel
                }
            }
            else
            {
                arrayCreatePanel1.Controls.Clear();
                label7.Text = "Вы хотите ввести пустой массив. Продолжить?";
                label7.Visible = true;
                button2.Enabled = true;
                return;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                ConfirmButton3.Enabled = false;
            else
                ConfirmButton3.Enabled = true;
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

        private void Button2_Click_1(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) != 0)
            {
                if (int.Parse(textBox1.Text) > 44)
                    array1 = new int[44];
                else
                    array1 = new int[int.Parse(textBox1.Text)];

                for (int i = 0; i < array1.Length; i++)
                    array1[i] = int.Parse(arrayCreatePanel1.Controls[i].Text);

                textBox1.Clear();
                label4.ForeColor = Color.Black;
                label4.Text = "Ваш массив";
                arrayCreatePanel1.Controls.Clear();
                rowActionsPanel.BringToFront();
                PrintArray(array1, outputBox1);
            }
            else
            {
                array1 = new int[0];
                textBox1.Clear();
                arrayCreatePanel1.Controls.Clear();
                rowActionsPanel.BringToFront();
                label4.ForeColor = Color.DarkBlue;
                label4.Text = "Ваш массив пуст!";
                outputBox1.Clear();
            }
            label7.Text = null;
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("0-44"))
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "0-44";
                textBox1.ForeColor = Color.Silver;
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

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals("0-10") && !textBox4.Text.Equals("0-12") && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
                button6.Enabled = true;
            else
                button6.Enabled = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox4.Text) != 0 && int.Parse(textBox3.Text) != 0)
            {
                Random rnd = new Random();
                int rows = int.Parse(textBox3.Text);
                int columns = int.Parse(textBox4.Text);

                if (rows > 10) rows = 10;
                if (columns > 12) columns = 12;

                array2 = new int[rows, columns];

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        array2[i, j] = rnd.Next(-100, 100);

                PrintArray(array2, outputBox2);

                label13.ForeColor = Color.Black;
                label13.Text = "Ваш массив";
            }
            else
            {
                array2 = new int[0, 0];
                label13.ForeColor = Color.DarkBlue;
                label13.Text = "Ваш массив пуст!";
                outputBox2.Clear();
            }

            textBox3.Text = "0-10";
            textBox3.ForeColor = Color.Silver;
            textBox4.Text = "0-12";
            textBox4.ForeColor = Color.Silver;
            matrixActionsPanel.BringToFront();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            label24.Text = null;
            fillChoosePanel.BringToFront();
            backButton1.Visible = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            outputBox2.Text = null;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            label24.Text = null;
            mainPanel.BringToFront();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            ConfirmButton1.Enabled = false;
            nextButton1.Enabled = false;
            outputBox2.Text = null;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox5.Text) != 0 && int.Parse(textBox6.Text) != 0)
            {
                label11.Text = "Введите элементы матрицы в ячейки:";
                label11.Visible = true;
                button10.Enabled = true;
                arrayCreatePanel2.Controls.Clear();

                if (int.Parse(textBox5.Text) > 6) textBox5.Text = "6";
                if (int.Parse(textBox6.Text) > 6) textBox6.Text = "6";

                int rows = int.Parse(textBox5.Text);
                int columns = int.Parse(textBox6.Text);

                for (int i = 0; i < rows; i++)
                {
                    Control lastControl = null;
                    for (int j = 0; j < columns; j++)
                    {
                        TextBox textbox = new TextBox();
                        textbox.Text = "0";
                        textbox.ForeColor = Color.Silver;
                        textbox.KeyPress += SpecialTBox1_KeyPress;
                        textbox.Enter += SpecialTBox1_Enter;
                        textbox.Leave += SpecialTBox1_Leave;
                        textbox.MaxLength = 4;
                        textbox.Width = 61;
                        arrayCreatePanel2.Controls.Add(textbox);

                        lastControl = textbox;
                    }
                    flowLayoutPanel1.SetFlowBreak(lastControl, true);
                }
            }
            else
            {
                arrayCreatePanel2.Controls.Clear();
                label11.Text = "Вы хотите ввести пустой массив. Продолжить?";
                label11.Visible = true;
                button10.Enabled = true;
                return;
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (!textBox5.Text.Equals("0-6") && !textBox6.Text.Equals("0-6") && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
                button11.Enabled = true;
            else
                button11.Enabled = false;
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (!textBox5.Text.Equals("0-6") && !textBox6.Text.Equals("0-6") && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
                button11.Enabled = true;
            else
                button11.Enabled = false;
        }

        private void TextBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals("0-6"))
            {
                textBox5.Clear();
                textBox5.ForeColor = Color.Black;
            }
        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals(""))
            {
                textBox5.Text = "0-6";
                textBox5.ForeColor = Color.Silver;
            }
        }

        private void TextBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals("0-6"))
            {
                textBox6.Clear();
                textBox6.ForeColor = Color.Black;
            }
        }

        private void TextBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals(""))
            {
                textBox6.Text = "0-6";
                textBox6.ForeColor = Color.Silver;
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox5.Text) != 0 && int.Parse(textBox6.Text) != 0)
            {
                int rows = int.Parse(textBox5.Text);
                int columns = int.Parse(textBox6.Text);

                array2 = new int[rows, columns];

                int index = 0;
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        array2[i, j] = int.Parse(arrayCreatePanel2.Controls[index].Text);
                        index++;
                    }

                label13.ForeColor = Color.Black;
                label13.Text = "Ваш массив";
                arrayCreatePanel2.Controls.Clear();
                matrixActionsPanel.BringToFront();
                PrintArray(array2, outputBox2);
            }
            else
            {
                array2 = new int[0, 0];
                arrayCreatePanel2.Controls.Clear();
                matrixActionsPanel.BringToFront();
                label13.ForeColor = Color.DarkBlue;
                label13.Text = "Ваш массив пуст!";
                outputBox2.Clear();
            }
            textBox5.Text = "0-6";
            textBox6.Text = "0-6";
            textBox5.ForeColor = Color.Silver;
            textBox6.ForeColor = Color.Silver;
            label11.Text = null;
        }

        private void TextBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals("0-10"))
            {
                textBox3.Clear();
                textBox3.ForeColor = Color.Black;
            }
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "0-10";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void TextBox4_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Equals("0-12"))
            {
                (sender as TextBox).Clear();
                (sender as TextBox).ForeColor = Color.Black;
            }
        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Equals(""))
            {
                (sender as TextBox).Text = "0-12";
                (sender as TextBox).ForeColor = Color.Silver;
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (array2 == null)
            {
                MessageBox.Show("Массива не существует! Создайте новый и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (array2.Length == 0)
            {
                MessageBox.Show("Ваш массив пуст! Создайте новый и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (array2.GetLength(0) >= 10)
            {
                MessageBox.Show("Максимальный размер матрицы! Для добавления строки создайте новый двумерный массив и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddRowForm addrowForm = new AddRowForm(this, array2);
            addrowForm.TopMost = true;
            addrowForm.ShowDialog();
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            if (!string.IsNullOrEmpty(textBox8.Text) && !textBox8.Text.Equals("0-9"))
            {
                button12.Enabled = true;
                int rows = int.Parse(textBox8.Text);

                for (int i = 0; i < rows; i++)
                {
                    Label label = new Label();
                    label.Text = $"{i + 1} строка: ";
                    flowLayoutPanel2.Controls.Add(label);

                    TextBox textbox = new TextBox();            //ячейки для ввода одномерного массива
                    textbox.Text = "1-12";
                    textbox.ForeColor = Color.Silver;
                    textbox.KeyPress += LengthBox_KeyPress;
                    textbox.TextChanged += SpecialTextBox2_TextChanged;
                    textbox.Enter += SpecialTextBox2_Enter;             //присвоение каждой события от специального textbox'a
                    textbox.Leave += SpecialTextBox2_Leave;             //
                    textbox.MaxLength = 2;
                    textbox.Width = 50;
                    textbox.Height = 20;
                    flowLayoutPanel2.Controls.Add(textbox);    //добавление ячейки в flowLayoutPanel

                    Control lastControl = textbox;
                    flowLayoutPanel2.SetFlowBreak(lastControl, true);   //переход на новую строку
                }
            }
            else
            {
                button12.Enabled = false;
            }
        }

        private void TextBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals("0-9"))
            {
                textBox8.Clear();
                textBox8.ForeColor = Color.Black;
            }
        }

        private void TextBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text.Equals(""))
            {
                textBox8.Text = "0-9";
                textBox8.ForeColor = Color.Silver;
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                if (int.Parse(textBox8.Text) != 0)
                {
                    int rows = int.Parse(textBox8.Text);
                    array3 = new int[rows][];

                    try
                    {
                        for (int i = 0, j = 1; i < rows; i++, j += 2)
                        {
                            if (int.Parse(flowLayoutPanel2.Controls[j].Text) > 12)
                                array3[i] = new int[12];
                            else
                                array3[i] = new int[int.Parse(flowLayoutPanel2.Controls[j].Text)];
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введите количество элементов в каждой строке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Random rnd = new Random();
                    foreach (int[] row in array3)
                        for (int j = 0; j < row.Length; j++)
                            row[j] = rnd.Next(-100, 100);

                    label18.ForeColor = Color.Black;
                    label18.Text = "Ваш массив";
                    flowLayoutPanel2.Controls.Clear();
                    tornActionsPanel.BringToFront();
                    PrintArray(array3, outputBox3);
                }
                else
                {
                    array3 = new int[0][];
                    arrayCreatePanel3.Controls.Clear();
                    flowLayoutPanel2.Controls.Clear();
                    tornActionsPanel.BringToFront();
                    label18.ForeColor = Color.DarkBlue;
                    label18.Text = "Ваш массив пуст!";
                    outputBox3.Clear();
                }
                textBox8.ForeColor = Color.Silver;
                textBox8.Text = "0-9";
            }
            if (radioButton5.Checked)
            {
                if (int.Parse(textBox8.Text) != 0)
                {
                    int rows = int.Parse(textBox8.Text);
                    array3 = new int[rows][];

                    try
                    {
                        for (int i = 0, j = 1; i < rows; i++, j += 2)
                        {
                            if (int.Parse(flowLayoutPanel2.Controls[j].Text) > 12)
                                array3[i] = new int[12];
                            else
                                array3[i] = new int[int.Parse(flowLayoutPanel2.Controls[j].Text)];
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введите количество элементов в каждой строке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int index = 0;
                    foreach (int[] row in array3)
                    {
                        index++;
                        Label label = new Label();
                        label.Text = $"{index} строка: ";
                        arrayCreatePanel3.Controls.Add(label);

                        Control lastControl = label;
                        for (int i = 0; i < row.Length; i++)
                        {
                            TextBox textbox = new TextBox();
                            textbox.Text = "0";
                            textbox.ForeColor = Color.Silver;
                            textbox.KeyPress += SpecialTBox1_KeyPress;
                            textbox.Enter += SpecialTBox1_Enter;
                            textbox.Leave += SpecialTBox1_Leave;
                            textbox.MaxLength = 4;
                            textbox.Width = 50;
                            textbox.Height = 20;
                            arrayCreatePanel3.Controls.Add(textbox);

                            lastControl = textbox;
                        }
                        arrayCreatePanel3.SetFlowBreak(lastControl, true);
                    }
                    tornPanel2.BringToFront();
                }
                else
                {
                    array3 = new int[0][];
                    arrayCreatePanel3.Controls.Clear();
                    flowLayoutPanel2.Controls.Clear();
                    tornActionsPanel.BringToFront();
                    label18.ForeColor = Color.DarkBlue;
                    label18.Text = "Ваш массив пуст!";
                    outputBox3.Clear();
                }
                textBox8.ForeColor = Color.Silver;
                textBox8.Text = "0-9";
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            fillChoosePanel.BringToFront();
            backButton1.Visible = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            label22.Text = null;
            label23.Text = null;
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            ConfirmButton1.Enabled = false;
            nextButton1.Enabled = false;
            label22.Text = null;
            label23.Text = null;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            int j = 0;
            foreach (int[] row in array3)
                for (int i = 0; i < row.Length; i++)
                {
                    try
                    {
                        row[i] = int.Parse(arrayCreatePanel3.Controls[j].Text);
                        j++;
                        continue;
                    }
                    catch (FormatException)
                    {
                        j++;
                        row[i] = int.Parse(arrayCreatePanel3.Controls[j].Text);
                        j++;
                    }
                }

            arrayCreatePanel3.Controls.Clear();
            label18.ForeColor = Color.Black;
            label18.Text = "Ваш массив";
            flowLayoutPanel2.Controls.Clear();
            tornActionsPanel.BringToFront();
            PrintArray(array3, outputBox3);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            if (array3 == null)
            {
                MessageBox.Show("Массива не существует! Создайте массив и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (array3.Length == 0)
            {
                label22.Text = null;
                label23.Text = null;
                MessageBox.Show("Ваш массив пуст! Создайте новый и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maxRowLength = -1, maxRowsCount = 0;
            var maxRowIndexes = new List<int>();     //список исключительно для вывода информации об удаленных строках
            var indexes = new List<int>();           //список для индексов строк, длина которых не равна максимальной

            foreach (int[] row in array3)
                if (row.Length > maxRowLength)
                    maxRowLength = row.Length;

            for (int j = 0; j < array3.Length; j++)
                if (array3[j].Length == maxRowLength)
                {
                    maxRowsCount++;
                    maxRowIndexes.Add(j);
                }
                else
                    indexes.Add(j);

            int[][] arrayNew = new int[array3.Length - maxRowsCount][];

            int i = 0;
            foreach (int index in indexes)
            {
                arrayNew[i] = new int[array3[index].Length];

                for (int j = 0; j < arrayNew[i].Length; j++)
                    arrayNew[i][j] = array3[index][j];

                i++;
            }

            array3 = arrayNew;

            if (maxRowsCount == 1)
            {
                label22.Text = $"Из массива удалена строка с номером: {maxRowIndexes[0] + 1}";
                label23.Text = $"Длина удаленной строки: {maxRowLength}";
            }
            else
            {
                label22.Text = "Из массива удалены строки с номерами: ";
                foreach (int index in maxRowIndexes)
                    label22.Text += $"{index + 1} ";
                label23.Text = $"Длина удаленных строк: {maxRowLength}";
            }

            if (array3.Length != 0)
                PrintArray(array3, outputBox3);
            else
            {
                outputBox3.Clear();
                label18.ForeColor = Color.DarkBlue;
                label18.Text = "Ваш массив пуст!";
            }
        }

        private void SpecialTextBox2_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Equals("1-12"))
            {
                (sender as TextBox).Clear();
                (sender as TextBox).ForeColor = Color.Black;
            }
        }

        private void SpecialTextBox2_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Equals(""))
            {
                (sender as TextBox).Text = "1-12";
                (sender as TextBox).ForeColor = Color.Silver;
            }
        }

        private void SpecialTextBox2_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "0")
                (sender as TextBox).Text = "";
        }

        private void PrintArray(int[] array, TextBox textBox) //вывод одномерного массива в textBox
        {
            textBox.Clear();
            string arrayStr = null;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < 0) arrayStr += " ";
                arrayStr += array1[i].ToString() + " ";
            }
            arrayStr += array[array.Length - 1].ToString(); //последний элемент без пробела

            textBox.Text = arrayStr;
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
        private void PrintArray(int[][] array, TextBox textBox) //вывод рваного массива в textBox
        {
            textBox.Clear();
            string arrayStr = null;
            int difference, maxLength = -1;

            foreach (int[] row in array)
                for (int i = 0; i < row.Length; i++)
                    if (row[i].ToString().Length > maxLength)
                        maxLength = row[i].ToString().Length;

            foreach (int[] row in array)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    difference = maxLength - row[i].ToString().Length;
                    for (int k = 0; k < difference; k++)
                        arrayStr += " ";
                    arrayStr += row[i].ToString() + " ";
                }
                textBox.Text += arrayStr + Environment.NewLine;
                arrayStr = null;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)   //если выбран файл в диалоговом окне
            {
                string name = saveFile.FileName;
                File.WriteAllText(name, outputBox3.Text);
            }
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)   //если выбран файл в диалоговом окне
            {
                string name = saveFile.FileName;
                File.WriteAllText(name, outputBox2.Text);
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK) //если выбран файл в диалоговом окне
            {
                string name = saveFile.FileName;
                File.WriteAllText(name, outputBox1.Text);
            }
        }
    }
}