using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ContactManagement.ViewModels
{
    public class Product
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //For DB use only!
        private int _contactId;
        public int _ContactId { get { return _contactId; } }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value; OnPropertyChanged(new PropertyChangedEventArgs("FirstName"));
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value; OnPropertyChanged(new PropertyChangedEventArgs("LastName"));
            }
        }

       
        private string emailID;
        public string EmailID
        {
            get { return emailID; }
            set { emailID = value; OnPropertyChanged(new PropertyChangedEventArgs("EmailID")); }
        }

        private string phno;
        public string PhNo
        {
            get { return phno; }
            set { phno = value; OnPropertyChanged(new PropertyChangedEventArgs("PhNo")); }
        }
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; OnPropertyChanged(new PropertyChangedEventArgs("State")); }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(new PropertyChangedEventArgs("City")); }
        }

        public Product()
        {
        }

        public Product(int contactId, string firstName, string lastName,string emailID, string phno, string state, string city)
        {
            this._contactId  = contactId ;
            FirstName   = firstName ;
            LastName = lastName;
            EmailID  = emailID ;
            PhNo = phno;
            State  = state ;
            City  = city ;
           
        }

        public void CopyProduct(Product p)
        {
            this._contactId = p._ContactId ;
            this.FirstName  = p.FirstName;
            this.LastName = p.LastName;
            this.EmailID  = p.EmailID ;
            this.PhNo = p.PhNo;
            this.State  = p.State ;
            this.City  = p.City ;
           
        }

        //Creating a new product in the DB assigns the ProductId
        //Update the ProductId from the value in the corresponding SqlProduct
        public void ProductAdded2DB(SqlProduct sqlProduct)
        {
            this._contactId = sqlProduct.ContactID ;
        }

    } //class Product



    
    public class SqlProduct
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string PhNo { get; set; }
        public string State { get; set; }
        public string City { get; set; }
       

        public SqlProduct() { }

        public SqlProduct(int contactId, string firstname, string lastname, string emailid,string phno,
                        string state, string city)
        {
            ContactID = contactId ;
            FirstName  = firstname  ;
            LastName = lastname;
            EmailID = emailid ;
            PhNo = phno;
            State = state ;
            City = city ;
           
        }

        public SqlProduct(Product p)
        {
            ContactID = p._ContactId ;
            FirstName  = p.FirstName ;
            LastName = p.LastName;
            EmailID = p.EmailID;
            PhNo = p.PhNo;
            State = p.State;
            City = p.City;
            
        }

        public Product SqlProduct2Product()
        {
           // string unitCost = UnitCost.ToString();
            return new Product(ContactID , FirstName ,LastName  , EmailID ,PhNo, State , City);
        } //SqlProduct2Product()
    }

}
