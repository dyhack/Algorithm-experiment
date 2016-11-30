using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int []test={2,3,6,7,5,20,10,30,1,8,50};
            Program p = new Program();
            p.QuickSort(test, 0, 10);
            foreach(int t in test)
            {
                Console.Write(t+" ");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">要排序的数组</param>
        /// <param name="p">数组以p为起点的位置</param>
        /// <param name="r">数组的划分的结尾地址</param>
        public   void  QuickSort(int []a,int p,int r)
        {
            if(p<r)//递归判断条件
            {
                int q=Partition(a,p,r);
                QuickSort(a,p,q-1);//对左半段排序
                QuickSort(a,q+1,r);//对右半段排序
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">要排序的数组</param>
        /// <param name="p">数组以p为起点的位置</param>
        /// <param name="r">数组的划分的结尾地址</param>
        /// <returns>返回已经排好序的基准元素a[p]</returns>
        private int Partition(int []a,int p,int r)
        {
            int i=p,j=r+1;
            int x=a[p];//基准元素
            //将小于基准元素的交换到左边
            //大于基准元素的交换道右边
            while(true)
            {
                while(a[++i]<x&&i<r);
                while(a[--j]>x);
                if(i>=j)
                    break;
                //交换a[i]和a[j]
                int temp=a[i];
                a[i]=a[j];
                a[j]=temp;

            }
            a[p]=a[j];
            a[j]=x;
            return j;
            
        }
    }
}
