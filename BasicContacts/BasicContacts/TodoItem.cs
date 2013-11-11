using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContacts
{
    public class TodoItem : BaseVM
    {
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; OnPropertyChanged("Title"); }
        }

        private bool _Done;
        public bool Done
        {
            get { return _Done; }
            set { _Done = value; OnPropertyChanged("Done"); }
        }

        private DateTime _DueDate;
        public DateTime DueDate
        {
            get { return _DueDate; }
            set { _DueDate = value; OnPropertyChanged("DueDate"); }
        }

    }
}