using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Diagnostics;

namespace Wpftutorialsamples.Rich_text_controls
{
    public partial class Richtexteditorsample : Window
    {
        public Richtexteditorsample()
        {
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            rtbeditor.Loaded += (s, e) =>
            {
                ScrollViewer sv = GetScrollViewer(rtbeditor);
                if (sv != null)
                    sv.ScrollChanged += (s2, e2) => UpdateLineNumbers();
            };
            UpdateLineNumbers();
        }

        private void rtbeditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbeditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) &&
                                (temp.Equals(FontWeights.Bold));

            temp = rtbeditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) &&
                                  (temp.Equals(FontStyles.Italic));

            temp = rtbeditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) &&
                                     (temp.Equals(TextDecorations.Underline));

            temp = rtbeditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;

            temp = rtbeditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream filestream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(rtbeditor.Document.ContentStart,
                                               rtbeditor.Document.ContentEnd);
                range.Load(filestream, DataFormats.Rtf);
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream filestream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(rtbeditor.Document.ContentStart,
                                               rtbeditor.Document.ContentEnd);
                range.Save(filestream, DataFormats.Rtf);
            }
        }

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
                rtbeditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
        }

        private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtbeditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
        }

        private void rtbeditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLineNumbers();
        }

        private void UpdateLineNumbers()
        {
            TextRange range = new TextRange(
                rtbeditor.Document.ContentStart,
                rtbeditor.Document.ContentEnd);

            string text = range.Text;
            int lineCount = text.Split('\n').Length;
            if (lineCount < 1) lineCount = 1;

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= lineCount; i++)
                sb.AppendLine(i.ToString());

            tbLineNumbers.Text = sb.ToString();
        }

        private ScrollViewer GetScrollViewer(DependencyObject obj)
        {
            if (obj is ScrollViewer) return (ScrollViewer)obj;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var result = GetScrollViewer(VisualTreeHelper.GetChild(obj, i));
                if (result != null) return result;
            }
            return null;
        }
        private void btnOpenCalc_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("calc.exe");
        }
    }
}