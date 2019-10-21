using System;
using System.Collections.Generic;

namespace two_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> ans = ThreeSum_V2(new int[]{-1, 0, 1, 2, -1, -4});
            foreach(List<int> li in ans){
                Console.WriteLine(li[0]+","+li[1]+","+li[2]);
            }
        }
    
        public int[] TwoSum(int[] nums, int target) {
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();
            int[] result = new int[2];
            for(int i = 0; i < nums.Length; i++){
                if(numToIndex.ContainsKey(Math.Abs(nums[i] - target))){
                    result[1] = i;
                    numToIndex.TryGetValue(Math.Abs(nums[i] - target), out result[0]);
                    return result;
                }
                else{
                    numToIndex.Add(nums[i], i);
                }
            }
            return result;
        }

        class Tupple: IEqualityComparer<Tupple>{
            public int num1, num2;

            public Tupple(int num1, int num2){
                this.num1 = num1;
                this.num2 = num2;
            }

            public bool Equals(Tupple t1, Tupple t2)
            {
                int t1Small, t2Small, t1Lrg, t2Lrg;

                if(t1.num1 > t1.num2){
                    t1Lrg = t1.num1;
                    t1Small = t1.num2;
                }else{
                    t1Lrg = t1.num2;
                    t1Small = t1.num1;
                }

                if(t2.num1 > t2.num2){
                    t2Lrg = t2.num1;
                    t2Small = t2.num2;
                }else{
                    t2Lrg = t2.num2;
                    t2Small = t2.num1;
                }
                return (t1Small == t2Small && t1Lrg == t2Lrg);
            }

            public int GetHashCode(Tupple tupple)
            {
                return tupple.num1 + tupple.num2;
            }

        }

        public static IList<IList<int>> ThreeSum(int[] nums) {
            IList<IList<int>> tupples = new List<IList<int>>();
            HashSet<string> dupCheck = new HashSet<string>();
            for(int i = 0; i < nums.Length; i++){
                for(int j = i+1; j < nums.Length; j++){
                    for(int k = j+1; k < nums.Length; k++){
                        if(nums[i] + nums[j] + nums[k] == 0)
                        {
                            List<int> newList = new List<int>{nums[i], nums[j], nums[k]};
                            newList.Sort();
                            string key = newList[0]+","+newList[1]+","+newList[2];
                            if(!dupCheck.Contains(key)){
                                tupples.Add(new List<int>(){nums[i], nums[j], nums[k]});
                                dupCheck.Add(key);
                            }
                        }
                    }
                }
            }
            return tupples;
        }


        public static IList<IList<int>> ThreeSum_V2(int[] nums) {
            IList<IList<int>> tupples = new List<IList<int>>();
            Dictionary<int, HashSet<Tupple>> sumToTupples = new Dictionary<int, HashSet<Tupple>>();            
            for(int i = 0; i < nums.Length; i++){
                for(int j = i+1; j < nums.Length; j++){
                    Tupple t = new Tupple(nums[i], nums[j]);
                    if(sumToTupples.TryGetValue(nums[i]+nums[j], out HashSet<Tupple> nosWithSum)){
                        if(!nosWithSum.Contains(t))
                        {
                            nosWithSum.Add(t);
                        }
                    }else{
                        sumToTupples.Add(nums[i]+nums[j], new HashSet<Tupple>(){t});
                    }
                }
            }

            foreach(int num in nums){
                int neg = -1 * num;
                if(sumToTupples.TryGetValue(neg, out HashSet<Tupple> tups)){
                    foreach(Tupple tup in tups)
                    {
                        tupples.Add(new List<int>{tup.num1, tup.num2, num});
                    }
                }
            }

            return tupples;
        }
        

    }
}
