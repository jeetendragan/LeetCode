using System;

namespace add_two_nums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListNode l1 = new ListNode(2);
            ListNode p1 = new ListNode(4);
            l1.next = p1;
            ListNode p2 = new ListNode(3);
            p1.next = p2;


        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            // int number1 = 0;
            // ListNode p = l1;
            // pow = 0;
            // while(p != null)
            // {
            //     number1 += p.val * Math.Pow(10, pow);
            //     pow++;
            //     p = p.next;
            // }

            // int number2 = 0;
            // p = l2;
            // pow = 0;
            // while(p != null)
            // {
            //     number2 += p.val * Math.Pow(10, pow);
            //     pow++;
            //     p = p.next;
            // }

            ListNode p1 = l1;
            ListNode p2 = l2;
            ListNode p3Prev = null;
            ListNode p3 = null;
            ListNode ans = null;
            int n1, n2, carry = 0;
            while(p1 != null && p2 != null){
                if(p1 != null){
                    n1 = p1.val;
                }else{
                    n1 = 0;
                }
                p1 = p1.next;

                if(p2 != null){
                    n2 = p2.val;
                }else{
                    n2 = 0;
                }
                p2 = p2.next;

                int sum = n1 + n2 + carry;
                carry = sum / 10;
                int rem = sum % 10;
                p3 = new ListNode(rem);
                if(p3Prev == null){
                    p3Prev = p3;
                    ans = p3;
                }else{
                    p3Prev.next = p3;
                }
                p3Prev = p3;
                
            }

            if(carry != 0){
                p3 = new ListNode(carry);
                p3Prev.next = p3;
            }
            
            return ans;

        }

    }

    

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
