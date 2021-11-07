﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRex
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int jumpingSpeed = 10;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rnd = new Random();


        public Form1()
        {
            InitializeComponent();

            resetGame();
        }

        private void gameEvent(object sender, EventArgs e)
        {
            trex.Top += jumpingSpeed;
            scoreText.Text = "Score: " + score;
            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (jumping)
            {
                jumpingSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpingSpeed = 12;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left + x.Width < -120)
                    {
                        x.Left = this.ClientSize.Width + rnd.Next(200, 800);
                        score++;
                    }

                    if (trex.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer1.Enabled = false;
                        trex.Image = Properties.Resources.dead;
                        scoreText.Text += "Press R to restart";
                    }
                }
            }

            if (trex.Top >= 380 && !jumping)
            {
                force = 12;
                trex.Top = floor.Top - trex.Height;
                jumpingSpeed = 0;
            }

            if (score >= 10)
            {
                obstacleSpeed = 15;
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                resetGame();
            }

            if (jumping)
            {
                jumping = false;
            }
        }

        public void resetGame()
        {
            force = 12;
            trex.Top = floor.Top - trex.Height;
            jumpingSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            scoreText.Text = "Score: " + score;
            trex.Image = Properties.Resources.running;

            foreach ( Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "obstacle")
                {
                    int position = rnd.Next(600, 1000);
                    x.Left = 640 + (x.Left + position + x.Width * 3);
                }
            }
            timer1.Enabled = true;
        }
    }
}
