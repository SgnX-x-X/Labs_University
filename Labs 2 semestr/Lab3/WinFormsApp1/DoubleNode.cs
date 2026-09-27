using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class DoubleNode
    {
        private char info;
        private DoubleNode next;
        private DoubleNode prev;
        public char Info { get; set; }
        public DoubleNode Next { get; set; }
        public DoubleNode Prev { get; set; }
        public DoubleNode() { }
        public DoubleNode(char info)
        {
            Info = info;
        }
        public DoubleNode(char info, DoubleNode next, DoubleNode prev)
        {
            Info = info; Next = next; Prev = prev;
        }
    }
}
