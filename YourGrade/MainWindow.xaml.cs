
﻿using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace YourGrade
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Multiselect = false;
            dialog.Filter = "PDF(*.pdf)|*.pdf";
            dialog.Title = "PDF 파일 선택";
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                PDFReader pdfReader = new PDFReader();
                User user = new User();

                string path, fileName;
                path = dialog.FileName;
                string[] dir = path.Split('\\');
                fileName = dir[dir.Length - 1];
                fileNameTextBlock.Text = fileName;
                pdfReader.SetDataFromPDF(user, path);

                majorGradeTextBox.Text = (Math.Truncate(user.MajorGrade * 100) / 100).ToString();
                majorScoreTextBox.Text = (Math.Truncate(user.MajorScore * 10) / 10).ToString();
                majorPointTextBlock.Text = user.MajorPoint.ToString();

                totalGradeTextBox.Text = (Math.Truncate(user.TotalGrade * 100) / 100).ToString();
                totalScoreTextBox.Text = (Math.Truncate(user.TotalScore * 10) / 10).ToString();
                totalPointTextBlock.Text = user.TotalPoint.ToString();
            }

        }

        private void InfoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            InformationWindow infoWindow = new InformationWindow();
            infoWindow.Top = this.Top + (this.ActualHeight - infoWindow.Height) / 2;
            infoWindow.Left = this.Left + (this.ActualWidth - infoWindow.Width) / 2;
            infoWindow.Show();
        }
    }
}