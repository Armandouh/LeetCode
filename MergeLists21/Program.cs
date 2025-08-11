using System;

class Program
{
    static void Main()
    {
        ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(6)));
        ListNode l2 = new ListNode(4, new ListNode(8, new ListNode(12)));
        ListNode Merged = MergeLists(l1, l2);

        DisplayList(Merged);
    }

    static ListNode MergeLists(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode(int.MinValue);
        ListNode result = dummy;

        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                dummy.next = l1;
                l1 = l1.next;
            }

            else
            {
                dummy.next = l2;
                l2 = l2.next;
            }

            dummy = dummy.next;
        }

        if (l1 == null)
            dummy.next = l2;
        else dummy.next = l1;

        return result.next;
    }

    static void DisplayList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " -> ");
            head = head.next;
        }

        Console.Write("null ");
        Console.WriteLine();
    }
}


class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}