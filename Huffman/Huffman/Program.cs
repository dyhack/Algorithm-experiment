using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 哈夫曼树的定义
 * 给定一组带权重的叶节点，用它们来构造完全二叉树，最终整颗树的带权路径(总)长度最小的即为啥夫曼树。
 * 
 */
namespace Huffman
{
    public class Node
    {
        private int weight;//权重值
        private int lChild;//左子节点的序号
        private int rChild;//右子节点的序号
        private int index;//本节点的序号

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int LChild
        {
            get { return this.lChild; }
            set { lChild = value; }
        }

        public int RChild
        {
            get { return this.rChild; }
            set { rChild = value; }
        }

        public int Index
        {
            get { return this.index; }
            set { index = value; }
        }

        public Node()
        {
            weight = 0;
            lChild = -1;
            rChild = -1;
            index = -1;
        }

        public Node(int w, int lc, int rc, int p)
        {
            weight = w;
            lChild = lc;
            rChild = rc;
            index = p;
        }
    }
    public class HuffmanTree
    {
        private List<Node> _tmp;
        private List<Node> _nodes;

        public HuffmanTree(params int[] weights)
        {
            if (weights.Length < 2)
            {
                throw new Exception("叶节点不能少于2个!");
            }

            int n = weights.Length;

            Array.Sort(weights);

            //先生成叶子节点，并按weight从小到大排序
            List<Node> lstLeafs = new List<Node>(n);
            for (int i = 0; i < n; i++)
            {
                var node = new Node();
                node.Weight = weights[i];
                node.Index = i;
                lstLeafs.Add(node);
            }


            //创建临时节点容器
            _tmp = new List<Node>(2 * n - 1);

            //真正存放所有节点的容器
            _nodes = new List<Node>(_tmp.Capacity);

            _tmp.AddRange(lstLeafs);
            _nodes.AddRange(_tmp);
        }

        /// <summary>
        /// 构造Huffman树
        /// </summary>
        public void Create()
        {
            while (this._tmp.Count > 1)
            {
                var tmp = new Node(this._tmp[0].Weight + this._tmp[1].Weight, _tmp[0].Index, _tmp[1].Index, this._tmp.Max(c => c.Index) + 1);
                this._tmp.Add(tmp);
                this._nodes.Add(tmp);

                //删除已经处理过的二个节点
                this._tmp.RemoveAt(0);
                this._tmp.RemoveAt(0);


                //重新按权重值从小到大排序
                this._tmp = this._tmp.OrderBy(c => c.Weight).ToList();
            }
        }

        /// <summary>
        /// 测试输出各节点的关键值(调试用)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _nodes.Count; i++)
            {
                var n = _nodes[i];
                sb.AppendLine("index:" + i + "，weight:" + n.Weight.ToString().PadLeft(2, ' ') + "，lChild_index:" + n.LChild.ToString().PadLeft(2, ' ') + "，rChild_index:" + n.RChild.ToString().PadLeft(2, ' '));
            }
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanTree tree = new HuffmanTree(2, 1, 4, 3);
            tree.Create();

            Console.WriteLine("最终树的节点值如下：");
            Console.WriteLine(tree.ToString());
            Console.ReadLine();
        }
    }
}
