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

namespace PasswordManagementSystem.TemplateRecord
{
    /// <summary>
    /// Interaction logic for TemplateLecture.xaml
    /// </summary>
    public partial class TemplateLecture : Window
    {
        private MainWindow main;
        private string DatabaseName, purpose;

        private ButtonSubmitForm submit;
        private ButtonModifyForm modify;

        public TemplateLecture(MainWindow main, string databaseName,string purpose, string [] information)
        {
            InitializeComponent();
            this.main = main;
            this.DatabaseName = databaseName;
            this.purpose = purpose;
            if (purpose == "Add")
            {
                this.submit = new ButtonSubmitForm(this, main,databaseName, "RecordLecture");
                ButtonArea.Children.Add(submit);
                Reset_KeyUp();
            }
            else
            {
                var br = new BrushConverter();
                TextBox[] boxes = { TitleBox, SubjectBox, LessonBox,  NoteBox };
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
                this.modify = new ButtonModifyForm(this, main, databaseName, "RecordLecture");
                this.modify.toChange = information[1];
                for (int i = 0; i < information.Length - 1; i++)
                {
                    this.modify.recordLecture[i] = information[i];
                }
                ButtonArea.Children.Add(modify);
            }
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

        private void LessonBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (LessonBox.Text == "Lesson"){
                LessonBox.Text = "";
                LessonBox.Foreground = Brushes.Black;
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
                    this.submit.recordLecture[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.submit.recordLecture[1] = "Input Title Here";
                    }
                }
                else
                {
                    this.modify.recordLecture[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.modify.recordLecture[1] = "Input Title Here";
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
                    this.submit.recordLecture[2] = SubjectBox.Text;
                    if (SubjectBox.Text == "Subject")
                    {
                        this.submit.recordLecture[2] = "";
                    }
                }
                else
                {
                    this.modify.recordLecture[2] = SubjectBox.Text;
                    if (SubjectBox.Text == "Subject")
                    {
                        this.modify.recordLecture[2] = "";
                    }
                }
            }

            if (LessonBox.Text == ""){
                LessonBox.Text = "Lesson";
                LessonBox.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordLecture[3] = LessonBox.Text;
                    if (LessonBox.Text == "Lesson")
                    {
                        this.submit.recordLecture[3] = "";
                    }
                }
                else
                {
                    this.modify.recordLecture[3] = LessonBox.Text;
                    if (LessonBox.Text == "Lesson")
                    {
                        this.modify.recordLecture[3] = "";
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
                    this.submit.recordLecture[4] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.submit.recordLecture[4] = "";
                    }
                }
                else
                {
                    this.modify.recordLecture[4] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.modify.recordLecture[4] = "";
                    }
                }
            }
            return;
        }
    }
}
