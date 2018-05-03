using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    //public class Node : IEnumerable<Node>, ITree
    //{
    //    public string Data { get; set; }
    //    public Dictionary<int, HashSet<int>> Adjacent { get; private set; }

    //    public Node(string data)
    //    {
    //        Adjacent = new Dictionary<int, HashSet<int>>();
    //        this.Data = data;
    //    }

    //    int count;
    //    Node[] nodes = new Node[5];
    //    public void Add(Node node)
    //    {
    //        if (count == nodes.Length)
    //            Array.Resize(ref nodes, nodes.Length * 2);
    //        nodes[count++] = node;
    //    }

    //    public IEnumerator<Node> GetEnumerator()
    //    {
    //        for (int i = 0; i < count; i++)
    //            yield return nodes[i];
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }

    //    public IEnumerable<Node> GetNeighbors(Node n)
    //    {
    //        foreach (Node x in n)
    //            yield return x;
    //    }
    //}
}
