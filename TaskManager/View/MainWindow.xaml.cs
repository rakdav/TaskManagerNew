using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process[] Processes { get; set; }
        private TimerCallback callback;   
        private Timer timer;
        private int timeUpdate;
        private Process process;
        public MainWindow()
        {
            InitializeComponent();
            TasksUpdate();
            callback= new TimerCallback(TimerMethod);
            timer = new Timer(callback);
            timeUpdate = int.Parse(txtNum.Text);
            timer.Change(0, timeUpdate*1000);
            txtNum.Text = _numValue.ToString();
        }

        private int _numValue = 0;

        #region
        public void TimerMethod(object a)
        {
            TasksUpdate();
        }
        public void TasksUpdate()
        {
            Processes = Process.GetProcesses().OrderBy(p=>p.ProcessName).ToArray();
            Dispatcher.Invoke(() => lbProcesses.ItemsSource=Processes);
        }

        #endregion

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }
        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
            timeUpdate=NumValue;
            timer.Change(0, timeUpdate * 1000);
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
            if (NumValue > 0)
            {
                timeUpdate = NumValue;
                timer.Change(0, timeUpdate * 1000);
            }
            else
            {
                NumValue = 1;
            }
        }

        private void txtNum_TextChangeds(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out _numValue))
                txtNum.Text = _numValue.ToString();
            timeUpdate = int.Parse(txtNum.Text);
        }

        private void lbProcesses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lbProcesses.SelectedIndex;
            if (index != -1)
            {
                process = Processes[index];
                if (process != null)
                {
                    try
                    {
                        lbIdProcess.Content = process.Id.ToString();
                        lbCPUTime.Content = process.PrivilegedProcessorTime.ToString();
                        lbCountThread.Content = process.Threads.Count.ToString();
                        lbTimeStartPro.Content = process.StartTime.ToString();
                        lbCountProcess.Content = Processes.Where(p => p.ProcessName.Equals(process.ProcessName)).ToArray().Length;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            process.CloseMainWindow();
            process.Close();
            TasksUpdate();
        }
    }
}
