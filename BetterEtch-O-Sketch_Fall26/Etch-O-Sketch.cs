namespace BetterEtch_O_Sketch_Fall26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisplayPictureBox.MouseMove += DisplayPictureBox_MouseStuff;
            DisplayPictureBox.MouseDown += DisplayPictureBox_MouseDown;
            DisplayPictureBox.ContextMenuStrip = DisplayContextMenuStrip;
            AcceptButton = DrawSineWavesButton; // Enter draws the waveforms
            CancelButton = ClearButton;         // Esc clears

            ToolComboBox.Items.Add(2);
            ToolComboBox.Items.Add(3);
            ToolComboBox.Items.Add(4);
            ToolComboBox.Items.Add(5);
            ToolComboBox.Items.Add(6);
            ToolComboBox.Items.Add(7);
            ToolComboBox.SelectedIndex = 1;
            ToolComboBox.SelectedIndexChanged += ToolComboBox_SelectedIndexChanged;

            BottomStatusStrip.Items.Add(DrawingStatusLabel); // status text at the bottom of the form
            PortsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PortsComboBox.DropDown += PortsComboBox_DropDown;
            LoadPorts();

            PicTimer.Interval = 20; // ask the PIC for a reading every 20 ms
            PicTimer.Tick += PicTimer_Tick;

            MouseRadioButton.Checked = true; // start in mouse mode
        }
        int oldX, oldY;

        private Color penColor = Color.Black;
        private Color BackGround = Color.White;
        private int penWidth = 3;
        private ColorDialog PenColorDialog = new ColorDialog();
        private ToolStripStatusLabel DrawingStatusLabel = new ToolStripStatusLabel();

        void DrawLineSegment(int newX, int newY)
        {
            //create a Graphics object named g that draws on the picture box
            Graphics g = DisplayPictureBox.CreateGraphics();
            // create a pen to draw with
            Pen thePen = new Pen(this.penColor);
            thePen.Width = this.penWidth;
            //draw the line here
            g.DrawLine(thePen, oldX, oldY, newX, newY);

            //free up resources
            g.Dispose();
            thePen.Dispose();
        }

        void ClearDrawing()
        {
            // create a graphics object named g that draws on the PictureBox
            Graphics g = DisplayPictureBox.CreateGraphics();

            // Shake the form
            var original = this.Location; // save the original position of the form
            var random = new Random(); // create a random number generator
            int shake_amplitude = 75; // how far the form should shake in pixels
            // play sound effect (only if the file is found, so it can't crash)
            string soundPath = "..\\..\\..\\Resources_shaker.wav";
            if (File.Exists(soundPath))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundPath);
                player.Play();
            }

            for (int i = 0; i < 15; i++) // shake the form 15 times
            {
                // Randomly offset the form's position
                this.Location = new Point(
                    original.X + random.Next(-shake_amplitude, shake_amplitude), // shake horizontally
                    original.Y + random.Next(-shake_amplitude, shake_amplitude));// shake vertically
                System.Threading.Thread.Sleep(60); // Small pause for visibility
            }
            // clear the drawing by filling the picture box with the background color
            g.Clear(this.BackGround);
            // Reset to original position
            this.Location = original;

            // free up resources
            g.Dispose();
        }

        void UpdatePenColor()
        {
            // only change the color if the user pressed OK
            if (PenColorDialog.ShowDialog() == DialogResult.OK)
            {
                this.penColor = PenColorDialog.Color;
            }
        }

        void UpdateBackGroundColor()
        {
            if (PenColorDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackGround = PenColorDialog.Color;
                DisplayPictureBox.BackColor = this.BackGround;
            }
        }

        void UpdatePenWidth()
        {
            if (ToolComboBox.SelectedItem != null)
            {
                this.penWidth = int.Parse(ToolComboBox.SelectedItem.ToString());
            }
        }
        void DrawSineWave()
        {
            DrawGrid();
            // create a graphics object named g that draws on the PictureBox
            Graphics g = DisplayPictureBox.CreateGraphics();
            // create a pen to draw with
            Pen thePen = new Pen(Color.Lime);
            // set the width of the pen
            thePen.Width = 3;
            int lastX = 0, lastY = 0, currentY = 0;
            // draw the line here 
            float scaleX = DisplayPictureBox.Width / 360f;
            float scaleY = (DisplayPictureBox.Height / 200f) * -1;
            // scale the x-axis so that one period of the sine wave fits in the width of the picture box
            g.TranslateTransform(0, DisplayPictureBox.Height / 2);
            // move the origin (start) of the drawing area to the center of the picture box
            g.ScaleTransform(scaleX, scaleY);
            // scale the drawing area so that the sine wave is wider and flip
            // the y-axis so that positive values go upinstead of down
            for (int currentX = 0; currentX < 360; currentX++)
            {
                currentY = (int)(Math.Round(100 * Math.Sin((Math.PI / 180) * currentX)));
                g.DrawLine(thePen, lastX, lastY, currentX, currentY);
                lastX = currentX;
                lastY = currentY;
            }
            g.Dispose();
            thePen.Dispose();
        }
        void DrawGrid()
        {
            // create a graphics object named g that draws on the PictureBox
            Graphics g = DisplayPictureBox.CreateGraphics();
            // create a pen to draw with
            Pen thePen = new Pen(Color.LightGray);
            // set the width of the pen
            thePen.Width = 1;
            // draw the line here 
            for (int x = 0; x < DisplayPictureBox.Width; x += 100)
            {
                g.DrawLine(thePen, x, 0, x, DisplayPictureBox.Height);
            }
            for (int y = 0; y < DisplayPictureBox.Height; y += 100)
            {
                g.DrawLine(thePen, 0, y, DisplayPictureBox.Width, y);
            }
            g.Dispose();
            thePen.Dispose();
        }


        // Event Handler Below here********************************************
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SelectColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePenColor();
        }

        private void DrawWaveformsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawSineWave();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDrawing();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DrawSineWavesButton_Click(object sender, EventArgs e)
        {
            DrawSineWave();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearDrawing();
        }

        private void SelectColorButton_Click(object sender, EventArgs e)
        {
            UpdatePenColor();
        }

        private void MouseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MouseRadioButton.Checked)
            {
                DrawingStatusLabel.Text = "Mouse Mode";
            }
        }

        private void DisplayPictureBox_MouseStuff(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && MouseRadioButton.Checked)
            {
                DrawLineSegment(e.X, e.Y);
            }
            // save the current mouse position for the next time we draw a line segment
            this.oldX = e.X;
            this.oldY = e.Y;
        }

        private void DisplayPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.oldX = e.X;   // start the next line where the button went down
            this.oldY = e.Y;

            if (e.Button == MouseButtons.Middle)
            {
                UpdatePenColor();
            }
        }

        private void ClearMenuItem_Click(object sender, EventArgs e)
        {
            ClearDrawing();
        }

        private void PenColorMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePenColor();
        }

        private void BackGroundColorMenuItem_Click(object sender, EventArgs e)
        {
            UpdateBackGroundColor();
        }
    }
}
