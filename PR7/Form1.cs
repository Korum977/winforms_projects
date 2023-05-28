using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR7
{
    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();

        }

        private void окрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpeDlg = new OpenFileDialog();
            if(OpeDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpeDlg.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpeDlg.Dispose();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog SaveDlg = new OpenFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информация о приложении и разработчике");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            listBox1.BeginUpdate();
            String[] Strings = richTextBox1.Text.Split(new char[]
                { '\n','\t',' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string each in Strings)
            {
                String Str = each.Trim();

                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                }
            }
            listBox1.EndUpdate();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 3; i++)
            {
                ListBox listBox = (ListBox)Controls.Find("listBox" + i, true)[0];
                listBox.Items.Clear();
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            string Find = textBox1.Text;

            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }

            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();
        }


        private void DeleteSelectedStrings(ListBox ListBox)
        {
            for (int i = ListBox.Items.Count - 1; i >= 0; i--)
            {
                if (ListBox.GetSelected(i)) ListBox.Items.RemoveAt(i);
            }
        }

        private void TransferSelectedString(ListBox ListBoxFrom, 
                                            ListBox ListBoxTo)
        {
            for (int i = 0; i < ListBoxFrom.Items.Count; i++)
            {
                if (ListBoxFrom.GetSelected(i)) 
                {
                    ListBoxTo.Items.Add(ListBoxFrom.Items[i]); 
                    ListBoxFrom.Items.RemoveAt(i); 
                    i--;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) DeleteSelectedStrings(listBox1);
            if (checkBox2.Checked) DeleteSelectedStrings(listBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransferSelectedString(listBox1, listBox2);
        }

        private void sort(ComboBox comboBox, ListBox listBox)
        {
            int sortIndex = comboBox.SelectedIndex;

            switch (sortIndex)
            {
                case 0:
                    var elem1 = listBox.Items.Cast<string>().OrderBy(x => x).ToList();
                    listBox.Items.Clear();
                    elem1.ForEach(x => listBox.Items.Add(x));
                    break;
                case 1:
                    var elem2 = listBox.Items.Cast<string>().OrderByDescending(x => x).ToList();
                    listBox.Items.Clear();
                    elem2.ForEach(x => listBox.Items.Add(x));
                    break;
                case 2:
                    var elem3 = listBox.Items.Cast<string>().OrderBy(x => x.Length).ToList();
                    listBox.Items.Clear();
                    elem3.ForEach(x => listBox.Items.Add(x));
                    break;
                case 3:
                    var elem4 = listBox.Items.Cast<string>().OrderByDescending(x => x.Length);
                    listBox.Items.Clear();
                    elem4.ToList().ForEach(x => listBox.Items.Add(x));
                    break;
                default:
                    break;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            TransferSelectedString(listBox2, listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort(comboBox1, listBox1);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort(comboBox2, listBox2);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
