using System;
using System.Collections.Generic;
using System.Text;

namespace ASA_lab1
{
    enum Color
    {
        Red,
        Black
    }
    class RB
    {
        public class TreeNode
        {
            public Color color;
            public TreeNode left;
            public TreeNode right;
            public TreeNode parent;
            public double data;

            public TreeNode(double data) { this.data = data; }
            public TreeNode(Color color) { this.color = color; }
            public TreeNode(double data, Color color) { this.data = data; this.color = color; }
            public override string ToString()
            {
                return data.ToString();
            }
        }
        public TreeNode root;
        public RB() { }
        private void LeftRotate(TreeNode x)
        {
            TreeNode y = x.right;
            x.right = y.left;
            if (y.left != null) { y.left.parent = x; }
            if (y != null) { y.parent = x.parent; }
            if (x.parent == null) { root = y; }
            else { x.parent.right = y; }
            y.left = x;
            if (x != null) { x.parent = y; }
        }
        private void RightRotate(TreeNode y)
        {
            TreeNode x = y.left;
            y.left = x.right;
            if (x.right != null) { x.right.parent = y; }
            if (x != null) { x.parent = y.parent; }
            if (y.parent == null) { root = x; }
            if (y == y.parent.right && y.parent != null) { y.parent.right = x; }
            if (y == y.parent.left) { y.parent.left = x; }
            x.right = y;
            if (y != null) { y.parent = x; }
        }
        
        public StringBuilder Print(TreeNode x, int tab = 0, int pos = 2)
        {
            var sb = new StringBuilder();
            if (x != null)
            {
                sb.Append(Print(x.right, tab + pos, pos));
                sb.Append(new string(' ', tab)).Append($"{ x.color + " " + x.ToString()}({OrNotNil((TreeNode)x.parent)},{OrNotNil((TreeNode)x.left)},{OrNotNil((TreeNode)x.right)})").AppendLine();
                sb.Append(Print(x.left, tab + pos, pos));
            }
            return sb;
        }

        private string OrNotNil(TreeNode x)
        {
            return (x == null) ? "null" : x.data.ToString();
        }
        
        public TreeNode Find(double key)
        {
            TreeNode temp = root;
            while (temp != null)
            {
                if (key == temp.data)
                {
                    break;
                }
                if (key < temp.data)
                {
                    temp = temp.left;
                }
                else
                {
                    temp = temp.right;
                }

            }
            Console.WriteLine(temp == null ? key + " Elementas nerastas." : temp + " Buvo rastas.");
            return temp;
        }

        public void Insert(double item)
        {
            TreeNode newItem = new TreeNode(item);
            if (root == null)
            {
                root = newItem;
                root.color = Color.Black;
                return;
            }
            TreeNode y = null;
            TreeNode x = root;
            while (x != null)
            {
                y = x;
                if (newItem.data < x.data)
                    x = x.left;
                else x = x.right;
            }
            newItem.parent = y;
            if (y == null) { root = newItem; }
            else if (newItem.data < y.data) { y.left = newItem; }
            else y.right = newItem;
            newItem.left = null;
            newItem.right = null;
            newItem.color = Color.Red;
            InsertFixUp(newItem);
        }
        private void InsertFixUp(TreeNode item)
        {
            while (item != root && item.parent.color == Color.Red)
            {
                if (item.parent == item.parent.parent.left)
                {
                    TreeNode y = item.parent.parent.right;
                    if (y != null && y.color == Color.Red)
                    {
                        item.parent.color = Color.Black;
                        y.color = Color.Black;
                        item.parent.parent.color = Color.Red;
                        item = item.parent.parent;
                    }
                    else
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        item.parent.color = Color.Black;
                        item.parent.parent.color = Color.Red;
                        RightRotate(item.parent.parent);
                    }
                }
                else
                {
                    TreeNode x = null;
                    x = item.parent.parent.left;
                    if (x != null && x.color == Color.Black)
                    {
                        item.parent.color = Color.Red;
                        x.color = Color.Red;
                        item.parent.parent.color = Color.Black;
                        item = item.parent.parent;
                    }
                    else
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        item.parent.color = Color.Black;
                        item.parent.parent.color = Color.Red;
                        LeftRotate(item.parent.parent);
                    }
                }
                root.color = Color.Black;
            }
        }
    }
}
