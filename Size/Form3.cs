using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Size
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = folderBrowserDialog.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(selectedFolder);
                // Tính tổng kích thước các file trong thư mục
                long totalSize = 0;
                foreach (var file in directoryInfo.EnumerateFiles())
                {
                    totalSize += file.Length;
                }

                
                string convertedSize = ConvertFolderSize(totalSize);
                textBox1.Text = $"{Path.GetFileName(selectedFolder)}";
                textBox2.Text = convertedSize ;
                
            }
        }
        private string ConvertFolderSize(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }

            return "0 bytes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
