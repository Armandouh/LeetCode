using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static public void Main()
    {
        ListNode list = new ListNode(1, new ListNode(2, new ListNode(3)));
        var curr = list;
    }

    static ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode curr = head;

        while (curr != null)
        {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}