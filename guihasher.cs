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
        public static string ToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Any file|*.*";
            openFileDialog1.Title = "Select a File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                fileName = openFileDialog1.SafeFileName;
                button1.Text = fileName;
                origin = openFileDialog1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "md5 files (*.md5)|*.md5";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = origin.SafeFileName + ".md5";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    generateMD5(origin.FileName, saveFileDialog1.FileName);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
