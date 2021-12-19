using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace care
{
    public partial class Form2 : Form
    {
        int timerSpeed;
        int gameSpeed;
        int carTunSpeed;
        bool isGameOver;

        PictureBox[] roadlines;
        PictureBox[] enemys;
        PictureBox[] coins;
        Random random;
        int collectedCoins;

        void init_game()
        {
            timerSpeed = 100;
            gameSpeed = 4;
            carTunSpeed = 15;
            isGameOver = false;

            roadlines = new PictureBox[] { polosa, polosa1, polosa2,
                polosa3};
            enemys = new PictureBox[] { madara, obito, };
            coins = new PictureBox[] {coin,coin1,coin2,};
            random = new Random();
            collectedCoins = 0;

            gen_start_pos();



            car.Image = Properties.Resources.naruto;

            game_timer.Interval = 1000 / timerSpeed;
            game_timer.Start();

        }
        void move_enemys()
        {
            int x;
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].Top > this.Height)
                {
                    x = random.Next(polosa4.Right, polosa5.Left);
                    enemys[i].Location = new Point(x, -enemys[i].Height);
                }
                else
                {
                    enemys[i].Top += gameSpeed;
                }
            }
        }

        void move_coins()
        {
            int x;
            for(int i = 0; i < coins.Length; i++)
            {
                if(coins[i].Top > this.Height)
                {
                    x = random.Next(polosa4.Right, polosa5.Left - 
                        coins[i].Width);
                    coins[i].Location = new Point(x, -coins[i].Height);
                }
                else
                {
                    coins[i].Top += gameSpeed;
                }
            }
        }

        void move_lines()
        {
            for (int i = 0; i < roadlines.Length; i++)
            {
                if (roadlines[i].Top > this.Height)
                {
                    roadlines[i].Top = -roadlines[i].Height; 
                }
                else
                {
                    roadlines[i].Top += gameSpeed;
                }
            }

        }

        void gen_start_pos()
        {
            int startY = -obito.Height;
            int x;
            for (int i = 0; i < enemys.Length; i++)
            {
                x = random.Next(polosa4.Right, polosa5.Left);
                enemys[i].Location = new Point(x, startY);
                startY -= this.Height / enemys.Length;
            }
        }

        public Form2()
        {
            InitializeComponent();
            init_game();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void coin1_Click(object sender, EventArgs e)
        {

        }

        private void obito_Click(object sender, EventArgs e)
        {

        }

        private void game_timer_Tick(object sender, EventArgs e)
        {
            move_enemys();
            move_coins();
            move_lines();
        }
    }
}
