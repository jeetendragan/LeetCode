using System;
using System.Collections.Generic;
using System.Text;

namespace mock_3
{
    class Dir {
        public string name;
        public string path;

        public Dir(string name, string path){
            this.name = name;
            this.path = path;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(NextClosestTime("19:34"));"5F3Z-2e-"5F3Z-2e-9-w"9-w"
            // Console.WriteLine(LicenseKeyFormatting("adsasd-asdad", 4));
            Console.WriteLine(LengthLongestPath("dir\n\t\tc.txt"));
        }

        public static int LengthLongestPath(string input) {
            Stack<Dir> dirs = new Stack<Dir>();
            string[] splitStr = input.Split('\n');
            Dir root = new Dir(splitStr[0],splitStr[0]+"/");
            dirs.Push(root);
            int longestLength = 0;

            if(splitStr.Length <= 1){
                if(splitStr[0].Contains('.'))
                    return splitStr[0].Length;
                else
                {
                    return 0;
                }
            }

            for(int splitStrPtr = 1; splitStrPtr < splitStr.Length; splitStrPtr++){
                string split = splitStr[splitStrPtr];
                int level = 0;
                StringBuilder filDirName = new StringBuilder();
                int ptr = 0;
                while(ptr < split.Length){
                    if(split[ptr] == '\t')
                    {
                        level++;   
                    }else
                    {
                        filDirName.Append(split[ptr]);
                    }
                    ptr++;
                }

                string fileDirNameStr = filDirName.ToString();
                bool isFile = fileDirNameStr.Contains('.');

                if(level == dirs.Count){
                    if(isFile){
                        Dir parent = dirs.Peek();
                        string newFilePath = parent.path+fileDirNameStr;
                        if(longestLength < newFilePath.Length){
                            longestLength = newFilePath.Length;
                        }
                    }else{
                        Dir parent = dirs.Peek();
                        string newDirPath = parent.path+fileDirNameStr+"/";
                        Dir newDir = new Dir(fileDirNameStr, newDirPath);
                        dirs.Push(newDir);
                    }
                }else if(level < dirs.Count){
                    int pops = dirs.Count - level;
                    for(int p = 1; p <= pops; p++){dirs.Pop();}
                    Dir parent = dirs.Peek();
                    if(isFile){
                        string newFilePath = parent.path+fileDirNameStr;
                        if(longestLength < newFilePath.Length) {
                            longestLength = newFilePath.Length;
                        }
                    }else
                    {
                        string newDirPath = parent.path+fileDirNameStr+"/";
                        Dir newDir = new Dir(fileDirNameStr, newDirPath);
                        dirs.Push(newDir);
                    }
                }

            }

            return longestLength;
        }


        public static string LicenseKeyFormatting(string S, int K) {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            int charCount = 0;
            StringBuilder chars = new StringBuilder();
            while(i < S.Length)
            {
                if(S[i] == '-'){
                    i++;
                    continue;
                }
                chars.Append(S[i]);
                charCount++;
                i++;
            }
            if(chars.Length <= K){
                for(int a = 0; a < chars.Length; a++){
                    sb.Append(chars[a]);
                }
                return sb.ToString().ToUpper();
            }

            int pieces = charCount / K;
            int firstPieceLength = charCount % K;
            int c = 0;
            for(c = 0; c < firstPieceLength; c++){
                sb.Append(chars[c]);
            }
            if(firstPieceLength != 0)
                sb.Append("-");

            int ctr = 0;
            int p = 0;
            for(int j = c; j < charCount; j++){
                if(p == K){
                    p = 0;
                    sb.Append('-');
                }

                sb.Append(chars[j]);
                p++;
            }

            return sb.ToString().ToUpper();
        }

        // public static string NextClosestTime(string time)
        // {
        //     string[] splitTime = time.Split(':');
        //     string hrsStr = splitTime[0];
        //     string minStr = splitTime[1];
        //     int dig1 = int.Parse(hrsStr[0] + "");
        //     int dig2 = int.Parse(hrsStr[1] + "");
        //     int dig3 = int.Parse(minStr[0] + "");
        //     int dig4 = int.Parse(minStr[1] + "");
        //     int givenHours = int.Parse(hrsStr);
        //     int givenMins = int.Parse(minStr);

        //     HashSet<int> digits = new HashSet<int>();
        //     digits.Add(dig1); digits.Add(dig2); digits.Add(dig3); digits.Add(dig4);

        //     foreach (int d1 in digits)
        //     {
        //         if (!(d1 == 0 || d1 == 1 || d1 == 2))
        //         {
        //             continue;
        //         }
        //         foreach (int d2 in digits)
        //         {
        //             bool isValid = false;
        //             if (d1 == 0 || d1 == 1)
        //             {
        //                 if (d2 >= 0 && d2 <= 9)
        //                     isValid = true;
        //                 else
        //                     isValid = false;
        //             }
        //             else if (d1 == 2)
        //             {
        //                 if (d2 >= 0 && d2 <= 4)
        //                     isValid = true;
        //                 else
        //                     isValid = false;
        //             }

        //             foreach (int d3 in digits)
        //             {
        //                 if (d3 > 5)
        //                     continue;

        //                 foreach (int d4 in digits)
        //                 {
        //                     Console.WriteLine(d1 + "" + d2 + ":" + d3 + "" + d4);
        //                     int newHrs = int.Parse(d1 + d2);
        //                     int newMins = int.Parse(d3 + d4);
        //                     int hrDiff = newHrs - givenHours;
        //                     int minDiff = newMins - givenMins;
        //                     CompareDates(newHrs, newMins, givenHours, givenMins);
        //                 }

        //             }
        //         }
        //     }

        //     return "";
        // }

        


    }
}
