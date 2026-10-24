namespace BetterEtch_O_Sketch_Fall26
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ExitButton = new Button();
            BottomStatusStrip = new StatusStrip();
            TopMenuStrip = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            SelectColorToolStripMenuItem = new ToolStripMenuItem();
            DrawWaveformsToolStripMenuItem = new ToolStripMenuItem();
            ClearToolStripMenuItem = new ToolStripMenuItem();
            HelpToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            MainToolTip = new ToolTip(components);
            DrawSineWavesButton = new Button();
            ClearButton = new Button();
            ButtonGroupBox = new GroupBox();
            SelectColorButton = new Button();
            MouseRadioButton = new RadioButton();
            ExternalRadioButton = new RadioButton();
            RadioGroupBox = new GroupBox();
            DisplayPictureBox = new PictureBox();
            PortsComboBox = new ComboBox();
            DisplayContextMenuStrip = new ContextMenuStrip(components);
            ClearMenuItem = new ToolStripMenuItem();
            ColorMenuItem = new ToolStripMenuItem();
            PenColorMenuItem = new ToolStripMenuItem();
            BackGroundColorMenuItem = new ToolStripMenuItem();
            PenMenuItem = new ToolStripMenuItem();
            ToolComboBox = new ToolStripComboBox();
            TopMenuStrip.SuspendLayout();
            ButtonGroupBox.SuspendLayout();
            RadioGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DisplayPictureBox).BeginInit();
            DisplayContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(435, 30);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(137, 60);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "E&xit";
            MainToolTip.SetToolTip(ExitButton, "Exit the form");
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // BottomStatusStrip
            // 
            BottomStatusStrip.ImageScalingSize = new Size(24, 24);
            BottomStatusStrip.Location = new Point(0, 428);
            BottomStatusStrip.Name = "BottomStatusStrip";
            BottomStatusStrip.Size = new Size(800, 22);
            BottomStatusStrip.TabIndex = 1;
            BottomStatusStrip.Text = "statusStrip1";
            // 
            // TopMenuStrip
            // 
            TopMenuStrip.ImageScalingSize = new Size(24, 24);
            TopMenuStrip.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, EditToolStripMenuItem, HelpToolStripMenuItem });
            TopMenuStrip.Location = new Point(0, 0);
            TopMenuStrip.Name = "TopMenuStrip";
            TopMenuStrip.Size = new Size(800, 33);
            TopMenuStrip.TabIndex = 2;
            TopMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExitToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(54, 29);
            FileToolStripMenuItem.Text = "File";
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(141, 34);
            ExitToolStripMenuItem.Text = "Exit";
            ExitToolStripMenuItem.ToolTipText = "Exit the form";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SelectColorToolStripMenuItem, DrawWaveformsToolStripMenuItem, ClearToolStripMenuItem });
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(58, 29);
            EditToolStripMenuItem.Text = "Edit";
            EditToolStripMenuItem.ToolTipText = "More editing tools";
            // 
            // SelectColorToolStripMenuItem
            // 
            SelectColorToolStripMenuItem.Name = "SelectColorToolStripMenuItem";
            SelectColorToolStripMenuItem.Size = new Size(250, 34);
            SelectColorToolStripMenuItem.Text = "Select Color";
            SelectColorToolStripMenuItem.ToolTipText = "Select a color";
            SelectColorToolStripMenuItem.Click += SelectColorToolStripMenuItem_Click;
            // 
            // DrawWaveformsToolStripMenuItem
            // 
            DrawWaveformsToolStripMenuItem.Name = "DrawWaveformsToolStripMenuItem";
            DrawWaveformsToolStripMenuItem.Size = new Size(250, 34);
            DrawWaveformsToolStripMenuItem.Text = "Draw Waveforms";
            DrawWaveformsToolStripMenuItem.ToolTipText = "Draw a Sinewave";
            DrawWaveformsToolStripMenuItem.Click += DrawWaveformsToolStripMenuItem_Click;
            // 
            // ClearToolStripMenuItem
            // 
            ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            ClearToolStripMenuItem.Size = new Size(250, 34);
            ClearToolStripMenuItem.Text = "Clear";
            ClearToolStripMenuItem.ToolTipText = "Clear the Picture";
            ClearToolStripMenuItem.Click += ClearToolStripMenuItem_Click;
            // 
            // HelpToolStripMenuItem
            // 
            HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutToolStripMenuItem });
            HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            HelpToolStripMenuItem.Size = new Size(65, 29);
            HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(164, 34);
            AboutToolStripMenuItem.Text = "About";
            AboutToolStripMenuItem.ToolTipText = "See the About section";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // DrawSineWavesButton
            // 
            DrawSineWavesButton.Location = new Point(292, 30);
            DrawSineWavesButton.Name = "DrawSineWavesButton";
            DrawSineWavesButton.Size = new Size(137, 60);
            DrawSineWavesButton.TabIndex = 3;
            DrawSineWavesButton.Text = "&Draw Sinewave";
            MainToolTip.SetToolTip(DrawSineWavesButton, "Draw a Sinewave");
            DrawSineWavesButton.UseVisualStyleBackColor = true;
            DrawSineWavesButton.Click += DrawSineWavesButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(149, 30);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(137, 60);
            ClearButton.TabIndex = 4;
            ClearButton.Text = "&Clear";
            MainToolTip.SetToolTip(ClearButton, "Clear the picture");
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // ButtonGroupBox
            // 
            ButtonGroupBox.Controls.Add(SelectColorButton);
            ButtonGroupBox.Controls.Add(ExitButton);
            ButtonGroupBox.Controls.Add(ClearButton);
            ButtonGroupBox.Controls.Add(DrawSineWavesButton);
            ButtonGroupBox.Location = new Point(211, 309);
            ButtonGroupBox.Name = "ButtonGroupBox";
            ButtonGroupBox.Size = new Size(577, 103);
            ButtonGroupBox.TabIndex = 5;
            ButtonGroupBox.TabStop = false;
            ButtonGroupBox.Text = "Main Controls";
            MainToolTip.SetToolTip(ButtonGroupBox, "Main controls for drawing");
            // 
            // SelectColorButton
            // 
            SelectColorButton.Location = new Point(6, 30);
            SelectColorButton.Name = "SelectColorButton";
            SelectColorButton.Size = new Size(137, 60);
            SelectColorButton.TabIndex = 5;
            SelectColorButton.Text = "&Select Color";
            MainToolTip.SetToolTip(SelectColorButton, "Select the color of the pen");
            SelectColorButton.UseVisualStyleBackColor = true;
            SelectColorButton.Click += SelectColorButton_Click;
            // 
            // MouseRadioButton
            // 
            MouseRadioButton.AutoSize = true;
            MouseRadioButton.Location = new Point(6, 29);
            MouseRadioButton.Name = "MouseRadioButton";
            MouseRadioButton.Size = new Size(134, 31);
            MouseRadioButton.TabIndex = 6;
            MouseRadioButton.TabStop = true;
            MouseRadioButton.Text = "Mouse Draw";
            MainToolTip.SetToolTip(MouseRadioButton, "Draw with the Mouse");
            MouseRadioButton.UseCompatibleTextRendering = true;
            MouseRadioButton.UseVisualStyleBackColor = true;
            MouseRadioButton.CheckedChanged += MouseRadioButton_CheckedChanged;
            // 
            // ExternalRadioButton
            // 
            ExternalRadioButton.AutoSize = true;
            ExternalRadioButton.Location = new Point(6, 64);
            ExternalRadioButton.Name = "ExternalRadioButton";
            ExternalRadioButton.Size = new Size(144, 29);
            ExternalRadioButton.TabIndex = 7;
            ExternalRadioButton.TabStop = true;
            ExternalRadioButton.Text = "External Darw";
            MainToolTip.SetToolTip(ExternalRadioButton, "Draw with an External Device");
            ExternalRadioButton.UseVisualStyleBackColor = true;
            ExternalRadioButton.CheckedChanged += ExternalRadioButton_CheckedChanged;
            // 
            // RadioGroupBox
            // 
            RadioGroupBox.Controls.Add(MouseRadioButton);
            RadioGroupBox.Controls.Add(ExternalRadioButton);
            RadioGroupBox.Location = new Point(12, 312);
            RadioGroupBox.Name = "RadioGroupBox";
            RadioGroupBox.Size = new Size(148, 100);
            RadioGroupBox.TabIndex = 8;
            RadioGroupBox.TabStop = false;
            RadioGroupBox.Text = "Draw Controls";
            MainToolTip.SetToolTip(RadioGroupBox, "Select draw controls");
            // 
            // DisplayPictureBox
            // 
            DisplayPictureBox.Location = new Point(12, 36);
            DisplayPictureBox.Name = "DisplayPictureBox";
            DisplayPictureBox.Size = new Size(776, 233);
            DisplayPictureBox.TabIndex = 9;
            DisplayPictureBox.TabStop = false;
            MainToolTip.SetToolTip(DisplayPictureBox, "Draw here");
            DisplayPictureBox.Click += DisplayPictureBox_Click;
            // 
            // PortsComboBox
            // 
            PortsComboBox.FormattingEnabled = true;
            PortsComboBox.Location = new Point(12, 275);
            PortsComboBox.Name = "PortsComboBox";
            PortsComboBox.Size = new Size(776, 33);
            PortsComboBox.TabIndex = 10;
            MainToolTip.SetToolTip(PortsComboBox, "Com Ports available for conection");
            // 
            // DisplayContextMenuStrip
            // 
            DisplayContextMenuStrip.ImageScalingSize = new Size(24, 24);
            DisplayContextMenuStrip.Items.AddRange(new ToolStripItem[] { ClearMenuItem, ColorMenuItem, PenMenuItem });
            DisplayContextMenuStrip.Name = "DisplayContextMenuStrip";
            DisplayContextMenuStrip.Size = new Size(149, 100);
            MainToolTip.SetToolTip(DisplayContextMenuStrip, "More control of the display");
            // 
            // ClearMenuItem
            // 
            ClearMenuItem.Name = "ClearMenuItem";
            ClearMenuItem.Size = new Size(240, 32);
            ClearMenuItem.Text = "Clear";
            ClearMenuItem.Click += ClearMenuItem_Click;
            // 
            // ColorMenuItem
            // 
            ColorMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PenColorMenuItem, BackGroundColorMenuItem });
            ColorMenuItem.Name = "ColorMenuItem";
            ColorMenuItem.Size = new Size(240, 32);
            ColorMenuItem.Text = "Color";
            // 
            // PenColorMenuItem
            // 
            PenColorMenuItem.Name = "PenColorMenuItem";
            PenColorMenuItem.Size = new Size(270, 34);
            PenColorMenuItem.Text = "Pen Color";
            PenColorMenuItem.Click += PenColorMenuItem_Click;
            // 
            // BackGroundColorMenuItem
            // 
            BackGroundColorMenuItem.Name = "BackGroundColorMenuItem";
            BackGroundColorMenuItem.Size = new Size(270, 34);
            BackGroundColorMenuItem.Text = "Back Ground Color";
            BackGroundColorMenuItem.Click += BackGroundColorMenuItem_Click;
            // 
            // PenMenuItem
            // 
            PenMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolComboBox });
            PenMenuItem.Name = "PenMenuItem";
            PenMenuItem.Size = new Size(240, 32);
            PenMenuItem.Text = "Pen Size";
            // 
            // ToolComboBox
            // 
            ToolComboBox.Name = "ToolComboBox";
            ToolComboBox.Size = new Size(121, 33);
            ToolComboBox.Click += ToolComboBox_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PortsComboBox);
            Controls.Add(DisplayPictureBox);
            Controls.Add(RadioGroupBox);
            Controls.Add(ButtonGroupBox);
            Controls.Add(BottomStatusStrip);
            Controls.Add(TopMenuStrip);
            MainMenuStrip = TopMenuStrip;
            Name = "Form1";
            Text = "Better Etch-O-sketch";
            TopMenuStrip.ResumeLayout(false);
            TopMenuStrip.PerformLayout();
            ButtonGroupBox.ResumeLayout(false);
            RadioGroupBox.ResumeLayout(false);
            RadioGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DisplayPictureBox).EndInit();
            DisplayContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ExitButton;
        private StatusStrip BottomStatusStrip;
        private MenuStrip TopMenuStrip;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem SelectColorToolStripMenuItem;
        private ToolStripMenuItem DrawWaveformsToolStripMenuItem;
        private ToolStripMenuItem HelpToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem ClearToolStripMenuItem;
        private ToolTip MainToolTip;
        private Button DrawSineWavesButton;
        private Button ClearButton;
        private GroupBox ButtonGroupBox;
        private RadioButton MouseRadioButton;
        private RadioButton ExternalRadioButton;
        private GroupBox RadioGroupBox;
        private Button SelectColorButton;
        private PictureBox DisplayPictureBox;
        private ComboBox PortsComboBox;
        private ContextMenuStrip DisplayContextMenuStrip;
        private ToolStripMenuItem ClearMenuItem;
        private ToolStripMenuItem ColorMenuItem;
        private ToolStripMenuItem PenColorMenuItem;
        private ToolStripMenuItem BackGroundColorMenuItem;
        private ToolStripMenuItem PenMenuItem;
        private ToolStripComboBox ToolComboBox;
    }
}
