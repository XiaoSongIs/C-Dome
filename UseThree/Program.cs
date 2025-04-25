namespace UseThree
#nullable disable
{
    /// <summary>
    /// 使用树
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            int[] values = { 50, 30, 70, 20, 40, 60, 80 };
            foreach (var item in values)
            {
                tree.Insert(item);
            }
            List<int> list = new List<int>();
            //tree.PreOrder();
            tree.InOrder();
        }
    }

    public class Tree<T>
    {
        public class TreeNode
        {
            public T value;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(T t)
            {
                this.value = t;
                left = null;
                right = null;
            }
        }

        public TreeNode root;  // 父节点

        private TreeNode InsetRe(TreeNode node,T value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }
            if (int.Parse(value.ToString()) < int.Parse(node.value.ToString()))
            {
                node.left = InsetRe(node.left, value);
            }
            else
            {
                node.right = InsetRe(node.right, value);
            }
            return node;
        }

        public void Insert(T value)
        {
            root = InsetRe(root, value);
        }


        /// 遍历前序遍历
        private void PrOrderT(TreeNode node)
        {
            if (node == null) return;
            Console.Write(node.value + " ");
            PrOrderT(node.left);
            PrOrderT(node.right);
        }

        public void PreOrder()
        {
            PrOrderT(root);
            Console.WriteLine();
        }

        List<int> list = new List<int>();
        /// 遍历中序遍历
        private void InOrderTraversal(TreeNode node)
        {
            if (node == null) return;
            InOrderTraversal(node.left);
            //Console.WriteLine(node.value + "");
           
            InOrderTraversal(node.right);

            list.Add(int.Parse(node.value.ToString()));
        }

        public void InOrder()
        {
            InOrderTraversal(root);

            foreach (var item in list)
            {
                Console.WriteLine(item+"->");
            }

            Console.ReadLine();
        }
    }
    
}
