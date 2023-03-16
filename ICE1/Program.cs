using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declare variables
            int iTotalScripts = default;
            int iTotalLectures = default;
            int iQuestionMarkAmount;
            int iQuestionAmt = default;
            int iScriptsPerLecturer;
            int iRemainingScripts;
            int iTotalPoints = default;
            int iTimePerTest;
            int iTimePerLecturer;
            int iTimeTotal;
            int iTimeTotalExtra;
            int iTimeExtraLecturer;

            //while loop to ensure entered number is more than 0
            while (iTotalScripts<1)
            {
                Console.WriteLine("Please enter the amount of scripts to be marked.");
                iTotalScripts = Convert.ToInt32(Console.ReadLine());
            }

            //while loop to ensure entered number is more than 0
            while (iTotalLectures < 1)
            {
                Console.WriteLine("Please enter the amount of lecturers who will be marking.");
                iTotalLectures = Convert.ToInt32(Console.ReadLine());
            }

            //while loop to ensure entered number is between 1 and 10 inculsive
            while ((iQuestionAmt < 1) || (iQuestionAmt > 10) )
            {
                Console.WriteLine("Please enter the amount of questions to be marked.");
                iQuestionAmt = Convert.ToInt32(Console.ReadLine());
            }

            //reads in all subtotals for the allotted amount of questions entered above
            for (int i = 0; i < iQuestionAmt; i++)
            {
                iQuestionMarkAmount = default;
                while (iQuestionMarkAmount < 1)
                {
                    Console.WriteLine("Pleas enter the value for question " + (i + 1));
                    iQuestionMarkAmount = Convert.ToInt32(Console.ReadLine());
                    if (iQuestionMarkAmount >= 1) iTotalPoints += iQuestionMarkAmount;
                }
            }

            Console.WriteLine("The total for a test is: " + iTotalPoints);

            //calculates the scripts per lecturer and remaining scripts
            iScriptsPerLecturer = iTotalScripts / iTotalLectures;
            Console.WriteLine("Scripts per lec: " + iScriptsPerLecturer);

            //Calculates and display total points to mark per lecturer
            Console.WriteLine("Total points to mark per lecture: " + iScriptsPerLecturer*iTotalPoints);

            //Calculates remaining script
            iRemainingScripts = iTotalScripts % iTotalLectures;
            Console.WriteLine("Remaining scripts: " + iRemainingScripts);

            //calculates the total amount of seconds needed to do a test
            iTimePerTest = iTotalPoints * 2;
            iTimePerLecturer = iTimePerTest * iScriptsPerLecturer;
            iTimeTotal = iTimePerLecturer / 60;

            Console.WriteLine("Total seconds: " + iTimePerLecturer);

            Console.WriteLine("Minutes: " + iTimeTotal);
            Console.WriteLine("Seconds: " + (iTimePerLecturer % 60));

            //check
            if ((iTimePerLecturer % 60 < 60) && (iTimePerLecturer % 60 > 30) && !(iTimePerLecturer % 60 == 0)) iTimeTotal++;

            Console.WriteLine("New Time: " + iTimeTotal);
            Console.WriteLine("The lecturers will spend an average of " + (iTimeTotal/60) + " hours and " + (iTimeTotal%60) + " minutes marking scripts.");

            //checks if there are any remaining scripts, if there are add the time the extra scripts will take to mark.
            if (iRemainingScripts != 0)
            {
                iTimeExtraLecturer = iTimePerTest * (iRemainingScripts+iScriptsPerLecturer);
                iTimeTotalExtra = iTimeExtraLecturer / 60;

                Console.WriteLine("Minutes x: " + iTimeTotalExtra);
                Console.WriteLine("Seconds x: " + (iTimeExtraLecturer % 60));

                if ((iTimeExtraLecturer % 60 < 60) && (iTimeExtraLecturer % 60 > 30) && !(iTimeExtraLecturer % 60 == 0)) iTimeTotalExtra++;

                Console.WriteLine("New TimeExtra: " + iTimeTotalExtra);
                Console.WriteLine("The extra lecturer will spend an estimated time of " + (iTimeTotalExtra / 60) + " hours and " + (iTimeTotalExtra % 60) +" minutes marking extra scripts");
            }

            Console.ReadLine();
        }
    }
}
