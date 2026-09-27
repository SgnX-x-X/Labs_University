using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp1
{
    class CycleDoubleLinkedList
    {
        private DoubleNode head;
        public CycleDoubleLinkedList()
        {
            head = new DoubleNode();
            head.Next = head;
            head.Prev = head;
        }
        public void InsertAfterLast(char data)
        {
            if (head != null)
            {
                DoubleNode p = new DoubleNode(data, head, head.Prev);
                head.Prev.Next = p;
                head.Prev = p;
            }
        }
        public void Print(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Номер";
            dataGridView1.Columns[1].Name = "Значение";
            DoubleNode p = head.Next;
            int i = 1;
            while (p != head)
            {
                dataGridView1.Rows.Add(i, $"{p.Info} , {p.Next.Info}");
                p = p.Next.Next;
                i++;
            }
        }
    }
}
