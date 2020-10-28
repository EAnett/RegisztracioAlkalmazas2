using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegisztracioAlkalmazas2
{
    public partial class Form_Regisztracio : Form
    {
        public Form_Regisztracio()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Hobby.Text.Trim()))
            {
                MessageBox.Show("Nem töltötte ki a hobby mezőt vagy hibás!", "Hiányos vagy hibás adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Hobby.Focus();
                return;
            }
            string nev=textBox_Nev.Text.Trim();
            string kor=textBox_Kor.Text;
            int szulev=(int)numericUpDown_Kor.Value;
            string nem;
            if (radioButton_No.Checked)
            {
                nem = "No";
                nem = "Ferfi";
            }
            else 
            {
                nem = "Ferfi";
            }
            
            string hobby=textBox_Hobby.Text.Trim();
            Regisztracio Regisztracio = new Regisztracio(nev, kor, szulev, nem, hobby);
            listBox_Hobby.Items.Add(Regisztracio);
            textBox_Hobby.Text = "";
            numericUpDown_Kor.Value = 1990;
            listBox_Hobby.SelectedIndex = -1;
        }

        private void listBox_Hobby_SelecetedIndexChange(object sender, EventArgs e)
        {
            Regisztracio regisztracio = (Regisztracio)listBox_Hobby.Items[listBox_Hobby.SelectedIndex];
            textBox_Hobby.Text = regisztracio.Hobby;
        }

        private void button_Mentes_Click(object sender, EventArgs e)
        {

            if (textBox_Kor.Text==""|| DateTime.Parse(textBox_Kor.Text)>DateTime.Now) 
            {
                MessageBox.Show("Nem töltötte ki a 'KOR' mezőt vagy hibás!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Kor.Focus();
                return;

            }
            if (string.IsNullOrEmpty(textBox_Nev.Text.Trim()))
            {
                MessageBox.Show("Nem töltötte ki a 'NÉV' mezőt!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Nev.Focus();
                return;
            }

            if (!(radioButton_Ferfi.Checked || radioButton_No.Checked))
            {
                MessageBox.Show("Nem töltötte ki a 'NEM' mezőt!", "Hiányzó adat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBox_Hobby.SelectedIndex == -1)
            {
                MessageBox.Show("Jelölj ki egy kedvenc hobbyt!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                using (StreamWriter sw = new StreamWriter(file))
                {
                    foreach (Regisztracio item in listBox_Hobby.Items)
                    {
                        sw.WriteLine(item.Sorba());
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void button_Beolvas_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        Regisztracio Regisztracio = new Regisztracio(sr.ReadLine());
                        listBox_Hobby.Items.Add(sr.ReadLine());
                    }
                }
            }
        }
    }
}
