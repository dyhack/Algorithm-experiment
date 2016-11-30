using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DateTime now =DateTime.Now;
                Program Hanoi = new Program();
                string n;
                char a = 'A', b = 'B', c = 'C';
                n = Console.ReadLine();
                Hanoi.hanoi(int.Parse(n), a, b, c);
                DateTime end = DateTime.Now;
                Console.WriteLine("总共耗时" + (end - now).TotalSeconds+"秒");
            }
            catch (Exception e)
            {
                Console.WriteLine("输入错误，请重新输入");
            }
            
           
        }
        /// <summary>
        /// 汉诺塔移动程序(递归方法)
        /// </summary>
        /// <param name="n">圆盘总的个数</param>
        /// <param name="a">A柱的位置</param>
        /// <param name="b">B柱的位置</param>
        /// <param name="c">C柱的位置</param>
        public void hanoi(int n, char a, char b, char c)
        {
            if (n > 0)//盘子个数足够
            {
                hanoi(n - 1, a, c, b);//n-1个盘子先从a移动到c通过b
                move(a, b);//把最低下的一个盘子从a上移动到b
                hanoi(n - 1, c, b, a);//n-1个盘子从c移动到b通过a

            }
            else
            //递归结束条件
            {
                return;
            }

 
        }
        private void move(char a,char b)
        {
            Console.WriteLine(a+"-->"+b);
        }
    }
}
