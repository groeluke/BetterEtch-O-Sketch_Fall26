namespace BetterEtch_O_Sketch_Fall26
{
    partial class AboutForm
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
            AboutLabel = new Label();
            AboutOkButton = new Button();
            SuspendLayout();
            // 
            // AboutLabel
            // 
            AboutLabel.AutoSize = true;
            AboutLabel.Location = new Point(7, 8);
            AboutLabel.Name = "AboutLabel";
            AboutLabel.Size = new Size(49, 25);
            AboutLabel.TabIndex = 0;
            AboutLabel.Text = "label";
            // 
            // AboutOkButton
            // 
            AboutOkButton.Location = new Point(254, 198);
            AboutOkButton.Name = "AboutOkButton";
            AboutOkButton.Size = new Size(112, 34);
            AboutOkButton.TabIndex = 1;
            AboutOkButton.Text = "&Ok";
            AboutOkButton.UseVisualStyleBackColor = true;
            AboutOkButton.Click += AboutOkButton_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 244);
            Controls.Add(AboutOkButton);
            Controls.Add(AboutLabel);
            Name = "AboutForm";
            Text = "AboutForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AboutLabel;
        private Button AboutOkButton;
    }
}