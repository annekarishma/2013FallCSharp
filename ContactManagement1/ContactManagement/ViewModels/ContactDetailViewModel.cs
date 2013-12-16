using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManagement.Models;
using System.ComponentModel;
using System.Windows.Input;
using ContactManagement.Common;
using ContactManagement;
using System.Windows;
using System.Collections.ObjectModel;

namespace ContactManagement.ViewModels
{
    public class ContactDetailViewModel: INotifyPropertyChanged
    {
        #region Private Variables
       
        private readonly Contact domObject;
        private readonly ContactManager contactManager;
        private readonly ObservableCollection<Contact> _contacts;
        private readonly ICommand _addContactCmd;
        private readonly ICommand _deleteContactCmd;
        private readonly ICommand _searchContactCmd;
        #endregion

        #region Constructors

        /// <summary>
        /// Instatiates all the readonly variables
        /// </summary>
        public ContactDetailViewModel()
        {
            domObject = new Contact();
            contactManager = new ContactManager();

            _contacts = new ObservableCollection<Contact>();
            _addContactCmd = new RelayCommand(Add, CanAdd);
            _deleteContactCmd = new RelayCommand(Delete, CanDelete);
            _searchContactCmd = new RelayCommand(Search, CanSearch);
        }
        #endregion

        #region Properties
        
