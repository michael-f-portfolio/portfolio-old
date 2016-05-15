using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using ConsoleApplication.Views;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var node1 = new Node { Text = "x" };
            //var node2 = new Node { Text = "y" };
            //var node3 = new Node { Text = "z" };

            //Node[] nodeArray = {node1, node2, node3};

            //TreeNode node = new TreeNode
            //{
            //    Nodes = nodeArray,
            //    Text = "This is the root node"
            //};

            //var node1 = new System.Windows.Forms.TreeNode { Text = "x" };
            //var node2 = new System.Windows.Forms.TreeNode { Text = "y" };
            //var node3 = new System.Windows.Forms.TreeNode { Text = "z" };

            //var root = new System.Windows.Forms.TreeNode("ROOT", new []{ node1, node2, node3});

            //Foo(root);

            DisplayHome();

        }

        public static void DisplayHome()
        {
            Console.Title = Templates.HomePageTitle;
            var home = Templates.HomePage;

            Console.WriteLine(home);
            var input = Console.ReadLine();            

        }

        public static void GetChoice(string choice)
        {
            
        }

        public static void Foo(System.Windows.Forms.TreeNode root)
        {
            var stack = new Stack();
            stack.Push(root);

            Console.WriteLine($"DEBUG : {stack.Count}");

            while (stack.Count > 0)
            {
                var node = (TreeNode) stack.Pop();
                Console.WriteLine($"OUTPUT : {node.Text}");

                for (var i = node.Nodes.Count - 1; i >= 0; i--)
                {
                    stack.Push(node.Nodes[i]);
                }
            }
        }
    }

    //public class TreeNode : Node
    //{
    //    public Node[] Nodes { get; set; }
        
    //}

    //public class Node 
    //{
    //    public virtual string Text { get; set; }
    //}
}
