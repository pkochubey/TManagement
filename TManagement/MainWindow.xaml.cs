using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
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
    public partial class MainWindow
    {
        public delegate void DelegateForTime(Label label);

        private readonly BackgroundWorker _worker = new BackgroundWorker();

        private DelegateForTime _delegateTime;

        private DateTime _endDateTime;
        private int _indexSelectProject;
        private DateTime _startDateTime;
        public TimeManagement TimeManagement;
        private Thread _timeThread;

        public MainWindow()
        {
            InitializeComponent();

            using (var textReader = new StreamReader("tm.xml"))
            {
                var deserializer = new XmlSerializer(typeof (TimeManagement));
                TimeManagement = (TimeManagement) deserializer.Deserialize(textReader);
            }

            var bindProjectsListBox = new Binding
            {
                Source = TimeManagement,
                Path = new PropertyPath("Projects"),
                Mode = BindingMode.TwoWay
            };

            ProjectListBox.SetBinding(ItemsControl.ItemsSourceProperty, bindProjectsListBox);

            _worker.DoWork += worker_DoWork;
            _worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(10000);
                GetTextActiveWindow();
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private void GetTextActiveWindow()
        {
            var name = new StringBuilder {Length = 266};
            GetWindowText(GetForegroundWindow(), name, 256);

            Trace.WriteLine(name.ToString());
        }

        private void AddNewProject_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProjectName("");
            form.ShowDialog();

            if (String.IsNullOrWhiteSpace(form.ProjectNameTextBox.Text))
                return;

            var proj = new Project();
            proj.Name = form.ProjectNameTextBox.Text;
            proj.TimeIntervals = new List<TimeInterval>();

            TimeManagement.Projects.Add(proj);
            UpdateUi();
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListBox.SelectedValue != null)
            {
                var form = new ProjectName(TimeManagement.Projects[ProjectListBox.SelectedIndex].Name);
                form.ShowDialog();
                TimeManagement.Projects[ProjectListBox.SelectedIndex].Name = form.ProjectNameTextBox.Text;
            }
            UpdateUi();
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            TimeManagement.Projects.RemoveAt(ProjectListBox.SelectedIndex);
            UpdateUi();
        }

        public void UpdateUi()
        {
            ProjectListBox.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            if (StartButton.Content.ToString() == "Старт")
            {
                _startDateTime = DateTime.Now;
                _delegateTime = CalculateTime;

                _timeThread = new Thread(SetLabelTime)
                {
                    IsBackground = true,
                    Priority = ThreadPriority.Lowest
                };
                _timeThread.Start();

                StartButton.Content = "Стоп";
                StartButton.Background = (Brush) bc.ConvertFrom("#FFF97171");

                ProjectListBox.IsEnabled = false;
                TaskbarItemInfo.Overlay = (ImageSource) Resources["OverlayImage"];
            }
            else
            {
                _endDateTime = DateTime.Now;
                _timeThread.Abort();
                StartButton.Content = "Старт";
                StartButton.Background = (Brush) bc.ConvertFrom("#FF63B85F");

                TimeLabel.Content = "0 ч. 0 м.";

                var ti = new TimeInterval();
                ti.StartDate = _startDateTime.ToString();
                ti.EndDate = _endDateTime.ToString();

                TimeManagement.Projects[_indexSelectProject].TimeIntervals.Add(ti);

                RebuildTimeInfo();

                ProjectListBox.IsEnabled = true;
                TaskbarItemInfo.Overlay = null;
            }
        }

        private void CalculateTime(Label label)
        {
            _endDateTime = DateTime.Now;

            var elapsedTicks = _endDateTime.Ticks - _startDateTime.Ticks;
            var elapsedSpan = new TimeSpan(elapsedTicks);

            label.Content = elapsedSpan.Hours + " ч. " + elapsedSpan.Minutes + " м.";
        }

        private void SetLabelTime()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Dispatcher.Invoke(_delegateTime, TimeLabel);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            using (var writer = XmlWriter.Create("tm.xml"))
            {
                var serializer = new XmlSerializer(typeof (TimeManagement));
                serializer.Serialize(writer, TimeManagement);
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

            DateTime endDt = DateTime.Now;
            DateTime startDt = DateTime.Now;

            long allDateTime = 0;
            foreach (TimeInterval item in TimeManagement.Projects[_indexSelectProject].TimeIntervals)
            {
                endDt = DateTime.Parse(item.EndDate);
                startDt = DateTime.Parse(item.StartDate);
                allDateTime += (endDt.Ticks - startDt.Ticks);
            }

            long elapsedTicks = endDt.Ticks - startDt.Ticks;
            var elapsedSpan = new TimeSpan(elapsedTicks);
            var elapsedSpanAll = new TimeSpan(allDateTime);

            LastSessionLabel.Content = elapsedSpan.Hours + " ч. " + elapsedSpan.Minutes + " м. " + elapsedSpan.Seconds +
                                       " с. ";
            AllTimeLabel.Content = elapsedSpanAll.Hours + " ч. " + elapsedSpanAll.Minutes + " м. " +
                                   elapsedSpanAll.Seconds + " с. ";
        }

        private void ProjectListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProjectListBox.SelectedIndex >= 0)
            {
                (new AboutProject(TimeManagement.Projects[ProjectListBox.SelectedIndex].TimeIntervals)).ShowDialog();
            }
        }
    }
}