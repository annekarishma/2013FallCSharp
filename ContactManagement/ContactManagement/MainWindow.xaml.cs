using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace Contactmanagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Member Fields

        private ListSortDirection _lastDirection;
        private GridViewColumnHeader _lastHeaderClicked;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void miLoad_Click(object sender, RoutedEventArgs e)
        {
            var context = new ContactDBEntities ();

            DataContext = (from employees in context.Details
                           select employees).ToList();

            miLoad.IsEnabled = !miLoad.IsEnabled;
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked != null)
            {
                ListSortDirection direction;

                if (headerClicked != _lastHeaderClicked)
                {
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    direction = _lastDirection == ListSortDirection.Ascending
                                    ? ListSortDirection.Descending
                                    : ListSortDirection.Ascending;
                }

                ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);

                if (view != null)
                {
                    using (view.DeferRefresh())
                    {
                        view.SortDescriptions.Clear();
                        view.SortDescriptions.Add(new SortDescription("lName", direction));
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        private void tbSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);

            //if (view != null)
            //{
            //    view.Filter = item =>
            //    {
            //        var employee = item as Detail ;
            //        if (employee != null)
            //        {
            //            if (employee.lName .StartsWith(tbSearch.Text))
            //            {
            //                return true;
            //            }
            //        }

            //        return false;
            //    };
            //}
        }
       
        // Establishing Connection String from Configuration File
        string _ConnectionString = @"Data Source=(localdb)\v11.0;database=ContactDB;Integrated Security=True";

        public void BindGrid()
        {

            SqlConnection _Conn = new SqlConnection(_ConnectionString);

            // Open the Database Connection
            _Conn.Open();

            SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from Details", _Conn);

            DataSet _Bind = new DataSet();
            _Adapter.Fill(_Bind, "MyDataBinding");


            dataGrid1.DataContext = _Bind;

            // Close the Database Connection
            _Conn.Close();

        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection _Conn = new SqlConnection(_ConnectionString);

                // Open the Database Connection
                _Conn.Open();

              //  string _Date = DOB_Txt.DisplayDate.ToShortDateString();

                // Command String
                string _Insert = @"insert into Details
                               (fName,lName,contactNo,PrimaryEmailID,SecondryEmailID)
                               Values('" + fName_Txt.Text + "','" + lName_Txt.Text + "','" + cn_Txt.Text + "','" + pe_Txt.Text + "','" + se_Txt.Text + "')";

                // Initialize the command query and connection
                SqlCommand _cmd = new SqlCommand(_Insert, _Conn);

                // Execute the command
                _cmd.ExecuteNonQuery();

                MessageBox.Show("One Record Inserted");
                fName_Txt.Text = string.Empty;
                lName_Txt.Text = string.Empty;
                cn_Txt .Text = string.Empty;
                pe_Txt .Text = string.Empty;
                se_Txt.Text = string.Empty;

                this.BindGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Del_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection _conn = new SqlConnection(_ConnectionString);

                // Open Database Connection
                _conn.Open();

                // Command String
                string _DelCmd = @"Delete from Details
                              Where fName='" + fName_Txt.Text + "'";

                // Initialize the command query and connection
                SqlCommand _CmdDelete = new SqlCommand(_DelCmd, _conn);

                // Execute the command
                _CmdDelete.ExecuteNonQuery();

                MessageBox.Show("One Record Deleted");
                fName_Txt.Text = string.Empty;
                lName_Txt.Text = string.Empty;
                cn_Txt .Text = string.Empty;
                pe_Txt .Text = string.Empty;
                se_Txt.Text = string.Empty;
                this.BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _DataView = dataGrid1.CurrentCell.Item as DataRowView;

                if (_DataView != null)
                {
                    fName_Txt.Text = _DataView.Row[0].ToString();
                    fName_Txt.IsEnabled = false;
                    lName_Txt.Text = _DataView.Row[1].ToString();
                    cn_Txt.Text = _DataView.Row[2].ToString();
                    pe_Txt.Text = _DataView.Row[3].ToString();
                    se_Txt.Text = _DataView.Row[4].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection _Conn = new SqlConnection(_ConnectionString);

                // Open Database Connection
                _Conn.Open();

              //  string _Date = DOB_Txt.DisplayDate.ToShortDateString();

                // Command String
                string _UpdateCmd = @"Update Details Set 
                                    lName = '" + lName_Txt.Text + "',contactNo = '" + cn_Txt.Text + "',PrimaryEmailID = '" + pe_Txt.Text + "',SecondryEmailID = '" + pe_Txt.Text + "' where fName = '" + fName_Txt.Text + "'";

                // Initialize the command query and connection
                SqlCommand _CmdUpdate = new SqlCommand(_UpdateCmd, _Conn);

                // Execute the command
                _CmdUpdate.ExecuteNonQuery();

                MessageBox.Show("One Record Updated");
                fName_Txt.Text = string.Empty;
                lName_Txt.Text = string.Empty;
                cn_Txt.Text = string.Empty;
                pe_Txt .Text = string.Empty;
                se_Txt.Text = string.Empty;
                this.BindGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void New_Btn_Click(object sender, RoutedEventArgs e)
        {
            fName_Txt.Text = string.Empty;
            if (fName_Txt.IsEnabled != true)
            {
                fName_Txt.IsEnabled = true;
            }
            lName_Txt.Text = string.Empty;
            cn_Txt.Text = string.Empty;
            pe_Txt .Text = string.Empty;
            se_Txt.Text = string.Empty;
        }
    }


}