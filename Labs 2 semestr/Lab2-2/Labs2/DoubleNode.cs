public class DoubleNode
{
    private int info;
    private DoubleNode next;
    private DoubleNode prev;
    public int Info{ get; set; }
    public DoubleNode Next { get; set; }
    public DoubleNode Prev { get; set; }
    public DoubleNode() { }
    public DoubleNode(int info)
    {
        Info = info;
    }
    public DoubleNode(int info, DoubleNode next, DoubleNode prev)
    {
        Info = info; Next = next; Prev = prev;
    }
}