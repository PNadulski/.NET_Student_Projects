namespace Samochody
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.distance = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pojazdLewy = new System.Windows.Forms.PictureBox();
            this.przeszkodaLewy = new System.Windows.Forms.PictureBox();
            this.pojazdPrawy = new System.Windows.Forms.PictureBox();
            this.pojazdSrodkowy = new System.Windows.Forms.PictureBox();
            this.przeszkodaPrawy = new System.Windows.Forms.PictureBox();
            this.przeszkodaSrodkowy = new System.Windows.Forms.PictureBox();
            this.roadTrack1 = new System.Windows.Forms.PictureBox();
            this.roadTrack2 = new System.Windows.Forms.PictureBox();
            this.SI1 = new System.Windows.Forms.PictureBox();
            this.SI2 = new System.Windows.Forms.PictureBox();
            this.SI3 = new System.Windows.Forms.PictureBox();
            this.explosion = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.trophy = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pojazdLewy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.przeszkodaLewy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pojazdPrawy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pojazdSrodkowy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.przeszkodaPrawy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.przeszkodaSrodkowy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SI3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trophy)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(409, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(404, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dystans:";
            // 
            // distance
            // 
            this.distance.AutoSize = true;
            this.distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.distance.Location = new System.Drawing.Point(504, 10);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(38, 26);
            this.distance.TabIndex = 2;
            this.distance.Text = "00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pojazdLewy);
            this.panel1.Controls.Add(this.przeszkodaLewy);
            this.panel1.Controls.Add(this.pojazdPrawy);
            this.panel1.Controls.Add(this.pojazdSrodkowy);
            this.panel1.Controls.Add(this.przeszkodaPrawy);
            this.panel1.Controls.Add(this.przeszkodaSrodkowy);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 489);
            this.panel1.TabIndex = 4;
            // 
            // pojazdLewy
            // 
            this.pojazdLewy.BackColor = System.Drawing.Color.Transparent;
            this.pojazdLewy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pojazdLewy.Location = new System.Drawing.Point(46, 328);
            this.pojazdLewy.Name = "pojazdLewy";
            this.pojazdLewy.Size = new System.Drawing.Size(80, 100);
            this.pojazdLewy.TabIndex = 14;
            this.pojazdLewy.TabStop = false;
            this.pojazdLewy.Visible = false;
            // 
            // przeszkodaLewy
            // 
            this.przeszkodaLewy.BackColor = System.Drawing.Color.Transparent;
            this.przeszkodaLewy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.przeszkodaLewy.Location = new System.Drawing.Point(46, 0);
            this.przeszkodaLewy.Name = "przeszkodaLewy";
            this.przeszkodaLewy.Size = new System.Drawing.Size(80, 410);
            this.przeszkodaLewy.TabIndex = 13;
            this.przeszkodaLewy.TabStop = false;
            this.przeszkodaLewy.Visible = false;
            // 
            // pojazdPrawy
            // 
            this.pojazdPrawy.BackColor = System.Drawing.Color.Transparent;
            this.pojazdPrawy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pojazdPrawy.Location = new System.Drawing.Point(273, 328);
            this.pojazdPrawy.Name = "pojazdPrawy";
            this.pojazdPrawy.Size = new System.Drawing.Size(80, 100);
            this.pojazdPrawy.TabIndex = 14;
            this.pojazdPrawy.TabStop = false;
            this.pojazdPrawy.Visible = false;
            // 
            // pojazdSrodkowy
            // 
            this.pojazdSrodkowy.BackColor = System.Drawing.Color.Transparent;
            this.pojazdSrodkowy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pojazdSrodkowy.Location = new System.Drawing.Point(154, 328);
            this.pojazdSrodkowy.Name = "pojazdSrodkowy";
            this.pojazdSrodkowy.Size = new System.Drawing.Size(80, 100);
            this.pojazdSrodkowy.TabIndex = 14;
            this.pojazdSrodkowy.TabStop = false;
            this.pojazdSrodkowy.Visible = false;
            // 
            // przeszkodaPrawy
            // 
            this.przeszkodaPrawy.BackColor = System.Drawing.Color.Transparent;
            this.przeszkodaPrawy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.przeszkodaPrawy.Location = new System.Drawing.Point(273, 0);
            this.przeszkodaPrawy.Name = "przeszkodaPrawy";
            this.przeszkodaPrawy.Size = new System.Drawing.Size(80, 410);
            this.przeszkodaPrawy.TabIndex = 14;
            this.przeszkodaPrawy.TabStop = false;
            this.przeszkodaPrawy.Visible = false;
            // 
            // przeszkodaSrodkowy
            // 
            this.przeszkodaSrodkowy.BackColor = System.Drawing.Color.Transparent;
            this.przeszkodaSrodkowy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.przeszkodaSrodkowy.Location = new System.Drawing.Point(154, 0);
            this.przeszkodaSrodkowy.Name = "przeszkodaSrodkowy";
            this.przeszkodaSrodkowy.Size = new System.Drawing.Size(80, 410);
            this.przeszkodaSrodkowy.TabIndex = 14;
            this.przeszkodaSrodkowy.TabStop = false;
            this.przeszkodaSrodkowy.Visible = false;
            // 
            // roadTrack1
            // 
            this.roadTrack1.BackColor = System.Drawing.Color.Black;
            this.roadTrack1.Image = global::Samochody.Properties.Resources.Droga;
            this.roadTrack1.Location = new System.Drawing.Point(10, -638);
            this.roadTrack1.Name = "roadTrack1";
            this.roadTrack1.Size = new System.Drawing.Size(385, 632);
            this.roadTrack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roadTrack1.TabIndex = 5;
            this.roadTrack1.TabStop = false;
            // 
            // roadTrack2
            // 
            this.roadTrack2.BackColor = System.Drawing.Color.Black;
            this.roadTrack2.Image = global::Samochody.Properties.Resources.Droga;
            this.roadTrack2.Location = new System.Drawing.Point(10, -222);
            this.roadTrack2.Name = "roadTrack2";
            this.roadTrack2.Size = new System.Drawing.Size(385, 691);
            this.roadTrack2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roadTrack2.TabIndex = 6;
            this.roadTrack2.TabStop = false;
            // 
            // SI1
            // 
            this.SI1.BackColor = System.Drawing.Color.Black;
            this.SI1.Image = global::Samochody.Properties.Resources.auto1;
            this.SI1.Location = new System.Drawing.Point(60, 10);
            this.SI1.Name = "SI1";
            this.SI1.Size = new System.Drawing.Size(50, 100);
            this.SI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SI1.TabIndex = 7;
            this.SI1.TabStop = false;
            // 
            // SI2
            // 
            this.SI2.BackColor = System.Drawing.Color.Black;
            this.SI2.Image = global::Samochody.Properties.Resources.auto4;
            this.SI2.Location = new System.Drawing.Point(175, 10);
            this.SI2.Name = "SI2";
            this.SI2.Size = new System.Drawing.Size(50, 100);
            this.SI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SI2.TabIndex = 8;
            this.SI2.TabStop = false;
            // 
            // SI3
            // 
            this.SI3.BackColor = System.Drawing.Color.Black;
            this.SI3.Image = global::Samochody.Properties.Resources.auto7;
            this.SI3.Location = new System.Drawing.Point(290, 10);
            this.SI3.Name = "SI3";
            this.SI3.Size = new System.Drawing.Size(50, 100);
            this.SI3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SI3.TabIndex = 9;
            this.SI3.TabStop = false;
            // 
            // explosion
            // 
            this.explosion.BackColor = System.Drawing.Color.Black;
            this.explosion.Image = global::Samochody.Properties.Resources.explozja;
            this.explosion.Location = new System.Drawing.Point(168, 320);
            this.explosion.Name = "explosion";
            this.explosion.Size = new System.Drawing.Size(64, 64);
            this.explosion.TabIndex = 10;
            this.explosion.TabStop = false;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Black;
            this.player.Image = global::Samochody.Properties.Resources.auto8;
            this.player.Location = new System.Drawing.Point(175, 330);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(50, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 11;
            this.player.TabStop = false;
            // 
            // trophy
            // 
            this.trophy.BackColor = System.Drawing.Color.Transparent;
            this.trophy.Image = global::Samochody.Properties.Resources.bronze;
            this.trophy.Location = new System.Drawing.Point(80, 210);
            this.trophy.Name = "trophy";
            this.trophy.Size = new System.Drawing.Size(250, 100);
            this.trophy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.trophy.TabIndex = 12;
            this.trophy.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.Maroon;
            this.button2.Location = new System.Drawing.Point(409, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 73);
            this.button2.TabIndex = 13;
            this.button2.Text = "Wczytaj dane";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.ForeColor = System.Drawing.Color.Maroon;
            this.button3.Location = new System.Drawing.Point(409, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 82);
            this.button3.TabIndex = 14;
            this.button3.Text = "SI Gra smodzielnie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer4
            // 
            this.timer4.Interval = 10;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Tai Le", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.ForeColor = System.Drawing.Color.Maroon;
            this.button4.Location = new System.Drawing.Point(409, 348);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 82);
            this.button4.TabIndex = 15;
            this.button4.Text = "Przerwij grę SI";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Poziom błędu SSN:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(581, 470);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.trophy);
            this.Controls.Add(this.SI1);
            this.Controls.Add(this.SI3);
            this.Controls.Add(this.SI2);
            this.Controls.Add(this.player);
            this.Controls.Add(this.explosion);
            this.Controls.Add(this.roadTrack1);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.roadTrack2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(597, 509);
            this.MinimumSize = new System.Drawing.Size(597, 509);
            this.Name = "Form1";
            this.Text = "Samochody";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.moveCar);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pojazdLewy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.przeszkodaLewy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pojazdPrawy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pojazdSrodkowy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.przeszkodaPrawy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.przeszkodaSrodkowy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SI3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trophy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox roadTrack1;
        private System.Windows.Forms.PictureBox roadTrack2;
        private System.Windows.Forms.PictureBox SI1;
        private System.Windows.Forms.PictureBox SI2;
        private System.Windows.Forms.PictureBox SI3;
        private System.Windows.Forms.PictureBox explosion;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox trophy;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox przeszkodaLewy;
        private System.Windows.Forms.PictureBox pojazdPrawy;
        private System.Windows.Forms.PictureBox pojazdSrodkowy;
        private System.Windows.Forms.PictureBox pojazdLewy;
        private System.Windows.Forms.PictureBox przeszkodaPrawy;
        private System.Windows.Forms.PictureBox przeszkodaSrodkowy;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

