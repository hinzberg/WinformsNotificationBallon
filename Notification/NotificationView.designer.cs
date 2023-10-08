namespace Hinzberg.BallonNotification
{
    partial class NotificationView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.contentLabel = new System.Windows.Forms.Label();
            this.headlineLabel = new System.Windows.Forms.Label();
            this.XButton = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // contentLabel
            // 
            this.contentLabel.BackColor = System.Drawing.Color.Transparent;
            this.contentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentLabel.Location = new System.Drawing.Point(51, 25);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(337, 66);
            this.contentLabel.TabIndex = 1;
            this.contentLabel.Text = "Text";
            this.contentLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnNotificationClick);
            // 
            // headlineLabel
            // 
            this.headlineLabel.BackColor = System.Drawing.Color.Transparent;
            this.headlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headlineLabel.Location = new System.Drawing.Point(48, 6);
            this.headlineLabel.Name = "headlineLabel";
            this.headlineLabel.Size = new System.Drawing.Size(340, 18);
            this.headlineLabel.TabIndex = 2;
            this.headlineLabel.Text = "Titel";
            this.headlineLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnNotificationClick);
            // 
            // XButton
            // 
            this.XButton.BackColor = System.Drawing.Color.Transparent;
            this.XButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.XButton.FlatAppearance.BorderSize = 0;
            this.XButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.XButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.XButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XButton.ForeColor = System.Drawing.Color.Red;
            this.XButton.Location = new System.Drawing.Point(377, 4);
            this.XButton.Name = "XButton";
            this.XButton.Size = new System.Drawing.Size(16, 16);
            this.XButton.TabIndex = 4;
            this.XButton.UseVisualStyleBackColor = false;
            this.XButton.Click += new System.EventHandler(this.OnCloseButtonClick);
            this.XButton.Paint += new System.Windows.Forms.PaintEventHandler(this.CloseButtonPaint);
            // 
            // icon
            // 
            this.icon.BackColor = System.Drawing.Color.Transparent;
            this.icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.icon.Location = new System.Drawing.Point(10, 5);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(32, 32);
            this.icon.TabIndex = 5;
            this.icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnNotificationClick);
            // 
            // NotificationBallon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.XButton);
            this.Controls.Add(this.headlineLabel);
            this.Controls.Add(this.contentLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotificationBallon";
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnNotificationClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.Label headlineLabel;
        private System.Windows.Forms.Button XButton;
        private System.Windows.Forms.Panel icon;
    }
}