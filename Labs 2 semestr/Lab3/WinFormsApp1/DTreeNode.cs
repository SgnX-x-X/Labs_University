using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class DTreeNode
    {
        private char info;
        private int key;
        private DTreeNode left;
        private DTreeNode right;
        public char Info { get; set; }
        public int Key { get; set; }
        public DTreeNode Left { get; set; }
        public DTreeNode Right { get; set;  }
        public DTreeNode() { } 
        public DTreeNode(char info, int key)
        {
            Info = info; Key = key;
        }
        public DTreeNode(char info, int key, DTreeNode left, DTreeNode right)
        {
            Info = info; Key = key; Left = left; Right = right;
        }
    }
}
