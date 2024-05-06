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

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        Hashtable hashtable = new Hashtable();
        Hashtable hashtable2 = new Hashtable();
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
                    MessageBox.Show("Ошибка: Строка пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string disk_author = textBox1.Text;
                    hashtable.Add(hashtable.Count + 1, disk_author);
                    listBox1.Items.Add(hashtable[hashtable.Count]);
                    textBox1.Clear();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Элемент уже добавлен");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "";
            }
            else if (!string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Ошибка: Строка пустая", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string music_author = textBox2.Text;
                    hashtable2.Add(hashtable2.Count + 1, music_author);
                    listBox2.Items.Add(hashtable2[hashtable2.Count]);
                    textBox2.Clear();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Элемент уже добавлен");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0 && listBox2.Items.Count <= 0)
            {
                MessageBox.Show("Ничего сортировать");
                return;
            }
            else if (listBox1.Items.Count > 0)
            {
                List<string> symma = new List<string>(hashtable.Values.Cast<string>());

                symma.Sort();

                listBox1.Items.Clear();

                foreach (string value in symma)
                {
                    listBox1.Items.Add(value);
                }

            }
            else if (listBox2.Items.Count > 0)
            {
                List<string> symma2 = new List<string>(hashtable2.Values.Cast<string>());

                symma2.Sort();

                listBox2.Items.Clear();

                foreach(string value in symma2)
                {
                    listBox2.Items.Add(value);
                }
            }

            
            

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                hashtable.Remove(listBox1.SelectedIndex + 1);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
                return;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string search = textBox3.Text;

            List<string> symma1 = new List<string>();
            foreach(string value in hashtable.Values)
            {
                if (value.StartsWith(search))
                {
                    symma1.Add(value);
                }
            }

            listBox1.ClearSelected();

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if(symma1.Contains(listBox1.Items[i].ToString()))
                {
                    listBox1.SetSelected(i, true);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                hashtable2.Remove(listBox2.SelectedIndex + 1);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string search = textBox4.Text;

            List<string> symma1 = new List<string>();
            foreach (string value in hashtable2.Values)
            {
                if (value.StartsWith(search))
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
    }
}
