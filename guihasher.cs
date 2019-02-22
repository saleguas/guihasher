using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WindowsFormsApp2
{

    public partial class guihasher : Form
    {
        private OpenFileDialog origin;
        private HashFile md5File;
        private HashFile sha1File;
        private HashFile sha256File;
        private String fileName;

        public guihasher()
        {
            InitializeComponent();
        }

        private void generateMD5(string inpath, string outpath)
        {
            FileStream fs = File.OpenRead(inpath);
            HashAlgorithm hashAlgorithm = MD5.Create();
            byte[] retn = hashAlgorithm.ComputeHash(fs);
            md5File = new HashFile(ToHexString(retn), "md5");
            fs.Close();
            md5File.generateFile(outpath);
        }

        private void generateSHA1(string inpath, string outpath)
        {
            FileStream fs = File.OpenRead(inpath);
            SHA1Managed sha1 = new SHA1Managed();
            byte[] retn = sha1.ComputeHash(fs);
            sha1File = new HashFile(ToHexString(retn), "sha1");
            fs.Close();
            sha1File.generateFile(outpath);
        }

        private void generateSHA256(string inpath, string outpath)
        {
            FileStream fs = File.OpenRead(inpath);
            SHA256 mySHA256 = SHA256.Create();
            byte[] retn = mySHA256.ComputeHash(fs);
            sha256File = new HashFile(ToHexString(retn), "sha256");
            fs.Close();
            sha256File.generateFile(outpath);
        }

        public static string ToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Any file|*.*";
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.SafeFileName;
                button1.Text = fileName;
                origin = openFileDialog1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream mystream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "md5 files (*.md5)|*.md5";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = origin.SafeFileName + ".md5";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystream = saveFileDialog1.OpenFile()) != null)
                {
                    mystream.Close();
                    generateMD5(origin.FileName, saveFileDialog1.FileName);

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream mystream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "sha1 files (*.sha1)|*.sha1";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = origin.SafeFileName + ".sha1";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystream = saveFileDialog1.OpenFile()) != null)
                {
                    mystream.Close();
                    generateSHA1(origin.FileName, saveFileDialog1.FileName);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stream mystream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "sha256 files (*.sha256)|*.sha256";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = origin.SafeFileName + ".sha256";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystream = saveFileDialog1.OpenFile()) != null)
                {
                    mystream.Close();
                    generateSHA256(origin.FileName, saveFileDialog1.FileName);

                }
            }
        }
    }
}
