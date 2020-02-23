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

namespace lista_de_carpetas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            string ruta = string.Empty;
          
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ruta = folderBrowserDialog1.SelectedPath;
            }
            textBox1.Text = ruta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("No hay direccion a escanear");
            }
            else
            {
                DirectoryInfo directori = new DirectoryInfo(textBox1.Text);

                foreach (var fi in directori.GetDirectories("*.*", SearchOption.AllDirectories))
                {
                    listBox1.Items.Add(fi.Name);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                SaveFileDialog Guardar = new SaveFileDialog();
                Guardar.Filter = "txt(*.txt)|*.txt|xls(*.xls)|*.xls";
               
                if (Guardar.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(Guardar.FileName))
                {
                    string nom = Guardar.FileName;
                    StreamWriter sw = new StreamWriter(Guardar.FileName);
                    foreach (Object lis in listBox1.Items)
                    {

                        sw.WriteLine(lis.ToString());

                    }
                    sw.Close();
                    MessageBox.Show("Guardado con exito");
                 
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            listBox1.Items.Clear();
        }
    }
}
