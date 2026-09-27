using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
class CycleDoubleLinkedList
{
    private DoubleNode head;
    public CycleDoubleLinkedList()
    {
        head = new DoubleNode();
        head.Next = head;
        head.Prev = head;
    }
    public void Create(int[] dates)
    {
        Clear();
        DoubleNode p;
        for (int i = 0; i < dates.Length; i++)
        {
            p = new DoubleNode(dates[i]);
            p.Next = head;
            p.Prev = head.Prev;
            head.Prev.Next = p;
            head.Prev = p;
        }
    }
    public void InsertBeforeFirst(int data)
    {
        if (head != null)
        {
            DoubleNode p = new DoubleNode(data, head.Next, head);
            head.Next.Prev = p;
            head.Next = p;
        }
    }
    public void InsertAfterLast(int data)
    {
        if (head != null)
        {
            DoubleNode p = new DoubleNode(data, head, head.Prev);
            head.Prev.Next = p;
            head.Prev = p;
        }
    }
    public void InsertAt(int data, int number)
    {
        if (head != null)
        {
            DoubleNode current = head.Next;
            int currentIndex = 1;
            while (current != head && currentIndex < number)
            {
                current = current.Next;
                currentIndex++;
            }
            if (current != head)
            {
                DoubleNode p = new DoubleNode(data, current, current.Prev);
                current.Prev.Next = p;
                current.Prev = p;
            }
            else throw new Exception("В списке недостаточно элементов");
        }
        else throw new Exception("Список пуст");
    }
    public void DeleteFirst()
    {
        if (head != null)
        {
            head.Next = head.Next.Next;
            head.Next.Prev = head;
        }
        else throw new Exception("Список пуст");
    }
    public void DeleteLast()
    {
        if (head != null)
        {
            head.Prev = head.Prev.Prev;
            head.Prev.Next = head;
        }
        else throw new Exception("Список пуст");
    }
    public void DeleteAt(int number)
    {
        if (head != null)
        {
            DoubleNode current = head.Next;
            int currentIndex = 1;
            while (current != head && currentIndex < number)
            {
                current = current.Next;
                currentIndex++;
            }
            if (current != head)
            {
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }
            else throw new Exception("В списке недостаточно элементов");
        }
        else throw new Exception("Список пуст");
    }
    public void Clear()
    {
        if (head != null)
        {
            head.Next = head;
            head.Prev = head;
        }
        else throw new Exception("Список пуст");
    }
    public DoubleNode Find(int x)
    {
        if (head != null)
        {
            DoubleNode p = head.Next;
            int i = 1;
            while(p != head && i != x)
            {
                p = p.Next;
                i++;
            }
            if (p == head)
            {
                p = null;
                throw new Exception("В списке недостаточно элементов");
            }
                return p;
        }
        else throw new Exception("Список пуст"); 
    }
    public void Task(int m, int n)
    {
        if (head != null)
        {
            DoubleNode p = Find(n);
            if (p != null) 
            { 
               DoubleNode q = p.Prev;
                int i = 1;
                while (p != head && i != m)
                {
                    p = p.Next;
                    i++;
                }
                if (p != head)
                {
                    q.Next = p.Next;
                    p.Next.Prev = q;
                }
                else throw new Exception("В списке недостаточно элементов");  
            }
        }
        else throw new Exception("Список пуст");
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
            dataGridView1.Rows.Add(i, p.Info);
            p = p.Next;
            i++;
        }
    }
}