using System;

namespace BiDirectionalList;

class Program
{
    static void Main(string[] args)
    {
        BiDirectionalList list = new BiDirectionalList();

        Random rng = new Random();

        for (int i = 0; i < 5; i++)
        {
            list.AddToBeginning(Math.Round(rng.NextDouble() * 10, 2));
        }
        
        int index = list.FindFirstEntryOfElementBelowAvarage();

        foreach (double item in list)
        {
            if(index == 0) {
                Console.WriteLine(item + " <- first element below avarage =)");
            }
            else{
                Console.WriteLine(item);
            }
            index--;
        }          

        Console.WriteLine("Avarage: " + Math.Round(list.FindAvarage(), 2));
        Console.WriteLine("Max element: " + Math.Round(list.FindMaxElement(), 2));
        Console.WriteLine("Sum after max element: " + Math.Round(list.FindSumAfterMaxElement(), 2));


        
        Console.WriteLine("Enter the number to create a new list from the first one but without " + 
        "elements below it: ");
        double yourNumber = Convert.ToDouble(Console.ReadLine());

        var newList = list.NewListGreaterThanNumber(yourNumber);
        Console.WriteLine("New list with elements greater than " + yourNumber + ": ");

        foreach (double item in newList)
        {
            Console.WriteLine(item);
        }

        var newList2 = list.NewListWithoutElementsBeforeMax();
        Console.WriteLine("New list without elements before max element: ");

        foreach (double item in newList2)
        {
            Console.WriteLine(item);
        }

        Console.ReadKey();
    }
}
