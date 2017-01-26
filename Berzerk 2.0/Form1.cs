//Created by: Manuel Muncaster
//Date: January 16, 2017
//Purpose: Final Project
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
        //Setting up all variables
        int xHero = 100;
        int yHero = 200;
        int speedHero = 3;
        int widthHero = 10;
        int heightHero = 20;
        int heroLife = 5;
        int heroDirection = 0;
        int heroPreset = 0;
        int xHeroPreset = 0;
        int yHeroPreset = 0;

        int map = 0;
        int score1 = 00000000;

        int robotNumber = 0;
        int xRobot1 = -100000;
        int yRobot1 = -100000;
        int xRobot2 = -100000;
        int yRobot2 = -100000;
        int xRobot3 = -100000;
        int yRobot3 = -100000;

        int xRobot1HitRec = -10000;
        int yRobot1HitRec = -10000;
        int xRobot2HitRec = -10000;
        int yRobot2HitRec = -10000;
        int xRobot3HitRec = -10000;
        int yRobot3HitRec = -10000;
        int robotWidth = 35;
        int robotHeight = 35;

        int xRobot1Rec = -100000;
        int yRobot1Rec = -100000;
        int xRobot2Rec = -100000;
        int yRobot2Rec = -100000;
        int xRobot3Rec = -100000;
        int yRobot3Rec = -100000;

        int robot3Speed = 4;

        int xLaser = 1000;
        int yLaser = -1000;
        int laserSpeed = 5;

        int xLaserRec = 1000;
        int yLaserRec = -1000;
        int laserRecSpeed = 5;
        int laserWidth = 10;
        int laserHeight = 10;
        Random randGen = new Random();

        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown;

        Rectangle heroRec, doorleftRec, doorrightRec, doorupRec, doordownRec, wallLeft, wallTop, wallRight, wallBottom, robot1HitRec, robot2HitRec, robot3HitRec, robot1Rec, robot2Rec, robot3Rec, laserRec;
        #region Character Movement
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
                case Keys.Space:
                    spaceDown = true;
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
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }
        #endregion
        //create graphic objects
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        SolidBrush blueBrush = new SolidBrush(Color.Cyan);
        Font drawFont = new Font("Courier", 16, FontStyle.Bold);

        public Form1()
        {
            InitializeComponent();
            gameTimer.Enabled = true;
            gameTimer.Start();
            //Setting up all hitboxes
            doorleftRec = new Rectangle(0, 192, 10, 40);
            doorrightRec = new Rectangle(560, 190, 10, 40);
            doorupRec = new Rectangle(265, 0, 50, 10);
            doordownRec = new Rectangle(265, 400, 50, 10);

            robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
            robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
            robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

            robot1Rec = new Rectangle(xRobot1Rec, yRobot1Rec, robotWidth, robotHeight);
            robot2Rec = new Rectangle(xRobot2Rec, yRobot2Rec, robotWidth, robotHeight);
            robot3Rec = new Rectangle(xRobot3Rec, yRobot3Rec, robotWidth, robotHeight);

            wallLeft = new Rectangle(0, 0, 10, 600);
            wallTop = new Rectangle(0, 0, 600, 10);
            wallRight = new Rectangle(560, 0, 10, 600);
            wallBottom = new Rectangle( 0, 400, 600, 10);
            //Sound players 
            SoundPlayer player1 = new SoundPlayer(Properties.Resources.laser);
            SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
            SoundPlayer player3 = new SoundPlayer(Properties.Resources.robotdeath);

            laserRec = new Rectangle(xLaserRec, yLaserRec, laserWidth, laserHeight);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            int xtemp = xHero;
            int ytemp = yHero;

            #region Move character based on key presses

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
        if (xRobot1 < xHero)
            {
                robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                xRobot1++;
                xRobot1HitRec++;
            }
            else if (xRobot1 > xHero)
            {
                robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                xRobot1--;
                xRobot1HitRec--;
            }
            else if (xRobot1 == xHero && yRobot1 < yHero)
            {
                robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                yRobot1++;
                yRobot1HitRec++;
            }
            else if (xRobot1 == xHero && yRobot1 > yHero)
            {
                robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                yRobot1--;
                yRobot1HitRec--;
            }
            else if (yRobot1 < yHero)
            {
                robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                yRobot1++;
                yRobot1HitRec++;
            }
            else if (yRobot1 > yHero)
            {
                robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                yRobot1--;
                yRobot1HitRec--;
            }

            //Robot 2
            if (xRobot2 < xHero)
            {
                robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                xRobot2 = xRobot2 + 2;
                xRobot2HitRec = xRobot2HitRec + 2;
            }
            else if (xRobot2 > xHero)
            {
                robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                xRobot2 = xRobot2 - 2;
                xRobot2HitRec = xRobot2HitRec - 2;
            }

            else if (xRobot2 == xHero && yRobot2 < yHero)
            {
                robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                yRobot2 = yRobot2 + 2;
                yRobot2HitRec = yRobot2HitRec + 2;
            }
            else if (xRobot2 == xHero && yRobot2 > yHero)
            {
                robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                yRobot2 = yRobot2 - 2;
                yRobot2HitRec = yRobot2HitRec - 2;
            }
            else if (yRobot2 < yHero)
            {
                robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                yRobot2 = yRobot2 + 2;
                yRobot2HitRec = yRobot2HitRec + 2;
            }
            else if (yRobot2 > yHero)
            {
                robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                yRobot2 = yRobot2 - 2;
                yRobot2HitRec = yRobot2HitRec - 2;
            }

            //Robot 3
            if (xRobot3 < xHero)
            {
                robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);
                xRobot3 = xRobot3 + robot3Speed;
                xRobot3HitRec = xRobot3HitRec + robot3Speed;
            }
            else if (xRobot3 > xHero)
            {
                robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);
                xRobot3 = xRobot3 - robot3Speed;
                xRobot3HitRec = xRobot3HitRec - robot3Speed;
            }
            else if (xRobot3 == xHero && yRobot3 < yHero)
            {
                robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);
                yRobot3 = yRobot3 + robot3Speed;
                yRobot3HitRec = yRobot3HitRec + robot3Speed;
            }
            else if (xRobot3 == xHero && yRobot3 > yHero)
            {
                robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);
                yRobot3 = yRobot3 - robot3Speed;
                yRobot3HitRec = yRobot3HitRec - robot3Speed;
            }
            else if (yRobot3 < yHero)
            {
                robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);
                yRobot3 = yRobot3 + robot3Speed;
                yRobot3HitRec = yRobot3 + robot3Speed;
            }
            else if (yRobot3 > yHero)
            {
                robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);
                yRobot3 = yRobot3 - robot3Speed;
                yRobot3HitRec = yRobot3 + robot3Speed;
            }
