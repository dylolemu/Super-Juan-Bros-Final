using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Super_Juan_Bros_Final
{
    public partial class superJuanBros : Form
    {
        public superJuanBros()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            question1.Location = new Point(this.Width + 300, 56);
            brick4.Location = new Point(this.Width + 500, 560);
            brick3.Hide();
            brick2.Hide();
            brick.Hide();
            question.Hide();
            cactus1.Hide();
            cactus2.Hide();
            playerSlide.Hide();
            fireBall.Hide();
            fireBall2.Hide();
            fireBall3.Hide();
            invisibleCharge.Hide();
            invisibleChargeBack.Hide();
            brickHideBack.Hide();
            brickHideBox.Hide();
            coin.Hide();
            fireBall.SendToBack();
            playerSlide.Size = new Size(99, 57);
            ground.Location = new Point(0, this.Height - ground.Height+25);
            cactus1.Location = new Point(15, ground.Top + 7 - cactus1.Height);
            cactus2.Location = new Point(25, ground.Top + 7 - cactus2.Height);
            player.Top = ground.Top - player.Height;
            label1.Text = "" + cactus1.Top + cactus2.Top;
        }
        Random randNum = new Random();
        bool gifnotloaded;
        bool jump, doubleJump, sliding;
        int force;
        int G = 33;
        bool onBrick;
        bool start;
        bool fire;
        bool noFire;
        int recharge;
        bool live1 = true;
        bool live2 = true;
        bool live3 = true;
        bool extraHeart;
 
        private void superJuanBros_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); }

            if (e.KeyCode == Keys.Enter)
            {
                start = true;
                lose = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                sliding = true;
            }
            if (e.KeyCode == Keys.Right && noFire == false)
            {
                fire = true;
                recharge = 0;
                flameCharge.Size = new Size(0, 0);
            }
            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    force = G;
                    player.Image = Properties.Resources.mexicanJump;
                }
            }
            else if (doubleJump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    doubleJump = true;
                    force = G;
                }
            }
        } 
        private void superJuanBros_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                sliding = false;
                gifnotloaded = true;
                player.Show();
                playerSlide.Hide();
            }
            if (e.KeyCode == Keys.Space)
            {
                gifnotloaded = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                gifnotloaded = true;
            }
        }
        int xValue;
        int chanceValue;
        int powerUps;
        int score;
        int[] locations = { 560, 497, 434, 371, 308, 245, 182, 119, 56};
        int speed = 10;
        bool lose;

        //powerUps
        bool invisible;
        bool tripleFire;
        bool coinUp;
        bool brickHide;
        int points;
        int invisibleTime, tripleFireTime, brickHideTime;
 
        private void timer1_Tick(object sender, EventArgs e)
        {
            xValue = randNum.Next(this.Width, 2500);
            chanceValue = randNum.Next(1, 3);
            powerUps = randNum.Next(2, 100);

            if (points >= 1000 && points <=1500)
            {
                speed =10;
            }
            if (lose == true)
            {
                speed = 0;
                if (live1 == true)
                {
                    heart1.Hide();
                    live1 = false;
                }
                else if (live2 != false && live1 == false)
                {
                    heart2.Hide();
                    live2 = false;
                }
                else if (live3 != false && live2 == false)
                { heart3.Hide(); }

                invisible = true;
                lose = false;
            }
            else
            { speed = 10; }
          

            
            if (start == true)
            {
                label1.Text = Convert.ToString(points);
                points += 1;

                playerUps();

                brickMovement();
                brickRespawning();

                playerSlide.Top = player.Top + playerSlide.Height - 7;
                if (jump == true)
                {
                    player.Top -= force;
                    force -= 2;
                }
                else if (gifnotloaded == true)
                {
                    player.Image = Properties.Resources.mexicanRight;
                    gifnotloaded = false;
                }

                borders(brick);
                borders2(brick2);
                borders3(brick3);
                borders2(question);
                borders2(gameSign);
                borders4(brick4);
                borders4(cactus1);
                borders4(cactus2);

                slideBorders(brick);
                slideBorders(brick2);
                slideBorders(brick3);
                slideBorders(brick4);
                fireContact(brick);
                fireContact(brick2);
                fireContact(brick3);
                fireContact(brick4);
                fireContact(question);
                fireContact(question1);
                fireContact(cactus1);
                fireContact(cactus2);

                landingBrick();
                hidePowerUp(brick);
                hidePowerUp(brick2);
                hidePowerUp(brick3);
                hidePowerUp(brick4);
                hidePowerUp(cactus1);
                hidePowerUp(cactus2);
            }
        }
        public void borders(PictureBox x)
        {
            if (invisible == false && player.Top < x.Top && player.Top + player.Height >= x.Top && player.Right > x.Left && player.Left < x.Right)
            {
                player.Top = x.Top - player.Height;
                force = 0;
                jump = false;
                doubleJump = false;
                onBrick = true;
            }
            else { onBrick = false; }

            if (invisible == false && player.Right > x.Left && player.Left < x.Right && player.Top - x.Bottom <= 20 && player.Top - x.Top > -20)
            {
                force = -6;
            }
            if (invisible == false && sliding == false && player.Right >= x.Left-5 && player.Left < x.Right && player.Top < x.Bottom && player.Bottom > x.Top)
            {
                lose = true;
            }
        }
        public void borders2(PictureBox x)
        {
            if (invisible == false && player.Top < x.Top && player.Top + player.Height >= x.Top && player.Right > x.Left && player.Left < x.Right)
            {
                player.Top = x.Top - player.Height;
                force = 0;
                jump = false;
                doubleJump = false;
                onBrick = true;
            }

            if (invisible == false && player.Right > x.Left && player.Left < x.Right && player.Top - x.Bottom <= 20 && player.Top - x.Top > -20)
            {
                force = -6;
            }

            if (invisible == false && sliding == false && player.Right >= brick2.Left-5 && player.Left < brick2.Right && player.Top < brick2.Bottom && player.Bottom > brick2.Top)
            {
                lose = true;
            }
            if (gameSign.Right > 0)
            {
                gameSign.Left -= 4;
            }
            else { gameSign.Dispose(); }
        }
        public void borders3(PictureBox x)
        {
            if (invisible == false && player.Top < x.Top+12 && player.Top + player.Height >= x.Top+12 && player.Right > x.Left && player.Left < x.Right)
            {
                player.Top = x.Top - player.Height+12;
                force = 0;
                jump = false;
                doubleJump = false;
                onBrick = true;
            }

            if (invisible == false && player.Right > x.Left && player.Left < x.Right && player.Top - x.Bottom <= 15 && player.Top - x.Top > -15)
            {
                force = -6;
            }

            if (invisible == false && sliding == false && player.Top < x.Top && player.Top + player.Height >= x.Top + 12 && player.Right >= brick3.Left && player.Left <= brick3.Right - 90)
            {
                lose = true;
            }
        }
        public void borders4(PictureBox x)
        {
            if (invisible == false && sliding == false && player.Bottom >= x.Top + 10 && player.Top + 10 <x.Bottom && player.Right >= x.Left && player.Left < x.Right)
            {
                lose = true;
            }
            if (invisible == false && player.Right > brick4.Left && player.Left < brick4.Right && player.Top - brick4.Bottom <= 15 && player.Top - brick4.Top > -15)
            {
                force = -6;
            }
        }
        public void slideBorders(PictureBox x)
        {
            if (sliding == true && playerSlide.Top <= x.Bottom && playerSlide.Bottom >= x.Top+7 && playerSlide.Right >= x.Left && playerSlide.Left <= x.Right)
            {
                lose = true;
            }
        }
        public void fireContact(PictureBox x)
        {
            if (fire == true && fireBall.Top <= x.Bottom && fireBall.Bottom >= x.Top && fireBall.Right >= x.Left && fireBall.Left <= x.Right)
            {
                x.Hide();
                x.Top = this.Height;
            }
            if (tripleFire == true)
            {
                if (fire == true && fireBall2.Top <= x.Bottom && fireBall2.Bottom >= x.Top && fireBall2.Right >= x.Left && fireBall2.Left <= x.Right)
                {
                    x.Hide();
                    x.Top = this.Height;
                }
                if (fire == true && fireBall3.Top <= x.Bottom && fireBall3.Bottom >= x.Top && fireBall3.Right >= x.Left && fireBall3.Left <= x.Right)
                {
                    x.Hide();
                    x.Top = this.Height;
                }
            }
            if (x.Left >= this.Width)
            {
                x.Show();
            }
        }
        public void brickRespawning()
        {
            if (ground.Right <= this.Width)
            {
                ground.Left = -5;
            }

            if (score < 2)
            {
                if (brick2.Right <= 0)
                {
                    score += 1; ;
                    brick2.Location = new Point(xValue, locations[2]);
                }
                if (brick.Right <= 0)
                {
                    brick.Location = new Point(xValue, locations[4]);
                }
                if (brick3.Right <= 0)
                {
                    brick3.Location = new Point(xValue, locations[7]);
                }
                if (question.Right <= 0)
                {
                    question.Location = new Point(xValue + 91, locations[6]);
                }
                if (question1.Right <= 0)
                {
                    question1.Location = new Point(xValue + 78, locations[8]);
                }
                if (brick4.Right <= 0)
                {
                    brick4.Location = new Point(xValue, locations[0]);
                }
                if (brick4.Right < this.Width && cactus1.Right <= 0 && cactus2.Right <= 0)
                {
                    if (chanceValue == 1)
                    {
                        cactus1.Location = new Point(xValue, 609);
                    }
                    if (chanceValue == 2)
                    {
                        cactus2.Location = new Point(xValue, 623);
                    }
                }
            }
            if (score >= 2 && score < 4)
            {
                if (brick2.Right <= 0)
                {
                    score += 1; ;
                    brick2.Location = new Point(xValue, locations[6]);
                }
                if (brick.Right <= 0)
                {
                    brick.Location = new Point(xValue + 28, locations[1]);
                }
                if (brick3.Right <= 0)
                {
                    brick3.Location = new Point(xValue + 17, locations[5]);
                }
                if (question.Right <= 0)
                {
                    question.Location = new Point(xValue + 29, locations[8]);
                }
                if (question1.Right <= 0)
                {
                    question1.Location = new Point(xValue + 156, locations[7]);
                }
                if (brick4.Right <= 0)
                {
                    brick4.Location = new Point(xValue + 89, locations[3]);
                }
                if (cactus1.Right <= 0 && cactus2.Right <= 0)
                {
                    if (chanceValue == 1)
                    {
                        cactus1.Location = new Point(xValue, 609);
                    }
                    if (chanceValue == 2)
                    {
                        cactus2.Location = new Point(xValue, 623);
                    }
                }
            }
            if (score >= 4 && score <= 6)
            {
                if (brick2.Right <= 0)
                {
                    score += 1; ;
                    brick2.Location = new Point(xValue + 17, locations[8]);
                }
                if (brick.Right <= 0)
                {
                    brick.Location = new Point(xValue + 80, locations[3]);
                }
                if (brick3.Right <= 0)
                {
                    brick3.Location = new Point(xValue + 50, locations[0]);
                }
                if (question.Right <= 0)
                {
                    question.Location = new Point(xValue + 150, locations[7]);
                }
                if (question1.Right <= 0)
                {
                    question1.Location = new Point(xValue + 35, locations[6]);
                }
                if (brick4.Right <= 0)
                {
                    brick4.Location = new Point(xValue + 20, locations[1]);
                }
                if (brick3.Right < this.Width && cactus1.Right <= 0 && cactus2.Right <= 0)
                {
                    if (chanceValue == 1)
                    {
                        cactus1.Location = new Point(xValue, 609);
                    }
                    if (chanceValue == 2)
                    {
                        cactus2.Location = new Point(xValue, 623);
                    }
                }
                if (score == 6)
                {
                    score = 0;
                }
            }
        }
        public void playerUps()
        {
            //extra heart
            if(extraHeart == true)
            {
                if (live1 == false && live2 != false)
                {
                    heart1.Show();
                    live1 = true;
                }
                if (live2 == false)
                {
                    heart2.Show();
                    live2 = true;
                    live3 = true;
                }
                extraHeart = false;
            }
            //coin movement
            if (coinUp == true)
            {
                coin.Show();
                coin.Left = question.Left;
                coin.Top -= 12;
                if (question.Top - coin.Top >= 80)
                {
                    coin.Hide();
                    coinUp = false;
                }
            }
            else
            {
                coin.Top = question.Top;
                coin.Left = question.Left;
            }

            //ivisibility timer     
            if (invisible == true)
            {
                invisibleCharge.Show();
                invisibleChargeBack.Show();
                invisibleCharge.Size = new Size(148 - 148 * invisibleTime / 70, 27);
                invisibleTime += 1;
                if (invisibleTime < 10)
                {
                    player.Hide();
                }
                if (invisibleTime >= 10 && invisibleTime < 20)
                {
                    player.Show();
                }
                if (invisibleTime >= 20 && invisibleTime < 30)
                {
                    player.Hide();
                }
                if (invisibleTime >= 30 && invisibleTime < 40)
                {
                    player.Show();
                }
                if (invisibleTime >= 40 && invisibleTime < 50)
                {
                    player.Hide();
                }
                if (invisibleTime >= 50 && invisibleTime < 60)
                {
                    player.Show();
                }
                if (invisibleTime >= 60 && invisibleTime < 70)
                {
                    player.Hide();
                }

                if (invisibleTime > 70)
                {
                    player.Show();
                    invisible = false;
                    invisibleCharge.Hide();
                    invisibleChargeBack.Hide();
                }
            }
            else { invisibleTime = 0; }

            //triplefire timer     
            if (tripleFire == true)
            {
                tripleFireTime += 1;
                if (tripleFireTime > 300)
                {
                    tripleFire = false;
                    fireBall2.Hide();
                    fireBall3.Hide();
                }
            }
            else { tripleFireTime = 0; }
            
            if (noFire == true)
            {
                recharge += 1;
                flameCharge.Size = new Size(148* recharge/200, 27);
            }
            if (tripleFire == true)
            {
                noFire = false;
                if (fire == true)
                {
                    flameCharge.Size = new Size(148 * fireBall.Left / this.Width, 27);
                }
                else { flameCharge.Size = new Size(148, 27); }
            }
            else
            {
                if (recharge == 200)
                {
                    noFire = false;
                }
            }
            if (fire == true)
            {
                fireBall.Show();
                fireBall.Left += speed * 2;
                noFire = true;

                if (tripleFire == true)
                {
                    fireBall2.Show();
                    fireBall3.Show();
                    fireBall2.Left = fireBall.Left;
                    fireBall3.Left = fireBall.Left;
                }
                if (fireBall.Left > this.Width)
                {
                    fireBall.Left = player.Left;
                    fireBall2.Left = player.Left;
                    fireBall3.Left = player.Left;
                    fireBall.Hide();
                    fire = false;
                    fireBall2.Hide();
                    fireBall3.Hide();
                }

            }
            else
            {
                fireBall.Top = player.Top + 50;
                fireBall2.Top = fireBall.Top - fireBall.Width;
                fireBall3.Top = fireBall2.Top - fireBall2.Width;
            }
            if (invisible == false && player.Right > question.Left && player.Left < question.Right && player.Top - question.Bottom <= 20 && player.Top - question.Top > -20)
            {
                //coin
                if (powerUps <= 60)
                {
                    points += 1000;
                    coinUp = true;
                }
                else if (powerUps > 85 && powerUps <=100)
                {
                    brickHide = true;
                }
                else if (powerUps <= 80 && powerUps >60)
                {
                    tripleFire = true;
                }
                else if (powerUps >80 && powerUps<=85)
                {
                    extraHeart = true;
                }
            }
        }
        public void landingBrick()
        {
            if (player.Top >= ground.Top - player.Height)
            {
                player.Top = ground.Top - player.Height;
                force = 0;
                //sliding on ground
                if (sliding == true)
                {
                    playerSlide.Show();
                    player.Hide();
                    jump = true;
                    doubleJump = true;
                }
                else
                {
                    jump = false;
                    doubleJump = false;
                }
            }
            //falling off brick no jump
            else if (onBrick == false && jump == false)
            {
                jump = true;
                player.Top += 12;
                player.Image = Properties.Resources.mexicanJump;
                gifnotloaded = true;
            }
            if (onBrick == true)
            {
                if (sliding == true)
                {
                    playerSlide.Show();
                    player.Hide();
                }
            }
        }
        public void brickMovement()
        {
            brick.Left -= speed;
            brick2.Left -= speed;
            brick3.Left -= speed;
            question.Left -= speed;
            brick4.Left -= speed;
            question1.Left -= speed;
            cactus1.Left -= speed;
            cactus2.Left -= speed;
            ground.Left -= speed;
        }
        public void hidePowerUp(PictureBox x)
        {
            if (brickHide == true)
            {
                x.Hide();
                x.Top = this.Width;
                brickHideBox.Show();
                brickHideBack.Show();
                brickHideBox.Size = new Size(148 - 180 * brickHideTime / 1000, 27);
                brickHideTime += 1;
                if (brickHideTime > 800)
                {
                    brickHide = false;
                    brickHideBox.Hide();
                    brickHideBack.Hide();
                }
            }
            else {brickHideTime = 0; }
        }

    }
}
  
