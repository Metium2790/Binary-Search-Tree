using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class Node //node class
    {
        public int data;
        public Node parent;
        public Node LChild; //usage is for the tree
        public Node RChild; //usage is for the tree

        public Node(int d)
        {
            data = d;
            LChild = null;
            RChild = null;
            parent = null;
        }

        public void PrintNode_tree(string indent, bool last)
        {

            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "| ";
            }
            Console.WriteLine(data);

            var children = new List<Node>();
            if (this.RChild != null)
                children.Add(this.RChild);
            if (this.LChild != null)
                children.Add(this.LChild);

                    for (int i = 0; i < children.Count; i++)
                    {
                        if (children[0] != null)
                            children[i].PrintNode_tree(indent, i == children.Count - 1);
                    }

        } //purpose is for BST.Display

    }
}
