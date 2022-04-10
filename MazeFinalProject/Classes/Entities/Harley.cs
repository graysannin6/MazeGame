using MazeFinalProject.PathFinding;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFinalProject.Classes.Entities
{
    public class Harley : AbstractEntity
    {
        public Harley(int row, int column) : base(0, row, column) { }

        

        public bool eaten = false;
        public override void Draw(Graphics graphics)
        {
            //Drawing the background
            int pointX, pointY;
            base.DrawBackground(graphics, Color.Green, out pointX, out pointY);

            //Drawing batman
            int side = Map.Tile_size;
            Rectangle myRectangle = new Rectangle(pointX, pointY, side, side);
            using (Image myImage = Image.FromFile(Map.path + "Harley-icon.png"))
            {
                graphics.DrawImage(myImage, myRectangle);
            }
        }
    }
}
