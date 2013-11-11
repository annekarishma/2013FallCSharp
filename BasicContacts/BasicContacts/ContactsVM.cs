using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Input;
using System.Threading;
using System.Net.Http;

namespace BasicContacts
{

    public class ContactsVM : BaseVM
    {
        CSharpContext _DB;
        public ContactsVM()
        {
            int i = 0;
            _DB = new CSharpContext();
            Contacts = new ObservableCollection<Contact>();
            SaveCommand = new DelegateCommand(() => _DB.SaveChanges());
            AddCommand = new DelegateCommand(() =>
            {
                CurrentContact = new Contact();
                Contacts.Add(CurrentContact);
                _DB.Contacts.Add(CurrentContact);
            });
            AddEmailCommand = new DelegateCommand(() =>
            {
                var cm = new ContactMethod();
                CurrentContact.ContactMethods.Add(cm);
            });
            DeleteCommand = new DelegateCommand(() =>
            {
                _DB.Contacts.Remove(CurrentContact);
                Contacts.Remove(CurrentContact);
            });
            LoginCommand = new DelegateCommand(Login);


            Init();
        }

        async void Init()
        {
            IsLoading = System.Windows.Visibility.Visible;
            var temp = _DB.Contacts;
            var contacts = await temp.ToListAsync();
            foreach (var item in contacts)
            {
                Contacts.Add(item);
            }
            IsLoading = System.Windows.Visibility.Hidden;

        }

        string access_token = "CAAAAAI4KGBsBADZChr7PrZBIBCcwZAym3ZAS0vzOZCeeoc36gZB9XT0OgR4ZA1O00yHlge0wUihJuLhEGj6oZAdC9g86ZC4rtQgs3f5wrkzooYONsJuHPoEYbuKBBjVST0VCJZC0gnMzOU6rZBwIWZCshxRgTUj1TyI7Bs6Jr6exV8kBXZCZBu0pJ73VKOROASrhJZAGzmFEIYGQkN1yQZDZD";
        async void LoadFacebook()
        {
            if (CurrentContact == null) return;
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/"),
                DefaultRequestHeaders = { { "accept", "application/json" } }
            };
            try
            {
                var response = await client.GetAsync(CurrentContact.fbid + "?access_token=" + access_token);
                var fb = await response.Content.ReadAsAsync<FBUser>();
                FBUser = fb;
                Log = fb.about;
            }
            catch (Exception)
            {
            }
        }

        void Login()
        {
            var w = new BrowserWindow();
            w.web1.Navigate("https://www.facebook.com/dialog/oauth?client_id=2383026203&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token");
            w.Show();

            w.web1.Navigated += web1_Navigated;
        }

        void web1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.PathAndQuery == "/connect/login_success.html")
            {
                var str = e.Uri.Fragment;
            }
        }

        public ObservableCollection<Contact> Contacts { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddEmailCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }

        private Contact _CurrentContact;

        public Contact CurrentContact
        {
            get { return _CurrentContact; }
            set
            {
                _CurrentContact = value;
                OnPropertyChanged();
                LoadFacebook();
            }
        }

        private System.Windows.Visibility _IsLoading;
        public System.Windows.Visibility IsLoading
        {
            get { return _IsLoading; }
            set { _IsLoading = value; OnPropertyChanged(); }
        }

        private string _Log;
        public string Log
        {
            get { return _Log; }
            set { _Log = value; OnPropertyChanged(); }
        }

        private FBUser _FBUser;
        public FBUser FBUser
        {
            get { return _FBUser; }
            set { _FBUser = value; OnPropertyChanged(); }
        }


    }



    public class FBUser
    {
        public string about { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string directed_by { get; set; }
        public string genre { get; set; }
        public bool is_published { get; set; }
        public string produced_by { get; set; }
        public string release_date { get; set; }
        public string screenplay_by { get; set; }
        public string starring { get; set; }
        public string studio { get; set; }
        public int talking_about_count { get; set; }
        public string username { get; set; }
        public string website { get; set; }
        public int were_here_count { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public int likes { get; set; }
        public Cover cover { get; set; }
    }

    public class Cover
    {
        public string cover_id { get; set; }
        public string source { get; set; }
        public int offset_y { get; set; }
        public int offset_x { get; set; }
    }

}