#endregion
            #region Map Select/Player Spawn/Robot Spawn;
            heroRec = new Rectangle(xHero, yHero, widthHero, heightHero);

            if (heroRec.IntersectsWith(doorleftRec))
            {
                int robotNumber = 0;
                int map = randGen.Next(1, 6);
                int heroPreset = randGen.Next(1, 5);
                robotNumber = randGen.Next(1, 4);
                score1 = score1 + 5;

                if (map == 1)
                {
                    this.BackgroundImage = Properties.Resources.Map_1_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_2_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_3_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_4_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_5_Final;
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
            #region Robot Spawn
                if (map == 1)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;

                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = 390;
                        yRobot2 = 166;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = 390;
                        yRobot2 = 166;
                        xRobot3 = 300;
                        yRobot3 = 345;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 2)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = 380;
                        yRobot2 = 165;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = 380;
                        yRobot2 = 165;
                        xRobot3 = 300;
                        yRobot3 = 400;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }

                }
                else if (map == 3)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = 470;
                        yRobot2 = 225;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = 470;
                        yRobot2 = 225;
                        xRobot3 = 300;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 4)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = 300;
                        yRobot2 = 100;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = 300;
                        yRobot2 = 100;
                        xRobot3 = 450;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 5)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = 300;
                        yRobot2 = 275;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = 300;
                        yRobot2 = 275;
                        xRobot3 = 150;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
            #endregion
                Thread.Sleep(1500);
            }
            else if (heroRec.IntersectsWith(doorrightRec))
            {
                int robotNumber = 0;
                map = randGen.Next(1, 6);
                heroPreset = randGen.Next(1, 5);
                robotNumber = randGen.Next(1, 4);
                score1 = score1 + 5;

                if (map == 1)
                {
                    this.BackgroundImage = Properties.Resources.Map_1_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_2_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_3_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_4_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_5_Final;
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
                #region Robot Spawn
                if (map == 1)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;

                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = 390;
                        yRobot2 = 166;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = 390;
                        yRobot2 = 166;
                        xRobot3 = 300;
                        yRobot3 = 345;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 2)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = 380;
                        yRobot2 = 165;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = 380;
                        yRobot2 = 165;
                        xRobot3 = 300;
                        yRobot3 = 400;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }

                }
                else if (map == 3)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = 470;
                        yRobot2 = 225;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = 470;
                        yRobot2 = 225;
                        xRobot3 = 300;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 4)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = 300;
                        yRobot2 = 100;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = 300;
                        yRobot2 = 100;
                        xRobot3 = 450;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 5)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = 300;
                        yRobot2 = 275;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = 300;
                        yRobot2 = 275;
                        xRobot3 = 150;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                #endregion
                Thread.Sleep(1500);
            }
            else if (heroRec.IntersectsWith(doorupRec))
            {
                int robotNumber = 0;
                int map = randGen.Next(1, 6);
                int heroPreset = randGen.Next(1, 5);
                robotNumber = randGen.Next(1, 4);
                score1 = score1 + 5;

                if (map == 1)
                {
                    this.BackgroundImage = Properties.Resources.Map_1_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_2_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_3_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_4_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_5_Final;
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
                #region Robot Spawn
                if (map == 1)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;

                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = 390;
                        yRobot2 = 166;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = 390;
                        yRobot2 = 166;
                        xRobot3 = 300;
                        yRobot3 = 345;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 2)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = 380;
                        yRobot2 = 165;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = 380;
                        yRobot2 = 165;
                        xRobot3 = 300;
                        yRobot3 = 400;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }

                }
                else if (map == 3)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = 470;
                        yRobot2 = 225;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = 470;
                        yRobot2 = 225;
                        xRobot3 = 300;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 4)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = 300;
                        yRobot2 = 100;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = 300;
                        yRobot2 = 100;
                        xRobot3 = 450;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 5)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = 300;
                        yRobot2 = 275;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = 300;
                        yRobot2 = 275;
                        xRobot3 = 150;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                #endregion
                Thread.Sleep(1500);
            }
            else if (heroRec.IntersectsWith(doordownRec))
            {
                int robotNumber = 0;
                int map = randGen.Next(1, 6);
                int heroPreset = randGen.Next(1, 5);
                robotNumber = randGen.Next(1, 4);
                score1 = score1 + 5;

                if (map == 1)
                {
                    this.BackgroundImage = Properties.Resources.Map_1_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_2_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_3_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_4_Final;
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
                    this.BackgroundImage = Properties.Resources.Map_5_Final;
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
                #region Robot Spawn
                if (map == 1)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;

                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = 390;
                        yRobot2 = 166;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 214;
                        yRobot1 = 166;
                        xRobot2 = 390;
                        yRobot2 = 166;
                        xRobot3 = 300;
                        yRobot3 = 345;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 2)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = 380;
                        yRobot2 = 165;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 240;
                        yRobot1 = 165;
                        xRobot2 = 380;
                        yRobot2 = 165;
                        xRobot3 = 300;
                        yRobot3 = 400;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }

                }
                else if (map == 3)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = 470;
                        yRobot2 = 225;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 170;
                        yRobot1 = 225;
                        xRobot2 = 470;
                        yRobot2 = 225;
                        xRobot3 = 300;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 4)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = 300;
                        yRobot2 = 100;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 200;
                        yRobot1 = 225;
                        xRobot2 = 300;
                        yRobot2 = 100;
                        xRobot3 = 450;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                else if (map == 5)
                {
                    if (robotNumber == 1)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = -50;
                        yRobot2 = 1000;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 2)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = 300;
                        yRobot2 = 275;
                        xRobot3 = -50;
                        yRobot3 = 1000;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                    else if (robotNumber == 3)
                    {
                        xRobot1 = 300;
                        yRobot1 = 165;
                        xRobot2 = 300;
                        yRobot2 = 275;
                        xRobot3 = 150;
                        yRobot3 = 225;

                        robot1HitRec = new Rectangle(xRobot1HitRec, yRobot1HitRec, robotWidth, robotHeight);
                        robot2HitRec = new Rectangle(xRobot2HitRec, yRobot2HitRec, robotWidth, robotHeight);
                        robot3HitRec = new Rectangle(xRobot3HitRec, yRobot3HitRec, robotWidth, robotHeight);

                        robot1Rec = new Rectangle(xRobot1, yRobot1, robotWidth, robotHeight);
                        robot2Rec = new Rectangle(xRobot2, yRobot2, robotWidth, robotHeight);
                        robot3Rec = new Rectangle(xRobot3, yRobot3, robotWidth, robotHeight);

                        xRobot1Rec = xRobot1;
                        yRobot1Rec = yRobot1;
                        xRobot2Rec = xRobot2;
                        yRobot2Rec = yRobot2;
                        xRobot3Rec = xRobot3;
                        yRobot3Rec = yRobot3;

                        xRobot1HitRec = xRobot1;
                        yRobot1HitRec = yRobot1;
                        xRobot2HitRec = xRobot2;
                        yRobot2HitRec = yRobot2;
                        xRobot3HitRec = xRobot3;
                        yRobot3HitRec = yRobot3;

                        robot1HitRec = robot1Rec;
                        robot2HitRec = robot2Rec;
                        robot3HitRec = robot3Rec;
                    }
                }
                #endregion
                Thread.Sleep(1500);
            }
            #endregion
            #region Wall Collision

            if (heroRec.IntersectsWith(wallLeft))
            {
                xHero = xHero + 5;
            }

            if (heroRec.IntersectsWith(wallTop))
            {
                yHero = yHero + 5;
            }

            if (heroRec.IntersectsWith(wallRight))
            {
                xHero = xHero - 5;
            }
            if (heroRec.IntersectsWith(wallBottom))
            {
                yHero = yHero - 5;
            }

            #endregion
            #region Laser Collision
            if (laserRec.IntersectsWith(robot1HitRec))
            {
                SoundPlayer player3 = new SoundPlayer(Properties.Resources.robotdeath);
                xRobot1 = xRobot1 + 100000;
                yRobot1 = yRobot1 + 100000;
                xRobot1HitRec = xRobot1HitRec + 100000;
                score1 = score1 + 30;
                player3.Play();
            }
            
            if (laserRec.IntersectsWith(robot2HitRec))
            {
                SoundPlayer player3 = new SoundPlayer(Properties.Resources.robotdeath);
                xRobot2 = xRobot2 + 100000;
                yRobot2 = yRobot2 + 100000;
                xRobot2HitRec = xRobot2HitRec + 100000;
                score1 = score1 + 40;
                player3.Play();
            }

            if (laserRec.IntersectsWith(robot3HitRec))
            {
                SoundPlayer player3 = new SoundPlayer(Properties.Resources.robotdeath);
                xRobot3 = xRobot3 + 1000000;
                yRobot3 = yRobot3 + 1000000;
                xRobot3HitRec = xRobot3HitRec + 100000;
                score1 = score1 + 60;
                player3.Play();
            }

            #endregion
            #region Robot Collision/Player Death
            //Robot 1
            if (heroRec.IntersectsWith(robot1HitRec) && heroLife == 5)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life3.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 500;
                yHero = 350;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot1HitRec) && heroLife == 4)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life2.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 500;
                yHero = 45;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot1HitRec) && heroLife == 3)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life1.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 100;
                yHero = 45;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot1HitRec) && heroLife == 2)
            {
                heroLife--;
            }

            //Robot 2
            if (heroRec.IntersectsWith(robot2HitRec) && heroLife == 5)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life3.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 500;
                yHero = 350;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot2HitRec) && heroLife == 4)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life2.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 500;
                yHero = 45;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot2HitRec) && heroLife == 3)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life1.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 100;
                yHero = 45;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot2HitRec) && heroLife == 2)
            {
                heroLife--;
            }

            //Robot 3
            if (heroRec.IntersectsWith(robot3HitRec) && heroLife == 5)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life3.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 500;
                yHero = 350;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot3HitRec) && heroLife == 4)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life2.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 500;
                yHero = 45;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot3HitRec) && heroLife == 3)
            {
                SoundPlayer player2 = new SoundPlayer(Properties.Resources.death);
                life1.Visible = false;
                heroLife--;
                Thread.Sleep(3000);
                xHero = 100;
                yHero = 45;
                player2.Play();
            }
            else if (heroRec.IntersectsWith(robot3HitRec) && heroLife == 2)
            {
                heroLife--;
            }

            else if (heroLife == 1)
            {
                this.BackgroundImage = Properties.Resources.gameover;
                xHero = -500;
                yHero = -500;
                xRobot1 = -500;
                yRobot1 = -500;
                xRobot2 = -500;
                yRobot2 = -500;
                xRobot3 = -500;
                yRobot3 = -500;
                Thread.Sleep(5000);
                heroLife--;

            }
            else if (heroLife == 0)
            {
                Thread.Sleep(5000);
                this.Close();
            }
            #endregion
            Refresh();
            }
  
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            string score2 = score1.ToString();

            e.Graphics.DrawImage(Properties.Resources.PlayerTest, xHero, yHero, 30, 30);
            e.Graphics.DrawImage(Properties.Resources.robot, xRobot1, yRobot1, 30, 30);
            e.Graphics.DrawImage(Properties.Resources.robot, xRobot2, yRobot2, 30, 30);
            e.Graphics.DrawImage(Properties.Resources.laserUp, xLaser, yLaser, 5, 5);
            e.Graphics.DrawImage(Properties.Resources.robot, xRobot3, yRobot3, 30, 30);
            e.Graphics.DrawString(score2, drawFont, blueBrush, 425, 420); 

            e.Graphics.FillRectangle(blueBrush, laserRec);
            e.Graphics.FillRectangle(blueBrush, robot1HitRec);
            e.Graphics.FillRectangle(blueBrush, robot2HitRec);
            e.Graphics.FillRectangle(blueBrush, robot3HitRec);

            #region Character Direction/Character Shooting

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

            if (spaceDown == true && leftArrowDown == true)
            {
                SoundPlayer player1 = new SoundPlayer(Properties.Resources.laser);
                heroDirection = 1;
                xLaser = xHero;
                yLaser = yHero + 7;
                xLaserRec = xHero;
                yLaserRec = yHero + 7;
                laserRec = heroRec;
                player1.Play();
                
            }

            if (spaceDown == true && rightArrowDown == true)
            {
                SoundPlayer player1 = new SoundPlayer(Properties.Resources.laser);
                heroDirection = 2;
                xLaser = xHero;
                yLaser = yHero + 7;
                xLaserRec = xHero;
                yLaserRec = yHero + 7;
                laserRec = heroRec;
                player1.Play();
            }

            if (spaceDown == true && upArrowDown == true)
            {
                SoundPlayer player1 = new SoundPlayer(Properties.Resources.laser);
                heroDirection = 3;
                xLaser = xHero + 7;
                yLaser = yHero;
                xLaserRec = xHero + 7;
                yLaserRec = yHero;
                laserRec = heroRec;
                player1.Play();
            }

            if (spaceDown == true && downArrowDown == true)
            {
                SoundPlayer player1 = new SoundPlayer(Properties.Resources.laser);
                heroDirection = 4;
                xLaser = xHero + 7;
                yLaser = yHero;
                xLaserRec = xHero + 7;
                yLaserRec = yHero;
                laserRec = heroRec;
                player1.Play();
            }
            
            if (heroDirection == 1)
            {
                e.Graphics.DrawImage(Properties.Resources.laserSide, xLaser, yLaser, 5, 5);
                laserRec = new Rectangle(xLaserRec, yLaserRec, laserWidth, laserHeight);
                xLaser = xLaser - laserSpeed;
                xLaserRec = xLaserRec - laserRecSpeed;
            }

            if (heroDirection == 2)
            {
                e.Graphics.DrawImage(Properties.Resources.laserSide, xLaser, yLaser, 5, 5);
                laserRec = new Rectangle(xLaserRec, yLaserRec, laserWidth, laserHeight);
                xLaser = xLaser + laserSpeed;
                xLaserRec = xLaserRec + laserRecSpeed;
            }

            if (heroDirection == 3)
            {
                e.Graphics.DrawImage(Properties.Resources.laserUp, xLaser, yLaser, 5, 5);
                laserRec = new Rectangle(xLaserRec, yLaserRec, laserWidth, laserHeight);
                yLaser = yLaser - laserSpeed;
                yLaserRec = yLaserRec - laserRecSpeed; 
            }

            if (heroDirection == 4)
            {
                e.Graphics.DrawImage(Properties.Resources.laserUp, xLaser, yLaser, 5, 5);
                laserRec = new Rectangle(xLaserRec, yLaserRec, laserWidth, laserHeight);
                yLaser = yLaser + laserSpeed;
                yLaserRec = yLaserRec + laserRecSpeed;
            }

            #endregion
        }
    }
}
