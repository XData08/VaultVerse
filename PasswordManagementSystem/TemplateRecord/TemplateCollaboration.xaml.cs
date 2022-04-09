﻿using System;
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
using System.Windows.Shapes;
using PasswordManagementSystem;
using PasswordManagementSystem.Views.TemplateView;

namespace PasswordManagementSystem.TemplateRecord
{
    /// <summary>
    /// Interaction logic for TemplateCollaboration.xaml
    /// </summary>
    public partial class TemplateCollaboration : Window
    {
        private MainWindow main;
        private string DatabaseName, purpose;

        private ButtonSubmitForm submit;
        private ButtonModifyForm modify;

        public TemplateCollaboration(MainWindow main, string databaseName, string purpose, string[] information)
        {
            InitializeComponent();
            this.main = main;
            this.DatabaseName = databaseName;
            this.purpose = purpose;
            if (purpose == "Add")
            {
                this.submit = new ButtonSubmitForm(this, main, databaseName,"RecordCollaboration");
                ButtonArea.Children.Add(submit);
                Reset_KeyUp();
            }
            else
            {
                var br = new BrushConverter();
                TextBox[] boxes = { TitleBox, SubjectBox, NoteBox };
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(information[i + 1]))
                    {
                        boxes[i].Text = information[i + 1];
                        boxes[i].Foreground = Brushes.Black;
                    }
                    else
                    {
                        boxes[i].Foreground = (Brush)br.ConvertFrom("#ABABAB");
                    }
                }
                this.modify = new ButtonModifyForm(this, main, databaseName, "RecordCollaboration");
                this.modify.toChange = information[1];
                for (int i = 0; i < information.Length - 1; i++)
                {
                    this.modify.recordCollaboration[i] = information[i];
                }
                ButtonArea.Children.Add(modify);
            }
            return;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
            return;
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            return;
        }

        private void ExitWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.main.WindowState = WindowState.Normal;
            return;
        }

        private void TitleBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (TitleBox.Text == "Title")
            {
                TitleBox.Text = "";
                TitleBox.Foreground = Brushes.Black;
            }
            return;
        }

        private void SubjectBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (SubjectBox.Text == "Subject"){
                SubjectBox.Text = "";
                SubjectBox.Foreground = Brushes.Black;
            }
            return;
        }

        private void NoteBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (NoteBox.Text == "Notes"){
                NoteBox.Text = "";
                NoteBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void Reset_KeyUp(object sender = null, KeyEventArgs e = null)
        {
            var br = new BrushConverter();
            if (TitleBox.Text == ""){
                TitleBox.Text = "Title";
                TitleBox.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordCollaboration[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.submit.recordCollaboration[1] = "Input Title Here";
                    }
                }
                else
                {
                    this.modify.recordCollaboration[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.modify.recordCollaboration[1] = "Input Title Here";
                    }
                }
            }

            if (SubjectBox.Text == ""){
                SubjectBox.Text = "Subject";
                SubjectBox.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordCollaboration[2] = SubjectBox.Text;
                    if (SubjectBox.Text == "Subject")
                    {
                        this.submit.recordCollaboration[2] = "";
                    }
                }
                else
                {
                    this.modify.recordCollaboration[2] = SubjectBox.Text;
                    if (SubjectBox.Text == "Subject")
                    {
                        this.modify.recordCollaboration[2] = "";
                    }
                }
            }

            if (NoteBox.Text == ""){
                NoteBox.Text = "Notes";
                NoteBox.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordCollaboration[3] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.submit.recordCollaboration[3] = "";
                    }
                }
                else
                {
                    this.modify.recordCollaboration[3] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.modify.recordCollaboration[3] = "";
                    }
                }
            }
            return;
        }
    }

}
