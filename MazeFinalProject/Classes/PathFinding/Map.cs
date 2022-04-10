using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using MazeFinalProject.Classes.Entities;
using FinalProjectMaze.Classes.Entities;

namespace MazeFinalProject.PathFinding
{
    public static class Map
    {
        public static readonly int Tile_size = 25; 
        public static readonly string path = @"../../Classes/Ressources/";
        public static readonly string file = "Map.txt";
        public static List<EmptyTile> draw_entity = null;


        public static AbstractEntity[,] matrix_entities = null;
        public static int Max_rows;
        public static int Max_columns;
        

        public static void Remove_Entity(int row, int col)
        {
            AbstractEntity entity = matrix_entities[row, col];
            matrix_entities[row, col] = new EmptyTile(row, col);
        }
        public static void Load_Data()
        {
            Map.draw_entity = new List<EmptyTile>();

            string[] lines = File.ReadAllLines(Map.path + Map.file);
            Map.Max_rows = lines.Length;
            Map.Max_columns = lines[0].Length;
            int nbrRows = lines.Length;
            int nbrCols = lines[0].Length;
            matrix_entities = new AbstractEntity[Map.Max_rows, Map.Max_columns];
            

            int row = 0;

            foreach (string line in lines)
            {
                char[] chars = line.ToCharArray();
                Map.Max_columns = chars.Length;

                int column = 0;
                foreach (char character in chars)
                {
                    AbstractEntity obj = null;
                    switch (character)
                    {
                        case '#'://Create Wall
                            obj = new Wall(row, column);
                            break;
                        case 'H'://Create Home
                            obj = new Home(row, column);
                            
                            break;
                        case '.': //Create Empty Tile
                            obj = new EmptyTile(row, column);
                            draw_entity.Add(new EmptyTile(row, column));
                            break;
                    }
                    
                    matrix_entities[row, column] = obj;
                    column++;
                }
                row++;
            }
        }
  
    }
}
