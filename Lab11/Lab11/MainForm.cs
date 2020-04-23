using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab11
{
    public partial class MainForm : Form
    {
        public Queue peopleQ;
        public Dictionary<uint, IHuman> peopleD;

        public MainForm()
        {
            InitializeComponent();
            peopleQ = new Queue();
            peopleD = new Dictionary<uint, IHuman>();
        }

        private void objectChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            genderBox1.Text = "";
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            groupList.Items.Clear();

            if (objectChoice.SelectedIndex == 0)
            {
                personPanel.Visible = true;
                educatorPanel.Visible = false;
                studentPanel.Visible = false;
                enqueueButton.Location = new Point(16, 250);
                enqueueButton.Visible = true;
            }

            if (objectChoice.SelectedIndex == 1)
            {
                personPanel.Visible = true;
                educatorPanel.Visible = true;
                studentPanel.Visible = false;
                enqueueButton.Location = new Point(16, 425);
                enqueueButton.Visible = true;
            }

            if (objectChoice.SelectedIndex == 2)
            {
                personPanel.Visible = true;
                educatorPanel.Visible = false;
                studentPanel.Visible = true;
                enqueueButton.Location = new Point(16, 315);
                enqueueButton.Visible = true;
            }
        }

        private void objectChoice_TextChanged(object sender, EventArgs e)
        {
            if (objectChoice.Text.ToLower().Equals("person"))
            {
                objectChoice.SelectedIndex = 0;
                objectChoice.Focus();
                objectChoice.SelectionStart = objectChoice.Text.Length;
            }

            if (objectChoice.Text.ToLower().Equals("educator"))
            {
                objectChoice.SelectedIndex = 1;
                objectChoice.Focus();
                objectChoice.SelectionStart = objectChoice.Text.Length;
            }

            if (objectChoice.Text.ToLower().Equals("student"))
            {
                objectChoice.SelectedIndex = 2;
                objectChoice.Focus();
                objectChoice.SelectionStart = objectChoice.Text.Length;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if Enter pressed
            {
                string group = textBox4.Text.Trim();

                if (groupList.Items.Contains(group))
                {
                    groupList.SelectedIndex = groupList.Items.IndexOf(group);
                    return;
                }

                groupList.ClearSelected();

                if (Regex.IsMatch(group, @"..?-\d\d?-\d"))
                    groupList.Items.Add(group);
                else
                    MessageBox.Show("Некорректное название группы", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (groupList.SelectedIndex > -1 && (e.KeyChar == (char)8 || e.KeyChar == (char)46))
            {
                groupList.Items.RemoveAt(groupList.SelectedIndex);
            }
        }

        private void genderBox1_TextChanged(object sender, EventArgs e)
        {
            if (genderBox1.Text.ToLower().Equals("male"))
            {
                genderBox1.SelectedIndex = 0;
                genderBox1.Focus();
                genderBox1.SelectionStart = objectChoice.Text.Length;
            }

            if (genderBox1.Text.ToLower().Equals("female"))
            {
                genderBox1.SelectedIndex = 1;
                genderBox1.Focus();
                genderBox1.SelectionStart = objectChoice.Text.Length;
            }
        }

        private void enqueueButton_Click(object sender, EventArgs e)
        {
            string choice = objectChoice.Text.ToLower().Trim();

            if (choice.Equals("person"))
            {
                string name = textBox1.Text.Trim();
                string lastName = textBox2.Text.Trim();

                int age = 0;
                if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                    age = int.Parse(textBox3.Text.Trim());

                string gender = genderBox1.Text.Trim().ToLower();

                Person person = default;

                try
                {
                    person = new Person(name, lastName, age, gender);
                }
                catch (InvalidNameException)
                {
                    textBox1.Focus();
                    textBox1.SelectionStart = 0;
                    textBox1.SelectionLength = textBox1.Text.Length;
                    MessageBox.Show("Некорректное значение имени", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidLastNameException)
                {
                    textBox2.Focus();
                    textBox2.SelectionStart = 0;
                    textBox2.SelectionLength = textBox2.Text.Length;
                    MessageBox.Show("Некорректное значение фамилии", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidAgeException)
                {
                    textBox3.Focus();
                    textBox3.SelectionStart = 0;
                    textBox3.SelectionLength = textBox3.Text.Length;
                    MessageBox.Show("Некорректное значение возраста", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGenderException)
                {
                    genderBox1.Focus();
                    genderBox1.Select();
                    MessageBox.Show("Некорректное значение пола", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fullName = person.Name + " " + person.LastName;

                if (queueListBox.Items.Contains(fullName))
                {
                    queueListBox.SelectedIndex = queueListBox.Items.IndexOf(fullName);
                    MessageBox.Show("Человек с таким именем уже есть в очереди!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                peopleQ.Enqueue(person);
                queueListBox.Items.Add(fullName);
                CalculateQueue();
            }

            if (choice.Equals("educator"))
            {
                string name = textBox1.Text.Trim();
                string lastName = textBox2.Text.Trim();

                int age = 0;
                if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                    age = int.Parse(textBox3.Text.Trim());

                string gender = genderBox1.Text.Trim().ToLower();
                string university = textBox7.Text;

                int salary = -1;
                if (!string.IsNullOrEmpty(textBox8.Text.Trim()))
                    salary = int.Parse(textBox8.Text.Trim());

                string[] groups = new string[groupList.Items.Count];

                if (groups.Length == 0)
                {
                    groupList.Focus();
                    groupList.Select();
                    MessageBox.Show("Необходимо ввести хотя бы одну группу", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < groups.Length; i++)
                    groups[i] = (string)groupList.Items[i];

                Educator educator = default;

                try
                {
                    educator = new Educator(name, lastName, age, gender, university, salary, groups);
                }
                catch (InvalidNameException)
                {
                    textBox1.Focus();
                    textBox1.SelectionStart = 0;
                    textBox1.SelectionLength = textBox1.Text.Length;
                    MessageBox.Show("Некорректное значение имени", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidLastNameException)
                {
                    textBox2.Focus();
                    textBox2.SelectionStart = 0;
                    textBox2.SelectionLength = textBox2.Text.Length;
                    MessageBox.Show("Некорректное значение фамилии", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidAgeException)
                {
                    textBox3.Focus();
                    textBox3.SelectionStart = 0;
                    textBox3.SelectionLength = textBox3.Text.Length;
                    MessageBox.Show("Некорректное значение возраста", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGenderException)
                {
                    genderBox1.Focus();
                    genderBox1.Select();
                    MessageBox.Show("Некорректное значение пола", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidUniversityException)
                {
                    textBox7.Focus();
                    textBox7.Select();
                    MessageBox.Show("Некорректное название университета", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidSalaryException)
                {
                    textBox8.Focus();
                    textBox8.Select();
                    MessageBox.Show("Некорректное значение зарплаты", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGroupException)
                {
                    groupList.Focus();
                    groupList.Select();
                    MessageBox.Show("Некорректное название группы", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fullName = educator.Name + " " + educator.LastName;

                if (queueListBox.Items.Contains(fullName))
                {
                    queueListBox.SelectedIndex = queueListBox.Items.IndexOf(fullName);
                    MessageBox.Show("Человек с таким именем уже есть в очереди!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                peopleQ.Enqueue(educator);
                queueListBox.Items.Add(fullName);
                CalculateQueue();
            }

            if (choice.Equals("student"))
            {
                string name = textBox1.Text.Trim();
                string lastName = textBox2.Text.Trim();

                int age = 0;
                if (!string.IsNullOrEmpty(textBox3.Text.Trim()))
                    age = int.Parse(textBox3.Text.Trim());

                string gender = genderBox1.Text.Trim().ToLower();

                string university = textBox9.Text;

                string group = textBox6.Text;

                Student student = default;

                try
                {
                    student = new Student(name, lastName, age, gender, university, group);
                }
                catch (InvalidNameException)
                {
                    textBox1.Focus();
                    textBox1.SelectionStart = 0;
                    textBox1.SelectionLength = textBox1.Text.Length;
                    MessageBox.Show("Некорректное значение имени", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidLastNameException)
                {
                    textBox2.Focus();
                    textBox2.SelectionStart = 0;
                    textBox2.SelectionLength = textBox2.Text.Length;
                    MessageBox.Show("Некорректное значение фамилии", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidAgeException)
                {
                    textBox3.Focus();
                    textBox3.SelectionStart = 0;
                    textBox3.SelectionLength = textBox3.Text.Length;
                    MessageBox.Show("Некорректное значение возраста", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGenderException)
                {
                    genderBox1.Focus();
                    genderBox1.Select();
                    MessageBox.Show("Некорректное значение пола", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidUniversityException)
                {
                    textBox7.Focus();
                    textBox7.Select();
                    MessageBox.Show("Некорректное название университета", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGroupException)
                {
                    textBox6.Focus();
                    textBox6.Select();
                    MessageBox.Show("Некорректное название группы", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fullName = student.Name + " " + student.LastName;

                if (queueListBox.Items.Contains(fullName))
                {
                    queueListBox.SelectedIndex = queueListBox.Items.IndexOf(fullName);
                    MessageBox.Show("Человек с таким именем уже есть в очереди!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                peopleQ.Enqueue(student);
                queueListBox.Items.Add(fullName);
                CalculateQueue();
            }
        }

        private void flatButtonUI1_Click(object sender, EventArgs e)
        {
            if (peopleQ.Count > 0)
            {
                peopleQ.Dequeue();
                queueListBox.Items.RemoveAt(0);
                CalculateQueue();
            }
        }

        private void flatButtonUI3_Click(object sender, EventArgs e)
        {
            peopleQ.Clear();
            queueListBox.Items.Clear();
            CalculateQueue();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if enter is pressed
                enqueueButton_Click(sender, e);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (queueRB.Checked)
            {
                queuePanel.BringToFront();
                queueRB.Checked = false;
            }

            if (dictionaryRB.Checked)
            {
                dictionaryPanel.BringToFront();
                dictionaryRB.Checked = false;
            }

            if (textCollectionRB.Checked)
            {
                testCollectionPanel.BringToFront();
                textCollectionRB.Checked = false;
            }
        }

        private void flatButtonUI2_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();

            personPanel.Visible = false;
            educatorPanel.Visible = false;
            studentPanel.Visible = false;

            enqueueButton.Visible = false;

            objectChoice.Text = "";

            queueListBox.ClearSelected();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            genderBox1.Text = "";
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            groupList.Items.Clear();
        }

        private void CalculateQueue()
        {
            int personCount = 0;
            int educatorCount = 0;
            int studentCount = 0;

            foreach (object obj in peopleQ)
            {
                if (obj is Educator)
                {
                    educatorCount++;
                    continue;
                }
                if (obj is Student)
                {
                    studentCount++;
                    continue;
                }
                if (obj is Person)
                {
                    personCount++;
                    continue;
                }
            }

            personCountLabel.Text = $"Элементов типа Person: {personCount}";
            educatorCountLabel.Text = $"Элементов типа Educator: {educatorCount}";
            studentCountLabel.Text = $"Элементов типа Student: {studentCount}";
        }

        private void CalculateDictionary()
        {
            int personCount = 0;
            int educatorCount = 0;
            int studentCount = 0;

            foreach (IHuman human in peopleD.Values)
            {
                if (human is Educator)
                {
                    educatorCount++;
                    continue;
                }
                if (human is Student)
                {
                    studentCount++;
                    continue;
                }
                if (human is Person)
                {
                    personCount++;
                    continue;
                }
            }

            personCountLabel2.Text = $"Элементов типа Person: {personCount}";
            educatorCountLabel2.Text = $"Элементов типа Educator: {educatorCount}";
            studentCountLabel2.Text = $"Элементов типа Student: {studentCount}";

        }

        private Queue Clone(Queue queue)
        {
            Queue result = new Queue(queue.Count);

            while (queue.Count > 0)
            {
                object obj = (queue.Dequeue() as Person).Clone();
                result.Enqueue(obj);
            }

            return result;
        }

        private Dictionary<uint, IHuman> Clone(Dictionary<uint, IHuman> people)
        {
            Dictionary<uint, IHuman> result = new Dictionary<uint, IHuman>(people.Count);

            foreach (KeyValuePair<uint, IHuman> keyValue in people)
                result.Add(keyValue.Key, (IHuman)keyValue.Value.Clone());

            return result;
        }

        private void SortByKey(ref Dictionary<uint, IHuman> people)
        {
            SortedDictionary<uint, IHuman> sortedPeople = new SortedDictionary<uint, IHuman>(people);

            people = new Dictionary<uint, IHuman>(sortedPeople);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)13)              //if enter is pressed
                enqueueButton_Click(sender, e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)13)
                addButton_Click(sender, e);
        }

        private void keyChoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void valueChoice_TextChanged(object sender, EventArgs e)
        {
            if (valueChoice.Text.ToLower().Equals("person"))
            {
                valueChoice.SelectedIndex = 0;
                valueChoice.Focus();
                valueChoice.SelectionStart = valueChoice.Text.Length;
            }

            if (valueChoice.Text.ToLower().Equals("educator"))
            {
                valueChoice.SelectedIndex = 1;
                valueChoice.Focus();
                valueChoice.SelectionStart = valueChoice.Text.Length;
            }

            if (valueChoice.Text.ToLower().Equals("student"))
            {
                valueChoice.SelectedIndex = 2;
                valueChoice.Focus();
                valueChoice.SelectionStart = valueChoice.Text.Length;
            }

        }

        private void valueChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox10.Clear();
            genderBox2.Text = "";
            textBox5.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            groupList2.Items.Clear();

            if (valueChoice.SelectedIndex == 0)
            {
                personPanel2.Visible = true;
                educatorPanel2.Visible = false;
                studentPanel2.Visible = false;
                addButton.Location = new Point(16, 250);
                addButton.Visible = true;
            }

            if (valueChoice.SelectedIndex == 1)
            {
                personPanel2.Visible = true;
                educatorPanel2.Visible = true;
                studentPanel2.Visible = false;
                addButton.Location = new Point(16, 425);
                addButton.Visible = true;
            }

            if (valueChoice.SelectedIndex == 2)
            {
                personPanel2.Visible = true;
                educatorPanel2.Visible = false;
                studentPanel2.Visible = true;
                addButton.Location = new Point(16, 315);
                addButton.Visible = true;
            }
        }

        private void backButton2_Click(object sender, EventArgs e)
        {
            mainPanel.BringToFront();

            personPanel2.Visible = false;
            educatorPanel2.Visible = false;
            studentPanel2.Visible = false;

            addButton.Visible = false;

            valueChoice.Text = "";
            keyChoice.Text = "";

            dictionaryListBox.ClearSelected();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox10.Clear();
            genderBox2.Text = "";
            textBox5.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            groupList2.Items.Clear();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string value = valueChoice.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyChoice.Text.Trim()))
            {
                MessageBox.Show("Не введен ключ элемента", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                keyChoice.Focus();
                keyChoice.Select();
                return;
            }
            uint key = uint.Parse(keyChoice.Text.Trim());

            if (value.Equals("person"))
            {
                string name = textBox13.Text.Trim();
                string lastName = textBox12.Text.Trim();

                int age = 0;
                if (!string.IsNullOrEmpty(textBox11.Text.Trim()))
                    age = int.Parse(textBox11.Text.Trim());

                string gender = genderBox2.Text.Trim().ToLower();

                Person person = default;

                try
                {
                    person = new Person(name, lastName, age, gender);
                }
                catch (InvalidNameException)
                {
                    textBox13.Focus();
                    textBox13.SelectionStart = 0;
                    textBox13.SelectionLength = textBox13.Text.Length;
                    MessageBox.Show("Некорректное значение имени", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidLastNameException)
                {
                    textBox12.Focus();
                    textBox12.SelectionStart = 0;
                    textBox12.SelectionLength = textBox12.Text.Length;
                    MessageBox.Show("Некорректное значение фамилии", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidAgeException)
                {
                    textBox11.Focus();
                    textBox11.SelectionStart = 0;
                    textBox11.SelectionLength = textBox11.Text.Length;
                    MessageBox.Show("Некорректное значение возраста", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGenderException)
                {
                    genderBox2.Focus();
                    genderBox2.Select();
                    MessageBox.Show("Некорректное значение пола", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fullName = person.Name + " " + person.LastName;

                foreach (object obj in dictionaryListBox.Items)
                {
                    string strObj = (string)obj;

                    if (Regex.IsMatch(strObj, $@"{key}\..*"))
                    {
                        MessageBox.Show("Запись с таким ключем уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Regex.IsMatch(strObj, $@"\d*\. {fullName}"))
                    {
                        MessageBox.Show("Человек с таким именем уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                peopleD.Add(key, person);
                dictionaryListBox.Items.Add($"{key}. {fullName}");
                CalculateDictionary();
            }

            if (value.Equals("educator"))
            {
                string name = textBox13.Text.Trim();
                string lastName = textBox12.Text.Trim();

                int age = 0;
                if (!string.IsNullOrEmpty(textBox11.Text.Trim()))
                    age = int.Parse(textBox11.Text.Trim());

                string gender = genderBox2.Text.Trim().ToLower();
                string university = textBox16.Text;

                int salary = -1;
                if (!string.IsNullOrEmpty(textBox15.Text.Trim()))
                    salary = int.Parse(textBox15.Text.Trim());

                string[] groups = new string[groupList2.Items.Count];

                if (groups.Length == 0)
                {
                    groupList.Focus();
                    groupList.Select();
                    MessageBox.Show("Необходимо ввести хотя бы одну группу", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < groups.Length; i++)
                    groups[i] = (string)groupList2.Items[i];

                Educator educator = default;

                try
                {
                    educator = new Educator(name, lastName, age, gender, university, salary, groups);
                }
                catch (InvalidNameException)
                {
                    textBox13.Focus();
                    textBox13.SelectionStart = 0;
                    textBox13.SelectionLength = textBox13.Text.Length;
                    MessageBox.Show("Некорректное значение имени", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidLastNameException)
                {
                    textBox12.Focus();
                    textBox12.SelectionStart = 0;
                    textBox12.SelectionLength = textBox12.Text.Length;
                    MessageBox.Show("Некорректное значение фамилии", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidAgeException)
                {
                    textBox11.Focus();
                    textBox11.SelectionStart = 0;
                    textBox11.SelectionLength = textBox11.Text.Length;
                    MessageBox.Show("Некорректное значение возраста", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGenderException)
                {
                    genderBox2.Focus();
                    genderBox2.Select();
                    MessageBox.Show("Некорректное значение пола", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidUniversityException)
                {
                    textBox16.Focus();
                    textBox16.Select();
                    MessageBox.Show("Некорректное название университета", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidSalaryException)
                {
                    textBox15.Focus();
                    textBox15.Select();
                    MessageBox.Show("Некорректное значение зарплаты", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGroupException)
                {
                    groupList2.Focus();
                    groupList2.Select();
                    MessageBox.Show("Некорректное название группы", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fullName = educator.Name + " " + educator.LastName;

                foreach (object obj in dictionaryListBox.Items)
                {
                    string strObj = (string)obj;

                    if (Regex.IsMatch(strObj, $@"{key}\..*"))
                    {
                        MessageBox.Show("Запись с таким ключем уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Regex.IsMatch(strObj, $@"\d*\. {fullName}"))
                    {
                        MessageBox.Show("Человек с таким именем уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                peopleD.Add(key, educator);
                dictionaryListBox.Items.Add($"{key}. {fullName}");
                CalculateDictionary();
            }

            if (value.Equals("student"))
            {
                string name = textBox13.Text.Trim();
                string lastName = textBox12.Text.Trim();

                int age = 0;
                if (!string.IsNullOrEmpty(textBox11.Text.Trim()))
                    age = int.Parse(textBox11.Text.Trim());

                string gender = genderBox2.Text.Trim().ToLower();

                string university = textBox10.Text;

                string group = textBox5.Text;

                Student student = default;

                try
                {
                    student = new Student(name, lastName, age, gender, university, group);
                }
                catch (InvalidNameException)
                {
                    textBox13.Focus();
                    textBox13.SelectionStart = 0;
                    textBox13.SelectionLength = textBox13.Text.Length;
                    MessageBox.Show("Некорректное значение имени", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidLastNameException)
                {
                    textBox12.Focus();
                    textBox12.SelectionStart = 0;
                    textBox12.SelectionLength = textBox12.Text.Length;
                    MessageBox.Show("Некорректное значение фамилии", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidAgeException)
                {
                    textBox11.Focus();
                    textBox11.SelectionStart = 0;
                    textBox11.SelectionLength = textBox11.Text.Length;
                    MessageBox.Show("Некорректное значение возраста", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGenderException)
                {
                    genderBox2.Focus();
                    genderBox2.Select();
                    MessageBox.Show("Некорректное значение пола", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidUniversityException)
                {
                    textBox10.Focus();
                    textBox10.Select();
                    MessageBox.Show("Некорректное название университета", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (InvalidGroupException)
                {
                    textBox5.Focus();
                    textBox5.Select();
                    MessageBox.Show("Некорректное название группы", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string fullName = student.Name + " " + student.LastName;

                foreach (object obj in dictionaryListBox.Items)
                {
                    string strObj = (string)obj;

                    if (Regex.IsMatch(strObj, $@"{key}\..*"))
                    {
                        MessageBox.Show("Запись с таким ключем уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Regex.IsMatch(strObj, $@"\d*\. {fullName}"))
                    {
                        MessageBox.Show("Человек с таким именем уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                peopleD.Add(key, student);
                dictionaryListBox.Items.Add($"{key}. {fullName}");
                CalculateDictionary();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dictionaryListBox.Items.Count == 0 || dictionaryListBox.SelectedIndex == -1)
                return;

            Match match = Regex.Match(dictionaryListBox.Items[dictionaryListBox.SelectedIndex].ToString(), @"(\d*)\.*.");
            uint key = uint.Parse(match.Groups[1].ToString());

            peopleD.Remove(key);
            dictionaryListBox.Items.RemoveAt(dictionaryListBox.SelectedIndex);
            CalculateDictionary();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            peopleD.Clear();
            dictionaryListBox.Items.Clear();
            CalculateDictionary();
        }

        private void genderBox2_TextChanged(object sender, EventArgs e)
        {
            if (genderBox2.Text.ToLower().Equals("male"))
            {
                genderBox2.SelectedIndex = 0;
                genderBox2.Focus();
                genderBox2.SelectionStart = valueChoice.Text.Length;
            }

            if (genderBox2.Text.ToLower().Equals("female"))
            {
                genderBox2.SelectedIndex = 1;
                genderBox2.Focus();
                genderBox2.SelectionStart = valueChoice.Text.Length;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if Enter pressed
            {
                string group = textBox14.Text.Trim();

                if (groupList2.Items.Contains(group))
                {
                    groupList2.SelectedIndex = groupList2.Items.IndexOf(group);
                    return;
                }

                groupList2.ClearSelected();

                if (Regex.IsMatch(group, @"..?-\d\d?-\d"))
                    groupList2.Items.Add(group);
                else
                    MessageBox.Show("Некорректное название группы", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupList2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (groupList2.SelectedIndex > -1 && (e.KeyChar == (char)8 || e.KeyChar == (char)46))
            {
                groupList2.Items.RemoveAt(groupList2.SelectedIndex);
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            SortByKey(ref peopleD);

            dictionaryListBox.Items.Clear();

            foreach (KeyValuePair<uint, IHuman> keyValuePair in peopleD)
            {
                dictionaryListBox.Items.Add($"{keyValuePair.Key}. {keyValuePair.Value.Name} {keyValuePair.Value.LastName}");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                objectChoice.Focus();
                objectChoice.Select();
            }

            if (e.KeyCode == Keys.Down)              //if down button pressed
            {
                textBox2.Focus();
                textBox2.Select();
            }
        }

        private void objectChoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)              //if down button pressed
            {
                textBox1.Focus();
                textBox1.Select();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                textBox1.Focus();
                textBox1.Select();
            }

            if (e.KeyCode == Keys.Down)              //if down button pressed
            {
                textBox3.Focus();
                textBox3.Select();
            }
        }

        private void genderBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                textBox3.Focus();
                textBox3.Select();
            }

            if (e.KeyCode == Keys.Down)              //if down button pressed
            {
                if (studentPanel.Visible)
                {
                    textBox9.Focus();
                    textBox9.Select();
                }
                if (educatorPanel.Visible)
                {
                    textBox7.Focus();
                    textBox7.Select();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                textBox2.Focus();
                textBox2.Select();
            }

            if (e.KeyCode == Keys.Down)              //if down button pressed
            {
                genderBox1.Focus();
                genderBox1.Select();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                genderBox1.Focus();
                genderBox1.Select();
            }

            if (e.KeyCode == Keys.Down)              //if down button pressed
            {
                textBox6.Focus();
                textBox6.Select();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                genderBox1.Focus();
                genderBox1.Select();
            }

            if (e.KeyCode == Keys.Down)              //if down button pressed
            {
                textBox8.Focus();
                textBox8.Select();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                textBox7.Focus();
                textBox7.Select();
            }

            if (e.KeyCode == Keys.Down)              //if down button pressed
            {
                textBox4.Focus();
                textBox4.Select();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                textBox9.Focus();
                textBox9.Select();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)              //if up button pressed 
            {
                textBox8.Focus();
                textBox8.Select();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if enter is pressed
                enqueueButton_Click(sender, e);
        }

        private void genderBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if enter is pressed
                enqueueButton_Click(sender, e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if enter is pressed
                enqueueButton_Click(sender, e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if enter is pressed
                enqueueButton_Click(sender, e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if enter is pressed
                enqueueButton_Click(sender, e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)              //if enter is pressed
                enqueueButton_Click(sender, e);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void keyChoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                valueChoice.Focus();
                valueChoice.Select();
            }
        }

        private void valueChoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                keyChoice.Focus();
                keyChoice.Select();
            }

            if (e.KeyCode == Keys.Down)
            {
                textBox13.Focus();
                textBox13.Select();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                valueChoice.Focus();
                valueChoice.Select();
            }

            if (e.KeyCode == Keys.Down)
            {
                textBox12.Focus();
                textBox12.Select();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox12.Focus();
                textBox12.Select();
            }

            if (e.KeyCode == Keys.Down)
            {
                genderBox2.Focus();
                genderBox2.Select();
            }
        }

        private void genderBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox11.Focus();
                textBox11.Select();
            }

            if (e.KeyCode == Keys.Down)
            {
                if (studentPanel2.Visible)
                {
                    textBox10.Focus();
                    textBox10.Select();
                }
                if (educatorPanel2.Visible)
                {
                    textBox16.Focus();
                    textBox16.Select();
                }
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                genderBox2.Focus();
                genderBox2.Select();
            }

            if (e.KeyCode == Keys.Down)
            {
                textBox5.Focus();
                textBox5.Select();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox10.Focus();
                textBox10.Select();
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                genderBox2.Focus();
                genderBox2.Select();
            }

            if (e.KeyCode == Keys.Down)
            {
                textBox15.Focus();
                textBox15.Select();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox16.Focus();
                textBox16.Select();
            }

            if (e.KeyCode == Keys.Down)
            {
                textBox14.Focus();
                textBox14.Select();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox13.Focus();
                textBox13.Select();
            }

            if (e.KeyCode == Keys.Down)
            {
                textBox11.Focus();
                textBox11.Select();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox15.Focus();
                textBox15.Select();
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                addButton_Click(sender, e);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                addButton_Click(sender, e);
        }

        private void genderBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                addButton_Click(sender, e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                addButton_Click(sender, e);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                addButton_Click(sender, e);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                addButton_Click(sender, e);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
         
        private void createButton_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(sizeOfCollections.Value);
            TestCollections testCollections = new TestCollections(size);

            string peopleL_time1 = testCollections.MeasureContains_peopleL(Position.First);
            string stringQ_time1 = testCollections.MeasureContains_stringS(Position.First);
            string peoplePS_key_time1 = testCollections.MeasureContains_peoplePS_key(Position.First);
            string peoplePS_value_time1 = testCollections.MeasureContains_peoplePS_value(Position.First);
            string peopleSS_key_time1 = testCollections.MeasureContains_peopleSS_key(Position.First);

            list1.Text = $"{peopleL_time1} sec";
            queue1.Text = $"{stringQ_time1} sec";
            dictionary_key1.Text = $"{peoplePS_key_time1} sec";
            dictionary_value1.Text = $"{peoplePS_value_time1} sec";
            sortedDictionary1.Text = $"{peopleSS_key_time1} sec";

            string peopleL_time2 = testCollections.MeasureContains_peopleL(Position.Middle);
            string stringQ_time2 = testCollections.MeasureContains_stringS(Position.Middle);
            string peoplePS_key_time2 = testCollections.MeasureContains_peoplePS_key(Position.Middle);
            string peoplePS_value_time2 = testCollections.MeasureContains_peoplePS_value(Position.Middle);
            string peopleSS_key_time2 = testCollections.MeasureContains_peopleSS_key(Position.Middle);

            list2.Text = $"{peopleL_time2} sec";
            queue2.Text = $"{stringQ_time2} sec";
            dictionary_key2.Text = $"{peoplePS_key_time2} sec";
            dictionary_value2.Text = $"{peoplePS_value_time2} sec";
            sortedDictionary2.Text = $"{peopleSS_key_time2} sec";

            string peopleL_time3 = testCollections.MeasureContains_peopleL(Position.Last);
            string stringQ_time3 = testCollections.MeasureContains_stringS(Position.Last);
            string peoplePS_key_time3 = testCollections.MeasureContains_peoplePS_key(Position.Last);
            string peoplePS_value_time3 = testCollections.MeasureContains_peoplePS_value(Position.Last);
            string peopleSS_key_time3 = testCollections.MeasureContains_peopleSS_key(Position.Last);

            list3.Text = $"{peopleL_time3} sec";
            queue3.Text = $"{stringQ_time3} sec";
            dictionary_key3.Text = $"{peoplePS_key_time3} sec";
            dictionary_value3.Text = $"{peoplePS_value_time3} sec";
            sortedDictionary3.Text = $"{peopleSS_key_time3} sec";

            string peopleL_time4 = testCollections.MeasureContains_peopleL(Position.None);
            string stringQ_time4 = testCollections.MeasureContains_stringS(Position.None);
            string peoplePS_key_time4 = testCollections.MeasureContains_peoplePS_key(Position.None);
            string peoplePS_value_time4 = testCollections.MeasureContains_peoplePS_value(Position.None);
            string peopleSS_key_time4 = testCollections.MeasureContains_peopleSS_key(Position.None);

            list4.Text = $"{peopleL_time4} sec";
            queue4.Text = $"{stringQ_time4} sec";
            dictionary_key4.Text = $"{peoplePS_key_time4} sec";
            dictionary_value4.Text = $"{peoplePS_value_time4} sec";
            sortedDictionary4.Text = $"{peopleSS_key_time4} sec";
        }

        private void flatButtonUI2_Click_1(object sender, EventArgs e)
        {
            mainPanel.BringToFront();

            sizeOfCollections.Value = 99;

            list1.Text = "________";
            queue1.Text = "________";
            dictionary_key1.Text = "________";
            dictionary_value1.Text = "________";
            sortedDictionary1.Text = "________";

            list2.Text = "________";
            queue2.Text = "________";
            dictionary_key2.Text = "________";
            dictionary_value2.Text = "________";
            sortedDictionary2.Text = "________";

            list3.Text = "________";
            queue3.Text = "________";
            dictionary_key3.Text = "________";
            dictionary_value3.Text = "________";
            sortedDictionary3.Text = "________";

            list4.Text = "________";
            queue4.Text = "________";
            dictionary_key4.Text = "________";
            dictionary_value4.Text = "________";
            sortedDictionary4.Text = "________";
        }

        private void sizeOfCollections_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                createButton_Click(sender, e);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}