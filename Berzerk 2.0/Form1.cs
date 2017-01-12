using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Berzerk_2._0
{
    public partial class Form1 : Form
    {
        int xHero = 100;
        int yHero = 200;
        int speedHero = 2;
        int widthHero = 10;
        int heightHero = 20;
        int robotAI = 0;
        int map = 0;
        int robotNumber = 0;
        int xRobot = 0;
        int yRobot = 0;
        int chance = 0;

        Random randGen = new Random();

        //images
        // Image = new properties.Resources.
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                default:
                    break;
            }
        }



        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        public Form1()
        {
            InitializeComponent();
            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region move character based on key presses

            if (leftArrowDown == true)
            {
                if (xHero > 0)
                {
                    xHero = xHero - speedHero;
                }
            }

            if (downArrowDown == true)
            {
                yHero = yHero + speedHero;
            }

            if (rightArrowDown == true)
            {
                if (xHero < this.Width - widthHero)
                {
                    xHero = xHero + speedHero;
                }
            }

            if (upArrowDown == true)
            {
                yHero = yHero - speedHero;
            }

            #endregion
            #region Robot AI
            if (robotAI == 1)
            {

            }

            #endregion
            #region Map Select
            if (xHero == 0 & yHero == 50)
            {
                int chance = randGen.Next(1, 6);
            }
             if (xHero == 50 & yHero == 0)
            {
                map = 2;

            }
            #endregion


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.PlayerTest, xHero, yHero, 30, 30);

            #region Character Direction

            if (leftArrowDown == true)
            {
                e.Graphics.DrawImage(Properties.Resources.LeftTest, xHero, yHero, 30, 30);
            }

            if (rightArrowDown == true)
            {
                e.Graphics.DrawImage(Properties.Resources.RightTest, xHero, yHero, 30, 30);
            }

            if (upArrowDown == true)
            {
                e.Graphics.DrawImage(Properties.Resources.UpTest, xHero, yHero, 30, 30);
            }

            if (downArrowDown == true)
            {
                e.Graphics.DrawImage(Properties.Resources.DownTest, xHero, yHero, 30, 30);
            }
            #endregion
            #region Map Draw
            #endregion

        }
    }
}
