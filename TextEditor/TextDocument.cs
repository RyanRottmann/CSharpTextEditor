using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    class TextDocument
    {


        public string open()
        {
            String docText = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Text File";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    docText = sr.ReadToEnd();
                    sr.Close();
                }
            }
            return docText;
        }

        public void save(String filePath, String saveText)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (filePath != "")
            {
                saveFileDialog.FileName = System.IO.Path.GetFileName(filePath);
                saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(filePath);
            }
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            StreamWriter text = new StreamWriter(saveFileDialog.FileName);
            text.Write(saveText);
            text.Close();
            
        }
        public void saveAs(String filePath, String saveText)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (filePath != "")
            {
                saveFileDialog.FileName = System.IO.Path.GetFileName(filePath);
                saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(filePath);
            }
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter text = new StreamWriter(saveFileDialog.FileName);
                text.Write(saveText);
                text.Close();
            }
        }
    }
}
