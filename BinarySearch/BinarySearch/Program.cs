using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 2, 3, 4, 5, 30, 31, 33, 50, 89};
            Program p = new Program();
            foreach (int t in test)
            {
                Console.Write(t+" ");
            }
            Console.WriteLine();
            p.BinarySearch1(test, 89, 0, 9);
        }
        /// <summary>
        /// 二分搜索算法(递归方法)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="num"></param>
        public void BinarySearch(int[] a, int num, int left, int right)
        {
            //int left = left1, right = right1;
                int middle = (left + right) / 2;
                if (num == a[middle])
                {
                    Console.WriteLine("在" + (middle + 1) + "位");
                    return;

                }
                if (left <= right)
                {
                    if (num < a[middle])
                    {
                        right = middle - 1;
                        BinarySearch(a, num, left, right);
                    }
                    else
                    {
                        left = middle + 1;
                        BinarySearch(a,num,left,right);

                    }

                }
                

            

                
                    
               

        }
        /// <summary>
        /// 二分搜索算法(常规方法)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="num"></param>
        public void BinarySearch1(int[] a, int num, int left1, int right1)
        {
            int left = left1, right = right1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (num == a[middle])
                {
                    Console.WriteLine("在" + (middle + 1) + "位");
                    return;

                }
                if (left <= right)
                {
                    if (num < a[middle])
                    {
                        right = middle - 1;
                   
                    }
                    else
                    {
                        left = middle + 1;
                       

                    }

                }

            }







        }
    }
}
