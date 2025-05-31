// See https://aka.ms/new-console-template for more information
using _01___OOP_Basic._03_Inheri_MediaLibrary;
using _01___OOP_Basic._03_Inheri_MediaLibrary.AfterReview;
using _01___OOP_Basic.Interssaction_Clock;
using _01___OOP_Basic.VendingMachine;

namespace _01___OOP_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to OOP Basic Learning...");

            #region Vending Machine
            VendingMachine.VendingMachine vendingMachine = new VendingMachine.VendingMachine();
            vendingMachine.ShowPromot();
            vendingMachine.ShowBalance();
            vendingMachine.ShowTotal();

            vendingMachine.InsertMoney(5);
            vendingMachine.GetVendingItem();
            vendingMachine.ShowBalance();
            vendingMachine.ShowTotal();
            vendingMachine.InsertMoney(3);
            vendingMachine.GetVendingItem();
            vendingMachine.ShowBalance();
            vendingMachine.ShowTotal();
            #endregion

            #region Property Learning
            PropertyLearning propertyLearning = new PropertyLearning() { LastName = "Doe" };
            propertyLearning.TestMethod();
            #endregion

            #region
            ConstructorLearning c1 = new ConstructorLearning();
            var value = c1.ComplexValueFromAPI; // This will call the getter and simulate an API call
            ConstructorLearning c2 = new ConstructorLearning("Jack");
            ConstructorLearning c3 = new ConstructorLearning(25);
            ConstructorLearning c4 = new ConstructorLearning("Jack", 30);
            ConstructorLearning c5 = new ConstructorLearning("Jack", 30, "Sydney");

            #endregion


            #region Clock
            Clock clock = new Clock();
            // clock.Start();
            #endregion

            #region
            _03_Inheri_MediaLibrary.MediaDatabase mediaDatabase = new _03_Inheri_MediaLibrary.MediaDatabase();
            mediaDatabase.AddCD(new Inheri_MediaLibrary.CD("Album1", "Artist1", 10, "Great album!"));
            mediaDatabase.AddCD(new Inheri_MediaLibrary.CD("Album2", "Artist2", 12, "Another great album!"));

            mediaDatabase.AddDVD(new Inheri_MediaLibrary.DVD("Movie1", "Director1", "Great movie!"));
            mediaDatabase.AddDVD(new Inheri_MediaLibrary.DVD("Movie2", "Director2", "Another great movie!"));
   

            mediaDatabase.PrintAllMedia();

            _03_Inheri_MediaLibrary.AfterReview.MediaDatabase mediaDatabase1 = new _03_Inheri_MediaLibrary.AfterReview.MediaDatabase();
            mediaDatabase1.Add(new _03_Inheri_MediaLibrary.AfterReview.CD("Album1", "Artist1", 10, "Great album!"));
            mediaDatabase1.Add(new _03_Inheri_MediaLibrary.AfterReview.CD("Album2", "Artist2", 12, "Another great album!"));
            mediaDatabase1.Add(new _03_Inheri_MediaLibrary.AfterReview.DVD("Movie1", "Director1", "Great movie!"));
            mediaDatabase1.Add(new _03_Inheri_MediaLibrary.AfterReview.DVD("Movie2", "Director2", "Another great movie!"));
            mediaDatabase1.PrintAllMedia();
            #endregion
        }
    }
}