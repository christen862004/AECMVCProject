using AECMVCProject.Repository;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AECMVCProject.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //logic using buuble sort
        }
    }
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {
            //logic using buuble sort
        }
    }
    class ChirsSort : ISort
    {
        public void Sort(int[] arr)
        {
            //logic using buuble sort
        }
    }
    //DIP
    class MyList//High Level Class
    {
        int[] arr;
        ISort SortAlg;//Tigh Couple [dependd on Low Level Class] ,base on abstratcion or interface
        public MyList(ISort sortAlg)//DI 
            //repose creat sort ,ask [ControllerFacotr==>As kContainer]
        {
            this.SortAlg = sortAlg; 
        }
        public void SortList() {
            SortAlg.Sort(arr);
        }
    }
    public class TEstClass
    {
        public void TestDay7()
        {
            MyList list = new MyList(new BubbleSort());
            MyList list2 = new MyList(new SelectionSort());
            MyList list3 = new MyList(new ChirsSort());
            list.SortList();
        }
        public int Add(dynamic x,int y)
        {
            Controller1 c1=new Controller1();
            c1.DisplayData();
            c1.SetData();//
            c1 = new Controller1();
            c1.DisplayData();//empty
            



            dynamic c = new Student();
            //c.sdhasjfhajks=10;//Exception
            return x + y;
        }
        public class Controller1
        {

            private int x;//fiels

            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public dynamic Y
            {
                get { return x; }
                set { x = value; }
            }



            public List<string> Data { get; set; }
            public Controller1()
            {
                Data = new List<string>();
            }
            public void SetData()
            {
                Data.Add("1");
                Data.Add("1");
                Data.Add("1");
                Data.Add("1");
                Data.Add("1");
            }
            public void DisplayData()
            {
                //diplas list
            }
        }
        public void DisplayAdd()
        {
            int a = 10;
            int b = 20;
            Add(a,b);//call Add send a,b
            Add(10, 20);
            Add(10 + 10, 30 + 90);
        }
    }
}
/*
*/