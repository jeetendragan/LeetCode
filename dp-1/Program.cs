using System;

namespace dp_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ClimbStairs(1));
        }

        public static int ClimbStairs(int n) {
            int[] memo = new int[n+1];
            for(int i = 0; i < n+1; i++){
                memo[i] = -1;
            }
            return CountClimb(n, memo);
        }
        public static int CountClimb(int n, int[] memo)
        {
            if(n == 0)
            {
                memo[n] = 0;
                return 0;
            }
            if(n == 1){
                memo[n] = 1;
                return 1;
            }
            if(n == 2){
                memo[n] = 2;
                return 2;
            }
            if(memo[n] == -1){
                memo[n] = CountClimb(n-1, memo) + CountClimb(n-2, memo);
            }
            return memo[n];
        }
    }
}
