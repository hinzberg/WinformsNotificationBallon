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
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Settings";
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
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(320, 381);
            this.Controls.Add(this.behaviourCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoRemoveCheckBox);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox autoRemoveCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox behaviourCheckBox;
    }
}

