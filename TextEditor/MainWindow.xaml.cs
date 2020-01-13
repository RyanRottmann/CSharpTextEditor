using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String currentFilePath = "new.txt";
        public Boolean modified = false;

        public MainWindow()
        {
            InitializeComponent();

            //StreamWriter outputFile;
            //outputFile = File.CreateText("courses.txt"); //File.AppendText appends text File.CreateText creates file and if file exists contents are erased
            // File.CreateText(@"Users\Chris\Documents\Names.txt"); @ gets rid of tabs and newline characters
            //outputFile.WriteLine("Introduction to Computer Science");
            //outputFile.Close();
            // while inputFile.EndOfStream == false){ }

        }

        private Boolean modifiedAlert()
        {
            TextDocument textDocument = new TextDocument();
            if (!modified) return true;

            string messageText = "This document has not been saved\nDo you want to save?";
            string caption = "Save Alert";

            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(messageText, caption, button, icon);
            switch (messageBoxResult)
            {
                case MessageBoxResult.Yes: // Save document and exit
                    textDocument.saveAs(currentFilePath, textBox1.Text);
                    return true;

                case MessageBoxResult.No: // Exit without saving
                    return true;

                case MessageBoxResult.Cancel: // Don't exit
                    return false;
            }

            return false;
        }

        private void New_menuItem_Click(object sender, RoutedEventArgs e)
        {
            if (modifiedAlert())
            {
                textBox1.Clear();

            }

        }

        private void Open_menuItem_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
            TextDocument textDocument = new TextDocument();
            textBox1.Text = textDocument.open();
            modified = false;
        }

        private void Save_menuItem_Click(object sender, RoutedEventArgs e)
        {
            TextDocument textDocument = new TextDocument();
            textDocument.save(currentFilePath, textBox1.Text);
            modified = false;
        }

        private void SaveAs_menuItem_Click(object sender, RoutedEventArgs e)
        {
            TextDocument textDocument = new TextDocument();
            textDocument.saveAs(currentFilePath, textBox1.Text);
            modified = false;
            save_menuItem.IsEnabled = true;
        }

        private void Exit_menuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_menuItem_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Text Editor Created By Ryan Rottmann";
            System.Windows.MessageBox.Show(messageBoxText);
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            modified = true;
        }
    }
}
