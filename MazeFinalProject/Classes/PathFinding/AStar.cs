using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeFinalProject.Classes.PathFinding
{
    public class AStar
    {
        public static List<Node> FindPath(Node startNode, Node goalNode)
        {
            List<Node> path = new List<Node>();// Resulat Final
            List<Node> openNodes = new List<Node>();
            List<Node> closedNodes = new List<Node>();

            openNodes.Add(startNode);

            while (openNodes.Count > 0)// There are not visited nodes
            {
                Node currentNode = TakeOutNode(openNodes);
                if (currentNode == goalNode)//don't forget to overload operator !=
                {
                    goalNode.ParentNode = currentNode.ParentNode;
                    break;
                }
                List<Node> successors = currentNode.GetSuccessors();
                foreach (Node succ in successors)
                {
                    int indexInOpenList = openNodes.IndexOf(succ);
                    if (indexInOpenList > 0)
                    {
                        if (openNodes[indexInOpenList].CompareTo(currentNode) <= 0)
                        {
                            continue;// Passer au suivant
                        }
                    }

                    int indexInClosedList = closedNodes.IndexOf(succ);
                    if (indexInClosedList > 0)
                    {
                        if (closedNodes[indexInClosedList].CompareTo(currentNode) <= 0)
                        {
                            continue;// Passer au suivant
                        }
                    }

                    if (indexInOpenList != -1)// succ node exists in Open List
                    {
                        openNodes.RemoveAt(indexInOpenList);
                    }

                    if (indexInClosedList != -1)// succ node exists in Closed List
                    {
                        closedNodes.RemoveAt(indexInClosedList);
                    }
                    openNodes.Add(succ);//Mettre a jours le parent et le cout optimal
                }// End of foreach : After adding all successors
                closedNodes.Add(currentNode);
            }//End of while
            if (goalNode.ParentNode is null)
            {
                MessageBox.Show("No Path Found");
                return new List<Node>();
            }

            Node pathNode = goalNode;
            while (pathNode != null)
            {
                path.Insert(0, pathNode);
                pathNode = pathNode.ParentNode;
            }

            return path;
        }
        private static Node TakeOutNode(List<Node> nodes)
        {
            nodes.Sort();
            Node node_LowestCost = nodes[0];
            nodes.RemoveAt(0);

            return node_LowestCost;
        }
    }
}
