using System;
using System.Collections.Generic;
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
        private Process[] process;
        private TimerCallback callback;   
        private Timer timer;
        private int timeUpdate;
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
            Dispatcher.Invoke(()=>lbProcesses.Items.Clear());
            process = Process.GetProcesses();
            foreach (Process proc in process)
            {
                Dispatcher.Invoke(() => 
                            lbProcesses.Items.Add(proc.ProcessName));
            }
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
            timeUpdate=NumValue;
            timer.Change(0, timeUpdate * 1000);
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
   }
}
