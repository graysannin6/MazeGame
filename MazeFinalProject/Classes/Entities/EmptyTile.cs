using FinalProjectMaze.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFinalProject.Classes.Entities
{
    public class EmptyTile : Tile
    {
        public EmptyTile(int row, int column) : base(row, column)
        {
            base.Entity_Color = Color.Green;
        }

    }
}
