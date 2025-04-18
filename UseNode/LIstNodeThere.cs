using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace UseNode
{
    /// <summary>
    ///  练习链表
    /// </summary>
    class LIstNodeThere<T>
    {
        private class Node
        {
            public T t;
            public Node next;

            public Node(T t)
            {
                this.t = t;
                next = null;
            }
            public Node(T t, Node next)
            {
                this.t = t;
                this.next = next;
            }

            public override string ToString()
            {
                return t.ToString();
            }
        }
        private Node head;
        private int count;

        public LIstNodeThere()
        {
           head = null;
           count = 0;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="index"></param>
        /// <param name="t"></param>
        public void Add(int index,T t)
        {
            /// 如果添加在首位
            if(index == 0)
            {
                Node node = new Node(t);
                node.next = head;
                head = node;
            }
            else
            {
                Node node = head;
                for(int i = 0; i < index - 1; i++)
                    node = node.next;
                Node node1 = new Node(t);
                node1.next = node.next;
                node.next = node1;
            }
            count++;
        }

        public void AddFirst(T t)
        {
            Add(0, t);
        }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            Node node = head;
            while(node != null)
            {
                str.Append(node.t.ToString()+"->");
                node = node.next;
            }
            str.Append("Null");
            return str.ToString();
        }


        public bool IsPalindrome()
        {
            List<int> list = new List<int>();
            Node node = head;
            while(node != null)
            {
                list.Add(int.Parse(node.t.ToString()));
                node = node.next;
            }
            int i;
            int j = list.Count - 1;
            for(i = 0; i < j; i++)
            {
                if (list[i] != list[j])
                {
                    return false;
                }
                j--;
            }
            return true;
        }

        //public Node MiddleNode()
        //{
        //    int i = 0;
        //    Node head1 = head;
        //    while(head1 != null)
        //    {
        //        i++;
        //        head1 = head1.next;
        //    }
        //    if(i == 1)
        //    {
        //        return head1;
        //    }
        //    if (i == 2)
        //    {
        //        return head1.next;
        //    }
        //    for (int j = 0; j < i; j ++)
        //    {
        //        if (j == i / 2)
        //        {
        //            return head;
        //        }
        //        head = head.next;
        //    }
        //    return head;
        //}

    }
}
