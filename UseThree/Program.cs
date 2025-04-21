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
            //if(node == null)
            //{
            //    return new TreeNode(value);
            //}
            //if (int.Parse(value.ToString()) < int.Parse(node.left.ToString()))
            //{
            //    node.Left = InsetRe(node.Left, value);
            //}
            return node;
        }

    }
    
}
