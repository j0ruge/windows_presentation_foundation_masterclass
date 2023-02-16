using DesktopContactsApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public Contacts Contacts
        {
            get { return (Contacts)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contacts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contacts", typeof(Contacts), typeof(ContactControl), new PropertyMetadata(new Contacts() {Name = "Full Name", Email = "Email Address", Phone="Phone Number" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            if (control != null )
            {
                control.nameTextBlock.Text = (e.NewValue as Contacts).Name;
                control.emailTextBlock.Text = (e.NewValue as Contacts).Email;
                control.phoneTextBlock.Text = (e.NewValue as Contacts).Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
