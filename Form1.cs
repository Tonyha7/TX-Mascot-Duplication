using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 天选姬多开
{
    public partial class Form1 : Form
    {
        String Mpath = "C:\\Program Files\\ASUS\\TX Mascot\\TX Mascot.exe";
        public Form1()
        {
            InitializeComponent();
        }

        private void SelectFile()
        {
            string path = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "TX Mascot.exe|*.exe"
            };

            //var result = openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }

            if (path != null && path != "")
            {
                textBox1.Text = path;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Mpath))
            {
                textBox1.Text = Mpath;
            }
            else
            {
                MessageBox.Show("未定位到天选姬程序 请手动选择路径");
                SelectFile();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count;
            if (textBox1.Text.Length > 0)
            {
                if (textBox2.Text.Length == 0)
                {
                    MessageBox.Show("请输入多开数量");
                    return;
                }

                try
                {
                    count = Convert.ToInt32(textBox2.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("请输入整数");
                    return;
                }

                if (count <= 0)
                {
                    MessageBox.Show("玩呢");
                    return;
                }

                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        System.Diagnostics.Process.Start(textBox1.Text, "/duplicate");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("启动失败");
                    return;
                }
            }
            else
            {
                SelectFile();
                return;
            }
        }
    }
}
