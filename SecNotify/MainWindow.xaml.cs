using Clickatell_Service;
using SecNotify.Models;
using SecNotify.Resources;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SecNotify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Location CurrentLocation { get; set; }
        public string InternetStatusMessage { get; set; }

        public MainWindow(Location location)
        {
            InitializeComponent();
            CurrentLocation = location;

            SMS checkInternet = new SMS();
            if (checkInternet.HasInternet())
            {
                InternetStatusMessage = "";
            }
            else
            {
                InternetStatusMessage = "NO INTERNET CONNECTION DETECTED";
            }

        }

        private void btnPageSecurity911_Click(object sender, RoutedEventArgs e)
        {
            SMS sms = new SMS
            {
                Content = ("|| 911 ** 911 ** 911 ||%0a"
                           + "|| " + this.CurrentLocation.Name + " ||%0a"
                           + "EMERGENCY - REPORT IMMEDIATELY")
            };

            Secret recipient = new Secret();
            if (sms.HasInternet())
            {
                sms.Send(recipient);
                SentResponse(sms);
            }
            else
            {
                MessageBoxResult popup = MessageBox.Show(this, "No internet connection detected. Use physical panic button.", "Message Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSendMsg_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMessage.Text))
            {
                SMS sms = new SMS
                {
                    Content = ("|| " + this.CurrentLocation.Name + " ||%0a"
                             + "|| " + this.CurrentLocation.Phone + " ||%0a"
                             + txtMessage.Text),
                };

                Secret recipient = new Secret();
                if (sms.HasInternet())
                {
                    sms.Send(recipient);
                    SentResponse(sms);
                }
                else
                {
                    MessageBoxResult popup = MessageBox.Show(this, "No internet connection detected.\nPlease use another method to contact security.", "Message Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

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

        private void SentResponse(SMS sms)
        {
            if (sms.Response.messages[0].accepted || (String.IsNullOrEmpty(sms.Response.messages[0].error.ToString())))
            {
                MessageBoxResult popup = MessageBox.Show(this, "Message successfully sent.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                txtMessage.Text = "";
            }
            else
            {
                MessageBoxResult popup = MessageBox.Show(this, "Message not sent. Please try again.", "Message Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
