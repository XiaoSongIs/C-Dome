#nullable disable
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;

namespace UseNode
{
    /*
     * 使用链表
     * 充分利用空间使用动态扩展 
     * 只能通过上一个节点的next指针来访问下一个节点
     */
    class Program
    {
        static void Main(string[] args)
        {
            ////ListNode<int> list1 = new ListNode<int>();

            //ListNodeOne<int> list = new ListNodeOne<int>();
            //list.AddFirst(1);
            ////Console.WriteLine(list);
            //list.AddFirst(2);
            //list.AddFirst(2);
            //list.AddFirst(2);
            ////Console.WriteLine(list);
            //list.AddFirst(1);
            ////Console.WriteLine(list);
            ////list.AddLast(1);
            ////Console.WriteLine(list);
            ////list.Remove(0);
            //Console.WriteLine(list);
            //Console.WriteLine("----------------------------");
            //list.Removes(1);
            //Console.WriteLine(list);
            ////list1.AddFirst(5);
            ////list1.AddFirst(4);
            ////list1.AddFirst(8);
            ////list1.AddFirst(1);
            ////list1.AddFirst(4);

            //////list1.AddFirst(4);
            //////list1.AddFirst(2);
            //////list1.AddFirst(1);
            //////list1.AddFirst(9);
            //////list1.AddFirst(0);

            ////ListNode<int> list2 = new ListNode<int>();

            ////list2.AddFirst(5);
            ////list2.AddFirst(4);
            ////list2.AddFirst(8);
            ////list2.AddFirst(1);
            ////list2.AddFirst(0);
            ////list2.AddFirst(5);

            //////list2.AddFirst(4);
            //////list2.AddFirst(2);
            //////list2.AddFirst(3);

            ////list2.Delete(2);

            ////Console.WriteLine(list1);
            ////Console.WriteLine(list2);



            ////Console.WriteLine(list1.IsEqual(list1, list2));

            ////                      "()[]{}"
            ////                      "{{}}"
            ///*onsole.WriteLine(IsValid("{{}}"));*/

            ////Console.WriteLine(CalPoints(["5", "-2", "4", "C", "D", "9", "+", "+"]));


            //ListNodeTwo<int> list = new ListNodeTwo<int>();
            //list.Add(0,1);
            //list.Add(1,2);
            //list.Add(2,3);
            //list.AddFirst(3);
            //list.AddLast(100);

            //List<int> list1 = new List<int>();
            //list1.Count = 0;
            //Console.WriteLine(list);

            LIstNodeThere<int> list = new UseNode.LIstNodeThere<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(2);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddFirst(1);
            Console.WriteLine(list.ToString());
            bool isPalindrom = list.IsPalindrome();
            Console.WriteLine(isPalindrom);



        }





        public static int CalPoints(string[] operations)
        {

            Stack<int> stakc = new Stack<int>();
            foreach (var item in operations)
            {
                if (item == "+" && stakc.Count >= 2)
                {
                    int a1 = stakc.Pop();
                    int a2 = stakc.Pop();
                    int sum = a1 + a2;
                    stakc.Push(a2);
                    stakc.Push(a1);
                    stakc.Push(sum);
                }
                else if (item == "D" && stakc.Count >= 1)
                {
                    int sum = stakc.Peek() * 2;
                    stakc.Push(sum);
                }
                else if (item == "C" && stakc.Count >= 1)
                {
                    stakc.Pop();
                }
                else
                {
                    stakc.Push(int.Parse(item));
                }
            }

            int sum1 = 0;
            foreach (var item in stakc)
            {
                sum1 += item;
            }

            return sum1;
        }


        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            if (s.Length % 2 != 0)
                return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(')');
                }
                else if (s[i] == '[')
                {
                    stack.Push(']');
                }
                else if (s[i] == '{')
                {
                    stack.Push('}');
                }
                else if (stack.Count == 0 || s[i] != stack.Pop())
                {
                    return false;
                }
            }

            if (stack.Count != 0)
            {
                return false;
            }
            return true;

        }

        public static bool IsPalindrome(ListNode head)
        {
           
            Stack<int> stack = new Stack<int>();
            var handx = head;
            while (handx != null)
            {
                stack.Push(handx.val);
                handx = handx.next;
            }

            if (stack.Count % 2 != 0) return false;
            int sum = 0;
            int sum1 = 0;
            for (int i = 0; i < stack.Count / 2; i++)
            {
                sum += stack.Pop();
            }
            for (int i = 0; i < stack.Count; i++)
            {
                sum1 += stack.Pop();
            }

            if (sum != sum1)
            {
                return false;
            }
            else
            {
                return true;
            }



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


    public class ListNode<T>
    {
        private Node heard;
        private int Count;
        private class Node
        {
            public T t;
            public Node next;

            public Node(T t, Node next)
            {
                this.t = t;
                this.next = next;
            }

            public Node(T t)
            {
                this.t = t;
                this.next = null;
            }

            public override string ToString()
            {
                return t.ToString();
            }
        }

        public ListNode()
        {
            this.heard = null;
            this.Count = 0;
        }

        public void Add(int index, T t)
        {
            if (index == 0)
            {
                //Node node = new Node(t);
                //node.next = heard;
                //heard = node;
                heard = new Node(t, heard);
            }
            else
            {
                Node node = heard;
                for (int i = 0; i < index - 1; i++)
                    node.next = heard;

                Node newNode = new Node(t);
                newNode.next = node.next;
                node.next = newNode;

                //node.next = new Node(t,node.next);

            }

            Count++;
        }

        public void AddFirst(T t)
        {
            Add(0, t);
        }

        public void AddLast(T t)
        {
            Add(Count - 1, t);
        }

        public T Get(int index)
        {
            Node node = heard;
            for (int i = 0; i < index; i++)
                node = node.next;
            return node.t;
        }

        public T GetFirst()
        {
            return Get(0);
        }

        public T GetLast()
        {
            return Get(Count);
        }

        public void Set(int index, T t)
        {
            Node node = heard;
            for (int i = 0; i < index; i++)
                node = node.next;
            node.t = t;
        }

        public bool Contains(T t)
        {
            Node node = heard;

            while (node != null)
            {
                node = node.next;
                if (node.t.Equals(t))
                {
                    return true;
                }
            }

            //for (int i = 0; i < Count; i++)
            //{
            //    node = node.next;
            //    if (node.t.Equals(t))
            //    {
            //        return true;
            //    }
            //}
            return false;
        }


        public void Delete(int index)
        {
            Node node = heard;

            if (index == 0)
            {
                Node node2 = heard;
                heard = heard.next;
                Count--;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    node = node.next;

                Node node1 = node.next;
                node.next = node1.next;
                Count--;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            Node node = heard;
            while (node != null)
            {
                str.Append(node.t.ToString() + "->");
                node = node.next;
            }
            str.Append("Null");


            return str.ToString();
        }
    }





}
