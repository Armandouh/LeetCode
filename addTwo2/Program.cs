using System;
using System.Security.AccessControl;

class Program
{
    static void Main()
    {
        ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(3)));
        ListNode l2 = new ListNode(3, new ListNode(1, new ListNode(6)));
        
        DisplayList(l1);
        DisplayList(l2);

        ListNode result = addTwo(l1, l2);
        
        DisplayList(result);

    }

    static ListNode addTwo(ListNode l1, ListNode l2)
    {
        ListNode result = new ListNode();
        ListNode ptr = result;
        int carry = 0;
        
        while (l1 != null || l2 != null)
        {
            int sum = 0 + carry;

            if (l1 != null)
            {
                sum = sum + l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            carry = sum / 10;
            sum = sum % 10;
            ptr.next = new ListNode(sum);
            ptr = ptr.next;

            if (carry == 1) ptr.next = new ListNode(1);

        }
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