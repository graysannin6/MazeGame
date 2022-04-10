using MazeFinalProject.Classes;
using MazeFinalProject.Classes.Entities;
using MazeFinalProject.PathFinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeFinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameManager.Start_Game();
            this.pictureBox1.Width = Map.Max_columns * Map.Tile_size;
            this.pictureBox1.Height = Map.Max_rows * Map.Tile_size;

            int width = Map.Max_columns * Map.Tile_size;
            int height = Map.Max_rows * Map.Tile_size + (this.pictureBox1.Location.Y);
            this.ClientSize = new Size(width, height);
        }





        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            foreach (AbstractEntity obj in Map.matrix_entities)
            {
                obj.Draw(e.Graphics);
            }
            
            foreach (Batman batman in GameManager.ListBatman)
            {
                if (!batman.eaten)
                {
                    batman.Draw(e.Graphics);
                }
               
            }
           
            
            foreach (Harley harley1 in GameManager.ListHarley)
            {
                    if (!harley1.eaten)
                    {
                        harley1.Draw(e.Graphics);
                    }
            }
        
            GameManager.joker.Draw(e.Graphics);


            label_Destroyer.Text = GameManager.joker.WallDestroyers.ToString();
            label_Energy.Text = GameManager.joker.Energy.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    GameManager.joker.Current_Direction = Direction.UP;
                    break;
                case Keys.Down:
                    GameManager.joker.Current_Direction = Direction.DOWN;
                    break;
                case Keys.Left:
                    GameManager.joker.Current_Direction = Direction.LEFT;
                    break;
                case Keys.Right:
                    GameManager.joker.Current_Direction = Direction.RIGHT;
                    break;
                default:
                    GameManager.joker.Current_Direction = Direction.NONE;
                    break;
            }
            GameManager.joker.Move();
            this.pictureBox1.Refresh();
        }
    }
}
   
