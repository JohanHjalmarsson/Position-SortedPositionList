using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");
            Console.WriteLine(new Position(10, 15).Equals(new Position(10, 15)) + "\n");
            Console.WriteLine(new Position(10, 15).Equals(new Position(3, 15)) + "\n");

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + "\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine(list1 + "\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + "\n");

            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");




            // Create positions and SortedPosLists, add positions and use the ^ operator

            Position p1 = new Position(1, 2);
            Position p2 = new Position(4, 2);
            Position p3 = new Position(2, 2);
            Position p4 = new Position(6, 2);
            Position p5 = new Position(1, 2);
            Position p6 = new Position(1, 8);
            Position p7 = new Position(2, 2);
            Position p8 = new Position(2, 6);
            Position p9 = new Position(1, 1);
            Position p10 = new Position(1, 1);

            SortedPosList s1 = new SortedPosList();
            s1.Add(p1);
            s1.Add(p2);
            s1.Add(p3);
            s1.Add(p4);
            s1.Add(p9);
            SortedPosList s2 = new SortedPosList();
            s2.Add(p5);
            s2.Add(p6);
            s2.Add(p7);
            s2.Add(p8);
            s2.Add(p10);

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s1 ^ s2);




            // Create SortedPosList with path and sync with file

            string path = "/Users/canon/Google Drive/ITHS 2017 JH Drive/C SHARP/lab2/positionFiles/test.txt";

            SortedPosList s3 = new SortedPosList(path);
            s3.Add(new Position(2, 2));
            s3.Add(new Position(3, 2));
            Console.WriteLine(s3);


        }
    }
}
