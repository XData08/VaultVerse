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
using System.Windows.Shapes;
using PasswordManagementSystem;
using PasswordManagementSystem.Views.TemplateView;

namespace PasswordManagementSystem.TemplateDocument
{
    /// <summary>
    /// Interaction logic for TemplateFolder.xaml
    /// </summary>
    public partial class TemplateFolder : Window
    {
        private MainWindow main;
        private string DatabaseName, purpose;

        private ButtonSubmitForm submit;
        private ButtonModifyForm modify;

        public TemplateFolder(MainWindow main, string databaseName, string purpose, string[] information)
        {
            InitializeComponent();
            this.main = main;
            this.DatabaseName = databaseName;
            this.purpose = purpose;
            if (purpose == "Add")
            {
                this.submit = new ButtonSubmitForm(this, main, databaseName, "DocumentFolder");
                ButtonArea.Children.Add(submit);
                Reset_KeyUp();
            }
            else
            {
                var br = new BrushConverter();
                TextBox[] boxes = { TitleBox, NoteBox };
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
                this.modify = new ButtonModifyForm(this, main, databaseName, "DocumentFolder");
                this.modify.toChange = information[1];
                for (int i = 0; i < information.Length - 1; i++)
                {
                    this.modify.documentFolder[i] = information[i];
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

        private void NoteBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (NoteBox.Text == "Notes")
            {
                NoteBox.Text = "";
                NoteBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void Reset_KeyUp(object sender = null, KeyEventArgs e = null)
        {
            var br = new BrushConverter();

            if (TitleBox.Text == "")
            {
                TitleBox.Text = "Title";
                TitleBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    if (TitleBox.Text == "Title")
                    {
                        this.submit.documentFolder[1] = "Input Title Here";
                    }
                    this.submit.documentFolder[1] = TitleBox.Text;
                }
                else
                {
                    if (TitleBox.Text == "Title")
                    {
                        this.modify.documentFolder[1] = "Input Title Here";
                    }
                    this.modify.documentFolder[1] = TitleBox.Text;
                }
            }

            if (NoteBox.Text == "")
            {
                NoteBox.Text = "Notes";
                NoteBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    if (NoteBox.Text == "Notes")
                    {
                        this.submit.documentFolder[2] = "";
                    }
                    this.submit.documentFolder[2] = NoteBox.Text;
                }
                else
                {
                    if (NoteBox.Text == "Notes")
                    {
                        this.modify.documentFolder[2] = "";
                    }
                    this.modify.documentFolder[2] = NoteBox.Text;
                }
            }
            return;
        }
    }
}
