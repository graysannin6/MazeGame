using MazeFinalProject.PathFinding;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFinalProject.Classes.Entities
{
    public class Joker : AbstractEntity
    {
        private int wallDestroyers;
        private Direction current_Direction;
        private static string[] image_files = { "Joker.PNG",
                                                "Joker.PNG",
                                                "Joker - down.PNG",
                                                "Joker - left.PNG",
                                                "Joker - right.PNG" };
        int energy;
        

        public Joker(int row, int column) : base(50, row, column)
        {
            this.WallDestroyers = 3;
            this.current_Direction = Direction.RIGHT;
            this.energy = 100;
           
        }
        public int Energy { get => energy; set => energy = value; }
       

        public void PassWalls(AbstractEntity entity)
        {

            if (entity is Wall)
            {
                if (this.wallDestroyers > 0)
                {
                    this.wallDestroyers--;
                    Map.Remove_Entity(entity.Row, entity.Column);
                }
            }
        }
        public void Winner(AbstractEntity entity)
        {

            if (entity is Home)
            {
                System.Windows.Forms.MessageBox.Show("You won");
                System.Windows.Forms.Application.Exit();
            }
        }

        public int WallDestroyers { get => wallDestroyers; set => wallDestroyers = value; }
        public Direction Current_Direction { get => current_Direction; set => current_Direction = value; }

        public override void Draw(Graphics graphics)
        {
            //Drawing the background
            int pointX, pointY;
            base.DrawBackground(graphics, Color.Green, out pointX, out pointY);

            //Draw Bird
            int index = (int)this.Current_Direction;
            string file_name = image_files[index];

            int side = Map.Tile_size;
            Rectangle myRectangle = new Rectangle(pointX, pointY, side, side);
            using (Image myImage = Image.FromFile(Map.path + file_name))
            {
                graphics.DrawImage(myImage, myRectangle);
            }
        }

        public void Eat(AbstractEntity entity)
        {
           foreach(Harley harley in GameManager.ListHarley)
            {
                if(!harley.eaten && this.Row == harley.Row && this.Column == harley.Column)
                {
                    this.energy += 10;
                    harley.eaten = true;
                }
            }
            

        }

        public void Move()
        {
            this.Energy -= 2;
            int vx = 0, vy = 0;
            if (this.Energy >= 0)
            {
                switch (this.Current_Direction)
                {
                    case Direction.UP:
                        vx = 0;
                        vy = -1;
                        break;

                    case Direction.DOWN:
                        vx = 0;
                        vy = 1;
                        break;

                    case Direction.LEFT:
                        vx = -1;
                        vy = 0;
                        break;

                    case Direction.RIGHT:
                        vx = 1;
                        vy = 0;
                        break;
                }
            }
            else
            {
              
                System.Windows.Forms.MessageBox.Show("You Lose");
                System.Windows.Forms.Application.Exit();
               
            }
            int next_Column = this.Column + vx;
            int next_Row = this.Row + vy;

            AbstractEntity entity = Map.matrix_entities[next_Row, next_Column];
            

            if (this.CanpassThrough(entity))
            {
                this.Column += vx;
                this.Row += vy; ;
                Eat(entity);
                Monster_Attack();
                Winner(entity);
                
            }
            else
            {
                PassWalls(entity);
            }
        }
        public bool CanpassThrough(AbstractEntity entity)
        {
            return !(entity is Wall);
        }
        public void Monster_Attack()
        {
            foreach (Batman batman in GameManager.ListBatman)
            {
                if (!batman.eaten && this.Row == batman.Row && this.Column == batman.Column)
                {
                    this.energy -= 5;
                    batman.eaten = true;
                }
            }
        }
        
    }
}
