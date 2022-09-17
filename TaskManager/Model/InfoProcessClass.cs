using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    internal class InfoProcessClass: INotifyPropertyChanged
    {
        private int idProcess;
        private DateTime timeStartPro;
        private int cpuTime;
        private int countThread;
        private int countProcess;
        public int IdProcess
        {
            get { return idProcess; }
            set
            {
                idProcess = value;
                OnPropertyChanged("idProcess");
            }
        }
        public DateTime TimeStartPro
        {
            get { return timeStartPro; }
            set
            {
                timeStartPro = value;
                OnPropertyChanged("idProcess");
            }
        }
        public int CPUTime
        {
            get { return cpuTime; }
            set
            {
                cpuTime = value;
                OnPropertyChanged("idProcess");
            }
        }

        public int CountThread
        {
            get { return countThread; }
            set
            {
                countThread = value;
                OnPropertyChanged("idProcess");
            }
        }
        public int CountProcess
        {
            get { return countProcess; }
            set
            {
                countProcess = value;
                OnPropertyChanged("idProcess");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
