using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;

namespace TaskManager.ViewModel
{
    internal class ProcessInfoViewModel
    {
        private InfoProcessClass selectedProcess;
        public ObservableCollection<InfoProcessClass> InfoProcesses { get; set; }
        public InfoProcessClass SelectedProcess
        {
            get { return selectedProcess; }
            set
            {
                selectedProcess = value;
                OnPropertyChanged("SelectedProcess");
            }
        }

        public ProcessInfoViewModel()
        {
            InfoProcesses = new ObservableCollection<InfoProcessClass>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
