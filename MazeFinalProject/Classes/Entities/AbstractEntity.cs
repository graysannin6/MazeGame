using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MazeFinalProject.PathFinding;

namespace MazeFinalProject.Classes.Entities
{
    public abstract class AbstractEntity
    {
        //private int score;
        private int row;
        private int column;
        private Color entity_Color;

        public AbstractEntity(int score, int row, int column)
        {
            //this.score = score;
            this.column = column;
            this.row = row;
            this.entity_Color = Color.White;
        }

        public int Column { get => column; set => column = (value < 0) ? 0 : value; }
        public int Row { get => row; set => row = (value < 0) ? 0 : value; }
       // public int Score { get => score; set => score = value; }
        public Color Entity_Color { get => entity_Color; set => entity_Color = value; }

        public abstract void Draw(Graphics graphics);

        public void DrawBackground(Graphics graphics, Color backgroundColor, out int pointX, out int pointY)
        {
            //Drawing the background
            pointX = this.Column * Map.Tile_size;
            pointY = this.Row * Map.Tile_size;
            int side = Map.Tile_size;
            Rectangle myRectangle = new Rectangle(pointX, pointY, side, side);
            Brush myBrush = new SolidBrush(backgroundColor);
            graphics.FillRectangle(myBrush, myRectangle);
            myBrush.Dispose();
        }
    }
}
