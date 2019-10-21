using System;
using System.Collections.Generic;

namespace LengthOfLongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine(LengthOfLongestSubstring("bbbbb"));
            Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
            Console.WriteLine(LengthOfLongestSubstring("  "));
            Console.WriteLine(LengthOfLongestSubstring("pp"));
        }

        public static int LengthOfLongestSubstring(string s) {
            Dictionary<char, int> subsetIndex = new Dictionary<char, int>();
            int max = 0;
            for(int p = 0; p < s.Length; p++){
                if(subsetIndex.ContainsKey(s[p])){
                    
                    subsetIndex.TryGetValue(s[p], out int index);

                    if(subsetIndex.Count > max){
                        max = subsetIndex.Count;
                    }
                    subsetIndex.Clear();
                    p = index+1; 
                    subsetIndex.Add(s[p], p);
                }else{
                    subsetIndex.Add(s[p], p);
                }
            }
            if(max < subsetIndex.Count){
                max = subsetIndex.Count;
            }
            return max;
        }

    }
}
