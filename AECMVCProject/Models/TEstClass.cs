using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AECMVCProject.Models
{
    public class TEstClass
    {
        public int Add(int x,int y)
        {

            dynamic c = new Student();
            //c.sdhasjfhajks=10;//Exception
            return x + y;
        }

        public void DisplayAdd()
        {
            int a = 10;
            int b = 20;
            Add(a,b);//call Add send a,b
        }
    }
}
