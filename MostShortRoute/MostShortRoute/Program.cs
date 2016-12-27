using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostShortRoute
{
    public class MaxSum 
    {
    static int MAX_SIZE=6; //设顶点数为6
    public static void dijkstra(int v,float[,]a,float[]dist,int[]prev)
    {  //v是源点，a[i][j]是边(i,j)的权，dist[i]表示当前从源到顶点i的最短特殊路径长度
    //prev[i]记录的是从源点到顶点i的最短路径上i的前一个顶点
   int n=dist.Length-1;  //n为G图中的顶点个数,问题的规模，0号元素未使用
   if(v<1||v>n)return;  //在所有点中选择一点作为源点v
   bool []s=new bool[n+1];//判断点是否在集合S中,一个顶点属于s(值为true)当且仅当从源到该顶点的最短路径长度已知0
   for(int i=1;i<=n;i++)
   {
    dist[i]=a[v,i];
    s[i]=false;//将集合s中的所有点设为false,即dist[i]不确定是否为最短路径
    if(dist[i]==float.MaxValue)
     prev[i]=0;//说明从源点v需要经过别的点才能到达i(Float.MAX_VALUE意为大数无穷)
    else
     prev[i]=v;//有通路则让点i的前驱指向源
   }
   dist[v]=0;s[v]=true;//初始时s中只含有v
   for(int i=1;i<n;i++)
   {
    float temp=float.MaxValue;
    int u=v;   //在剩下的点中除了没有通路的点中找到最容易到达的，并把最容易到达的放入u中
    for(int j=1;j<=n;j++)
     if((!s[j])&&(dist[j]<temp))
     {
      u=j;
      temp=dist[j];//temp为所有的dist[j]的最优解
     }
    s[u]=true;  //dist[u]已确定，则可将点u放入s中去
    for(int j=1;j<=n;j++)
        if ((!s[j]) && (a[u, j] < float.MaxValue))
     {//源到点j通过点u的最短特殊路径长度newdist
      float newdist=dist[u]+a[u,j];
      if(newdist<dist[j])
      {//v到j的最短路径经过u
       dist[j]=newdist;
       prev[j]=u;
      }
     }
   }
} static void Main(String[] args)
{
   float [,]a=new float[MAX_SIZE,MAX_SIZE];float[]dist=new float[MAX_SIZE];int []prev=new int[MAX_SIZE];
   for(int i=0;i<6;i++)
    for(int j=0;j<6;j++)
     a[i,j]=float.MaxValue;;
   a[1,2]=10;
   a[1,4]=30;
   a[1,5]=100;
   a[2,3]=50;
   a[3,5]=10;
   a[4,3]=20;
   a[4,5]=60;
   int v=1;//假设从顶点1处出发
   
   dijkstra(v,a,dist,prev);
   
   Console.WriteLine("从1出发到2、3、4、5的最短路径依次是:");
   for(int j=2;j<6;j++)
   {
    Console.WriteLine(dist[j]);
   }
   
   int z=prev[5],y=prev[z],x=prev[y];
   Console.WriteLine("从1到5最短路径经过的点为：");
   Console.WriteLine(x + " " + y + " " + z + " " + "5");
 
}
 
}
    //class Program
    //{
    //    static void Main(String[] args)
    //    {
            
 
    //    }
    //}

    
    
}
