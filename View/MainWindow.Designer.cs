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
            ((System.ComponentModel.ISupportInitialize)(this.modeAndStepsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 150);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(93, 150);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(75, 23);
            this.RegisterButton.TabIndex = 1;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(12, 52);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(156, 20);
            this.emailTextBox.TabIndex = 2;
            this.emailTextBox.Tag = "";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 78);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(156, 20);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // modeAndStepsBindingSource
            // 
            this.modeAndStepsBindingSource.DataSource = typeof(Models.ModeAndSteps);
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
            this.StepsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StepsDataGridView.Location = new System.Drawing.Point(174, 12);
            this.StepsDataGridView.Name = "StepsDataGridView";
            this.StepsDataGridView.Size = new System.Drawing.Size(614, 400);
            this.StepsDataGridView.TabIndex = 4;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(12, 415);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 23);
            this.OpenFileButton.TabIndex = 5;
            this.OpenFileButton.Text = "Open file";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            // 
            // UpdateDbButton
            // 
            this.UpdateDbButton.Location = new System.Drawing.Point(93, 415);
            this.UpdateDbButton.Name = "UpdateDbButton";
            this.UpdateDbButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateDbButton.TabIndex = 6;
            this.UpdateDbButton.Text = "Update DB";
            this.UpdateDbButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UpdateDbButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.StepsDataGridView);
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
    }
}

