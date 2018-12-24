using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordsCounterV2wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string fileName = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                fileName = openFileDialog1.FileName;
            }
            

            List<string> words = new List<string>();
            List<int> counts = new List<int>();
            string[] linewords;

            if (fileName != null)
            {
                StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("Windows-1251"));
                string line = sr.ReadLine();
                while (line != null)
                {
                    linewords = line.Split(' ');
                    for (int i = 0; i < linewords.Length; i++)
                    {
                        if (!words.Contains(linewords[i]))
                        {
                            words.Add(linewords[i]);
                            counts.Add(1);
                        }
                        else
                        {
                            counts[words.FindIndex(str => str == linewords[i])]++;
                        }

                    }
                    line = sr.ReadLine();
                }
            }
            for (int i = 0; i < counts.Count; i++)
            {
                for (int j = 0; j < counts.Count - 1; j++)
                {
                    if (counts[j] > counts[j + 1])
                    {
                        int z = counts[j];
                        string s = words[j];
                        counts[j] = counts[j + 1];
                        words[j] = words[j + 1];
                        counts[j + 1] = z;
                        words[j + 1] = s;
                    }
                }
            }
            for (int i = 0; i < words.Count; i++)
            {
                listBox.Items.Add(words[i] + " | " + counts[i]);
            }
        }
    }
}
