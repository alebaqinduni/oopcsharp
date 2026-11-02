using System;
using ClassStore;

namespace ClassApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.Start();
        }
    }
}
//for second one:
//2.For the second one given as numeric range(minimum and maximum one),as i have only product which has SalePrice no else price or age one so ill add the condition of minimum 100 and maximum 500 one record to be shown in the productservice.cs layer and then the condition will work in this productui.cs and program.cs one 
//we can also add this condition to purchaseprice in our productservice.cs one file

//for third one:
//3.in category or status i have only category one in my categoryservice.cs one so ill add condition there