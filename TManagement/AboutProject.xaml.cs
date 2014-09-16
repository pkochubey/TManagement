using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using TManagement.Models;

namespace TManagement
{
    public partial class AboutProject : Window
    {
        public AboutProject(IEnumerable<TimeInterval> timeIntervals)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;

            var items = new List<Week>();

            foreach (var ti in timeIntervals)
            {
                DateTime startDateTime = DateTime.Parse(ti.StartDate);
                DateTime endDateTime = DateTime.Parse(ti.EndDate);
                int numberWeek = GetWeekNumber(endDateTime);

                long elapsedTicks = endDateTime.Ticks - startDateTime.Ticks;
                var elapsedSpan = new TimeSpan(elapsedTicks);

                var hours = elapsedSpan.Hours + " ч. " + elapsedSpan.Minutes + " м. " + elapsedSpan.Seconds + " c. ";

                items.Add(new Week()
                {
                    Number = numberWeek,
                    Hours = hours,
                    Day = endDateTime.ToString("MM/dd/yyyy"),
                    Tick = elapsedTicks
                });
            }

            ListViewTime.ItemsSource = items;
            ListViewTime.Items.SortDescriptions.Add(new SortDescription("Number", ListSortDirection.Descending));

            var view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewTime.ItemsSource);

            if (view.GroupDescriptions != null)
            {
                view.GroupDescriptions.Add(new PropertyGroupDescription("Number"));
            }
        }
        private static int GetWeekNumber(DateTime dtPassed)
        {
            var ciCurr = CultureInfo.CurrentCulture;
            return ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
