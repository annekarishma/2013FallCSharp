
using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace Contactmanagement
{
    #region Contexts
    
    
    public partial class ContactDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ContactDBEntities object using the connection string found in the 'ContactDBEntities' section of the application configuration file.
        /// </summary>
        public ContactDBEntities() : base("name=ContactDBEntities", "ContactDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ContactDBEntities object.
        /// </summary>
        public ContactDBEntities(string connectionString) : base(connectionString, "ContactDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ContactDBEntities object.
        /// </summary>
        public ContactDBEntities(EntityConnection connection) : base(connection, "ContactDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        
        public ObjectSet<Detail> Details
        {
            get
            {
                if ((_Details == null))
                {
                    _Details = base.CreateObjectSet<Detail>("Details");
                }
                return _Details;
            }
        }
        private ObjectSet<Detail> _Details;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Details EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDetails(Detail detail)
        {
            base.AddObject("Details", detail);
        }

        #endregion

    }

    #endregion

    #region Entities
    
  
    [EdmEntityTypeAttribute(NamespaceName="ContactDB2Model", Name="Detail")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Detail : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Detail object.
        /// </summary>
        /// <param name="fName">Initial value of the fName property.</param>
        public static Detail CreateDetail(global::System.String fName)
        {
            Detail detail = new Detail();
            detail.fName = fName;
            return detail;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String fName
        {
            get
            {
                return _fName;
            }
            set
            {
                if (_fName != value)
                {
                    OnfNameChanging(value);
                    ReportPropertyChanging("fName");
                    _fName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("fName");
                    OnfNameChanged();
                }
            }
        }
        private global::System.String _fName;
        partial void OnfNameChanging(global::System.String value);
        partial void OnfNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String lName
        {
            get
            {
                return _lName;
            }
            set
            {
                OnlNameChanging(value);
                ReportPropertyChanging("lName");
                _lName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("lName");
                OnlNameChanged();
            }
        }
        private global::System.String _lName;
        partial void OnlNameChanging(global::System.String value);
        partial void OnlNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String contactNo
        {
            get
            {
                return _contactNo;
            }
            set
            {
                OncontactNoChanging(value);
                ReportPropertyChanging("contactNo");
                _contactNo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("contactNo");
                OncontactNoChanged();
            }
        }
        private global::System.String _contactNo;
        partial void OncontactNoChanging(global::System.String value);
        partial void OncontactNoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PrimaryEmailID
        {
            get
            {
                return _PrimaryEmailID;
            }
            set
            {
                OnPrimaryEmailIDChanging(value);
                ReportPropertyChanging("PrimaryEmailID");
                _PrimaryEmailID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PrimaryEmailID");
                OnPrimaryEmailIDChanged();
            }
        }
        private global::System.String _PrimaryEmailID;
        partial void OnPrimaryEmailIDChanging(global::System.String value);
        partial void OnPrimaryEmailIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SecondryEmailID
        {
            get
            {
                return _SecondryEmailID;
            }
            set
            {
                OnSecondryEmailIDChanging(value);
                ReportPropertyChanging("SecondryEmailID");
                _SecondryEmailID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SecondryEmailID");
                OnSecondryEmailIDChanged();
            }
        }
        private global::System.String _SecondryEmailID;
        partial void OnSecondryEmailIDChanging(global::System.String value);
        partial void OnSecondryEmailIDChanged();

        #endregion

    
    }

    #endregion

    
}
