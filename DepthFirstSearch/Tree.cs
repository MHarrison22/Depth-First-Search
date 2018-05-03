using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{
    public class Tree
    {
        // Keeps track of node relationships
        public Dictionary<int, HashSet<int>> NeighborList { get; set; }
        public Tree()
        {
            var visited = new HashSet<int>();
            NeighborList = new Dictionary<int, HashSet<int>>();
        }

        public IEnumerable<int> GetNeighbors(Tree tree, int node)
        {
            foreach (var i in tree.NeighborList.Where(x => x.Key == node).SelectMany(r => r.Value))
                yield return i;
        }

        public void AddNode(int node, int neighbor)
        {
            if (NeighborList.ContainsKey(node))
                try
                {
                    // Access the node, and add an adjacent node
                    NeighborList[node].Add(neighbor);
                    if (NeighborList.ContainsKey(node))
                    {
                        NeighborList[node].Add(neighbor);
                        foreach (var nodeKey in NeighborList.SelectMany(x => x.Value))
                        {
                            if (!NeighborList.ContainsKey(nodeKey))
                            {
                                // If the neighbor list doesn't have a dictionary entry with the passed key value
                                // create a new entry with the passed key as the key, and empty values
                                NeighborList.Add(nodeKey, new HashSet<int>());
                                // access the entry by key, add the node to the empty values hashset.
                                NeighborList[nodeKey].Add(node);
                            }
                        }
                    }
                }
                catch
                {
                    // The relationship has already been created
                    // Console.WriteLine("This relationship already exists: node:" + node + " to neighbor:" + neighbor);
                }
            else
            {
                // If it's a new node, create a hashset
                var hs = new HashSet<int>();
                // Add the adjacent node to the hash set
                hs.Add(neighbor);
                // Add the entry to the NeighborList
                NeighborList.Add(node, hs);
            }
        }

        //Helper method to get neighbors for a given node
        public static void CheckNeighbors(Tree mytree, int num)
        {
            Console.WriteLine("Enter a node number to get it's neighbors: ");
            var criteria = Console.ReadLine();
            int val;
            bool success = Int32.TryParse(criteria, out val);
            var neigh = mytree.GetNeighbors(mytree, val);
            Console.WriteLine("Neighbors of node: " + val);
            foreach (var i in neigh)
                Console.Write(" " + i.ToString() + " ");
            Console.WriteLine();
            CheckNeighbors(mytree, 1);
        }
    }
}
