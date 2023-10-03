using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Hinzberg.BallonNotification
{
    public enum NotificationListBehavior { AddOnTop = 0, AddAtBottom = 1 };
    
    public class NotificationRepository : List<NotificationView>
    {
        private int _maxElements;
        private int _notificationViewReservedHeight = 0;
        private List<bool> _emptySlotsList = new List<bool>();

        public NotificationListBehavior Behavior { get; set; } = NotificationListBehavior.AddOnTop;
        public int NotificationRowOffsetBottom { get; set; } = 5;
        public int NotificationRowOffsetRight { get; set; } = 5;

        public NotificationRepository(int notificationViewReservedHeight)
        {
            _notificationViewReservedHeight = notificationViewReservedHeight;
            int screenheight = Screen.PrimaryScreen.WorkingArea.Height;
            int maxElements = screenheight / _notificationViewReservedHeight;

            this._maxElements = maxElements;

            for (int i = 0; i < _maxElements; i++)
                _emptySlotsList.Add(true);
        }
       
        public NotificationView GetNotification()
        {
            int freeSlotNumber = GetSlotNumber();
            if (freeSlotNumber < 0)
                return null;

            NotificationView notification = new NotificationView();
            notification.SlotNumber = freeSlotNumber;
            return notification;
        }

        private int GetSlotNumber()
        {
            if (this.Behavior == NotificationListBehavior.AddAtBottom)
                return 0;
            
            for (int i = 0; i < _emptySlotsList.Count; i++)
            {
                if (_emptySlotsList[i] == true)
                {
                    _emptySlotsList[i] = false;
                    return i;
                }
            }

            // no empty slot right now
            return -1;
        }

        public new void Add(NotificationView notification)
        {
            int offset = _notificationViewReservedHeight * notification.SlotNumber;
            notification.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - notification.Width - NotificationRowOffsetRight, Screen.PrimaryScreen.WorkingArea.Bottom - notification.Height - NotificationRowOffsetBottom - offset);

            if (this.Behavior == NotificationListBehavior.AddOnTop)
                AddOnTop(notification);
            else if (this.Behavior == NotificationListBehavior.AddAtBottom)
                AddWithMove(notification);
        }
        
        private void AddOnTop(NotificationView notification)
        {
            // No empty slot at this time
            _emptySlotsList[notification.SlotNumber] = false;
            base.Add(notification);
        }

        private void AddWithMove(NotificationView notification)
        {
            // Move all notifications upward
            foreach (NotificationView notif in this)
                notif.MoveUpNotification(_notificationViewReservedHeight);

            // No empty slot at this time
            _emptySlotsList[notification.SlotNumber] = false;
            base.Add(notification);
        }

        public new void Remove(NotificationView notification)
        {
            // Slot is empty now
            _emptySlotsList[notification.SlotNumber] = true;
            base.Remove(notification);
        }
    };
}
