using Clickatell_Service;
using SecNotify.Resources;
using System;
using System.Windows;

namespace SecNotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPageSecurity911_Click(object sender, RoutedEventArgs e)
        {
            SMS sms = new SMS
            {
                Content = "** 911 ** 911 ** 911 **%0aStill not an asshole",
            };

            Secret recipient = new Secret();
            sms.Send(recipient);
            MessageBoxResult popup = MessageBox.Show(this, "Message successfully sent.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            Console.WriteLine(sms.Response);
        }

        private void btnSendMsg_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMessage.Text))
            {
                SMS sms = new SMS
                {
                    Content = ("|| " + tboxLocation.Text + " ||%0a"
                               + "|| " + tboxPhone.Text + " ||%0a"
                               + txtMessage.Text),
                };

                Secret recipient = new Secret();
                sms.Send(recipient);
                MessageBoxResult popup = MessageBox.Show(this, "Message successfully sent.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                txtMessage.Text = "";
                Console.WriteLine(sms.Response);
            }
            else
            {
                MessageBoxResult popup = MessageBox.Show(this, "Please enter a nonurgent message for security.", "Message Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult popup = MessageBox.Show(this, "Admin controls coming soon!", "Coming Soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
