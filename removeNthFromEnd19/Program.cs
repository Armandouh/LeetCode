using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        ListNode l1 = new ListNode(1);
        ListNode l2 = new ListNode(2);
        ListNode l3 = new ListNode(3);
        ListNode l4 = new ListNode(4);
        ListNode l5 = new ListNode(5);

        l1.next = l2;
        l2.next = l3;
        l3.next = l4;
        l4.next = l5;
        
        
 
        l1 = RemoveNthFromEnd(l1, 2);
        printList(l1);
    }

    private static void printList(ListNode head)
    {
        ListNode current = head;

        while (current != null)
        {
            Console.Write(current.val + " -> ");
            current = current.next;
        }
        Console.WriteLine("null");
        Console.WriteLine();
    }

    private static ListNode RemoveNthFromEnd(ListNode head, int position)
    {
        ListNode dummy = new ListNode(-1);

        dummy.next = head;
        ListNode ptr1 = dummy.next;
        ListNode ptr2 = dummy.next;

        for (int i = 0; i < position; i++)
            ptr2 = ptr2.next;

        while (ptr2.next != null)
        {
            ptr1 = ptr1.next;
            ptr2 = ptr2.next;
        }

        ptr1.next = ptr1.next.next;

        return dummy.next;
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
}