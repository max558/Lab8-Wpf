﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.IO;

/*
 * Доработать проект текстового редактора из задания 5, заменив все обработчики событий нажатия пунктов меню командами.
 */

namespace TextReader
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

        private void ComboBox_SelectionChanged_Font(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (texBox != null)
            {
                texBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_Size(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (texBox != null)
            {
                texBox.FontSize = Convert.ToDouble(fontSize);
            }
        }
        
        private void RadioButton_Checked_Black(object sender, RoutedEventArgs e)
        {
            if (texBox == null)
            {
                return;
            }
            texBox.Foreground = Brushes.Black;
        }

        private void RadioButton_Checked_Red(object sender, RoutedEventArgs e)
        {
            if (texBox == null)
            {
                return;
            }

            texBox.Foreground = Brushes.Red;
        }


        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpepExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                texBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, texBox.Text);
            }
        }

        private void BoldExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            
            if (texBox == null)
            {
                return;
            }
            if (texBox.FontWeight != FontWeights.Normal)
            {
                texBox.FontWeight = FontWeights.Normal;
            }
            else
            {
                texBox.FontWeight = FontWeights.Bold;
            }
        }

        private void ItalicExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (texBox == null)
            {
                return;
            }
            if (texBox.FontStyle == FontStyles.Italic)
            {
                texBox.FontStyle = FontStyles.Normal;
            }
            else
            {
                texBox.FontStyle = FontStyles.Italic;
            }
        }

        private void UnderLineExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (texBox == null)
            {
                return;
            }

            if (texBox.TextDecorations == TextDecorations.Underline)
            {
                texBox.TextDecorations = null;
            }
            else
            {
                texBox.TextDecorations = TextDecorations.Underline;
            }
        }
    }
}
