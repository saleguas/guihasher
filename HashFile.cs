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
    public class HashFile
    {
        public string hash, extension;

        public HashFile(string hash, string extension)
        {
            this.hash = hash;
            this.extension = extension;
        }

        public void generateFile(string path)
        {
            MessageBox.Show(path);
            using (TextWriter tw = new StreamWriter(path ))
            {
                tw.WriteLine(hash);
                tw.Close();
            }
        }
    }
}
