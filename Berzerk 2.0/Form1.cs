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
using System.Threading;
namespace Berzerk_2._0
{
    public partial class Form1 : Form
    {
        int xHero = 100;
        int yHero = 200;
        int speedHero = 4;
        int widthHero = 10;
        int heightHero = 20;
        int robotAI = 0;
        int map = 0;
        int robotNumber = 0;
        int xRobot = 0;
        int yRobot = 0;
        int heroPreset = 0;
        int xHeroPreset = 0;
        int yHeroPreset = 0;

        Random randGen = new Random();

        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        Rectangle heroRec, doorleftRec, doorrightRec, doorupRec, doordownRec, wallLeft1, wallLeft2, wallTop1, wallTop2, wallRight1, wallRight2, wallDown1, wallDown2;

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

            doorleftRec = new Rectangle(0, 192, 10, 60);
            doorrightRec = new Rectangle(580, 190, 10, 70);
            doorupRec = new Rectangle(265, 0, 70, 10);
            doordownRec = new Rectangle(265, 400, 70, 10);

            wallLeft1 = new Rectangle(0, 0, 10, 150);
            wallLeft2 = new Rectangle(264, 0, 8, 264);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            int xtemp = xHero;
            int ytemp = yHero;

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
            heroRec = new Rectangle(xHero, yHero, widthHero, heightHero);

            if (heroRec.IntersectsWith(doorleftRec) && robotNumber == 0)
            {
                int map = randGen.Next(1, 6);
                int heroPreset = randGen.Next(1, 5);
            
                if (map == 1)
                {
                    this.BackgroundImage = Properties.Resources.Map_1;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 2)
                {
                    this.BackgroundImage = Properties.Resources.Map_2;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 3)
                {
                    this.BackgroundImage = Properties.Resources.Map_3;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 4)
                {
                    this.BackgroundImage = Properties.Resources.Map_4;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 5)
                {
                    this.BackgroundImage = Properties.Resources.Map_5;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                Thread.Sleep(1500);
            }
            else if (heroRec.IntersectsWith(doorrightRec) && robotNumber == 0)
            {
                map = randGen.Next(1, 6);
                heroPreset = randGen.Next(1, 5);

                if (map == 1)
                {
                    this.BackgroundImage = Properties.Resources.Map_1;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 2)
                {
                    this.BackgroundImage = Properties.Resources.Map_2;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 3)
                {
                    this.BackgroundImage = Properties.Resources.Map_3;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 4)
                {
                    this.BackgroundImage = Properties.Resources.Map_4;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 5)
                {
                    this.BackgroundImage = Properties.Resources.Map_5;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                Thread.Sleep(1500);
            }
            else if (heroRec.IntersectsWith(doorupRec) && robotNumber == 0)
            {
                int map = randGen.Next(1, 6);
                int heroPreset = randGen.Next(1, 5);

                if (map == 1)
                {
                    this.BackgroundImage = Properties.Resources.Map_1;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 2)
                {
                    this.BackgroundImage = Properties.Resources.Map_2;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 3)
                {
                    this.BackgroundImage = Properties.Resources.Map_3;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 4)
                {
                    this.BackgroundImage = Properties.Resources.Map_4;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 5)
                {
                    this.BackgroundImage = Properties.Resources.Map_5;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                Thread.Sleep(1500);
            }
            else if (heroRec.IntersectsWith(doordownRec) && robotNumber == 0)
            {
                int map = randGen.Next(1, 6);
                int heroPreset = randGen.Next(1, 5);

                if (map == 1)
                {
                    this.BackgroundImage = Properties.Resources.Map_1;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 2)
                {
                    this.BackgroundImage = Properties.Resources.Map_2;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 3)
                {
                    this.BackgroundImage = Properties.Resources.Map_3;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 4)
                {
                    this.BackgroundImage = Properties.Resources.Map_4;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                else if (map == 5)
                {
                    this.BackgroundImage = Properties.Resources.Map_5;
                    #region Player Presets  
                    //Map 1, Map 2, Map 3, and Map 5 Player Spawns
                    if (heroPreset == 1)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 2)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 46;
                    }
                    else if (heroPreset == 3)
                    {
                        xHeroPreset = 46;
                        yHeroPreset = 303;
                    }
                    else if (heroPreset == 4)
                    {
                        xHeroPreset = 504;
                        yHeroPreset = 303;
                    }
                    #endregion
                    xHero = xHeroPreset;
                    yHero = yHeroPreset;
                }
                Thread.Sleep(1500);
            }
            #endregion
            #region Wall Collision
            if (heroRec.IntersectsWith(wallLeft1))
            {
                xHero++;

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

        }
    }
}
