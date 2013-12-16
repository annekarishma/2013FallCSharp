using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Contactmanagement;
using Contactmanagement.Commands;

namespace Contactmanagement.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Member Fields

        /// <summary>
        /// The connection to the database.
        /// </summary>
        private readonly ContactDBEntities m_DbContext;

        /// <summary>
        /// The variable that is use to store the LoadCommand.
        /// </summary>
        private RelayCommand m_LoadCommand;


        /// <summary>
        /// The variable that is use to store the ExitCommand.
        /// </summary>
        private RelayCommand m_ExitCommand;

        /// <summary>
        /// The variable that is use to store the SortCommand.
        /// </summary>
        private RelayCommand m_SortCommand;

        /// <summary>
        /// The list of all the employees, loaded from the database.
        /// </summary>
        private ObservableCollection<Detail> m_EmployeesList;

        /// <summary>
        /// The default view that will be get from the bound control.
        /// </summary>
        private ICollectionView m_EmployeesView;

        /// <summary>
        /// The last direction of the sort.
        /// </summary>
        private ListSortDirection m_lastDirection = ListSortDirection.Ascending;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the load command.
        /// </summary>
        /// <value>The load command.</value>
        public ICommand LoadCommand
        {
            get
            {
                if (m_LoadCommand == null)
                {
                    m_LoadCommand = new RelayCommand(param => CanLoad(), param => Load());
                }

                return m_LoadCommand;
            }
        }

        /// <summary>
        /// Gets the exit command.
        /// </summary>
        /// <value>The exit command.</value>
        public ICommand ExitCommand
        {
            get
            {
                if (m_ExitCommand == null)
                {
                    m_ExitCommand = new RelayCommand(param => CanExit(), param => Exit());
                }

                return m_ExitCommand;
            }
        }

        /// <summary>
        /// Gets the sort command.
        /// </summary>
        /// <value>The sort command.</value>
        public ICommand SortCommand
        {
            get
            {
                if (m_SortCommand == null)
                {
                    m_SortCommand = new RelayCommand(param => CanSort(), param => Sort());
                }

                return m_SortCommand;
            }
        }

        /// <summary>
        /// Gets or sets the employees list.
        /// </summary>
        /// <value>The employees list.</value>
        public ObservableCollection<Detail> EmployeesList
        {
            get
            {
                return m_EmployeesList;
            }
            set
            {
                m_EmployeesList = value;

                OnPropertyChanged("EmployeesList");
            }
        }

        /// <summary>
        /// Gets the current employee.
        /// </summary>
        /// <value>The current employee.</value>
        public Detail  CurrentEmployee
        {
            get
            {
                if (m_EmployeesView != null)
                {
                    return m_EmployeesView.CurrentItem as Detail;
                }

                return null;
            }
        }

        /// <summary>
        /// Sets the employee to look for.
        /// </summary>
        /// <value>The employee to look for.</value>
        public string EmployeeLookFor
        {
            set
            {
                m_EmployeesView.Filter = item =>
                {
                    if (item as Detail  != null)
                    {
                        if ((item as Detail).lName.StartsWith(value))
                        {
                            return true;
                        }
                    }

                    return false;
                };
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            m_DbContext = new ContactDBEntities();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Determines whether the data can be loaded from database.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if data can be loaded; otherwise, <c>false</c>.
        /// </returns>
        private bool CanLoad()
        {
            return true;
        }

        /// <summary>
        /// Loads the data from database.
        /// </summary>
        private void Load()
        {
            EmployeesList =
                new ObservableCollection<Detail>((from contact in m_DbContext.Details.Include("Details")
                                                   select contact));

            m_EmployeesView = CollectionViewSource.GetDefaultView(EmployeesList);

            if (m_EmployeesView != null)
            {
                m_EmployeesView.CurrentChanged += OnCollectionViewCurrentChanged;
            }

            OnPropertyChanged("CurrentEmployee");
        }

        /// <summary>
        /// Determines whether application can be exited.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if application can be exited; otherwise, <c>false</c>.
        /// </returns>
        private static bool CanExit()
        {
            return true;
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private static void Exit()
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Determines whether the ListView can be sorted.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if the ListView can be sorted; otherwise, <c>false</c>.
        /// </returns>
        private static bool CanSort()
        {
            return true;
        }

        /// <summary>
        /// Sorts the ListView.
        /// </summary>
        private void Sort()
        {
            var direction = m_lastDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;

            using (m_EmployeesView.DeferRefresh())
            {
                m_EmployeesView.SortDescriptions.Clear();
                m_EmployeesView.SortDescriptions.Add(new SortDescription("lName", direction));
            }

            m_lastDirection = m_lastDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
        }

        /// <summary>
        /// Called when [collection view current changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("CurrentEmployee");
        }

        #endregion
    }
}
