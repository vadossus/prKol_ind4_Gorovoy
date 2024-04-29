using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Security.Policy;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Hashtable hs = new Hashtable();
        Hashtable hs2 = new Hashtable();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Ошибка: Пустые строка в поле");
                    return;
                }
                else
                {
                    string disk_author = textBox1.Text;

                    if (!listBox1.Items.Contains(disk_author))
                    {
                        hs.Add(hs.Count + 1, disk_author);
                        listBox1.Items.Add(hs[hs.Count]);
                    }
                    else
                    {
                        MessageBox.Show("Данный диск уже присутствует");
                        return;
                    }
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ошибка: Данный элемент уже добавлен");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("Ошибка: Пустые строка в поле");
                    return;
                }
                else
                {
                    string music = textBox4.Text;

                    if (!listBox2.Items.Contains(music))
                    {
                        hs2.Add(hs2.Count + 1, music);
                        listBox2.Items.Add(hs2[hs2.Count]);
                    }
                    else
                    {
                        MessageBox.Show("Данная песня уже присутствует");
                        return;
                    }
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ошибка: Данный элемент уже добавлен");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                hs.Remove(listBox1.SelectedIndex + 1);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                hs2.Remove(listBox2.SelectedIndex + 1);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;

            List<string> symma = new List<string>();
            foreach (string value in hs.Values)
            {
                if (value.StartsWith(name))
                {
                    symma.Add(value);
                }
            }

            listBox1.ClearSelected();  

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (symma.Contains(listBox1.Items[i].ToString()))
                {
                    listBox1.SetSelected(i, true); 
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;

            List<string> symma1 = new List<string>();
            foreach (string value in hs2.Values)
            {
                if (value.StartsWith(name))
                {
                    symma1.Add(value);
                }
            }

            listBox2.ClearSelected();

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (symma1.Contains(listBox2.Items[i].ToString()))
                {
                    listBox2.SetSelected(i, true);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0 && listBox2.Items.Count <= 0)
            {
                MessageBox.Show("Нечего сортировать");
                return;
            }
            else if (listBox1.Items.Count > 0)
            {
                List<string> values = new List<string>(hs.Values.Cast<string>());

                values.Sort();

                listBox1.Items.Clear();

                foreach (string value in values)
                {
                    listBox1.Items.Add(value);
                }
            }
            else if (listBox2.Items.Count > 0)
            {
                List<string> values = new List<string>(hs2.Values.Cast<string>());

                values.Sort();

                listBox2.Items.Clear();

                foreach (string value in values)
                {
                    listBox2.Items.Add(value);
                }
            }


        }
    }
}
