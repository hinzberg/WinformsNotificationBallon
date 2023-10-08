namespace Ballonbenachrichtigung
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
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
            this.button1 = new System.Windows.Forms.Button();
            this.autoRemoveCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.behaviourCheckBox = new System.Windows.Forms.CheckBox();
            this.hideIconCheckBox = new System.Windows.Forms.CheckBox();
            this.colorBorderCheckBox = new System.Windows.Forms.CheckBox();
            this.userIconRadioButton = new System.Windows.Forms.RadioButton();
            this.mailIconRadioButton = new System.Windows.Forms.RadioButton();
            this.alertIconRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(296, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Notification";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnShowNotificationButtonClick);
            // 
            // autoRemoveCheckBox
            // 
            this.autoRemoveCheckBox.AutoSize = true;
            this.autoRemoveCheckBox.Checked = true;
            this.autoRemoveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRemoveCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoRemoveCheckBox.Location = new System.Drawing.Point(16, 105);
            this.autoRemoveCheckBox.Name = "autoRemoveCheckBox";
            this.autoRemoveCheckBox.Size = new System.Drawing.Size(108, 20);
            this.autoRemoveCheckBox.TabIndex = 2;
            this.autoRemoveCheckBox.Text = "Auto Remove";
            this.autoRemoveCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sample Settings";
            // 
            // behaviourCheckBox
            // 
            this.behaviourCheckBox.AutoSize = true;
            this.behaviourCheckBox.Checked = true;
            this.behaviourCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.behaviourCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.behaviourCheckBox.Location = new System.Drawing.Point(16, 131);
            this.behaviourCheckBox.Name = "behaviourCheckBox";
            this.behaviourCheckBox.Size = new System.Drawing.Size(194, 20);
            this.behaviourCheckBox.TabIndex = 4;
            this.behaviourCheckBox.Text = "Add new Notifications on top";
            this.behaviourCheckBox.UseVisualStyleBackColor = true;
            // 
            // hideIconCheckBox
            // 
            this.hideIconCheckBox.AutoSize = true;
            this.hideIconCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideIconCheckBox.Location = new System.Drawing.Point(16, 183);
            this.hideIconCheckBox.Name = "hideIconCheckBox";
            this.hideIconCheckBox.Size = new System.Drawing.Size(83, 20);
            this.hideIconCheckBox.TabIndex = 6;
            this.hideIconCheckBox.Text = "Hide Icon";
            this.hideIconCheckBox.UseVisualStyleBackColor = true;
            // 
            // redBorderCheckBox
            // 
            this.colorBorderCheckBox.AutoSize = true;
            this.colorBorderCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorBorderCheckBox.Location = new System.Drawing.Point(16, 157);
            this.colorBorderCheckBox.Name = "redBorderCheckBox";
            this.colorBorderCheckBox.Size = new System.Drawing.Size(102, 20);
            this.colorBorderCheckBox.TabIndex = 7;
            this.colorBorderCheckBox.Text = "Color Border";
            this.colorBorderCheckBox.UseVisualStyleBackColor = true;
            // 
            // userIconRadioButton
            // 
            this.userIconRadioButton.AutoSize = true;
            this.userIconRadioButton.Checked = true;
            this.userIconRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIconRadioButton.Location = new System.Drawing.Point(16, 209);
            this.userIconRadioButton.Name = "userIconRadioButton";
            this.userIconRadioButton.Size = new System.Drawing.Size(89, 20);
            this.userIconRadioButton.TabIndex = 8;
            this.userIconRadioButton.TabStop = true;
            this.userIconRadioButton.Text = "Icon - User";
            this.userIconRadioButton.UseVisualStyleBackColor = true;
            // 
            // mailIconRadioButton
            // 
            this.mailIconRadioButton.AutoSize = true;
            this.mailIconRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailIconRadioButton.Location = new System.Drawing.Point(16, 235);
            this.mailIconRadioButton.Name = "mailIconRadioButton";
            this.mailIconRadioButton.Size = new System.Drawing.Size(85, 20);
            this.mailIconRadioButton.TabIndex = 9;
            this.mailIconRadioButton.TabStop = true;
            this.mailIconRadioButton.Text = "Icon - Mail";
            this.mailIconRadioButton.UseVisualStyleBackColor = true;
            // 
            // alertIconRadioButton
            // 
            this.alertIconRadioButton.AutoSize = true;
            this.alertIconRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertIconRadioButton.Location = new System.Drawing.Point(16, 261);
            this.alertIconRadioButton.Name = "alertIconRadioButton";
            this.alertIconRadioButton.Size = new System.Drawing.Size(87, 20);
            this.alertIconRadioButton.TabIndex = 10;
            this.alertIconRadioButton.TabStop = true;
            this.alertIconRadioButton.Text = "Icon - Alert";
            this.alertIconRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(322, 294);
            this.Controls.Add(this.alertIconRadioButton);
            this.Controls.Add(this.mailIconRadioButton);
            this.Controls.Add(this.userIconRadioButton);
            this.Controls.Add(this.colorBorderCheckBox);
            this.Controls.Add(this.hideIconCheckBox);
            this.Controls.Add(this.behaviourCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoRemoveCheckBox);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notification Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox autoRemoveCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox behaviourCheckBox;
        private System.Windows.Forms.CheckBox hideIconCheckBox;
        private System.Windows.Forms.CheckBox colorBorderCheckBox;
        private System.Windows.Forms.RadioButton userIconRadioButton;
        private System.Windows.Forms.RadioButton mailIconRadioButton;
        private System.Windows.Forms.RadioButton alertIconRadioButton;
    }
}

