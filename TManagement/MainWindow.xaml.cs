using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;
using TManagement.Models;

namespace TManagement
{
    public partial class MainWindow : Window
    {
        public delegate void DelegateForTime(Label label);

        public TimeManagement _timeManagement;
        Thread _timeThread;
        DelegateForTime _delegateTime;

        private DateTime _startDateTime, _endDateTime;
        private int _indexSelectProject;

        public MainWindow()
        {
            InitializeComponent();

            using (var textReader = new StreamReader("tm.xml"))
            {
                var deserializer = new XmlSerializer(typeof(TimeManagement));
                _timeManagement = (TimeManagement)deserializer.Deserialize(textReader);
            }

            var bindProjectsListBox = new Binding()
            {
                Source = _timeManagement,
                Path = new PropertyPath("Projects"),
                Mode = BindingMode.TwoWay
            };

            ProjectListBox.SetBinding(ListBox.ItemsSourceProperty, bindProjectsListBox);
        }
        private void AddNewProject_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProjectName("");
            form.ShowDialog();

            if (String.IsNullOrWhiteSpace(form.ProjectNameTextBox.Text))
                return;

            Project proj = new Project();
            proj.Name = form.ProjectNameTextBox.Text;
            proj.TimeIntervals = new List<TimeInterval>();

            _timeManagement.Projects.Add(proj);
            UpdateUI();
        }
        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListBox.SelectedValue != null)
            {
                var form = new ProjectName(_timeManagement.Projects[ProjectListBox.SelectedIndex].Name);
                form.ShowDialog();
                _timeManagement.Projects[ProjectListBox.SelectedIndex].Name = form.ProjectNameTextBox.Text.ToString();
            }
            UpdateUI();    
        }
        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            _timeManagement.Projects.RemoveAt(ProjectListBox.SelectedIndex);
            UpdateUI();
        }
        public void UpdateUI()
        {
            ProjectListBox.Items.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            if (StartButton.Content.ToString() == "Старт")
            {
                _startDateTime = DateTime.Now;
                _delegateTime = new DelegateForTime(CalculateTime);

                _timeThread = new Thread(SetLabelTime)
                {
                    IsBackground = true,
                    Priority = ThreadPriority.Lowest
                
                };
                _timeThread.Start();

                StartButton.Content = "Стоп";
                StartButton.Background = (Brush)bc.ConvertFrom("#FFF97171");

                ProjectListBox.IsEnabled = false;
                TaskbarItemInfo.Overlay = (ImageSource)Resources["OverlayImage"];
            } 
            else
            {
                _endDateTime = DateTime.Now;
                _timeThread.Abort();
                StartButton.Content = "Старт";
                StartButton.Background =  (Brush)bc.ConvertFrom("#FF63B85F");

                TimeLabel.Content = "0 ч. 0 м."; 

                TimeInterval ti = new TimeInterval();
                ti.StartDate = _startDateTime.ToString();
                ti.EndDate = _endDateTime.ToString();

                _timeManagement.Projects[_indexSelectProject].TimeIntervals.Add(ti);

                RebuildTimeInfo();

                ProjectListBox.IsEnabled = true;
                TaskbarItemInfo.Overlay = null;
            }
        }
        void CalculateTime(Label label)
        {
            _endDateTime = DateTime.Now;

            long elapsedTicks = _endDateTime.Ticks - _startDateTime.Ticks;
            var elapsedSpan = new TimeSpan(elapsedTicks);

            label.Content = elapsedSpan.Hours + " ч. " + elapsedSpan.Minutes + " м.";
        }  
        void SetLabelTime()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Dispatcher.Invoke(_delegateTime, TimeLabel);
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (var writer = XmlWriter.Create("tm.xml"))
            {
                var serializer = new XmlSerializer(typeof(TimeManagement));
                serializer.Serialize(writer, _timeManagement);
            }
        }
        private void ProjectListBox_Selected(object sender, RoutedEventArgs e)
        {
            _indexSelectProject = ProjectListBox.SelectedIndex;
            StartButton.IsEnabled = true;

            RebuildTimeInfo();
        }
        private void RebuildTimeInfo()
        {
            if (_indexSelectProject < 0)
            {
                LastSessionLabel.Content = "0 ч. 0 м. 0 с. ";
                AllTimeLabel.Content = "0 ч. 0 м. 0 с. ";
                return;
            }

            DateTime _endDT = DateTime.Now;
            DateTime _startDT = DateTime.Now;

            long allDateTime = 0;
            foreach (var item in _timeManagement.Projects[_indexSelectProject].TimeIntervals)
            {
                _endDT = DateTime.Parse(item.EndDate);
                _startDT = DateTime.Parse(item.StartDate);
                allDateTime += (_endDT.Ticks - _startDT.Ticks);
            }

            long elapsedTicks = _endDT.Ticks - _startDT.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            TimeSpan elapsedSpanAll = new TimeSpan(allDateTime);

            LastSessionLabel.Content = elapsedSpan.Hours + " ч. " + elapsedSpan.Minutes + " м. " + elapsedSpan.Seconds + " с. ";
            AllTimeLabel.Content = elapsedSpanAll.Hours + " ч. " + elapsedSpanAll.Minutes + " м. " + elapsedSpanAll.Seconds + " с. ";
        }
        private void ProjectListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProjectListBox.SelectedIndex >= 0)
            {
                (new AboutProject(_timeManagement.Projects[ProjectListBox.SelectedIndex].TimeIntervals)).ShowDialog();
            }  
        }
    }
}
