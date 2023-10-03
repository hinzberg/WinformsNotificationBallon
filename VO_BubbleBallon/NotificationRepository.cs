using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Hinzberg.BallonNotification
{
    public enum NotificationListBehavior { AddOnTop = 0, AddAtBottom = 1 };
    
    public class NotificationRepository : List<NotificationBallon>
    {
        private int _maxElements;
        private int _notificationBallonHeight = 0;
        private List<bool> _emptySlotsList = new List<bool>();

        public NotificationListBehavior Behavior { get; set; } = NotificationListBehavior.AddOnTop;

        public NotificationRepository(int offset)
        {
            _notificationBallonHeight = offset;
            int screenheight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int maxElements = screenheight / _notificationBallonHeight;

            this._maxElements = maxElements;

            for (int i = 0; i < _maxElements; i++)
                _emptySlotsList.Add(true);
        }
       
        public NotificationBallon GetNotification()
        {
            int freeSlotNumber = GetSlotNumber();
            if (freeSlotNumber < 0)
                return null;

            NotificationBallon notification = new NotificationBallon();
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

        public new void Add(NotificationBallon notification)
        {
            int offset = _notificationBallonHeight * notification.SlotNumber;
            notification.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - notification.Width - 5, Screen.PrimaryScreen.WorkingArea.Bottom - notification.Height - 5 - offset);

            if (this.Behavior == NotificationListBehavior.AddOnTop)
                AddOnTop(notification);
            else if (this.Behavior == NotificationListBehavior.AddAtBottom)
                AddWithMove(notification);
        }
        
        private void AddOnTop(NotificationBallon notification)
        {
            // No empty slot at this time
            _emptySlotsList[notification.SlotNumber] = false;
            base.Add(notification);
        }

        private void AddWithMove(NotificationBallon notification)
        {
            // Move all notifications upward
            foreach (NotificationBallon notif in this)
                notif.MoveUpNotification(_notificationBallonHeight);

            // No empty slot at this time
            _emptySlotsList[notification.SlotNumber] = false;
            base.Add(notification);
        }

        public new void Remove(NotificationBallon notification)
        {
            // Slot is empty now
            _emptySlotsList[notification.SlotNumber] = true;
            base.Remove(notification);
        }
    };
}
