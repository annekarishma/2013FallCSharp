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

namespace WPFAutoCompleteTextbox
{
    
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            textBox1.AddItem(new AutoCompleteEntry("Holtsville, NY", "Holtsville, NY"));
            textBox1.AddItem(new AutoCompleteEntry("Adjuntas, PR", "Adjuntas, PR"));
            textBox1.AddItem(new AutoCompleteEntry("Aguada, PR", "Aguada, PR"));
            textBox1.AddItem(new AutoCompleteEntry("Aguadilla, PR", "Aguadilla, PR", "Aguadilla, PR"));
            textBox1.AddItem(new AutoCompleteEntry("Maricao, PR", "Marico, PR"));
            textBox1.AddItem(new AutoCompleteEntry("Anasco, PR ", "Anasco, PR"));
            textBox1.AddItem(new AutoCompleteEntry("Angeles, PR ", "Angeles, PR"));
          
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }
}
