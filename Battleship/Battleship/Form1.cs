using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Label[,] map1, map2;
        int SIDE = 1;
        bool player1_ready = false, player2_ready = false;

        private void start_button_Click(object sender, EventArgs e)
        {
            SIDE = 1;
            player1_ready = false;
            player2_ready = false;

            ready1.Enabled = ready2.Enabled = true;
            ready1.Visible = ready2.Visible = true;

            menu.Enabled = false;
            menu.Visible = false;

            title.Enabled = false;
            title.Visible = false;

            start_button.Enabled = false;
            start_button.Visible = false;

            quit_button.Enabled = false;
            quit_button.Visible = false;

            map1 = new Label[,]
            {
                { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 },
                { label11, label12, label13, label14, label15, label16, label17, label18, label19, label20 },
                { label21, label22, label23, label24, label25, label26, label27, label28, label29, label30 },
                { label31, label32, label33, label34, label35, label36, label37, label38, label39, label40 },
                { label41, label42, label43, label44, label45, label46, label47, label48, label49, label50 },
                { label51, label52, label53, label54, label55, label56, label57, label58, label59, label60 },
                { label61, label62, label63, label64, label65, label66, label67, label68, label69, label70 },
                { label71, label72, label73, label74, label75, label76, label77, label78, label79, label80 },
                { label81, label82, label83, label84, label85, label86, label87, label88, label89, label90 },
                { label91, label92, label93, label94, label95, label96, label97, label98, label99, label100 },
            };

            map2 = new Label[,]
            {
                { label240, label239, label238, label237, label236, label231, label232, label233, label234, label235 },
                { label221, label222, label223, label224, label225, label226, label227, label228, label229, label230 },
                { label211, label212, label213, label214, label215, label216, label217, label218, label219, label220 },
                { label201, label202, label203, label204, label205, label206, label207, label208, label209, label210 },
                { label191, label192, label193, label194, label195, label196, label197, label198, label199, label200 },
                { label181, label182, label183, label184, label185, label186, label187, label188, label189, label190 },
                { label171, label172, label173, label174, label175, label176, label177, label178, label179, label180 },
                { label161, label162, label163, label164, label165, label166, label167, label168, label169, label170 },
                { label151, label152, label153, label154, label155, label156, label157, label158, label159, label160 },
                { label141, label142, label143, label144, label145, label146, label147, label148, label149, label150 },
            };

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map1[i, j].Text = map2[i, j].Text = "";
                    map1[i, j].BackColor = map2[i, j].BackColor = Color.Silver;
                    map1[i, j].Tag = map2[i, j].Tag = "";
                }
            }

            timer1.Enabled = true;
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void ready1_Click(object sender, EventArgs e)
        {
            ready1.BackColor = Color.Green;
            txtPlayer1.ForeColor = Color.Red;
            txtPlayer2.ForeColor = Color.Green;
            player1_ready = true;
            SIDE = 2;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map1[i, j].BackColor = Color.Silver;
                }
            }
            ready1.Enabled = false;
            ready1.Visible = false;
        }

        private void ready2_Click(object sender, EventArgs e)
        {
            ready2.BackColor = Color.Green;
            txtPlayer2.ForeColor = Color.Red;
            txtPlayer1.ForeColor = Color.Green;
            player2_ready = true;
            SIDE = 1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map2[i, j].BackColor = Color.Silver;
                }
            }
            ready2.Enabled = false;
            ready2.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            int x = 0, y = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (label == map1[i, j])
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            if (!player1_ready && SIDE == 1)
            {
                label.BackColor = Color.Red;
                label.Tag = "X";
            }
            else if (player1_ready && player2_ready && label.Text == "" && label.BackColor == Color.Silver && SIDE == 2)
            {
                if (label.Tag == "X")
                {
                    label.BackColor = Color.Red;
                    label.Tag = "";
                    bool destroyed = true;
                    if (x - 1 >= 0 && map1[x - 1, y].Tag == "X")
                        destroyed = false;
                    else if (x + 1 < 10 && map1[x + 1, y].Tag == "X")
                        destroyed = false;
                    else if (y + 1 < 10 && map1[x, y + 1].Tag == "X")
                        destroyed = false;
                    else if (y - 1 >= 0 && map1[x, y - 1].Tag == "X")
                        destroyed = false;
                    if (destroyed)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (map1[i, j].BackColor == Color.Red)
                                {
                                    map1[i, j].BackColor = Color.DarkRed;
                                    map1[i, j].Tag = "";
                                }
                            }
                        }
                    }
                }
                else
                {
                    label.Text = "X";
                    SIDE = 1;
                }
                if (SIDE == 1)
                {
                    txtPlayer1.ForeColor = Color.Green;
                    txtPlayer2.ForeColor = Color.Red;
                }
            }
        }

        private void label1r_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            int x = 0, y = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (label == map2[i, j])
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            if (!player2_ready && SIDE == 2)
            {
                label.BackColor = Color.Red;
                label.Tag = "X";
            }
            else if (player1_ready && player2_ready && label.Text == "" && label.BackColor == Color.Silver && SIDE == 1)
            {
                if (label.Tag == "X")
                {
                    label.BackColor = Color.Red;
                    label.Tag = "";
                    bool destroyed = true;
                    if (x - 1 >= 0 && map2[x - 1, y].Tag == "X")
                        destroyed = false;
                    else if (x + 1 < 10 && map2[x + 1, y].Tag == "X")
                        destroyed = false;
                    else if (y + 1 < 10 && map2[x, y + 1].Tag == "X")
                        destroyed = false;
                    else if (y - 1 >= 0 && map2[x, y - 1].Tag == "X")
                        destroyed = false;
                    if (destroyed)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (map2[i, j].BackColor == Color.Red)
                                {
                                    map2[i, j].BackColor = Color.DarkRed;
                                    map2[i, j].Tag = "";
                                }
                            }
                        }
                    }
                }
                else
                {
                    label.Text = "X";
                    SIDE = 2;
                }
                if (SIDE == 2)
                {
                    txtPlayer1.ForeColor = Color.Red;
                    txtPlayer2.ForeColor = Color.Green;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player1_ready && player2_ready)
            {
                bool win1 = true, win2 = true;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (map1[i, j].Tag == "X")
                            win2 = false;
                        if (map2[i, j].Tag == "X")
                            win1 = false;
                    }
                }
                if (win1)
                    gameOver(1);
                if (win2)
                    gameOver(2);
            }
        }

        private void gameOver(int player)
        {
            timer1.Enabled = false;

            menu.Enabled = true;
            menu.Visible = true;

            if (player == 1)
                title.Text = "Player1 Wins!";
            else
                title.Text = "Player2 Wins!";
            title.Enabled = true;
            title.Visible = true;

            start_button.Text = "Play Again";
            start_button.Enabled = true;
            start_button.Visible = true;

            quit_button.Enabled = true;
            quit_button.Visible = true;
        }
    }
}
