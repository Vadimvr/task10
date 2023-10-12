namespace View
{
    partial class ModeEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ModeIdLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ModeNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxBottleNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MaxUsedTipsTextBox = new System.Windows.Forms.TextBox();
            this.SaveModeButton = new System.Windows.Forms.Button();
            this.ExitModeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // ModeIdLabel
            // 
            this.ModeIdLabel.AutoSize = true;
            this.ModeIdLabel.Location = new System.Drawing.Point(139, 23);
            this.ModeIdLabel.Name = "ModeIdLabel";
            this.ModeIdLabel.Size = new System.Drawing.Size(43, 13);
            this.ModeIdLabel.TabIndex = 1;
            this.ModeIdLabel.Text = "ModeId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // ModeNameTextBox
            // 
            this.ModeNameTextBox.Location = new System.Drawing.Point(142, 52);
            this.ModeNameTextBox.Name = "ModeNameTextBox";
            this.ModeNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.ModeNameTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max Bottle Number";
            // 
            // MaxBottleNumberTextBox
            // 
            this.MaxBottleNumberTextBox.Location = new System.Drawing.Point(142, 85);
            this.MaxBottleNumberTextBox.Name = "MaxBottleNumberTextBox";
            this.MaxBottleNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxBottleNumberTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Used Tips";
            // 
            // MaxUsedTipsTextBox
            // 
            this.MaxUsedTipsTextBox.Location = new System.Drawing.Point(142, 114);
            this.MaxUsedTipsTextBox.Name = "MaxUsedTipsTextBox";
            this.MaxUsedTipsTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxUsedTipsTextBox.TabIndex = 7;
            // 
            // SaveModeButton
            // 
            this.SaveModeButton.Location = new System.Drawing.Point(26, 168);
            this.SaveModeButton.Name = "SaveModeButton";
            this.SaveModeButton.Size = new System.Drawing.Size(75, 23);
            this.SaveModeButton.TabIndex = 8;
            this.SaveModeButton.Text = "Save";
            this.SaveModeButton.UseVisualStyleBackColor = true;
            // 
            // ExitModeButton
            // 
            this.ExitModeButton.Location = new System.Drawing.Point(142, 168);
            this.ExitModeButton.Name = "ExitModeButton";
            this.ExitModeButton.Size = new System.Drawing.Size(75, 23);
            this.ExitModeButton.TabIndex = 9;
            this.ExitModeButton.Text = "Exit";
            this.ExitModeButton.UseVisualStyleBackColor = true;
            // 
            // ModeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 236);
            this.Controls.Add(this.ExitModeButton);
            this.Controls.Add(this.SaveModeButton);
            this.Controls.Add(this.MaxUsedTipsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaxBottleNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ModeNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ModeIdLabel);
            this.Controls.Add(this.label1);
            this.Name = "ModeEditor";
            this.Text = "ModeEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ModeIdLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ModeNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MaxBottleNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MaxUsedTipsTextBox;
        private System.Windows.Forms.Button SaveModeButton;
        private System.Windows.Forms.Button ExitModeButton;
    }
}