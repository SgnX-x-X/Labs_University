using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class DichotomyTree
    {
        private DTreeNode root;
        public DTreeNode Root
        {
            get { return root; }
            set { root = value; }
        }
        public DichotomyTree()
        {
            root = null;
        }
        public void Create(int[] keys, char[] infos)
        {
            this.root = null;
            for (int i = 0; i < keys.Length; i++)
            {
                this.root = Insert(this.root, keys[i], infos[i]);
            }
        }
        public DTreeNode Find(DTreeNode root, int key)
        {
            DTreeNode result = null;
            if (root != null)
            {
                if (key < root.Key) result = Find(root.Left, key);
                else if (key > root.Key) result = Find(root.Right, key);
                else result = root;
            }
            return result;
        }
        public DTreeNode Insert(DTreeNode root, int k, char info)
        {
            DTreeNode res = root;
            if (root == null) res = new DTreeNode(info, k);
            else if (k < root.Key) root.Left = Insert(root.Left, k, info);
            else if (k > root.Key) root.Right = Insert(root.Right, k, info);
            else if (k == root.Key) throw new ArgumentException("Такой ключ уже есть в дереве");
            return res;
        }
        public void Task(DTreeNode node1, DichotomyTree tree2, CycleDoubleLinkedList list)
        {
            if (node1 != null)
            {
                DTreeNode result = tree2.Find(tree2.Root, node1.Key);
                if (result != null)
                {
                    list.InsertAfterLast(node1.Info);
                    list.InsertAfterLast(result.Info);
                }
                Task(node1.Left, tree2, list);
                Task(node1.Right, tree2, list);
            }
        }
        public void Show(DTreeNode root, float x, float y, float dX, float dY, Graphics g, Font font, Brush brush, StringFormat format)
        {
            if (root != null)
            {
                g.DrawString($"{root.Key}({root.Info})", font, brush, x, y, format); 
                if (root.Left != null)
                {
                    Show(root.Left, x-dX, y+dY, dX/2, dY, g, font, brush, format);
                }
                if (root.Right != null)
                {
                    Show(root.Right, x + dX, y + dY, dX/2, dY, g, font, brush, format);
                }
            }
        }
        public void Destroy()
        {
            root = null;
        }
    }
}
