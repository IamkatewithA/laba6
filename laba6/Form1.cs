using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void calculation_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "X";
            dataGridView1.Columns[1].Name = "Y";
            dataGridView1.Columns[2].Name = "G";

            TabPage selectedTab = tabControl1.SelectedTab;
            var textBoxes = selectedTab.Controls.OfType<TextBox>().ToList();


            string s1 = textBoxes[0].Text;
            string s2 = textBoxes[1].Text;
            string s3 = textBoxes[2].Text;
            string s4 = textBoxes[3].Text;
            string s5 = textBoxes[4].Text;
            string s6 = textBoxes[5].Text;

            try
            {

                double startY = Convert.ToDouble(s1);
                double endY = Convert.ToDouble(s2);
                int n = int.Parse(s3);

                double startX = Convert.ToDouble(s6);
                double endX = Convert.ToDouble(s5);
                double step = Convert.ToDouble(s4);

                Class1 class1 = new Class1();
                Array X = class1.X(startX, endX, step);
                Array Y = class1.Y(startY, endY, n);

                int count = X.Length;

                double[] range = new double[count];


                double x, y;
                int size = (int)Math.Ceiling((endX - startX) / step) + 1;
                double step_y = (endY - startY) / (n - 1);

                for (int i = 0; i < count; i++)
                {
                    x = startX + step * i;
                    y = startY + step_y * i;
                    double gValue = class1.G(x, y);

                    dataGridView1.Rows.Add(x, y, gValue);
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                }

            }
            catch
            {
                MessageBox.Show("Неверный ввод данных");
            }


        }

        private void closef_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void output_in_table_Click(object sender, EventArgs e)
        {
            try
            {
                string directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DataFiles";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string logFilePath = "myProgram.log";
                string path_1 = Path.Combine(directoryPath, logFilePath);



                using (FileStream file = new FileStream(path_1, FileMode.OpenOrCreate))
                using (StreamWriter stream = new StreamWriter(file))
                {
                    stream.WriteLine("Название программы: laba6");
                    stream.WriteLine("Вариант: 3");
                    stream.WriteLine("Расчитывемая функция: f = y / sin(-x^2)");
                    stream.WriteLine($"Дата и время начала выполнения расчёта: {DateTime.Now}");
                }
                MessageBox.Show("Файл успешно создан на вашем рабочем столе");
            }
            catch
            {
                MessageBox.Show("Ошибка при создании файла");
            }

        }

        public int count = 2;
        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем новую вкладку
            
            string name = count.ToString();
            TabPage newTab = new TabPage(name);
            count++;

            // Копируем все элементы с первой вкладки на новую вкладку
            foreach (Control control in tabControl1.TabPages[0].Controls)
            {
                Control newControl = (Control)Activator.CreateInstance(control.GetType());
                newControl.Location = control.Location;
                newControl.Size = control.Size;
                newControl.Text = control.Text;
                newTab.Controls.Add(newControl);
                
            }

            // Добавляем новую вкладку в tabControl
            tabControl1.TabPages.Add(newTab);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1) // Проверяем, что вкладок больше одной
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab); // Удаляем текущую выбранную вкладку
            }
            else
            {
                MessageBox.Show("Нельзя удалить последнюю вкладку!");
            }
        }
    }
}
