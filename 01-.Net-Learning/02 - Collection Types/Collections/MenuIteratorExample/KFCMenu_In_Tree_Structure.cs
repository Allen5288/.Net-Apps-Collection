using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.MenuIteratorExample
{
    public class KFCMenu_In_Tree_Structure
    {
        private BinaryTree Foods = new BinaryTree();
        public KFCMenu_In_Tree_Structure()
        {
            Foods = new BinaryTree();
            // Insert values
            Foods.Insert(new Food { Id = 1, Name = "Chicken", Price = 50.00 });
            Foods.Insert(new Food { Id = 2, Name = "Beef", Price = 30.00 });
            Foods.Insert(new Food { Id = 3, Name = "Seafood", Price = 70.00 });
            Foods.Insert(new Food { Id = 4, Name = "Fiery Zinger", Price = 20.00 });
            Foods.Insert(new Food { Id = 5, Name = "Giant Snack", Price = 40.00 });
            Foods.Insert(new Food { Id = 6, Name = "Supercharged Zinger", Price = 60.00 });
            Foods.Insert(new Food { Id = 7, Name = "Original Crispy Burger", Price = 80.00 });
        }

        public BinaryTree GetFoods()
        {
            Foods.PreOrderTraversal();
            return Foods;
        }

        public IIterator<Food> GetEnumerator()
        {
            return new KFCTreeMenuIterator(this);
        }
    }

    public class BinaryTree
    {
        public class TreeNode
        {
            public Food Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(Food value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        public TreeNode Root { get; private set; }

        public readonly Stack<TreeNode> _stack = new Stack<TreeNode>();
        public int Count;
        public BinaryTree() { Root = null; }
        public void Insert(Food value)
        {
            Root = InsertRec(Root, value);
        }

        private TreeNode InsertRec(TreeNode root, Food value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return root;
            }

            if (value.Price < root.Value.Price)
            {
                root.Left = InsertRec(root.Left, value);
            }
            else if (value.Price > root.Value.Price)
            {
                root.Right = InsertRec(root.Right, value);
            }

            Count++;
            return root;
        }

        public void InOrderTraversal()
        {
            _stack.Clear();
            InOrderRec(Root);
        }

        private void InOrderRec(TreeNode root)
        {
            if (root != null)
            {
                InOrderRec(root.Left);
                Console.Write(root.Value + " ");
                _stack.Push(root);
                InOrderRec(root.Right);
            }
        }

        public void PreOrderTraversal()
        {
            _stack.Clear();
            PreOrderRec(Root);
        }

        private void PreOrderRec(TreeNode root)
        {
            if (root != null)
            {
                Console.WriteLine($"{root.Value.Id} : {root.Value.Name} ${root.Value.Price}");
                _stack.Push(root);
                PreOrderRec(root.Left);
                PreOrderRec(root.Right);
            }
        }

        public void PostOrderTraversal()
        {
            _stack.Clear();
            PostOrderRec(Root);
        }

        private void PostOrderRec(TreeNode root)
        {
            if (root != null)
            {
                PostOrderRec(root.Left);
                PostOrderRec(root.Right);
                Console.Write(root.Value + " ");
                _stack.Push(root);
            }
        }

        public bool Search(Food value)
        {
            return SearchRec(Root, value);
        }

        private bool SearchRec(TreeNode root, Food value)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Value.Name == value.Name)
            {
                return true;
            }

            return value.Price < root.Value.Price ? SearchRec(root.Left, value) : SearchRec(root.Right, value);
        }

    }
}
