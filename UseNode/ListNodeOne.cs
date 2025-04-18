using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace UseNode
{
    public class ListNodeOne<T>
    {
        private class Node
        {
            public T t;
            public Node next;

            public Node(T t)
            {
                this.t = t;
                this.next = null;
            }
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

        //长度
        private int Count;
        //头节点
        private Node Head;

        public ListNodeOne()
        {
           Head = null;
           Count = 0;
        }


        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="node"></param>
        public void Add(int index, T t)
        {
            // 头部插入
            if (index == 0)
            {
                Node node1 = new Node(t);
                node1.next = Head;
                Head = node1;
            }
            else
            {
                Node nd = Head;
                for (int i = 0; i < index - 1; i++)
                    nd = nd.next;
                Node node = new Node(t);
                node.next = nd.next;
                nd.next = node;
            }
            Count++;
        }

        public void AddFirst(T t)
        {
            Add(0, t);
        }

        public void AddLast(T t)
        {
            Add(Count, t);
        }

        /// <summary>
        /// 删除 -- 根据位置 
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("index", "Index out of range");

            // 首位删除
            if (index == 0)
            {
                Node node = Head;
                Head = node.next;
            }
            else
            {
                Node node = Head;
                for (int i = 0; i < index - 1; i++)
                    node = node.next;
                Node remove = node.next;
                node.next = remove.next;
            }
            Count--;
        }

        /// <summary>
        /// 根据内容去删除
        /// </summary>
        public void Removes(T t)
        {
            if (Head.t.Equals(t))
            {
                while ( Head != null && Head.t.Equals(t))
                {
                    if (Head.next == null)
                    {
                        Head = null;
                    }
                    else
                    {
                        Head = Head.next;
                    }
                }
            }
            //else
            {
                Node nodes = Head;
                Node node = null;

                while (nodes != null)
                {
                    if (nodes.t.Equals(t))
                    {
                        //if (nodes != null && nodes.next != null)
                        {
                            node.next = nodes.next;
                            nodes = nodes.next;
                        }
                    }
                    else
                    {
                        node = nodes;
                        nodes = nodes.next;
                    }

                }
            }    
        }

        
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            Node node = Head;
            while (node != null)
            {
                str.Append(node.t + "->");
                node = node.next;
            }
            str.Append("Null");
            return str.ToString();
        }

    }
}
