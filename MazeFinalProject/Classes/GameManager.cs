using MazeFinalProject.Classes.Entities;
using MazeFinalProject.PathFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFinalProject.Classes
{
    public static class GameManager
    {
        public static Joker joker;
        private static Batman bat, bat1, bat2, bat3;
        private static Harley harl, harl1, harl2, harl3, harl4;
        public static List<Batman> ListBatman = null;
        public static List<Harley> ListHarley = null;
        static GameManager()
        {
            joker = new Joker(4, 0);
        }
        private static EmptyTile GetRandom_entity()
        {
            int max = Map.draw_entity.Count;
            int random_index = RNG.Get_Instance().Next(0, max);
            EmptyTile randomObj = Map.draw_entity[random_index];
            Map.draw_entity.RemoveAt(random_index);

            return randomObj;
        }
       
        public static void Start_Game()
        {
            Map.Load_Data();
            ListBatman = new List<Batman>();
            ListHarley = new List<Harley>();


            EmptyTile Obj1 = GetRandom_entity();
            bat = new Batman(Obj1.Row, Obj1.Column);
            ListBatman.Add(bat);

            EmptyTile Obj2 = GetRandom_entity();
            bat1 = new Batman(Obj2.Row, Obj2.Column);
            ListBatman.Add(bat1);

            EmptyTile Obj3 = GetRandom_entity();
            bat2 = new Batman(Obj3.Row, Obj3.Column);
            ListBatman.Add(bat2);

            EmptyTile Obj4 = GetRandom_entity();
            bat3 = new Batman(Obj4.Row, Obj4.Column);
            ListBatman.Add(bat3);

            EmptyTile Obj5 = GetRandom_entity();
            harl = new Harley(Obj5.Row, Obj5.Column);
            ListHarley.Add(harl);

            EmptyTile Obj6 = GetRandom_entity();
            harl1 = new Harley(Obj6.Row, Obj6.Column);
            ListHarley.Add(harl1);

            EmptyTile Obj7 = GetRandom_entity();
            harl2 = new Harley(Obj7.Row, Obj7.Column);
            ListHarley.Add(harl2);

            EmptyTile Obj8 = GetRandom_entity();
            harl3 = new Harley(Obj8.Row, Obj8.Column);
            ListHarley.Add(harl3);

            EmptyTile Obj9 = GetRandom_entity();
            harl4 = new Harley(Obj9.Row, Obj9.Column);
            ListHarley.Add(harl4);
        }
    }
}
