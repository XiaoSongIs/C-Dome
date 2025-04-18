using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace UseNode
{
    class ListNodeTwo<T>
    {
        private class  Node
        {
            public T t;
            public Node next;

            /// <summary>
            /// 
            /// </summary>
            public Node(T t)
            {
                this.t = t; 
                this.next = null;
            }
            /// <summary>
            /// 
            /// </summary>
            public Node(T t , Node node)
            {
                this.t = t;
                this.next = node;
            }

            public override string ToString()
            {
                return t.ToString();
            }
        }
        private int Count;
        private Node Head;

        public ListNodeTwo()
        {
            this.Count = 0;
            this.Head = null;
        }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="t">数据</param>
        public void Add(int index, T t)
        {
            if (index == 0)
            {
                Node node = new Node(t);
                node.next = Head;
                Head = node;
                Count++;
            }
            else
            {
                Node h1 = Head;
                Node node = new Node(t);
                for (int i = 0; i < index-1; i++)
                    h1 = h1.next;
                node.next = h1.next;
                h1.next = node;
                Count++;
            }
        }

        public void AddFirst(T t)
        {
            Add(0, t);
        }
        public void AddLast(T t)
        {
            Add(Count,t);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            Node node = Head;
            while(node != null)
            {
                str.Append(node.t.ToString() + "->");
                node = node.next;
            }
            str.Append("null");
            return str.ToString();
        }


        public T TrainingPlan()
        {



            return Head.t;
        }
    }
}
