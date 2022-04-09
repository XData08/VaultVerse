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
using PasswordManagementSystem.TemplateRecord;

namespace PasswordManagementSystem.Views.MainView
{
    /// <summary>
    /// Interaction logic for SubRecordView.xaml
    /// </summary>
    public partial class SubRecordView : UserControl
    {
        public string DatabaseName;
        public MainWindow main;
        public SubRecordView()
        {
            InitializeComponent();
        }

        private void AddLecture(object sender, RoutedEventArgs e)
        {
            
            TemplateLecture lecture = new TemplateLecture(this.main , this.DatabaseName, "Add", null);

            lecture.Show();
            this.main.WindowState = WindowState.Minimized;
        }

        private void AddList(object sender, RoutedEventArgs e)
        {
            
            TemplateList list = new TemplateList(this.main, this.DatabaseName, "Add", null);

            list.Show();
            this.main.WindowState = WindowState.Minimized;
        }

        private void AddSchedule(object sender, RoutedEventArgs e)
        {
            TemplateSchedule schedule = new TemplateSchedule(this.main, this.DatabaseName, "Add", null);

            schedule.Show();
            this.main.WindowState = WindowState.Minimized;

        }

        private void AddCollaboration(object sender, RoutedEventArgs e)
        {
            TemplateCollaboration collaboration = new TemplateCollaboration(main, this.DatabaseName, "Add", null);

            collaboration.Show();
            this.main.WindowState = WindowState.Minimized;

        }


    }
}
