using System;

namespace MielipiteenRekisteröijä
{
    class Program
    {
        static void Main(string[] args)
        {
            Registrant registrant = new Registrant();

            registrant.CreateTestData(); // Optional test data generator

            registrant.Start();
        }
    }
}
