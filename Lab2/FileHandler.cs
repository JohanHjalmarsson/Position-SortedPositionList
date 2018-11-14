using System;
namespace Lab2

{
    public static class FileHandler
    {
        public static bool Save(string path, SortedPosList list)
        {
            if (path != "") 
            {
                System.IO.File.WriteAllLines(path, ParseToStringList(list));
                return true;
            }

            return false;
        }

        private static string[] ParseToStringList(SortedPosList list)
        {
            string[] content = new string[list.Count()];

            for (var i = 0; i < list.Count(); i++)
            {
                content[i] = list[i].ToString();
            }

            return content;
        }


        public static Position ParseToPosition(string position)
        {
            char[] remove = { '(', ')' };
            string revidedPosition = position.Trim(remove);
            string[] xAndY = revidedPosition.Split(",");
                
            return xAndY.Length == 2 ? new Position(Int32.Parse(xAndY[0]), Int32.Parse(xAndY[1])) : new Position(0,0);
        }

        public static string[] Load(string path)
        {
            if (FileExists(path))
            {
                return System.IO.File.ReadAllLines(path);
            } else
            {
                return new string[0];
            }

        }

        public static bool FileExists(string path)
        {
            return System.IO.File.Exists(path);
        }
    }
}
