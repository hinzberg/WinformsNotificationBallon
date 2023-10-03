using Hinzberg.BallonNotification;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Ballonbenachrichtigung
{
    public partial class MainForm : Form
    {
        private const int _notificationBallonHeight = 100;
        NotificationRepository _notificationRepository;

        public MainForm()
        {
            InitializeComponent();
            _notificationRepository = new NotificationRepository(_notificationBallonHeight);
        }

        private void OnShowNotificationButtonClick(object sender, EventArgs e)
        {
            if (behaviourCheckBox.Checked)
                _notificationRepository.Behavior = NotificationListBehavior.AddOnTop;
            else
                _notificationRepository.Behavior = NotificationListBehavior.AddAtBottom;

            NotificationBallon notification = _notificationRepository.GetNotification();
            if (notification == null) 
                return;

            notification.NotificationIcon = this.Icon;

            notification.ShowDurationTime = 1000;
            
            notification.AutoRemove = this.autoRemoveCheckBox.Checked;
  
            notification.BorderColor = Color.Black;

            notification.ContentText = "Lorem ipsum dolor sit amet, consectetur \nadipisicing elit, sed do \neiusmod tempor.";
            notification.HeadlineText = DateTime.Now.ToLongTimeString() + " Important Message";
            notification.Tag = (string)"http://www.denic.de";

            notification.OnNotificationClicked += OnNotificationClicked;
            notification.OnNotificationClosed += OnNotificationClosed;

            _notificationRepository.Add(notification);
            notification.ShowNotification();
        }

        void OnNotificationClicked(object sender)
        {
            NotificationBallon notification = (NotificationBallon)sender;

            if ((string)notification.Tag == "")
                return;

            try
            {
                Process process = new Process();
                Uri url = new Uri((string)notification.Tag);
                process.StartInfo.FileName = url.ToString();
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch (UriFormatException) { }
        }

        void OnNotificationClosed(object sender)
        {
            _notificationRepository.Remove((NotificationBallon)sender);
        }
    }
}