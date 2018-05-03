using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{
    class Program
    {
        // Resources used:
        // https://stackoverflow.com/questions/5804844/implementing-depth-first-search-into-c-sharp-using-list-and-stack
        // http://www.koderdojo.com/blog/depth-first-search-algorithm-in-csharp-and-net-core
        public static void Main()
        {
            // see image in DFS folder for visual implementation
            // the first param is the node, the second param is a neighboring node
            var t = new Tree();
            t.AddNode(1, 2);
            t.AddNode(1, 3);
            t.AddNode(2, 4);
            t.AddNode(3, 5);
            t.AddNode(3, 6);
            t.AddNode(4, 7);
            t.AddNode(5, 7);
            t.AddNode(5, 8);
            t.AddNode(5, 6);
            t.AddNode(8, 9);
            t.AddNode(8, 10);
            t.AddNode(9, 10);
            RunSearch(t);
        }

        public static void RunSearch(Tree myTree)
        {
            Console.WriteLine("Enter a node to start your search:");
            string start = Console.ReadLine();
            int val;
            bool success = Int32.TryParse(start, out val);
            if (success)
            {
                Console.WriteLine("Enter a node value to find:");
                string value = Console.ReadLine();
                int myVal;
                bool canParse = Int32.TryParse(value, out myVal);
                if (canParse)
                {
                    var watch = Stopwatch.StartNew();
                    int result = myTree.DepthFirstTraversal(val).Where(v => v == myVal).FirstOrDefault();
                    watch.Stop();
                    var elapsed = watch.ElapsedMilliseconds;
                    Console.WriteLine("");
                    Console.WriteLine("Found " + result + " in: " + elapsed + "ms");
                    watch = null;
                    Console.WriteLine("");
                    RunSearch(myTree);
                }
                Console.WriteLine("Sorry, that value is not acceptable");
                RunSearch(myTree);
            }
            Console.WriteLine("Sorry, that value is not acceptable");
            RunSearch(myTree);
        }
    }
}
