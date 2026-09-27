public class Node
{
    private int info;
    private Node link;
    public int Info
    {
        get { return info; }
        set { info = value; }
    }
    public Node Link
    {
        get { return link; }
        set { link = value; }
    }
    public Node() { }

    public Node(int info)
    {
        Info = info;
    }

    public Node(int info, Node link)
    {
        Info = info; Link = link;
    }
}
