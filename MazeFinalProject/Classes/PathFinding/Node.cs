using MazeFinalProject.Classes.Entities;
using MazeFinalProject.PathFinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFinalProject.Classes.PathFinding
{
    public class Node : IComparer, IComparable
    {
        private int row;
        private int column;
        private Node goalNode;// Destination (example . Pacman position)
        private Node parentNode;//Previous Node
        private int g_Cost;//g value of the edge from parent node to current node
        private int heuristic; //h value = Global estimate of cost to reach the goal
        private int total_Cost; // f value = g + h

        public int Total_Cost { get => total_Cost + this.heuristic; }//AStar
        //public int Total_Cost { get => total_Cost; }// Dikjstra version with heuristic.

        public Node ParentNode { get => parentNode; set => parentNode = value; }

        public Node(int row, int column, Node goal, Node parent, int g = 1)
        {
            this.row = row; // y
            this.column = column;//x
            this.goalNode = goal;
            this.parentNode = parent;
            this.g_Cost = g;
            //Estimate of Cost from Current Node to Goal Node
            this.heuristic = (this.goalNode != null) ? (int)Euclidean_Distance() : 0;
            //Exact Cost from start Node to current Node (Total Cost of the Path)
            this.total_Cost = (this.parentNode != null) ? this.parentNode.Total_Cost + this.g_Cost : this.g_Cost;
        }
        private double Manhattan_Distance()
        {
            double xDistance = this.column - this.goalNode.column;
            double yDistance = this.row - this.goalNode.row;

            return Math.Abs(xDistance) + Math.Abs(yDistance);
        }
        private double Euclidean_Distance()
        {
            double xDistance = this.column - this.goalNode.column;
            double yDistance = this.row - this.goalNode.row;
            return Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
        }

        public List<Node> GetSuccessors()
        {
            List<Node> successors = new List<Node>();

            //Upper Tile (Grid system) : Column (X Axis), Row (Y Axis)
            AbstractEntity upperTile = Map.matrix_entities[this.row - 1, this.column];
            if (!(upperTile is Wall))
            {
                Node nodeUp = new Node(this.row - 1, this.column, this.goalNode, this);// this means the current node is parent for upperNode
                if (nodeUp != this.parentNode)//default operator != compares references (Reference Type)
                {                            //We have overload (define) the operator != for type Node
                    successors.Add(nodeUp);
                }
            }

            //Lower Tile
            AbstractEntity lowerTile = Map.matrix_entities[this.row + 1, this.column];
            if (!(lowerTile is Wall))
            {
                Node nodeDown = new Node(this.row + 1, this.column, this.goalNode, this);// this means the current node is parent for upperNode
                if (nodeDown != this.parentNode)//default operator != compares references (Reference Type)
                {                            //We have overload (define) the operator != for type Node
                    successors.Add(nodeDown);
                }
            }
            //Left Tile
            AbstractEntity leftTile = Map.matrix_entities[this.row, this.column - 1];
            if (!(leftTile is Wall))
            {
                Node nodeLeft = new Node(this.row, this.column - 1, this.goalNode, this);// this means the current node is parent for upperNode
                if (nodeLeft != this.parentNode)//default operator != compares references (Reference Type)
                {                            //We have overload (define) the operator != for type Node
                    successors.Add(nodeLeft);
                }
            }
            //Right Tile
            AbstractEntity rightTile = Map.matrix_entities[this.row, this.column + 1];
            if (!(rightTile is Wall))
            {
                Node nodeRight = new Node(this.row, this.column + 1, this.goalNode, this);// this means the current node is parent for upperNode
                if (!nodeRight.Equals(this.parentNode))//override Equals if you don't overload the operator != 
                {
                    successors.Add(nodeRight);
                }
            }
            return successors;
        }

        public static bool operator !=(Node a, Node b)
        {
            if (a is null && b is null) return false;// They are equal
            else if (a is null && b != null) return true;// They are diffrent
            else if (a != null && b is null) return true;// They are diffrent
            else return (a.row != b.row || a.column != b.column);// Check if they are diffrent  if (a != null && b != null) 
        }

        public static bool operator ==(Node a, Node b)
        {
            if (a is null && b is null) return true;// They are equal
            else if (a is null && b != null) return false;// They are diffrent
            else if (a != null && b is null) return false;// They are diffrent
            else return (a.row == b.row && a.column == b.column);// Check if they are equal if (a != null && b != null) 
        }

        public override bool Equals(object obj)
        {
            if (obj is Node)
            {
                Node node = obj as Node; // Casting 
                return (this.row == node.row && this.column == node.column);
            }
            return false;
        }

        public int Compare(object nodeX, object nodeY) // return -1 if x < y | return +1 if x > y | return 0 if x == y
        {
            return (((Node)nodeX).Total_Cost - ((Node)nodeY).Total_Cost);
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }
            else
            {
                Node nodeObj = obj as Node;
                return this.Total_Cost - nodeObj.Total_Cost;
            }
        }


    }
}
