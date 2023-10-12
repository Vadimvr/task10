namespace View
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.loginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.modeAndStepsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stepBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.StepsDataGridView = new System.Windows.Forms.DataGridView();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.UpdateDbButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ModeDataGridView = new System.Windows.Forms.DataGridView();
            this.UnregisterButton = new System.Windows.Forms.Button();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.modeAndStepsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsDataGridView)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(84, 53);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Sing in";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(165, 53);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(75, 23);
            this.RegisterButton.TabIndex = 1;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(84, 6);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(156, 20);
            this.emailTextBox.TabIndex = 2;
            this.emailTextBox.Tag = "";
            this.emailTextBox.Text = "email";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(84, 27);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(156, 20);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.Text = "password";
            // 
            // stepBindingSource
            // 
            this.stepBindingSource.DataSource = typeof(Models.Step);
            // 
            // modeBindingSource
            // 
            this.modeBindingSource.DataSource = typeof(Models.Mode);
            // 
            // stepBindingSource1
            // 
            this.stepBindingSource1.DataSource = typeof(Models.Step);
            // 
            // StepsDataGridView
            // 
            this.StepsDataGridView.AllowUserToAddRows = false;
            this.StepsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StepsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.StepsDataGridView.Name = "StepsDataGridView";
            this.StepsDataGridView.Size = new System.Drawing.Size(764, 325);
            this.StepsDataGridView.TabIndex = 4;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(233, 3);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 5;
            this.OpenFileButton.Text = "Open file";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Visible = false;
            // 
            // UpdateDbButton
            // 
            this.UpdateDbButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpdateDbButton.Location = new System.Drawing.Point(314, 3);
            this.UpdateDbButton.Name = "UpdateDbButton";
            this.UpdateDbButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateDbButton.TabIndex = 6;
            this.UpdateDbButton.Text = "Update DB";
            this.UpdateDbButton.UseVisualStyleBackColor = true;
            this.UpdateDbButton.Visible = false;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Controls.Add(this.tabPage2);
            this.MainTabControl.Location = new System.Drawing.Point(6, 82);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(782, 364);
            this.MainTabControl.TabIndex = 7;
            this.MainTabControl.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.StepsDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Steps";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ModeDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(774, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ModeDataGridView
            // 
            this.ModeDataGridView.AllowUserToAddRows = false;
            this.ModeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ModeDataGridView.Location = new System.Drawing.Point(4, 7);
            this.ModeDataGridView.Name = "ModeDataGridView";
            this.ModeDataGridView.Size = new System.Drawing.Size(764, 333);
            this.ModeDataGridView.TabIndex = 0;
            // 
            // UnregisterButton
            // 
            this.UnregisterButton.Location = new System.Drawing.Point(152, 3);
            this.UnregisterButton.Name = "UnregisterButton";
            this.UnregisterButton.Size = new System.Drawing.Size(75, 23);
            this.UnregisterButton.TabIndex = 8;
            this.UnregisterButton.Text = "Sing out";
            this.UnregisterButton.UseVisualStyleBackColor = true;
            this.UnregisterButton.Visible = false;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(3, 9);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(75, 13);
            this.labelEmail.TabIndex = 9;
            this.labelEmail.Text = "Email address ";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(3, 30);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 10;
            this.labelPassword.Text = "Password";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.UnregisterButton);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.UpdateDbButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.loginButton);
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.modeAndStepsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsDataGridView)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.BindingSource stepBindingSource;
        private System.Windows.Forms.BindingSource modeAndStepsBindingSource;
        private System.Windows.Forms.BindingSource modeBindingSource;
        private System.Windows.Forms.BindingSource stepBindingSource1;
        private System.Windows.Forms.DataGridView StepsDataGridView;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Button UpdateDbButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView ModeDataGridView;
        private System.Windows.Forms.Button UnregisterButton;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPassword;
    }
}