        /// <summary>
        /// Gets or Sets Patient Id. Ready to be binded to UI.
        /// Impelments INotifyPropertyChanged which enables the binded element to refresh itself whenever the value changes.
        /// </summary>
        public int Id
        {
            get { return domObject.Id; }
            set
            {
                domObject.Id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or Sets Patient Name. Ready to be binded to UI.
        /// Impelments INotifyPropertyChanged which enables the binded element to refresh itself whenever the value changes.
        /// </summary>
        public string Name
        {
            get { return domObject.Name; }
            set
            {
                domObject.Name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or Sets Patient MobileNumber. Ready to be binded to UI.
        /// Impelments INotifyPropertyChanged which enables the binded element to refresh itself whenever the value changes.
        /// </summary>
        public Int64 MobileNumber
        {
            get { return domObject.MobileNumber; }
            set
            {
                domObject.MobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        public string EmailId
        {
            get { return domObject.EmailId ; }
            set
            {
                domObject.EmailId = value;
                OnPropertyChanged("EmailId");
            }
        }

        public string City
        {
            get { return domObject.City; }
            set
            {
                domObject.City = value;
                OnPropertyChanged("City");
            }
        }
        public string State
        {
            get { return domObject.State; }
            set
            {
                domObject.State = value;
                OnPropertyChanged("State");
            }
        }
        /// <summary>
        /// Gets the Contacts. Used to maintain the Patient List.
        /// Since this observable collection it makes sure all changes will automatically reflect in UI 
        /// as it implements both CollectionChanged, PropertyChanged;
        /// </summary>
        public ObservableCollection<Contact> Contacts { get { return _contacts; } }

        /// <summary>
        /// Sets the Selected Patient. Used to identify the selected patient from the list. 
        /// </summary>
        public Contact SelectedPatient 
        { 
            set { Id = value.Id; 
                  MobileNumber = value.MobileNumber; 
                  Name = value.Name;
                  EmailId = value.EmailId;
                  City = value.City;
                  State = value.State;
            } 
        }

        #region Commands

        /// <summary>
        /// Gets the AddPatientCommand. Used for Add patient Button Operations
        /// </summary>
        public ICommand AddPatientCmd { get { return _addContactCmd; } }

        /// <summary>
        /// Gets the DeletePatientCmd. Used for Delete patient Button Operations
        /// </summary>
        public ICommand DeletePatientCmd { get { return _deleteContactCmd; } }

        /// <summary>
        /// Gets the SearchPatientCmd. Used for Search patient Button Operations
        /// </summary>
        public ICommand SearchPatientCmd { get { return _searchContactCmd; } }
        #endregion

        #endregion

        #region Commands

        #region AddCommand

        /// <summary>
        /// CanAdd operation of the AddPatientCmd.
        /// Tells us if the control is to be enabled or disabled.
        /// This method will be fired repeatedly as long as the view is open.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool CanAdd(object obj)
        {
            //Enable the Button only if the mandatory fields are filled
            if (Name != string.Empty && MobileNumber!=0)
                return true;
            return false;
        }

        /// <summary>
        /// Add operation of the AddPatientCmd.
        /// Operation that will be performormed on the control click.
        /// </summary>
        /// <param name="obj"></param>
        public void Add(object obj)
        {
            //Always create a new instance of patient before adding. 
            //Otherwise we will endup sending the same instance that is binded, to the BL which will cause complications
            var contact = new Contact  { Id = Id, Name = Name, MobileNumber=MobileNumber ,EmailId=EmailId,City=City,State=State  };
            //Add patient will be successfull only if the patient with same ID does not exist.
            if (contactManager.Add(contact))
            {
                Contacts.Add(contact);
                ResetPatient();
                MessageBox.Show("Contact Add Successful !");
            }
            else
                MessageBox.Show("Contact with this ID already exists !");
        }
        #endregion

        #region DeleteCommand

        /// <summary>
        /// CanDelete operation of the DeletePatientCmd.
        /// Tells us if the control is to be enabled or disabled.
        /// This method will be fired repeatedly as long as the view is open.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanDelete(object obj)
        {
            //Enable the Button only if the Contacts exist
            if(Contacts.Count>0)
                return true;
            return false;
        }

        /// <summary>
        /// Delete operation of the DeletePatientCmd.
        /// Operation that will be performormed on the control click.
        /// </summary>
        /// <param name="obj"></param>
        private void Delete(object obj)
        {
            //Delete patient will be successfull only if the patient with this ID exists.
            if (!contactManager.Remove(Id))
                MessageBox.Show("Contact with this ID does not exist !");
            else
            {
                //Remove the patient from our collection as well.
                Contacts.RemoveAt(GetIndex(Id));
                ResetPatient();
                MessageBox.Show("Contact Remove Successful !");
            }
        }

        #endregion

        #region SearchCommand

        /// <summary>
        /// CanSearch operation of the SearchPatientCmd.
        /// Tells us if the control is to be enabled or disabled.
        /// This method will be fired repeatedly as long as the view is open.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanSearch(object obj)
        {
            //Enable the Button only if the Contacts exist
            if(Contacts.Count>0)
                return true;
            return false;
        }

        /// <summary>
        /// Search operation of the SearchPatientCmd.
        /// Operation that will be performormed on the control click.
        /// </summary>
        /// <param name="obj"></param>
        private void Search(object obj)
        {
            Contact patient = contactManager.Search(Id);

            if (patient == null)
                MessageBox.Show("Contact with this ID does not exist !");
            else
            {
                //Change the binded elements so that the searched patient will reflect in UI
                Id = patient.Id;
                Name = patient.Name;
                MobileNumber = patient.MobileNumber;
                EmailId = patient.EmailId;
                City = patient.City;
                State = patient.State;
            }
        }
        #endregion
        #endregion

        #region Private Methods

        /// <summary>
        /// Resets the Patient properties which will in turn auto reset the UI aswell
        /// </summary>
        private void ResetPatient()
        {
            Id = 0;
            Name = string.Empty;
            MobileNumber = 0;
            EmailId = string.Empty;
            City = string.Empty;
            State = string.Empty;
        }

        /// <summary>
        /// Finds the patient in the collection and return the index
        /// </summary>
        /// <param name="Id">Patient ID</param>
        /// <returns></returns>
        private int GetIndex(int Id)
        {
            for (int i = 0; i < Contacts.Count; i++)
                if (Contacts[i].Id == Id)
                    return i;
            return -1;
        }
        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Event to which the view's controls will subscribe.
        /// This will enable them to refresh themselves when the binded property changes provided you fire this event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// When property is changed call this method to fire the PropertyChanged Event
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            //Fire the PropertyChanged event in case somebody subscribed to it
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

