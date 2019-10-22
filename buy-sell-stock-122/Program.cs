using System;

namespace buy_sell_stock_122
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit(new int[]{2, 1, 12, 31231, 123, 123, 94, 45, 5, 3, 4}));
        }

        public static int MaxProfit(int[] prices)
        {
            if(prices == null || prices.Length == 0)
                return 0;
            int[][] memo = new int[prices.Length][];
            for(int j = 0; j < prices.Length; j++){
                memo[j] = new int[prices.Length];
                for(int i = 0; i < prices.Length; i++){
                    memo[j][i] = -1;
                }
            }
            return MaxP(prices, 0, prices.Length-1, memo);
        }

        public static int MaxP(int[] prices, int left, int right, int[][] memo){
            // You could buy on left-day and sell on right-day
            if(memo[left][right] != -1)
                return memo[left][right];

            int fullRange = prices[right] - prices[left];
            int max = fullRange;
            for(int day = left+1; day < right; day++){
                // buying left and selling on days
                int tran = prices[day] - prices[left];
                int x = MaxP(prices, day, right, memo);
                max = Math.Max(max, tran);
                max = Math.Max(max, tran + x);
                max = Math.Max(max, x);
            }

            memo[left][right] = Math.Max(max, 0);
            return memo[left][right];
        }
    }


class Solution {
    public int maxProfit(int[] prices) {
        return calculate(prices, 0);
    }

    public int calculate(int prices[], int s) {
        if (s >= prices.length)
            return 0;
        int max = 0;
        for (int start = s; start < prices.length; start++) {
            int maxprofit = 0;
            for (int i = start + 1; i < prices.length; i++) {
                if (prices[start] < prices[i]) {
                    int profit = calculate(prices, i + 1) + prices[i] - prices[start];
                    if (profit > maxprofit)
                        maxprofit = profit;
                }
            }
            if (maxprofit > max)
                max = maxprofit;
        }
        return max;
    }
}

}

