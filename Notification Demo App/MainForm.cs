using Hinzberg.BallonNotification;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ballonbenachrichtigung
{
    public partial class MainForm : Form
    {
        private const int _notificationViewReservedHeight = 105;
        NotificationRepository _notificationRepository;

        public MainForm()
        {
            InitializeComponent();
            _notificationRepository = new NotificationRepository(_notificationViewReservedHeight);
        }

        private void OnShowNotificationButtonClick(object sender, EventArgs e)
        {
            if (behaviourCheckBox.Checked)
                _notificationRepository.Behavior = NotificationListBehavior.AddOnTop;
            else
                _notificationRepository.Behavior = NotificationListBehavior.AddAtBottom;

            NotificationView notification = _notificationRepository.GetNotification();
            if (notification == null)
                return;

            notification.NotificationIcon = this.Icon;
            notification.ShowDurationTime = 3000;

            notification.AutoRemove = this.autoRemoveCheckBox.Checked;

            // Icon
            if (hideIconCheckBox.Checked)
                notification.NotificationIcon = null;
            else if (userIconRadioButton.Checked)
                notification.NotificationIcon = Properties.Resources.user;
            else if (mailIconRadioButton.Checked)
                notification.NotificationIcon = Properties.Resources.mail;
            else if (alertIconRadioButton.Checked)
                notification.NotificationIcon = Properties.Resources.alert;

            if (colorBorderCheckBox.Checked)
                notification.BorderColor = Color.Red;

            notification.ContentText = "Lorem ipsum dolor sit amet, consectetur \nadipisicing elit, sed do \neiusmod tempor.";
            notification.HeadlineText = DateTime.Now.ToLongTimeString() + " Important Message";
            notification.AssociatedObject = @"http://www.denic.de";

            notification.NotificationClicked += OnNotificationClicked;
            notification.NotificationClosed += OnNotificationClosed;

            _notificationRepository.Add(notification);
            notification.ShowNotification();
        }

        void OnNotificationClicked(NotificationView notification)
        {
            var obj = notification.AssociatedObject;
            // Remove on Click, optional
            notification.HideNotification();
        }

        void OnNotificationClosed(NotificationView notification)
        {
            _notificationRepository.Remove(notification);            
        }
    }
}