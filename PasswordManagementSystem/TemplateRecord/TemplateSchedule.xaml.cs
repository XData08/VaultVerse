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
    /// Interaction logic for TemplateSchedule.xaml
    /// </summary>
    public partial class TemplateSchedule : Window
    {
        private MainWindow main;
        private string DatabaseName, purpose;

        private ButtonSubmitForm submit;
        private ButtonModifyForm modify;
        public TemplateSchedule(MainWindow main, string databaseName, string purpose, string [] information)
        {
            InitializeComponent();
            this.main = main;
            this.DatabaseName = databaseName;
            this.purpose = purpose;
            if (purpose == "Add")
            {
                this.submit = new ButtonSubmitForm(this, main,databaseName, "RecordSchedule");
                ButtonArea.Children.Add(submit);
                Reset_KeyUp();
            }
            else
            {
                var br = new BrushConverter();
                TextBox[] boxes = { TitleBox, MondaySchedule, TuesdaySchedule,
                    WednesdaySchedule,ThursdaySchedule,FridaySchedule, SaturdaySchedule,
                    SundaySchedule, NoteBox };
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
                this.modify = new ButtonModifyForm(this, main, databaseName, "RecordSchedule");
                this.modify.toChange = information[1];
                for (int i = 0; i < information.Length - 1; i++)
                {
                    this.modify.recordSchedule[i] = information[i];
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
            if (TitleBox.Text == "Title"){
                TitleBox.Text = "";
                TitleBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void MondaySchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (MondaySchedule.Text == "Monday Schedule"){
                MondaySchedule.Text = "";
                MondaySchedule.Foreground = Brushes.Black;
            }
            return;
        }
        private void TuesdaySchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (TuesdaySchedule.Text == "Tuesday Schedule"){
                TuesdaySchedule.Text = "";
                TuesdaySchedule.Foreground = Brushes.Black;
            }
            return;
        }
        private void WednesdaySchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (WednesdaySchedule.Text == "Wednesday Schedule"){
                WednesdaySchedule.Text = "";
                WednesdaySchedule.Foreground = Brushes.Black;
            }
            return;
        }
        private void ThursdaySchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (ThursdaySchedule.Text == "Thursday Schedule"){
                ThursdaySchedule.Text = "";
                ThursdaySchedule.Foreground = Brushes.Black;
            }
            return;
        }
        private void FridaySchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (FridaySchedule.Text == "Friday Schedule"){
                FridaySchedule.Text = "";
                FridaySchedule.Foreground = Brushes.Black;
            }
            return;
        }
        private void SaturdaySchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (SaturdaySchedule.Text == "Saturday Schedule"){
                SaturdaySchedule.Text = "";
                SaturdaySchedule.Foreground = Brushes.Black;
            }
            return;
        }
        private void SundaySchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (SundaySchedule.Text == "Sunday Schedule"){
                SundaySchedule.Text = "";
                SundaySchedule.Foreground = Brushes.Black;
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
                    this.submit.recordSchedule[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.submit.recordSchedule[1] = "Input Title Here";
                    }
                }
                else
                {
                    this.modify.recordSchedule[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.modify.recordSchedule[1] = "Input Title Here";
                    }
                }
            }

            if (MondaySchedule.Text == ""){
                MondaySchedule.Text = "Monday Schedule";
                MondaySchedule.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordSchedule[2] = MondaySchedule.Text;
                    if (MondaySchedule.Text == "Monday Schedule")
                    {
                        this.submit.recordSchedule[2] = "";
                    }
                }
                else
                {
                    this.modify.recordSchedule[2] = MondaySchedule.Text;
                    if (MondaySchedule.Text == "Monday Schedule")
                    {
                        this.modify.recordSchedule[2] = "";
                    }
                }
            }

            if (TuesdaySchedule.Text == ""){
                TuesdaySchedule.Text = "Tuesday Schedule";
                TuesdaySchedule.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordSchedule[3] = TuesdaySchedule.Text;
                    if (TuesdaySchedule.Text == "Tuesday Schedule")
                    {
                        this.submit.recordSchedule[3] = "";
                    }
                }
                else
                {
                    this.modify.recordSchedule[3] = TuesdaySchedule.Text;
                    if (TuesdaySchedule.Text == "Tuesday Schedule")
                    {
                        this.modify.recordSchedule[3] = "";
                    }
                }
            }

            if (WednesdaySchedule.Text == ""){
                WednesdaySchedule.Text = "Wednesday Schedule";
                WednesdaySchedule.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordSchedule[4] = WednesdaySchedule.Text;
                    if (WednesdaySchedule.Text == "Wednesday Schedule")
                    {
                        this.submit.recordSchedule[4] = "";
                    }
                }
                else
                {
                    this.modify.recordSchedule[4] = WednesdaySchedule.Text;
                    if (WednesdaySchedule.Text == "Wednesday Schedule")
                    {
                        this.modify.recordSchedule[4] = "";
                    }
                }
            }

            if (ThursdaySchedule.Text == ""){
                ThursdaySchedule.Text = "Thursday Schedule";
                ThursdaySchedule.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordSchedule[5] = ThursdaySchedule.Text;
                    if (ThursdaySchedule.Text == "Thursday Schedule")
                    {
                        this.submit.recordSchedule[5] = "";
                    }
                }
                else
                {
                    this.modify.recordSchedule[5] = ThursdaySchedule.Text;
                    if (ThursdaySchedule.Text == "Thursday Schedule")
                    {
                        this.modify.recordSchedule[5] = "";
                    }
                }
            }

            if (FridaySchedule.Text == ""){
                FridaySchedule.Text = "Friday Schedule";
                FridaySchedule.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordSchedule[6] = FridaySchedule.Text;
                    if (FridaySchedule.Text == "Friday Schedule")
                    {
                        this.submit.recordSchedule[6] = "";
                    }
                }
                else
                {
                    this.modify.recordSchedule[6] = FridaySchedule.Text;
                    if (FridaySchedule.Text == "Friday Schedule")
                    {
                        this.modify.recordSchedule[6] = "";
                    }
                }
            }

            if (SaturdaySchedule.Text == ""){
                SaturdaySchedule.Text = "Saturday Schedule";
                SaturdaySchedule.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordSchedule[7] = SaturdaySchedule.Text;
                    if (SaturdaySchedule.Text == "Saturday Schedule")
                    {
                        this.submit.recordSchedule[7] = "";
                    }
                }
                else
                {
                    this.modify.recordSchedule[7] = SaturdaySchedule.Text;
                    if (SaturdaySchedule.Text == "Saturday Schedule")
                    {
                        this.modify.recordSchedule[7] = "";
                    }
                }
            }

            if (SundaySchedule.Text == ""){
                SundaySchedule.Text = "Sunday Schedule";
                SundaySchedule.Foreground = (Brush) br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.recordSchedule[8] = SundaySchedule.Text;
                    if (SundaySchedule.Text == "Sunday Schedule")
                    {
                        this.submit.recordSchedule[8] = "";
                    }
                }
                else
                {
                    this.modify.recordSchedule[8] = SundaySchedule.Text;
                    if (SundaySchedule.Text == "Sunday Schedule")
                    {
                        this.modify.recordSchedule[8] = "";
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
                    this.submit.recordSchedule[9] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.submit.recordSchedule[9] = "";
                    }
                }
                else
                {
                    this.modify.recordSchedule[9] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.modify.recordSchedule[9] = "";
                    }
                }
            }
            return;
        }
    }
}
