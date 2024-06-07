using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            //user interaction menu

            List<BST> BSTs = new List<BST>();
            int cmd = -1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1-Make a BST tree");
                Console.WriteLine("2-Add an element to a BST tree");
                Console.WriteLine("3-Find the next node of a node");
                Console.WriteLine("4-Find the prevous node of node");
                Console.WriteLine("5-Delete a node");
                Console.WriteLine("6-Merge two BSTs");
                Console.WriteLine("7-Choose the # highest element in a BST and add it to its maxheap");
                Console.WriteLine("8-Display a BST");
                Console.WriteLine("9-Display the maxheap of a BST");
                Console.WriteLine("0-Exit");
                Console.WriteLine("----------------------------------------------------------------");
                Console.Write("Number of BSTs: "+BSTs.Count);
                Console.WriteLine("\n----------------------------------------------------------------");

                    cmd = Convert.ToInt32(Console.ReadLine());

                switch (cmd)
                {
                    case 1:
                        {
                            BSTs.Add(new BST());
                            Console.WriteLine("New BST added.\nPress to continue");
                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        {
                            Console.Write("Which tree ?: ");
                            int target = Convert.ToInt32(Console.ReadLine())-1;

                            if (target + 1 <= BSTs.Count)
                            {
                                Console.Write("Number of the element: ");
                                int newel = Convert.ToInt32(Console.ReadLine());

                                BSTs[target].Add(newel);
                                Console.WriteLine("New Element successfuly added to the BST\npress to continue");
                            }

                            else
                                Console.WriteLine("The chosen target is not valid.\npress to continue");

                            Console.ReadKey();
                            break;
                        }

                    case 3:
                        {
                            Console.Write("Which tree ?: ");
                            int target = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (target + 1 <= BSTs.Count)
                            {
                                Console.Write("Number of the element: ");
                                int newel = Convert.ToInt32(Console.ReadLine());

                                BSTs[target].Next_Node(newel);
                                Console.WriteLine("Press to continue");
                            }

                            else
                                Console.WriteLine("The chosen target is not valid.\npress to continue");

                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Which tree ?: ");
                            int target = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (target + 1 <= BSTs.Count)
                            {
                                Console.Write("Number of the element: ");
                                int newel = Convert.ToInt32(Console.ReadLine());

                                BSTs[target].Previous_Node(newel);
                                Console.WriteLine("Press to continue");
                            }

                            else
                                Console.WriteLine("The chosen target is not valid.\npress to continue");

                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Which tree ?: ");
                            int target = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (target + 1 <= BSTs.Count)
                            {
                                Console.Write("Number of the element: ");
                                int newel = Convert.ToInt32(Console.ReadLine());

                                BSTs[target].Delete_Node(newel);
                                Console.WriteLine("Press to continue");
                            }

                            else
                                Console.WriteLine("The chosen target is not valid.\npress to continue");

                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            Console.Write("Which tree ?(1): ");
                            int target1 = Convert.ToInt32(Console.ReadLine()) - 1;
                            Console.Write("Which tree ?(2): ");
                            int target2 = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (target1 + 1 <= BSTs.Count && target2 + 1 <= BSTs.Count)
                            {
                                BST newtree = new BST();
                                List<int> inorder_merged = BSTs[target1].Merge(BSTs[target2]);

                                BSTs[target1].MergedTree(newtree, inorder_merged, 0, inorder_merged.Count - 1);
                                BSTs.Add(newtree);
                                Console.WriteLine("New Tree added as " + BSTs.Count + " BST.\nPress to continue");
                            }

                            else
                                Console.WriteLine("The chosen targets/target are/is not valid.\npress to continue");

                            Console.ReadKey();
                            break;
                        }
                    case 7:
                        {
                            Console.Write("Which tree ?: ");
                            int target = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (target + 1 <= BSTs.Count)
                            {
                                Console.Write("Number of the element: ");
                                int newel = Convert.ToInt32(Console.ReadLine());

                                BSTs[target].EnterHeap(newel);
                                Console.WriteLine("The Element enter the maxheap successfuly\npress to continue");
                            }

                            else
                                Console.WriteLine("The chosen target is not valid.\npress to continue");

                            Console.ReadKey();
                            break;
                        }
                    case 8:
                        {
                            Console.Write("Which tree ?: ");
                            int target = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (target + 1 <= BSTs.Count)
                            {
                                BSTs[target].Display();
                                Console.WriteLine("Press to continue");
                            }

                            else
                                Console.WriteLine("The chosen target is not valid.\npress to continue");

                            Console.ReadKey();
                            break;
                        }
                    case 9:
                        {
                            Console.Write("Which tree ?: ");
                            int target = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (target + 1 <= BSTs.Count)
                            {
                                BSTs[target].heap.Display();

                                Console.WriteLine("Press to continue");
                            }

                            else
                                Console.WriteLine("The chosen target is not valid.\npress to continue");

                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        {
                            System.Environment.Exit(0);
                            break;
                        }
                }
            }
        }
    }
}
//coded by MohammadMahdi Mohammadi(Metium)
