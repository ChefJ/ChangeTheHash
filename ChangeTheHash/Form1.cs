using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeTheHash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            string inFilePath = "";
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog
            {
                //openFileDialog1.InitialDirectory = "c:\\";
                Filter = "All files (*.*)|*.*| Files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //此处做你想做的事 ...=openFileDialog1.FileName; 
                inFilePath = openFileDialog1.FileName + openFileDialog1.Title;
                try
                {
                    tbxFilePath.Text = inFilePath;
                    lblHash.Text = CalculateMD5(inFilePath);

                }
                catch (Exception exx)
                {

                    //MessageBox.Show("您的CMS文件格式可能不正确。");
                }
                // LicName = System.IO.Path.GetFileName(tbxStraightPath.Text);
            }
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        static void MD5Obs(string filename,string obschar)
        {
            File.AppendAllText(filename, obschar);
        }

        private void btnChangeHash_Click(object sender, EventArgs e)
        {
            MD5Obs(tbxFilePath.Text, "-");
            lblHash.Text = CalculateMD5(tbxFilePath.Text);

        }
    }
}
