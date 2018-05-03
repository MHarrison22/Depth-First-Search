using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{
    static class Extensions
    {
        public static IEnumerable<int> DepthFirstTraversal(
            this Tree tree, int node)
        {
            Console.WriteLine("");
            var visited = new HashSet<int>();
            var stack = new Stack<int>();

            stack.Push(node);

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                if (!visited.Add(current)) // if you cant add what's already there
                    continue; // continues popping;
                Console.WriteLine("Searched node..." + current);
                yield return current;

                var neighbors = tree.GetNeighbors(tree, current).Where(n => !visited.Contains(n));
                foreach (var x in neighbors)
                    stack.Push(x);
            }
        }
    }
}
