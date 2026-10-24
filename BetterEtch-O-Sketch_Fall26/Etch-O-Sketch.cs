using System.IO.Ports;
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
                this.penWidth = Convert.ToInt32(ToolComboBox.SelectedItem);
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
            // the y-axis so that positive values go up instead of down
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

        private SerialPort picPort = new SerialPort();
        private System.Windows.Forms.Timer PicTimer = new System.Windows.Forms.Timer();
        private bool waiting = false;          // true after we asked the PIC for a reading
        private DateTime replyDeadline;        // give up if no answer by this time
        private int nextChannel = 0;           // 0 = X pot, 1 = Y pot (check your wiring!)
        private int potX, potY;                // latest pot positions in pixels
        private bool havePicPoint = false;     // false until the first full X,Y reading

        void LoadPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            PortsComboBox.Items.Clear();
            foreach (string name in ports)
            {
                PortsComboBox.Items.Add(name);
            }
            if (PortsComboBox.Items.Count > 0)
            {
                PortsComboBox.SelectedIndex = 0;
            }
        }

        // Opens the selected COM port and starts asking for readings.
        void ConnectToPic()
        {
            if (PortsComboBox.Text == "")
            {
                PicError("No COM port selected. Plug in the PIC and pick a port.");
                return;
            }
            try
            {
                picPort.PortName = PortsComboBox.Text;
                picPort.BaudRate = 9600;
                picPort.DataBits = 8;
                picPort.Parity = Parity.None;
                picPort.StopBits = StopBits.One;
                picPort.WriteTimeout = 250;
                picPort.Open();
                picPort.DiscardInBuffer();

                waiting = false;
                havePicPoint = false;
                nextChannel = 0;
                PicTimer.Start();
                DrawingStatusLabel.Text = "External mode: " + picPort.PortName;
            }
            catch (Exception ex)
            {
                PicError("Could not open " + PortsComboBox.Text + ": " + ex.Message);
            }
        }

        // Stops asking for readings and closes the port.
        void DisconnectPic()
        {
            PicTimer.Stop();
            waiting = false;
            try
            {
                if (picPort.IsOpen)
                {
                    picPort.Close();
                }
            }
            catch
            {
                // the USB adapter may already be unplugged
            }
        }

        // Something went wrong: close the port, go back to mouse mode, tell the user.
        void PicError(string message)
        {
            DisconnectPic();
            MouseRadioButton.Checked = true;
            DrawingStatusLabel.Text = "COM ERR";
            MessageBox.Show(message, "PIC connection problem");
        }

        // The reply is 6 bytes: 24 41 03 channel HH LL
        void ReadAdcReply()
        {
            byte[] reply = new byte[6];
            picPort.Read(reply, 0, 6);
            waiting = false;

            if (reply[0] != 0x24 || reply[1] != 0x41)
            {
                picPort.DiscardInBuffer(); // out of sync, throw it away and ask again
                return;
            }

            int channel = reply[3];
            int adc = ((reply[4] & 0x03) << 8) | reply[5]; // 10-bit value, 0 to 1023

            if (channel == 0)
            {
                // scale 0-1023 to a pixel position
                potX = adc * DisplayPictureBox.Width / 1024;
                nextChannel = 1;
            }
            else
            {
                potY = adc * DisplayPictureBox.Height / 1024;
                nextChannel = 0;
                DrawFromPots(); // we now have a fresh X and Y
            }
        }

        // Draws from the last pot position to the new one.
        void DrawFromPots()
        {
            if (havePicPoint)
            {
                DrawLineSegment(potX, potY); // uses oldX and oldY as the start
            }
            oldX = potX;
            oldY = potY;
            havePicPoint = true; // the first reading only sets the starting point
        }

        // Event Handler Below here********************************************
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm(); //instantitate the about form
            aboutForm.FormClosed += AboutForm_FormClosed; //map the FormClosed event to a handler
            aboutForm.Show(); // show the about form
            this.Hide();// hide the main form while the about form is open
        }

        private void AboutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); // show the main form again when the about form is closed
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

        private void DisplayPictureBox_MouseStuff(object? sender, MouseEventArgs e)
        {
            DrawingStatusLabel.Text = $"({e.X},{e.Y}) | {e.Button} " +
                $"| {this.penColor} | {this.penWidth}";

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (MouseRadioButton.Checked) // only draw in mouse mode
                    {
                        DrawLineSegment(e.X, e.Y);
                    }
                    break;
                default:
                    break;
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

        private void ExternalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ExternalRadioButton.Checked)
            {
                ConnectToPic();
            }
            else
            {
                DisconnectPic();
            }
        }

        private void PortsComboBox_DropDown(object? sender, EventArgs e)
        {
            LoadPorts(); // refresh the list each time it opens
        }

        // Runs every 20 ms while in external mode.
        private void PicTimer_Tick(object? sender, EventArgs e)
        {
            try
            {
                // was the adapter unplugged?
                if (Array.IndexOf(SerialPort.GetPortNames(), picPort.PortName) < 0)
                {
                    throw new IOException("The COM port was unplugged.");
                }

                if (waiting)
                {
                    if (picPort.BytesToRead >= 6)
                    {
                        ReadAdcReply();
                    }
                    else if (DateTime.Now > replyDeadline)
                    {
                        throw new TimeoutException("The PIC did not answer. Is this the right COM port?");
                    }
                }
                else
                {
                    // ask for one pot: 24 41 01 channel
                    byte[] request = { 0x24, 0x41, 0x01, (byte)nextChannel };
                    picPort.Write(request, 0, request.Length);
                    waiting = true;
                    replyDeadline = DateTime.Now.AddMilliseconds(500);
                }
            }
            catch (Exception ex)
            {
                PicError(ex.Message);
            }
        }

        private void ToolComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdatePenWidth();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DisconnectPic(); // always release the COM port
            base.OnFormClosed(e);
        }
    }
}
