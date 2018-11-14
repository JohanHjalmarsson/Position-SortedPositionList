using System;
using System.Collections.Generic;

namespace Lab2
{
    public class SortedPosList
    {
        private List<Position> PositionList { get; set; }
        public string Path { get; set; }

        public SortedPosList()
        {
            Path = "";
            PositionList = new List<Position>();
        }

        public SortedPosList(string newPath)
        {
            PositionList = new List<Position>();
            Path = newPath;
            if (!Load())
            {
                SaveToFile();
            }

        }

        private void SaveToFile()
        {
            if (Path != "")
            {
                FileHandler.Save(Path, this);
            }
        }

        private bool Load()
        {
            bool result = false;
            if (Path != "")
            {
                if (FileHandler.FileExists(Path))
                {
                    string[] list = FileHandler.Load(Path);
                    result = list.Length > 0;
                    PositionList.Clear();
                    foreach (string pos in list)
                    {
                        Add(FileHandler.ParseToPosition(pos));
                    }
                }

            }

            return result;
        }

        public int Count()
        {
            return PositionList.Count;
        }

        public void Add(Position p)
        {
            PositionList.Add(p);
            PositionList.Sort(delegate (Position p1, Position p2)
            {
                return p1.Lenght().CompareTo(p2.Lenght());
            });
            SaveToFile();

        }

        public bool Remove(Position p)
        {
            bool result = PositionList.Remove(p);
            SaveToFile();
            return result;
        }

        public SortedPosList Clone()
        {
            SortedPosList s = new SortedPosList();
            PositionList.ForEach(s.Add);
            return s;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList s = Clone();
            for (var i = 0; i < s.Count(); i++)
            {
                double x = (s[i].X - centerPos.X) * (s[i].X - centerPos.X);
                double y = (s[i].Y - centerPos.Y) * (s[i].Y - centerPos.Y);
                if ( x + y >= radius * radius)
                {
                    s.Remove(s[i]);
                }
            }
            return s;

        }

        public static SortedPosList operator + (SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList result = sp1.Clone();
            for (var i = 0; i < sp2.Count(); i++)
            {
                result.Add(sp2[i]);
            }

            return result;
        }

        // VS ser "•" som "unexpected character" så jag använder "^" istället 
        // Hade gärna använt Except() här men eftersom PositionList endast får användas inom klassen så går ju inte det.

        public static SortedPosList operator ^ (SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList result = sp1.Clone();
            int indexA = 0;
            int indexB = 0;
            bool endOfList = false;
           

            while (!endOfList)
            {
                Position a = result[indexA];
                Position b = sp2[indexB];


                if (PositionsEquals(a, b))
                {
                    result.Remove(result[indexA]);
                    indexB++;
                }
                else if (a < b)
                {
                    indexA++;
                } else
                {
                    indexB++;
                }
                endOfList |= (indexA == result.Count() || indexB == sp2.Count());
            }
            return result;
        }

       

        private static bool PositionsEquals(Position p1, Position p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public Position this[int i]
        {
            get
            {
                return PositionList[i];
            }
        }

        public override string ToString()
        {
            return string.Join(", ", PositionList);
        }
    }
}