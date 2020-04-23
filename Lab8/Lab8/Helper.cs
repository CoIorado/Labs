using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Lab8
{
    class Helper
    {
        public static void PrintDataBase(string DBpath, RichTextBox textField)
        {
            textField.Clear();

            string result = "";
            double averageTemp = 0;

            Month month = Deserialize(DBpath);
            month.Sort();

            if (month.Days.Count == 0)
                return;

            foreach (Day day in month.Days)
            {
                if (day.Temperature >= 0)
                    result += $"{day.Number}\t\t\t\t {day.Temperature}\n";
                else
                    result += $"{day.Number}\t\t\t\t{day.Temperature}\n";

                averageTemp += day.Temperature;
            }
            averageTemp /= month.Days.Count;

            result = result.Trim();
            textField.Text = result;

            string[] resultRows = textField.Text.Split('\n');

            foreach (string row in resultRows)
            {
                Match match = Regex.Match(row, @"\t(.*)$");
                int temperature = int.Parse(match.Groups[1].Value);

                if (temperature > averageTemp)
                {
                    textField.SelectionStart = textField.Text.IndexOf(row);
                    textField.SelectionLength = row.Length;
                    textField.SelectionColor = System.Drawing.Color.FromArgb(179, 57, 57);
                }
            }
        }

        public static void AddDaysToComboBox(string DBpath, ComboBox comboBox)
        {
            comboBox.Items.Clear();

            Month month = Deserialize(DBpath);
            month.Sort();

            if (month.Days.Count == 0)
                return;

            foreach (Day day in month.Days)
            {
                comboBox.Items.Add(day.Number);
            }
        }

        public static void AddTempToComboBox(string DBpath, ComboBox comboBox)
        {
            comboBox.Items.Clear();

            Month month = Deserialize(DBpath);
            month.Sort();

            if (month.Days.Count == 0)
                return;

            List<int> temps = new List<int>();

            foreach(Day day in month.Days)
            {
                if (temps.IndexOf(day.Temperature) < 0)
                    temps.Add(day.Temperature);
            }

            temps.Sort();

            foreach (int temp in temps)
                comboBox.Items.Add(temp);
        }

        public static void Serialize(string path, Month month)
		{
			if (!Regex.IsMatch(path, @".*\.txt") && !Regex.IsMatch(path, @".*\.dat"))
				throw new InvalidPathException();

            XmlSerializer xml = new XmlSerializer(typeof(Month));

            using (FileStream fstream = new FileStream(path, FileMode.Create, FileAccess.Write))
			{
                xml.Serialize(fstream, month);
			}
		}

        public static Month Deserialize(string path)
		{
			if (!Regex.IsMatch(path, @".*\.txt") && !Regex.IsMatch(path, @".*\.dat"))
		        return null;

            XmlSerializer xml = new XmlSerializer(typeof(Month));
            string fileText = "";

            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
			{
                using (StreamReader reader = new StreamReader(fstream))
                    fileText = reader.ReadToEnd().Trim();
			}

            if (string.IsNullOrEmpty(fileText))
                return new Month();

            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                return (Month)xml.Deserialize(fstream);
            }
		}
	}

    class InvalidPathException : Exception { }
}