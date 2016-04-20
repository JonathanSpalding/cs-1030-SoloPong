using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoloPong
{
    public partial class frmMain : Form
    {
        int x = 1, y = 1, deltaX = 3, deltaY = 3;
        Bitmap ball;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Crate ball bitmap image
            ball = new Bitmap(picBall.Width, picBall.Height); // create blank bitmap
            Graphics gr = Graphics.FromImage(ball); // Drawing tool for ball
            SolidBrush br = new SolidBrush(Color.Red); // create new Red brush
            gr.FillEllipse(br, 1, 1, ball.Width - 1, ball.Height - 1); // Draw Ball
            
            picBall.Image = ball; // Assign ball to picBall.Image
            Timer.Enabled = true; //enable timer
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            this.pnlPaddle.Location = new System.Drawing.Point
                (pnlPaddle.Location.X, e.Y - pnlPaddle.Height / 2);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // compares below will be made against the middle of the ball
            int middle = picBall.Location.Y + picBall.Height / 2;
            //Check to see if picBall is moving left and hit paddle
            if (deltaX < 0 &&
            middle > pnlPaddle.Location.Y
            && middle < pnlPaddle.Location.Y + pnlPaddle.Height
            && picBall.Location.X <= pnlPaddle.Location.X)
            {
                // Place code here to process paddle hits
                // paddle was hit
                deltaX = -1 * deltaX; // change X direction to moving right
                int score = int.Parse(lblPoints.Text) + 1;
                lblPoints.Text = score.ToString(); // increment score
            }
            else
            {
                // Place code here to deal with
                // hitting game area sides
                // Check to see if ball missed paddle and hit left side
                if (picBall.Location.X <= 0)
                {
                    deltaX = -1 * deltaX; // Change X direction and
                    int score = int.Parse(lblPoints.Text) - 1; // decrement score
                    lblPoints.Text = score.ToString();
                }
                // Check to see if ball hit right side
                if (picBall.Location.X >= (this.ClientSize.Width - picBall.Width))
                {
                    deltaX = -1 * deltaX; // change X direction
                }
                // Check to see if picBall hit the top or bottom
                if (picBall.Location.Y <= 0 ||
                picBall.Location.Y >= (this.ClientSize.Height - picBall.Height))
                {
                    deltaY = -1 * deltaY; // Change Y direction
                }
            }
            // Place code here to actually move the ball.
            // Update picBall location
            x = picBall.Location.X + deltaX;
            y = picBall.Location.Y + deltaY;
            this.picBall.Location = new System.Drawing.Point(x, y);
            lblTime.Text = (float.Parse(lblTime.Text) + 0.01f).ToString("#0.00");

        }



    }
}