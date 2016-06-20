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
            //hides any unwanted pictureBoxes
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
            instructions.Hide();
            gameOverImage.Hide();
            playerDead.Hide();
            fireBall.SendToBack();
            //sets starting locations for desired pictureBoxes
            gameOverImage.Top = -200;
            question1.Location = new Point(this.Width + 300, 56);
            brick4.Location = new Point(this.Width + 500, 560);
            playerSlide.Size = new Size(99, 57);
            ground.Location = new Point(0, this.Height - ground.Height + 25);
            cactus1.Location = new Point(15, ground.Top + 7 - cactus1.Height);
            cactus2.Location = new Point(25, ground.Top + 7 - cactus2.Height);
            player.Location = new Point(150, 582);
            hotSauce.Top = question.Top;
            label1.Text = "0000000";//sets starting score to 0
            //clears text in all labels
            finalPoints.Text = "";
            labelFire.Text = "";
            labelBrickHide.Text = "";
            labelInvisibility.Text = "";
            medium = true;//sets starting difficulty to medium
            Cursor.Hide();//hides cursor
            Background bg = new Background();
            bg.Show();
            this.Focus();
        }
        Random randNum = new Random();
        bool gifnotloaded;//reloads the gif so it keeps running
        bool jump, doubleJump, sliding;//different movements player can perform
        int force;
        int G = 33;//force of gravity on player
        bool onBrick;//if player lands on a brick
        bool start;//game has started
        bool fire;//fire button has been pressed
        bool noFire;//can not fire  until recharged
        int recharge;
        //player lives
        bool live1 = true;
        bool live2 = true;
        bool live3 = true;
        bool extraHeart;
        bool settings, showInstructions, difficulty, character;//options in start menu
        bool luigi;//character 
        bool easy, medium, hard;//difficulties
        bool pause;
        bool countDown;

        //sounds used throuhout game
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
            powerUps = randNum.Next(2, 100);//randon number for powerUps inside box

          
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
                        pauseSound.Play();
                        pause1.Show();
                        pause = true;
                        speed = 0;//sets speed to 0 so nothing will move
                        if (player.Top == ground.Top - player.Height)//if player is on the ground
                        {
                            if (luigi == false)//sets the correct image depending on what character the player chose
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
                        pauseSound.Play();
                        pause1.Hide();
                        pause = false;
                        if (luigi == false)//sets the correct image depending on what character the player chose
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
                //closes the form
                if (e.KeyCode == Keys.M)
                {
                    this.Close();
                }
            }

           
            //play game has not been clicked
            if (start == false)
            {
                player.Location = new Point(150, 582);//sets starting location for player

                //options at start menu
                if (e.KeyCode == Keys.Space)
                {
                    if (selector.Top == 400)
                    {
                        if (difficulty == false)//if not on difficulties game begins
                        {
                            player.Show();
                            selector.Hide();
                            labelFire.Text = "FIRE";
                            countDown = true;
                           
                        }
                        else//easy difficulty is chosen
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
                            settings = true;//setting are clicked
                        }
                        else
                        {
                            easy = false;
                            medium = true;//medium difficulty is chosen
                            hard = false;
                            difficulty = false;
                            settings = true;
                            selector.Top = 420;
                        }
                    }
                    else if (selector.Top == 480)
                    {
                        selectSound.Play();
                        if (difficulty == false)//instructions are clicked
                        {
                            selections.Hide();
                            instructions.Show();//shows instructions
                            instructions.Size = new Size(1068, 657);
                            instructions.Location = new Point(this.Width / 2 - instructions.Width / 2, this.Height / 2 - instructions.Height / 2 - 5);
                            showInstructions = true;
                        }
                        else
                        {
                            easy = false;
                            medium = false;
                            hard = true;//hard difficulty is chosen
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
                            difficulty = true;//difficulties are chosen
                            settings = false;
                            selector.Top = 400;
                        }
                        else
                        {
                            settings = true;
                            character = false;
                            luigi = false;//character juan is chosen
                        }
                    }
                    else if (selector.Top == 460)
                    {
                        selectSound.Play();
                        if (character == true)
                        {
                            luigi = true;//charcater luigi is chosen
                            character = false;
                            settings = true;
                        }
                        else
                        {
                            settings = false;
                            character = true;//character tab is chosen
                        }
                    }
                }
                if (character == true)//selector movement while in character tab
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
                        player.Image = Properties.Resources.mexicanStanding;//sets correct character
                    }
                    if (selector.Top == 460)
                    {
                        player.Image = Properties.Resources.luigiStanding;//sets correct character
                    }
                }
                if (settings == false && character == false)//selector movement while in difficulty tab
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
                if (settings == true)//selector movement while in settings tab
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
                if (e.KeyCode == Keys.M)//goes back to the correct selection depending on which tab you are in
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
            if (restart == false && start != false && pause == false || gameOver == false && start != false && pause == false)//keys only work while game has started
            {
                if (e.KeyCode == Keys.B)
                {
                    sliding = true;//player slides
                    if (luigi == false)//sets correct player image
                    {
                        playerSlide.Image = Properties.Resources.marioSliding;
                    }
                    else
                    {
                        playerSlide.Image = Properties.Resources.luigiSliding;
                    }
                }
                if (e.KeyCode == Keys.M && noFire == false)//if fireBall recharge is full
                {
                    fireBallSound.Play();
                    fire = true;//fireBall is launched
                    recharge = 0;
                    flameCharge.Size = new Size(0, 0);
                }
                if (jump != true)// if player is not jumping
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        jumpSound.Play();
                        jump = true;//player jumps
                        force = G;//force of gravity is set
                        if (luigi == false)//sets correct player image
                        {
                            player.Image = Properties.Resources.mexicanJump;
                        }
                        else
                        {
                            player.Image = Properties.Resources.luigiJump;
                        }
                    }
                }
                else if (doubleJump != true)//if player has not double jumped
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        doubleJumpSound.Play();
                        doubleJump = true;//player double jumps
                        force = G;
                    }
                }
            }
        }
        private void superJuanBros_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B)//once key is release player no longer slides
            {
                sliding = false;
                gifnotloaded = true;
                player.Show();
                playerSlide.Hide();
            }
            if (e.KeyCode == Keys.Space)
            {
                gifnotloaded = true;//resets gif so it repeats
            }
        }
        int xValue;
        int chanceValue;
        int score;
        int[] locations = { 560, 497, 434, 371, 308, 245, 182, 119, 56 };//list of random set locations for bricks to reappear 
        int speed = 10;
        bool lose, gameOver, restart;
        int powerUps;

        //all available powerUps
        bool invisible;
        bool tripleFire;
        bool coinUp;
        bool brickHide;
        int points;
        int invisibleTime, tripleFireTime, brickHideTime;
        int x = 2500;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (countDown == true)//after game has been started it waits a certain amount of time
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (i == 3)
                    {
                        start = true;//game is started
                        lose = false;//lives are reset
                        restart = false;
                        selections.Hide();
                        player.Location = new Point(150, 560);//new location for player
                        countDown = false;//countdown is done
                    }
                    Refresh();
                }
            }

            if (pause != true)
            {
                //selections at main menu
                //changes pictureBox image, size and location
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
                    if (hard == true)//if hard difficulty is chosen
                    {
                        xValue = randNum.Next(this.Width, x);//respawns bricks closer together
                        if (x >= 1300)
                        {
                            x = 1800 - points / 70;
                        }
                        else { x = 1300; }

                        if (speed <= 14)//increases speed according to score
                        {
                            speed = 12 + points / 1000;
                        }
                        else { speed = 14; }
                    }
                    else if (medium == true)//medium difficulty
                    {
                        xValue = randNum.Next(this.Width, x);
                        if (x >= 1800)//respawns bricks closer together
                        {
                            x = 2500 - points / 60;
                        }
                        else { x = 1800; }

                        if (speed <= 13)//increases speed according to score
                        {
                            speed = 10 + points / 1500;
                        }
                        else { speed = 13; }
                    }
                    else if (easy == true)
                    {
                        xValue = randNum.Next(this.Width, 2800);
                        brick3.Hide();//hides one of the bricks so it is never shown
                        brick3.Top = this.Height;
                        if (speed <= 13)//increases speed according to score
                        {
                            speed = 10 + points / 1500;
                        }
                        else { speed = 13; }
                    }

                    if (lose == true)//if player loses a life
                    {
                        if (live1 == true)//first life
                        {
                            playerHitSound.Play();
                            heart1.Hide();
                            live1 = false;
                            lose = false;
                            labelInvisibility.Text = "INVISIBILITY";
                            invisible = true;//character is invisble 
                        }
                        else if (live2 != false && live1 == false)//second life
                        {
                            playerHitSound.Play();
                            heart2.Hide();
                            live2 = false;
                            lose = false;
                            labelInvisibility.Text = "INVISIBILITY";
                            invisible = true;
                        }
                        else if (live3 != false && live2 == false)//third and last life
                        {
                            invisible = true;
                            speed = 0;
                            heart3.Hide();
                            if (player.Top == ground.Top - player.Height)//if player is on the ground, Game Over
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
                    points += 1;//score increases by one each 0.25 seconds

                    playerUps();

                    brickMovement();
                    brickRespawning();

                    playerSlide.Top = player.Top + playerSlide.Height - 7;//location for when player is sliding
                    if (jump == true)
                    {
                        player.Top -= force;//player decreases due to gravity
                        force -= 2;
                    }
                    else if (gifnotloaded == true)//resets gif so it keeps repeating
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
                    slideBorders(cactus1);
                    slideBorders(cactus2);

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
        /// <summary>
        /// sets what occurs when all lives are lost
        /// </summary>
        public void gameOverMethod()
        {
            if (gameOver == true)//all lives are lost
            {
                pause = false;
                tripleFire = false;
                points -= 1;//score does not change
                speed = 0;//no bricks are moving
                playerDead.Show();//shows player dead
                //hides the bricks
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
                //sets desired locations for pictureBoxes
                player.Location = new Point(150, 582);
                brick.Location = new Point(199, 239);
                brick2.Location = new Point(256, 112);
                brick3.Location = new Point(295, 170);
                question1.Location = new Point(this.Width + 300, 56);
                brick4.Location = new Point(this.Width + 500, 560);
                cactus1.Location = new Point(15, -40);
                cactus2.Location = new Point(15, -40);
                if (luigi == false)//shows correct character dead
                {
                    playerDead.Image = Properties.Resources.marioDead;
                }
                else
                {
                    playerDead.Image = Properties.Resources.luigiDead;
                }
                gameOverImage.Show();
                if (gameOverImage.Top == -200)
                {
                    dieSound.Play();
                }
                if (gameOverImage.Top <= 103)//gameOver sign flies down from above
                {
                    gameOverImage.Top += 5;
                }
                else
                {
                    finalPoints.Text = points.ToString("0000000");//shows score

                    for (int i = 1; i <= 80; i++)//waits a certain amount of time until game is automatically restarted
                    {
                        if (i == 80)
                        {
                            gameOver = false;
                            restart = true;//allows you to restart a new game
                        }
                        Refresh();
                    }

                }
            }
        }
        /// <summary>
        /// sets what occurs after player lost and game is reset
        /// </summary>
        public void restartMethod()
        {
            if (restart == true)//if gameOver it restart
            {
                //resets all varialble and pictureBox locations
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
                //all lives are reset
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
        /// <summary>
        /// sets borders for the question mark box
        /// </summary>
        /// <param name="x">question mark pictureBox</param>
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
            //if bottom of brick is hit player loses a life
            if (invisible == false && player.Right > x.Left && player.Left < x.Right && player.Top - x.Bottom <= 20 && player.Top - x.Top > -20)
            {
                lose = true;
            }
        }
        /// <summary>
        /// sets borders for brick1
        /// </summary>
        /// <param name="x">brick1 pictureBox</param>
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
            else { onBrick = false; }//charcater is not on the brick

            // if bottom of brick is hit player flies down
            if (invisible == false && player.Right > x.Left && player.Left < x.Right && player.Top - x.Bottom <= 20 && player.Top - x.Top > -20)
            {
                force = -6;
            }
            //if spike is hit player loses a life
            if (invisible == false && sliding == false && player.Right >= x.Left - 5 && player.Left < x.Right && player.Top < x.Bottom && player.Bottom > x.Top)
            {
                lose = true;
            }
        }
        /// <summary>
        /// sets borders for brick2 and question mark box
        /// </summary>
        /// <param name="x">brick2 and question mark box</param>
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
            //game at start moves out of screen once game begins
            if (gameSign.Right > 0)
            {
                gameSign.Left -= 4;
            }
        }
        /// <summary>
        /// sets borders for brick3
        /// </summary>
        /// <param name="x">brick3</param>
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

            // if player lands on brick on top he loses a life
            if (invisible == false && sliding == false && player.Top < x.Top && player.Top + player.Height >= x.Top + 12 && player.Right >= brick3.Left && player.Left <= brick3.Right - 90)
            {
                lose = true;
            }
            //if player stands up while underneath the brick
            if (invisible == false && sliding == false && player.Top <= brick3.Top+25 && player.Bottom >= brick3.Bottom && player.Right >= brick3.Left && player.Left <= brick3.Right)
            {
                lose = true;
            }
        }
        /// <summary>
        /// sets borders for brick4
        /// </summary>
        /// <param name="x">brick4</param>
        public void borders4(PictureBox x)
        {
            // if top of brick is touched player loses a life
            if (invisible == false && sliding == false && player.Bottom >= x.Top + 10 && player.Top + 10 < x.Bottom && player.Right >= x.Left - 4 && player.Left < x.Right)
            {
                lose = true;
            }
            if (invisible == false && player.Right > brick4.Left && player.Left < brick4.Right && player.Top - brick4.Bottom <= 15 && player.Top - brick4.Top > -15)
            {
                force = -6;
            }
        }
        /// <summary>
        /// if player slides and hits any pictureBox spike he loses a life
        /// </summary>
        /// <param name="x">any pictureBox containing spikes</param>
        public void slideBorders(PictureBox x)
        {
            if (sliding == true && playerSlide.Top <= x.Bottom && playerSlide.Bottom >= x.Top + 7 && playerSlide.Right >= x.Left && playerSlide.Left <= x.Right)
            {
                lose = true;
            }
        }
        /// <summary>
        /// sets what occurs when a fireBall touches any pictureBox
        /// </summary>
        /// <param name="x">all pictureBoxes such as the bricks</param>
        public void fireContact(PictureBox x)
        {
            //if brick is hit it dissapears
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
            //once pictureBox is past the left side of screen it is shown
            if (x.Left >= this.Width)
            {
                x.Show();
            }
        }
        /// <summary>
        /// sets what occurs when the pictureBoxes are passed the left side of screen
        /// </summary>
        public void brickRespawning()
        {
            if (ground.Right <= this.Width)
            {
                ground.Left = -5;
            }
            //once brick leaves screen it randomly respawns at one of the 8 specified locations
            if (score < 2)//ensures none of the bricks overlap eachother
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
        /// <summary>
        /// sets what occurs when a powerUp question box is hit
        /// </summary>
        public void playerUps()
        {
            //extra heart powerUp
            if (extraHeart == true)
            {
                //adds one life if necessary
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
            //coin movement when box is hit
            if (coinUp == true)
            {
                coin.Show();
                coin.Left = question.Left;
                coin.Top -= 12;
                if (question.Top - coin.Top >= 80)//dissapears once it gets too high
                {
                    coin.Hide();
                    coinUp = false;
                }
            }
            else
            {//resets itself once hidden
                coin.Top = question.Top;
                coin.Left = question.Left;
            }

            //ivisibility timer for when life is lost    
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
                if (sliding == false)
                {
                    //makes player blink after a life is lost
                    if (invisibleTime < 10)
                    {
                        player.Hide();
                        sliding = false;
                    }
                    if (invisibleTime >= 10 && invisibleTime < 20)
                    {
                        player.Show();
                        sliding = false;
                    }
                    if (invisibleTime >= 20 && invisibleTime < 30)
                    {
                        player.Hide();
                        sliding = false;
                    }
                    if (invisibleTime >= 30 && invisibleTime < 40)
                    {
                        player.Show();
                        sliding = false;
                    }
                    if (invisibleTime >= 40 && invisibleTime < 50)
                    {
                        player.Hide();
                        sliding = false;
                    }
                    if (invisibleTime >= 50 && invisibleTime < 60)
                    {
                        player.Show();
                        sliding = false;
                    }
                    if (invisibleTime >= 60 && invisibleTime < 70)
                    {
                        player.Hide();
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
            }
            else { invisibleTime = 0; }

            //triplefire timer     
            if (tripleFire == true)
            {
                //movement for hotsauce 
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
                //timer for how long powerUp goes on for
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
            // once fireBall is shot time must be waited till you can shoot again
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
                    flameCharge.Size = new Size(148 * fireBall.Left / this.Width, 27);//fireBar
                }
                else { flameCharge.Size = new Size(148, 27); }
            }
            else
            {
                if (recharge == 200)//fire is recharged and player can shoot
                {
                    noFire = false;
                    labelFire.Text = "FIRE";
                    labelFire.Location = new Point(897, 13);
                }
            }
            if (fire == true)//fireBall is shot
            {
                fireBall.Show();
                fireBall.Left += speed * 2;
                noFire = true;
                labelFire.Text = "";

                if (tripleFire == true)//three fireBalls are shown
                {
                    fireBall2.Show();
                    fireBall3.Show();
                    fireBall2.Left = fireBall.Left;
                    fireBall3.Left = fireBall.Left;
                }
                if (fireBall.Left > this.Width)//once it leaves the screen it resets 
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

            //if bottom of question mark powerUp box is hit
            if (invisible == false && player.Right > question.Left && player.Left < question.Right && player.Top - question.Bottom <= 20 && player.Top - question.Top > -20)
            {
                //extra points
                if (powerUps <= 60)//chance of getting this powerUp
                {
                    points += 1000;
                    coinUp = true;
                    coinSound.Play();
                }
                else if (powerUps > 88 && powerUps <= 100)//hidden bricks powerUp
                {
                    brickHide = true;
                    labelBrickHide.Text = "BRICK HIDE";
                }
                else if (powerUps <= 80 && powerUps > 60)//tripleFire powerUp
                {
                    tripleFire = true;
                }
                else if (powerUps > 80 && powerUps <= 88)//extra life is earned
                {
                    heartSound.Play();
                    extraHeart = true;
                }
            }
        }
        /// <summary>
        /// sets physics for when player lands on a brick or the ground
        /// </summary>
        public void landingBrick()
        {
            if (player.Top >= ground.Top - player.Height)//if player is ground
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
            //falling off brick without jumping
            else if (onBrick == false && jump == false)
            {
                jump = true;
                player.Top += 12;
                //sets jumping image for player while falling
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
            if (onBrick == true)//player can slide if it is on a brick
            {
                if (sliding == true)
                {
                    playerSlide.Show();
                    player.Hide();
                }
            }
        }
        /// <summary>
        /// movement for all brick and pictureBoxes while game is playing
        /// </summary>
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
        /// <summary>
        /// sets what occurs when the hide powerUp is aquired
        /// </summary>
        /// <param name="x">all bricks/ pictureBoxes on screen</param>
        public void hidePowerUp(PictureBox x)
        {
            if (brickHide == true)
            {
                //hides all bricks
                x.Hide();
                x.Top = this.Width;
                brickHideBox.Show();
                brickHideBack.Show();
                brickHideBox.Size = new Size(148 - 180 * brickHideTime / 1000, 27);//powerUp timer bar
                brickHideTime += 1;
                if (brickHideTime > 800)//sets how long the powerUp lasts
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

