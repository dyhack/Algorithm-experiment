using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01backpack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = {17,13};
            int[] w = {3,4};//下标从1开始.价值的对应的物品的重量
            int m, n;
            /*
            int **p = new int *[50];
            for(int i=0;i<50;i++)  
            {  
                p[i] = new int[2];
            } 
             * */
            Console.WriteLine("请输入最大的容量和货物的个数");
            m = Convert.ToInt32(Console.ReadLine());
            n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("待装物品重量分别为");
            //for (int i = 1; i <= N; i++)
            //{
            //    w[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //Console.WriteLine("待装物品价值分别为：");
            //for (int i = 1; i <= N; i++)
            //{
            //    v[i] = Convert.ToInt32(Console.ReadLine());
            //}
            Console.WriteLine("最大价值为{0}", Knapsack(m, n));
        }


        public static int Knapsack(int m, int n)
        {
            int[,] c = new int[100, 100];
            int []w=new int[10];
            int[] v=new int[10];
            Console.WriteLine("请输入物品的重量");
            for (int i = 1; i < n + 1; i++)
            {
                w[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("请输入物品的价值");
            for (int i = 1; i < n + 1; i++)
            {
                v[i] = Convert.ToInt32(Console.ReadLine());
            }

                for (int i = 0; i < 100; i++)
                    for (int j = 0; j < 100; j++)
                        c[i, j] = 0;

            for (int i = 1; i < n + 1; i++)
                for (int j = 1; j < m + 1; j++)
                {
                    if (w[i] <= j)
                    {
                        if (v[i] + c[i - 1,j - w[i]] > c[i - 1,j])
                            c[i,j] = v[i] + c[i - 1,j - w[i]];
                        else
                            c[i,j] = c[i - 1,j];
                    }
                    else

                        c[i,j] = c[i - 1,j];
                }
            return (c[n,m]);



        }

    }
}
