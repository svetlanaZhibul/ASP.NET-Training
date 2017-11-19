using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class Tree<T> : ICollection<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> root;
        private int count = 0;

        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerable<T> PostOrder
        {
            get { return IteratePostOrder(root); }
        }

        public IEnumerable<T> InOriginalOrder
        {
            get { return IterateInOriginalOrder(root); }
        }

        public IEnumerable<T> InOrder
        {
            get { return IterateInOrder(root); }
        }

        public void Add(T item)
        {
            Insert(new Node<T>(item), ref root);
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            return Search(item, root);
        }

        public void CopyTo(T[] array, int arrIndex)
        {
        }

        public bool Remove(T item)
        {
            return true;
        }

        ////private Node<T> RemoveNode(T item, ref Node<T> root)
        ////{
        ////    if (root == null)
        ////    {
        ////        return null;
        ////    }
        ////    else
        ////    {
        ////        if (root.value.CompareTo(item) > 0)
        ////        {
        ////            root.LeftChild = RemoveNode(item, ref root.LeftChild);
        ////        }
        ////        else if (root.value.CompareTo(item) < 0)
        ////        {
        ////            root.RightChild = RemoveNode(item, ref root.RightChild);
        ////        }
        ////        else
        ////        {
        ////            if (root.LeftChild == null)
        ////            {
        ////                root = root.RightChild;
        ////            }
        ////            else if (root.RightChild == null)
        ////            {
        ////                root = root.LeftChild;
        ////            }
        ////            else
        ////            {

        ////            }
        ////        }
        ////    }
        ////}

        IEnumerator IEnumerable.GetEnumerator()
        {
            //// call the generic version of the method
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }

        private void Insert(Node<T> node, ref Node<T> root)
        {
            if (root == null)
            {
                root = node;
                count++;
            }
            else
            {
                if (node.value.CompareTo(root.value) < 0)
                {
                    Insert(node, ref root.LeftChild);
                }
                else
                {
                    Insert(node, ref root.RightChild);
                }

                count++;
            }
        }

        private IEnumerable<T> IterateInOrder(Node<T> node)
        {
            if (node != null)
            {
                foreach (T item in IterateInOrder(node.LeftChild))
                {
                    yield return item;
                }

                yield return node.value;

                foreach (T item in IterateInOrder(node.RightChild))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> IteratePostOrder(Node<T> node)
        {
            if (node != null)
            {
                foreach (T item in IteratePostOrder(node.RightChild))
                {
                    yield return item;
                }

                yield return node.value;

                foreach (T item in IteratePostOrder(node.LeftChild))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> IterateInOriginalOrder(Node<T> node)
        {
            if (node != null)
            {
                foreach (T item in IterateInOriginalOrder(node.LeftChild))
                {
                    Console.Write("L");
                    yield return item;
                }
                ////yield return node.value;
                foreach (T item in IterateInOriginalOrder(node.RightChild))
                {
                    Console.Write("R");
                    yield return item;
                }

                yield return node.value;
            }
        }

        private Node<T> Find(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            if (node.value.Equals(item))
            {
                return node;
            }

            if (node.value.CompareTo(item) < 0)
            {
                Find(node.RightChild, item);
            }

            if (node.value.CompareTo(item) > 0)
            {
                Find(node.LeftChild, item);
            }

            return null;
        }

        private bool Search(T item, Node<T> current_root)
        {
            if (root == null)
            {
                return false;
            }

            if (root.value.CompareTo(item) == 0)
            {
                return true;
            }
            else
            {
                if (root.value.CompareTo(item) > 0)
                {
                    Search(item, root.LeftChild);
                }
                else
                {
                    Search(item, root.RightChild);
                }
            }

            return false;
            ////restruct - is not possible
        }
    }

    internal class Node<T>
    {
        internal T value;
        internal Node<T> LeftChild;
        internal Node<T> RightChild;
        ////public int height;

        public Node(T value)
        {
            this.value = value;
            this.LeftChild = this.RightChild = null;
            ////height = 1;
        }

        ////public override string ToString()
        ////{
        ////    return (this == null) ? "00" : value.ToString();
        ////}
    }
}
