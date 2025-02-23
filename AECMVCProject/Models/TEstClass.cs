using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AECMVCProject.Models
{
    public class Controller1
    {
       
        private int x;//fiels

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public dynamic  Y
        {
            get { return x; }
            set {x = value; }
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

    public class TEstClass
    {
        
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
