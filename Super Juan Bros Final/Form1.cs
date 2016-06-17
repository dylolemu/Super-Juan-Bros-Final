using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

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
            hotSauce.Hide();
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
            pause1.Hide();
            coin.Hide();
            gameOverImage.Hide();
            gameOverImage.Top = -200;
            playerDead.Hide();
            fireBall.SendToBack();
            playerSlide.Size = new Size(99, 57);
            ground.Location = new Point(0, this.Height - ground.Height + 25);
            cactus1.Location = new Point(15, ground.Top + 7 - cactus1.Height);
            cactus2.Location = new Point(25, ground.Top + 7 - cactus2.Height);
            player.Location = new Point(150, 582);
            instructions.Hide();
            medium = true;
            hotSauce.Top = question.Top;
            label1.Text = "0000000";
            finalPoints.Text = "";
            labelFire.Text = "";
            labelBrickHide.Text = "";
            labelInvisibility.Text = "";
            Cursor.Hide();
            Background bg = new Background();
            bg.Show();
            this.Focus();
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
        bool settings, showInstructions, difficulty, character;
        bool luigi;
        bool easy, medium, hard;
        bool pause;
        SoundPlayer jumpSound = new SoundPlayer(Properties.Resources.jumpSound);
        SoundPlayer doubleJumpSound = new SoundPlayer(Properties.Resources.jumpSound);
        SoundPlayer fireBallSound = new SoundPlayer(Properties.Resources.fireballSound);
        SoundPlayer brickHitSound = new SoundPlayer(Properties.Resources.brickSmashSound);
        SoundPlayer selectSound = new SoundPlayer(Properties.Resources.selectSound);
        SoundPlayer coinSound = new SoundPlayer(Properties.Resources.coinSound);
        SoundPlayer pauseSound = new SoundPlayer(Properties.Resources.pauseSound);
        SoundPlayer heartSound = new SoundPlayer(Properties.Resources.heartSound);
        SoundPlayer dieSound = new SoundPlayer(Properties.Resources.dieSound);
        SoundPlayer playerHitSound = new SoundPlayer(Properties.Resources.playerHitSound);


        private void superJuanBros_KeyDown_1(object sender, KeyEventArgs e)
        {
            powerUps = randNum.Next(2, 100);
            if (gameOver == true)
            {
                dieSound.Play();
                gameOver = false;
                restart = true;
            }
            if (restart == false || gameOver == false)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (start == false)//if on main screen esc closes game
                    {
                        this.Close();
                    }
                    else if (pause == false)//if not on main screen it pauses the game
                    {
                        pause1.Show();
                        pause = true;
                        speed = 0;
                        if (player.Top == ground.Top - player.Height)
                        {
                            if (luigi == false)
                            {
                                player.Image = Properties.Resources.mexicanStanding;
                            }
                            else
                            {
                                player.Image = Properties.Resources.luigiStanding;
                            }
                        }
                    }
                    else//if already paused it unpauses game
                    {
                        pause1.Hide();
                        pause = false;
                        if (luigi == false)
                        {
                            player.Image = Properties.Resources.mexicanRight;
                        }
                        else
                        {
                            player.Image = Properties.Resources.luigiRight;
                        }
                    }
                }
            }
            if (pause == true)
            {
                if (e.KeyCode == Keys.Q)
                {
                    this.Close();
                }
            }

            //start
            if (start == false)
            {
                player.Location = new Point(150, 582);
                if (e.KeyCode == Keys.Enter)
                {
                    if (selector.Top == 400)
                    {
                        if (difficulty == false)
                        {
                            player.Show();
                            selector.Hide();
                            labelFire.Text = "FIRE";
                            start = true;
                            lose = false;
                            restart = false;
                            selections.Hide();
                            player.Location = new Point(150, 560);
                        }
                        else
                        {
                            selectSound.Play();
                            easy = true;
                            medium = false;
                            hard = false;
                            difficulty = false;
                            settings = true;
                            selector.Top = 420;
                        }
                    }
                    else if (selector.Top == 440)
                    {
                        selectSound.Play();
                        if (difficulty == false)
                        {
                            settings = true;
                        }
                        else
                        {
                            easy = false;
                            medium = true;
                            hard = false;
                            difficulty = false;
                            settings = true;
                            selector.Top = 420;
                        }
                    }
                    else if (selector.Top == 480)
                    {
                        selectSound.Play();
                        if (difficulty == false)
                        {
                            selections.Hide();
                            instructions.Show();
                            instructions.Size = new Size(1068, 657);
                            instructions.Location = new Point(this.Width / 2 - instructions.Width / 2, this.Height / 2 - instructions.Height / 2 - 5);
                            showInstructions = true;
                        }
                        else
                        {
                            easy = false;
                            medium = false;
                            hard = true;
                            difficulty = false;
                            settings = true;
                            selector.Top = 420;
                        }
                    }
                    else if (selector.Top == 420)
                    {
                        selectSound.Play();
                        if (settings == true)
                        {
                            difficulty = true;
                            settings = false;
                            selector.Top = 400;
                        }
                        else
                        {
                            settings = true;
                            character = false;
                            luigi = false;
                        }
                    }
                    else if (selector.Top == 460)
                    {
                        selectSound.Play();
                        if (character == true)
                        {
                            luigi = true;
                            character = false;
                            settings = true;
                        }
                        else
                        {
                            settings = false;
                            character = true;
                        }
                    }
                }
                if (character == true)
                {
                    selector.Top = 420;
                    if (selector.Top < 460 && e.KeyCode == Keys.Down)
                    {
                        selector.Top += 40;
                    }
                    if (selector.Top > 420 && e.KeyCode == Keys.Up)
                    {
                        selector.Top -= 40;
                    }
                    if (selector.Top == 420)
                    {
                        player.Image = Properties.Resources.mexicanStanding;
                    }
                    if (selector.Top == 460)
                    {
                        player.Image = Properties.Resources.luigiStanding;
                    }
                }
                if (settings == false && character == false)
                {
                    if (selector.Top < 480 && e.KeyCode == Keys.Down)
                    {
                        selector.Top += 40;
                    }
                    if (selector.Top > 400 && e.KeyCode == Keys.Up)
                    {
                        selector.Top -= 40;
                    }
                }
                if (settings == true)
                {
                    selector.Top = 420;
                    if (selector.Top < 460 && e.KeyCode == Keys.Down)
                    {
                        selector.Top += 40;
                    }
                    if (selector.Top > 420 && e.KeyCode == Keys.Up)
                    {
                        selector.Top -= 40;
                    }
                    if (selector.Top == 460)
                    {
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (showInstructions == true)
                    {
                        showInstructions = false;
                        instructions.Hide();
                        selector.Top = 400;
                    }
                    if (settings == true)
                    {
                        settings = false;
                        selector.Top = 400;
                    }
                    if (difficulty == true)
                    {
                        settings = true;
                        difficulty = false;
                        selector.Top = 420;
                    }
                    if (character == true)
                    {
                        settings = true;
                        character = false;
                        selector.Top = 420;
                    }
                }
            }
            if (restart == false || gameOver == false)
            {
                if (e.KeyCode == Keys.Down)
                {
                    sliding = true;
                    if (luigi == false)
                    {
                        playerSlide.Image = Properties.Resources.marioSliding;
                    }
                    else
                    {
                        playerSlide.Image = Properties.Resources.luigiSliding;
                    }
                }
                if (e.KeyCode == Keys.Right && noFire == false)
                {
                    fireBallSound.Play();
                    fire = true;
                    recharge = 0;
                    flameCharge.Size = new Size(0, 0);
                }
                if (jump != true)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        jumpSound.Play();
                        jump = true;
                        force = G;
                        if (luigi == false)
                        {
                            player.Image = Properties.Resources.mexicanJump;
                        }
                        else
                        {
                            player.Image = Properties.Resources.luigiJump;
                        }
                    }
                }
                else if (doubleJump != true)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        doubleJumpSound.Play();
                        doubleJump = true;
                        force = G;
                    }
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
        int[] locations = { 560, 497, 434, 371, 308, 245, 182, 119, 56 };
        int speed = 10;
        bool lose, gameOver, restart;

        //powerUps
        bool invisible;
        bool tripleFire;
        bool coinUp;
        bool brickHide;
        int points;
        int invisibleTime, tripleFireTime, brickHideTime;
        int x = 2500;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pause != true)
            {
                if (settings == true)
                {
                    selections.Image = Properties.Resources.settingsSelect;
                    selections.Location = new Point(550, 409);
                    selections.Size = new Size(188, 95);
                }
                else if (difficulty == true)
                {
                    selections.Image = Properties.Resources.difficultySelect;
                    selections.Location = new Point(550, 395);
                    selections.Size = new Size(176, 121);
                }
                else if (character == true)
                {
                    selections.Image = Properties.Resources.characterSelect;
                    selections.Location = new Point(550, 416);
                    selections.Size = new Size(155, 74);
                }
                else if (showInstructions == false && start == false)
                {
                    selections.Show();
                    selections.Image = Properties.Resources.startSelect;
                    selections.Location = new Point(550, 395);
                    selections.Size = new Size(211, 123);
                }

                if (start == true)
                {
                    chanceValue = randNum.Next(1, 3);
                    if (hard == true)
                    {
                        xValue = randNum.Next(this.Width, x);
                        if (x >= 1300)
                        {
                            x = 1800 - points / 70;
                        }
                        else { x = 1300; }

                        if (speed <= 14)
                        {
                            speed = 12 + points / 1000;
                        }
                        else { speed = 14; }
                    }
                    else if (medium == true)
                    {
                        xValue = randNum.Next(this.Width, x);
                        if (x >= 1800)
                        {
                            x = 2500 - points / 60;
                        }
                        else { x = 1800; }

                        if (speed <= 13)
                        {
                            speed = 10 + points / 1500;
                        }
                        else { speed = 13; }
                    }
                    else if (easy == true)
                    {
                        xValue = randNum.Next(this.Width, 2800);
                        brick3.Hide();
                        brick3.Top = this.Height;
                        if (speed <= 13)
                        {
                            speed = 10 + points / 1500;
                        }
                        else { speed = 13; }
                    }

                    if (lose == true)
                    {
                        if (live1 == true)
                        {
                            playerHitSound.Play();
                            heart1.Hide();
                            live1 = false;
                            lose = false;
                            labelInvisibility.Text = "INVISIBILITY";
                            invisible = true;
                        }
                        else if (live2 != false && live1 == false)
                        {
                            playerHitSound.Play();
                            heart2.Hide();
                            live2 = false;
                            lose = false;
                            labelInvisibility.Text = "INVISIBILITY";
                            invisible = true;
                        }
                        else if (live3 != false && live2 == false)
                        {
                            invisible = true;
                            speed = 0;
                            heart3.Hide();
                            if (player.Top == ground.Top - player.Height)
                            {
                                gameOver = true;
                                player.Hide();
                                invisible = false;
                            }
                        }
                    }
                    gameOverMethod();
                    restartMethod();


                    label1.Text = points.ToString("0000000");
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
                        if (luigi == false)
                        {
                            player.Image = Properties.Resources.mexicanRight;
                        }
                        else
                        {
                            player.Image = Properties.Resources.luigiRight;
                        }
                        gifnotloaded = false;
                    }

                    borders(brick);
                    questionBorders(question1);
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
        }
        public void gameOverMethod()
        {
            if (gameOver == true)
            {
                pause = false;
                tripleFire = false;
                points -= 1;
                speed = 0;
                playerDead.Show();
                brick.Hide();
                brick2.Hide();
                brick3.Hide();
                brick4.Hide();
                question.Hide();
                question1.Hide();
                cactus1.Hide();
                cactus2.Hide();
                fireBall.Hide();
                fireBall.Top = -50;
                player.Location = new Point(150, 582);
                brick.Location = new Point(199, 239);
                brick2.Location = new Point(256, 112);
                brick3.Location = new Point(295, 170);
                question1.Location = new Point(this.Width + 300, 56);
                brick4.Location = new Point(this.Width + 500, 560);
                cactus1.Location = new Point(15, -40);
                cactus2.Location = new Point(15, -40);
                if (luigi == false)
                {
                    playerDead.Image = Properties.Resources.marioDead;
                }
                else
                {
                    playerDead.Image = Properties.Resources.luigiDead;
                }
                gameOverImage.Show();
                if (gameOverImage.Top <= 103)
                {
                    gameOverImage.Top += 5;
                }
                else
                {
                    finalPoints.Text = points.ToString("0000000");
                }
            }
        }
        public void restartMethod()
        {
            if (restart == true)
            {
                player.Show();
                finalPoints.Text = "";
                playerDead.Hide();
                gameOverImage.Hide();
                gameOverImage.Top = -200;
                selector.Show();
                start = false;
                lose = true;
                speed = 0;
                selections.Show();
                gameSign.Location = new Point(295, 103);
                live1 = true;
                live2 = true;
                live3 = true;
                heart1.Show();
                heart2.Show();
                heart3.Show();
                points = 0;
                label1.Text = "0000000";
                if (luigi == true)
                {
                    player.Image = Properties.Resources.luigiStanding;
                }
                else
                {
                    player.Image = Properties.Resources.mexicanStanding;
                }

            }
        }
        public void questionBorders(PictureBox x)
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
                lose = true;
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
            if (invisible == false && sliding == false && player.Right >= x.Left - 5 && player.Left < x.Right && player.Top < x.Bottom && player.Bottom > x.Top)
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

            if (invisible == false && sliding == false && player.Right >= brick2.Left - 5 && player.Left < brick2.Right && player.Top < brick2.Bottom && player.Bottom > brick2.Top)
            {
                lose = true;
            }
            if (gameSign.Right > 0)
            {
                gameSign.Left -= 4;
            }
        }
        public void borders3(PictureBox x)
        {
            if (invisible == false && player.Top < x.Top + 12 && player.Top + player.Height >= x.Top + 12 && player.Right > x.Left && player.Left < x.Right)
            {
                player.Top = x.Top - player.Height + 12;
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
            if (invisible == false && sliding == false && player.Bottom >= x.Top + 10 && player.Top + 10 < x.Bottom && player.Right >= x.Left - 4 && player.Left < x.Right)
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
            if (sliding == true && playerSlide.Top <= x.Bottom && playerSlide.Bottom >= x.Top + 7 && playerSlide.Right >= x.Left && playerSlide.Left <= x.Right)
            {
                lose = true;
            }
        }
        public void fireContact(PictureBox x)
        {
            if (fire == true && fireBall.Top <= x.Bottom && fireBall.Bottom >= x.Top && fireBall.Right >= x.Left && fireBall.Left <= x.Right)
            {
                brickHitSound.Play();
                x.Hide();
                x.Top = this.Height;
            }
            if (tripleFire == true)
            {
                if (fire == true && fireBall2.Top <= x.Bottom && fireBall2.Bottom >= x.Top && fireBall2.Right >= x.Left && fireBall2.Left <= x.Right)
                {
                    brickHitSound.Play();
                    x.Hide();
                    x.Top = this.Height;
                }
                if (fire == true && fireBall3.Top <= x.Bottom && fireBall3.Bottom >= x.Top && fireBall3.Right >= x.Left && fireBall3.Left <= x.Right)
                {
                    brickHitSound.Play();
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
            if (extraHeart == true)
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
                if (invisibleCharge.Right <= 716)
                {
                    labelInvisibility.Text = "";
                }
                if (sliding == true)
                {
                    playerSlide.Show();
                }
                if (invisibleTime < 10)
                {
                    player.Hide();
                    playerSlide.Hide();
                    sliding = false;
                }
                if (invisibleTime >= 10 && invisibleTime < 20)
                {
                    player.Show();
                    playerSlide.Hide();
                    sliding = false;
                }
                if (invisibleTime >= 20 && invisibleTime < 30)
                {
                    playerSlide.Hide();
                    player.Hide();
                    sliding = false;
                }
                if (invisibleTime >= 30 && invisibleTime < 40)
                {
                    player.Show();
                    playerSlide.Hide();
                    sliding = false;
                }
                if (invisibleTime >= 40 && invisibleTime < 50)
                {
                    player.Hide();
                    playerSlide.Hide();
                    sliding = false;
                }
                if (invisibleTime >= 50 && invisibleTime < 60)
                {
                    player.Show();
                    playerSlide.Hide();
                    sliding = false;
                }
                if (invisibleTime >= 60 && invisibleTime < 70)
                {
                    player.Hide();
                    playerSlide.Hide();
                    sliding = false;
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
                if (question.Top - hotSauce.Top >= 100)
                {
                    hotSauce.Hide();
                }
                else
                {
                    hotSauce.Show();
                    hotSauce.Left = question.Left;
                    hotSauce.Top -= 12;
                    hotSauce.Left = question.Left;
                }
                tripleFireTime += 1;
                if (tripleFireTime > 300)
                {
                    tripleFire = false;
                    fireBall2.Hide();
                    fireBall3.Hide();
                }
            }
            else
            {
                tripleFireTime = 0;
                hotSauce.Top = question.Top;

            }

            if (noFire == true)
            {
                recharge += 1;
                flameCharge.Size = new Size(148 * recharge / 200, 27);
            }
            if (tripleFire == true)
            {
                labelFire.Text = "TRIPLE FIRE";
                labelFire.Location = new Point(872, 13);
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
                    labelFire.Text = "FIRE";
                    labelFire.Location = new Point(897, 13);
                }
            }
            if (fire == true)
            {
                fireBall.Show();
                fireBall.Left += speed * 2;
                noFire = true;
                labelFire.Text = "";

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
                    coinSound.Play();
                }
                else if (powerUps > 88 && powerUps <= 100)
                {
                    brickHide = true;
                    labelBrickHide.Text = "BRICK HIDE";
                }
                else if (powerUps <= 80 && powerUps > 60)
                {
                    tripleFire = true;
                }
                else if (powerUps > 80 && powerUps <= 88)
                {
                    heartSound.Play();
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
                if (luigi == false)
                {
                    player.Image = Properties.Resources.mexicanJump;
                }
                else
                {
                    player.Image = Properties.Resources.luigiJump;
                }
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
                if (brickHideBox.Right <= 439)
                {
                    labelBrickHide.Text = "";
                }
            }
            else { brickHideTime = 0; }
        }
    }
}
  
