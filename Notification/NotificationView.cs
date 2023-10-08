using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hinzberg.BallonNotification
{
    public partial class NotificationView : Form
    {
        #region << Win32 API >>
        [DllImport("user32.dll")]
        protected static extern bool ShowWindow(IntPtr hWnd, Int32 flags);
        [DllImport("user32.dll")]
        protected static extern bool SetWindowPos(IntPtr hWnd, Int32 hWndInsertAfter, Int32 X, Int32 Y, Int32 cx, Int32 cy, uint uFlags);

        // SetWindowPos()
        protected const Int32 HWND_TOPMOST = -1;
        protected const Int32 SWP_NOACTIVATE = 0x0010;
        // ShowWindow()
        protected const Int32 SW_SHOWNOACTIVATE = 4;
        // https://thecave.myjabber.net/svn/ags/XMPP/agsxmpp.ui/trunk/roster/Tooltip.cs
        #endregion    

        public enum NotificationBorderStyle { None, Thin, Thick }

        public Color BorderColor { get; set; } = Color.DarkGray;          // Border Color of the Notification
        public Color BackgroundColor { get; set; } = Color.White;   // Background Color of the Notification
        public NotificationBorderStyle BorderStyle { get; set; } = NotificationBorderStyle.Thin;

        public bool AutoRemove { get; set; } = true;                       // Remove Notification automatically

        public int FadeInDurationTime { get; set; } = 500;
        public int ShowDurationTime { get; set; } = 500;
        public int FadeOutDurationTime { get; set; } = 500;

        public Icon NotificationIcon { get; set; } = null;                 // Icon for Notification
        public DateTime SendTimeStamp { get; set; } = DateTime.Now;   // Zeitstempel
        public Font TextFont { get; set; }

        public int SlotNumber { get; set; } = 0;

        public delegate void RaiseEvent(NotificationView notification);
        public event RaiseEvent NotificationClosed;
        public event RaiseEvent NotificationClicked;

        private Timer _fadeInTimer;
        private Timer _showTimer;
        private Timer _fadeOutTimer;

        public string HeadlineText { get { return this.headlineLabel.Text; } set { this.headlineLabel.Text = value; } }
        public string ContentText { get { return this.contentLabel.Text; } set { this.contentLabel.Text = value; } }
        public object AssociatedObject { get; set; } = null;

        public NotificationView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Opacity = 1.0;
        }

        #region Timer für weiches ein und Ausblenden

        private void OnFadeInTimerTick(object sender, EventArgs e)
        {
            if (Opacity >= 1.0)
            {
                _fadeInTimer.Stop();
                _showTimer.Start();
            }
            Opacity += 0.1;
        }

        private void OnShowTimerTick(object sender, EventArgs e)
        {
            this.Opacity = 1;
            _showTimer.Stop();

            if (AutoRemove == true)
                _fadeOutTimer.Start();
        }

        private void OnFadeOutTimerTick(object sender, EventArgs e)
        {
            if (Opacity == 0.0)
            {
                _fadeOutTimer.Stop();

                this.NotificationClosed?.Invoke(this);
                this.Close();
            }
            Opacity -= 0.1;
        }

        #endregion

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Rectangle b_rect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            this.Region = new Region(b_rect);
        }

        private void OnNotificationClick(object sender, MouseEventArgs e)
        {
            this.NotificationClicked?.Invoke(this);
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            _fadeInTimer?.Stop();
            _showTimer?.Stop();
            _fadeOutTimer?.Start();
        }

        #region Paint Methods

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle backgroundRect;


            int borderThickness = 0;
            int offest = 2 * borderThickness + 2;
            bool drawBorder = true;

            switch (this.BorderStyle)
            {
                case NotificationBorderStyle.None:
                    drawBorder = false;
                    break;

                case NotificationBorderStyle.Thin:
                    borderThickness = 1;
                    offest = 2 * borderThickness + 2;
                    break;

                case NotificationBorderStyle.Thick:
                    borderThickness = 2;
                    offest = 2 * borderThickness + 2;
                    break;
                default:
                    break;
            }

            backgroundRect = new Rectangle(ClientRectangle.X + borderThickness, ClientRectangle.Y + borderThickness, ClientRectangle.Width - offest, ClientRectangle.Height - offest);
            e.Graphics.FillRectangle(new SolidBrush(this.BackgroundColor), backgroundRect);
            if (drawBorder)
                this.BackColor = BorderColor;
        }

        /// <summary>
        /// Draw the  X Close Button in the upper right corner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButtonPaint(object sender, PaintEventArgs e)
        {
            Rectangle xRect = new Rectangle(XButton.ClientRectangle.Location, XButton.ClientRectangle.Size);
            xRect.Inflate(-2, -2);
            xRect.Offset(1, 1);
            XShape xShape = new XShape(xRect, 4);
            xRect.Offset(2, 2);
            PathGradientBrush xBg = new PathGradientBrush(xShape);
            xBg.CenterColor = Color.Black;

            if (XButton.Focused)
                xBg.CenterColor = Color.Black;

            xBg.SurroundColors = new Color[] { Color.Black };
            e.Graphics.FillPath(xBg, xShape);
            e.Graphics.DrawPath(Pens.Black, xShape);
        }

        #endregion

        /// <summary>
        /// Start fade timers, show notification
        /// </summary>

        public void MoveUpNotification(int offset)
        {
            int newLocationY = this.Location.Y - offset;
            SetWindowPos(this.Handle, HWND_TOPMOST, this.Location.X, newLocationY, this.Width, this.Height, SWP_NOACTIVATE);
        }

        public void ShowNotification()
        {
            #region Without an icon there is more space for the text

            if (NotificationIcon == null)
            {
                icon.Visible = false;

                Point title_point = new Point();
                Size titel_size = new Size();

                title_point = headlineLabel.Location;
                titel_size = headlineLabel.Size;

                title_point.X = title_point.X - 40;
                headlineLabel.Location = title_point;

                titel_size.Width = titel_size.Width + 40;
                headlineLabel.Size = titel_size;

                Point text_point = new Point();
                Size text_size = new Size();

                text_point = contentLabel.Location;
                text_size = contentLabel.Size;

                text_point.X = text_point.X - 40;
                contentLabel.Location = text_point;

                text_size.Width = text_size.Width + 40;
                contentLabel.Size = text_size;
            }
            else
            {
                icon.BackgroundImage = NotificationIcon.ToBitmap();
            }

            #endregion                          

            contentLabel.Font = TextFont;

            ShowWindow(this.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(this.Handle, HWND_TOPMOST, this.Location.X, this.Location.Y, this.Width, this.Height, SWP_NOACTIVATE);

            _fadeInTimer = new Timer();
            _fadeInTimer.Interval = FadeInDurationTime / 10;
            _fadeInTimer.Tick += new EventHandler(OnFadeInTimerTick);

            _showTimer = new Timer();
            _showTimer.Interval = ShowDurationTime;
            _showTimer.Tick += new EventHandler(OnShowTimerTick);

            _fadeOutTimer = new Timer();
            _fadeOutTimer.Interval = FadeOutDurationTime / 10;
            _fadeOutTimer.Tick += new EventHandler(OnFadeOutTimerTick);

            // Fade in or no fade in
            if (FadeInDurationTime > 0)
            {
                this.Opacity = 0;
                _fadeInTimer.Start();
            }
            else
            {
                _showTimer.Start();
            }
        }

        public void HideNotification()
        {
            _fadeInTimer?.Stop();
            _showTimer?.Stop();
            _fadeOutTimer?.Start();
        }
    }
}