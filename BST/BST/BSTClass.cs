using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class BST //The Class of Binary Search Tree
    {
        public Node root; //Main root of tree
        private int ammount = 0; //amount of nodes
        public maxheap heap; //The maxheap for enterheap methode

        public BST()
        {
            heap = new maxheap();
        }

        public void Add(int x) //Adding a node to the tree
        {
            if (root == null)
            {
                root = new Node(x);
                ammount++;
            }

            else
            {
                Node temp = findnode(x);
                Node newnode = new Node(x);
                if (x > temp.data)
                {
                    temp.RChild = newnode;
                    newnode.parent = temp;

                    ammount++;
                }
                else
                {
                    temp.LChild = newnode;
                    newnode.parent = temp;

                    ammount++;
                }
            }

        }

        public Node findnode(int x)
        {
            bool flag = true;
            Node target = root;

            while (flag)
            {
                if (x > target.data)
                {
                    if (target.RChild == null)
                    {
                        flag = false;
                    }
                    else
                    {
                        target = target.RChild;
                    }
                }

                if (x < target.data)
                {
                    if (target.LChild == null)
                    {
                        flag = false;
                    }
                    else
                    {
                        target = target.LChild;
                    }
                }
                else if (x == target.data)
                {
                    return target;
                }
            }
            return target;
        } //finding the location of the node which it can be added

        public Node findexact_node(int x)
        {
            bool flag = true;
            Node target = root;

            while (flag)
            {
                if (x > target.data)
                {
                    if (target.RChild == null)
                    {
                        flag = false;
                    }
                    else
                    {
                        target = target.RChild;
                    }
                }

                if (x < target.data)
                {
                    if (target.LChild == null)
                    {
                        flag = false;
                    }
                    else
                    {
                        target = target.LChild;
                    }
                }
                else if (x == target.data)
                {
                    return target;
                }
            }
            return null;
        } //finding the exact node in the tree
        
        public void Next_Node(int x)
        {
            Node target = findexact_node(x);

            if (target == null)
            {
                Console.WriteLine("There is no node with this value");
            }
            else
            {
                Node next = target.RChild;

                if (next != null)
                {
                    if (next.LChild != null)
                    {
                        while (next.LChild != null)
                        {
                            next = next.LChild;
                        }
                        Console.WriteLine("The Next node of this node is : " + next.data);
                    }
                    else
                        Console.WriteLine("The Next node of this node is : " + next.data);
                }
                else
                    Console.WriteLine("There is no next node");
            }
        } //finding the next node of a node

        public void Previous_Node(int x)
        {
            Node target = findexact_node(x);

            if (target == null)
            {
                Console.WriteLine("There is no node with this value");
            }
            else
            {
                Node pre = target.LChild;

                if (pre != null)
                {
                    if (pre.RChild != null)
                    {
                        while (pre.RChild != null)
                        {
                            pre = pre.RChild;
                        }
                        Console.WriteLine("The Previous node of this node is : " + pre.data);
                    }
                    else
                        Console.WriteLine("The Previous node of this node is : " + pre.data);
                }
                else
                    Console.WriteLine("There is no previous node");
            }
        } //finding the prevous node of a node

        public void transplant(Node a, Node b) //replacing the node with each other
        {
            if (a.parent == null)
                root = b;
            else if (a == a.parent.LChild)
                a.parent.LChild = b;
            else
                a.parent.RChild = b;
            if (b != null)
                b.parent = a.parent;
        } //

        public void Delete_Node(int x)
        {
            Node target = findexact_node(x);

            if (target != null)
            {
                if (target.LChild == null)
                    transplant(target, target.RChild);
                if (target.RChild == null)
                    transplant(target, target.LChild);
                else
                {
                    Node temp = target.RChild;
                    while (temp.LChild != null)
                    {
                        temp = temp.LChild;
                    }
                    if (temp.parent != target)
                    {
                        transplant(temp, temp.RChild);
                        temp.RChild = target.RChild;
                        temp.RChild.parent = temp;
                    }
                    transplant(target, temp);
                    temp.LChild = target.LChild;
                    temp.LChild.parent = temp;
                }
                ammount--;
            }
            else
                Console.WriteLine("There is no node with this value");
        } //Deleting a node of the tre

        private List<int> store_inorder(Node n,List<int> list)
        {

            if(n == null)
            {
                return list;
            }
            else
            {
                store_inorder(n.LChild,list);
                list.Add(n.data);
                store_inorder(n.RChild, list);

                return list;
            }
        } //storing node as list in inorder traversal

        public List<int> givestored_inorder() //returning the list of inorder traversal
        {
            List<int> templist = new List<int>();
            List<int> templist2 = store_inorder(root, templist);
            return templist2;
        }

        public List<int> Merge(BST t1)
        {
            List<int> list_t1 = this.givestored_inorder();
            List<int> list_t2 = t1.givestored_inorder();
            List<int> final = new List<int>();

            int i = 0;
            int j = 0;

            while (i < list_t1.Count  && j < list_t2.Count)
            {
                if (list_t1[i] <= list_t2[j])
                {
                    final.Add(list_t1[i]);
                    i++;
                }
                else
                {
                    final.Add(list_t2[j]);
                    j++;
                }
            }

            while (i < list_t1.Count)
            {
                final.Add(list_t1[i]);
                i++;
            }

            while (j < list_t2.Count)
            {
                final.Add(list_t2[j]);
                j++;
            }

            return final;
        } //Merging two BSTs together

        public void MergedTree(BST final,List<int> t, int st, int en)
        {
            if (st > en)
            {
                return;
            }
            else
            {
                int mid = (st + en) / 2;
                final.Add(t[mid]);

                MergedTree(final, t, st, mid - 1);

                MergedTree(final, t, mid + 1, en);
            }

        } //returning the merged BSTs as a tree

        public void EnterHeap(int n)
        {
            List<int> inorder = givestored_inorder();

            if (n <= inorder.Count)
            {
                int max = inorder[inorder.Count - n];
                heap.Add(max);
            }
            else
                Console.WriteLine("the input is not correct");
        } //

        public void Display()
        {
            root.PrintNode_tree("", true);
        }
           

    }

    class maxheap //Maxheap class
    {
        public int[] arr;
        public int size; //actual size of the array

        public maxheap()
        {
            arr = new int[100];
            size = 1;
        }

        public void Add(int x) //adding a element to the heap
        {
            arr[size] = x;
            for (int i = 1; i <= size; i++)
                maxheapify(arr, i);
            size++;
        }

        private void maxheapify(int[] A, int i) //checking the elements of a heap
        {
            int left = 2 * i;
            int right = 2 * i + 1;
            int largest = 0;

            if (left <= A.Length && A[left] > A[i])
                largest = left;
            else
                largest = i;
            if (right <= A.Length && A[right] > A[largest])
                largest = right;
            if (largest != i)
            {
                int temp = A[i];
                A[i] = A[largest];
                A[largest] = temp;
                maxheapify(A, largest);
            }
        }

        public void Display() //well... it says what it does
        {
            for (int i = 1; i < size; i++)
            {
                Console.Write(arr[i]+",");
            }
            Console.WriteLine(" ");
        }
    }
}
//Coded by MohammadMahdi Mohammadi (Metium)