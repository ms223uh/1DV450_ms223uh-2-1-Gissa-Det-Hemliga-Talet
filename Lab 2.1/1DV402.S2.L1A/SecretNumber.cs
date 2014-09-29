using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    class SecretNumber
    {
        // Skapar fält enligt kraven för uppgiften & sätter värden på dom.

        private int _number;
        private int _count;
        public const int MaxNumberOfGuesses = 7;



        // _Count får ett värde.
       //  Vi skapar en slumgenerator i en ny metod för det hemliga numret som ska ligga mellan 1-100. Vi tar hjälp av attributen "Random"
       //  Det sista värdet som vi skriver ut ingår inte i intervallen. Så om vi hade skriver (1, 100) som hade varit logiskt tänkt så hade vi bara fått tal mellan 1 & 99.
       
        public void Initialize()
        {
            
            _count = 0;
            Random Random = new Random();
            _number = Random.Next(1, 101);

        }


        // number = Vad användaren skriver in för värde.
       //  _number = Vad vår slumpgenerator har kommit fram till för nummer.
      //   ArgumentOutOfRangeException = Om talet som användaren skriver in ligger utanför intervallen 1-100 så får denna ett nytt försök att skriva in ett nytt tal.
     //    Antal gissningar som är kvar räknas ut med "MaxNumberOFGuesses" - "_count". "MNOG" = 7 & för varje gång vi gör en gissning så dras ett värde bort..
    //     .. på det nuvaranded värde på gissningar med hjälp av vår loop.
   //      Så länge "_count" är mindre än "MNOG" så kör kör får loop alla if-satser.
  //       return true = Skickar tillbaka oss till början om "number" = "_number".
 //        return false = Skickar tillbaka oss till början om "number" inte är samma som "_number" efter alla gissningar.
//         ApplicationException = Ett meddelande där användaren får välja att börja om applikationen eller stänga av den.
 
        public bool MakeGuess(int number)
        {



            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_count < MaxNumberOfGuesses)
            {
                _count++;

                if (number > _number)
                {
                    Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - _count); 
                }

                if (number < _number)
                {
                    Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - _count);
                }

                if (number == _number)
                {
                    Console.WriteLine("\nGrattis {0} är rätt svar! - Du klarade det på {1} försök", number, _count);
                    return true;
                }

                if (_count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("\nDu har slut på gissningar - Det rätta talet var {0}", _number);
                }

                return false; 

        }

            else
            {
                throw new ApplicationException();
            }



        }


        //"SecretNumber" kallar på metoten "Initialize".

        public SecretNumber()
        {
            Initialize();
        }









    }
}
