using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class SingleLinkedList
{
    private Node first;
    public SingleLinkedList()
    {
        first = null;
    }
    public void Create(int[] data)
    {
        first = null;
        for (int i = data.Length - 1; i >= 0; i--)
        {
            Node p = new Node(data[i]);
            p.Link = first;
            first = p;
        }
    }
    public void InsertBeforeFirst(int data)
    {
        Node p = new Node(data, first);
        first = p;
    }
    public void InsertAfterLast(int data)
    {
        Node p = first;
        if (p != null)
        {
            while (p.Link != null)
            {
                p = p.Link;
            }
            p.Link = new Node(data);
        }
        else throw new Exception("Список пуст");
    }
    public void InsertAt(int data, int number)
    {
        if (first != null)
        {
            Node p = first;
            int i = 1;
            while (p != null && i < number - 1)
            {
                p = p.Link;
                i++;
            }
            if (p == null) throw new Exception("В списке недостаточно элементов");
            else
            {
                Node q = new Node(data);
                q.Link = p.Link;
                p.Link = q;
            }
        }
        else throw new Exception("Список пуст");
    }
    public void DeleteFirst()
    {
        if (first != null)
        {
            first = first.Link;
        }
        else throw new ArgumentException("Список пуст");
    }
    public void DeleteLast()
    {
        if (first != null)
        {
            Node p = first;
            while (p.Link.Link != null)
            {
                p = p.Link;
            }
            p.Link = null;
        }
        else throw new ArgumentException("Список пуст");
    }
    public void DeleteAt(int number)
    {
        if (first != null)
        {
            Node p = first;
            int i = 1;
            while (p != null && i < number - 1)
            {
                p = p.Link;
                i++;
            }
            if (p.Link == null) throw new Exception("В списке недостаточно элементов");
            else
            {
                p.Link = p.Link.Link;
            }
        }
        else throw new Exception("Список пуст");
    }
    public void Destroy()
    {
        if (first != null) first = null;
        else throw new ArgumentException("Список пуст");
    }
    public void Task(int m, int n)
    {
        if (n < 1 || m < 1 || Count() < n + m - 1)
            throw new Exception("Некорректные параметры или недостаточно элементов");
        if (n == 1)
        {
            int i = 0;
            while (i < m)
            {
                first = first.Link;
                i++;
            }
        }
        else
        {
            Node p = first;
            int i = 1;
            while (i < n - 1)
            {
                p = p.Link;
                i++;
            }
            int j = 0;
            while (j < m)
            {
                p.Link = p.Link.Link;
                j++;
            }
        }
    }
    public int Count()
    {
        int count = 0;
        Node p = first;
        while (p != null)
        {
            count++;
            p = p.Link;
        }
        return count;
    }
    public void Print(DataGridView dataGridView1)
    {
        dataGridView1.Rows.Clear();
        dataGridView1.ColumnCount = 2;
        dataGridView1.Columns[0].Name = "Номер";
        dataGridView1.Columns[1].Name = "Значение";
        Node p = first;
        int i = 1;
        while (p != null)
        {
            dataGridView1.Rows.Add(i, p.Info);
            p = p.Link;
            i++;
        }
    }
}
