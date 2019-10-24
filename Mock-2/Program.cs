using System;
using System.Collections.Generic;
using System.Text;

namespace Mock_2
{

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // int[] arr1 = new int[]{2,3,1,3,2,4,6,7,9,2,19};
            // int[] arr2 = new int[]{2,1,4,3,9,6};
            // Console.WriteLine(RelativeSortArray(arr1, arr2));
            // foreach(int i in arr1){
            //     Console.Write(i+" ");
            // }
            // Console.WriteLine(NumRollsToTarget(1, 6, 3));
            // Console.WriteLine(NumRollsToTarget(2, 6, 7));
            // Console.WriteLine(NumRollsToTarget(2, 5, 10));
            // Console.WriteLine(NumRollsToTarget(1, 2, 3));
            // Console.WriteLine(NumRollsToTarget(30, 30, 500));
            // Console.WriteLine(IsValid(""));

            // int[] arr = NextGreaterElement(new int[]{4, 1, 2}, new int[]{1, 3, 4, 2});
            // int[] arr = NextGreaterElement(new int[]{}, new int[]{1, 2, 3, 4});
            // foreach(int i in arr){
            //     Console.WriteLine(i);
            // }    

            // int[] arr = new int[]{1, 2, 2, 3, -1, 0, 3, 4, -1, -1 ,4};
            // TreeNode root = ConstTree(arr);
            // Console.WriteLine(IsBalanced(root));
            // Console.WriteLine(RemoveDuplicates(null));

            // Console.WriteLine(FindUnsortedSubarray(new int[]{2, 3, 3, 2, 4}));
            // Console.WriteLine(FindLengthOfLCIS(new int[]{2, 3, 3, 2, 4}));

            // Read from stdin, solve the problem, write answer to stdout.
            // int[] A = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);
            int[] A = new int[]{1, 2, 3, 4, 5};

            // List<int> maxs = new List<int>();
            // for(int i = 0; i < A.Length; i++){
            //     if(maxs.Count == 0){
            //         maxs.Add(A[i]);
            //     }
            //     else{
            //         // find a max
            //         bool locFound = false;
            //         for(int j = 0; j < maxs.Count; j++){
            //             if(A[i] < maxs[j]){
            //                 locFound = true;
            //                 // i will join the row j
            //                 maxs[j] = A[i];
            //                 break;
            //             }
            //         }
            //         if(!locFound){
            //             maxs.Add(A[i]);
            //         }
            //     }
            // }

            // Console.WriteLine(maxs.Count);

            // Console.Write(solution(A));

            // mapping = new Dictionary<int, int>();
            // mapping.Add(0, 0);
            // mapping.Add(1, 1);
            // mapping.Add(2, 5);
            // mapping.Add(5, 2);
            // mapping.Add(6, 9);
            // mapping.Add(8, 8);
            // mapping.Add(9, 6);

            // Console.WriteLine(IsValid(1000));
            // Console.WriteLine(RotatedDigits(12));
            Console.WriteLine(MaxDistToClosest(new int[]{1,0,0,0,1,0,1}));
        }

        public static int MaxDistToClosest(int[] seats) {
            int[] left = new int[seats.Length];
            int[] right = new int[seats.Length];
            for(int i = 0; i < seats.Length; i++){
                if(seats[i] == 0){
                    left[i] = 0;
                } else{
                    if(i>0)
                    left[i] = 1 + left[i-1];
                }
            }

            for(){
                
            }

        }

        static int solution(int[] A) {
            // Find the sum of all A's
            int sum = 0;
            foreach(int a in A){sum += a;}

            int minDiff = int.MaxValue;
            HashSet<int> items = new HashSet<int>();
            ComputeMinDiff(A, sum, 0, 0, ref minDiff, items);
            return minDiff;
        }

        static Dictionary<int, int> mapping;

        public static int RotatedDigits(int N) {
            mapping = new Dictionary<int, int>();
            mapping.Add(1, 1);
            mapping.Add(2, 5);
            mapping.Add(5, 2);
            mapping.Add(6, 9);
            mapping.Add(8, 8);
            mapping.Add(9, 6);
            int ctGoodNos = 0;
            for(int i = 1; i <= N; i++){
                if(IsValid(i)){
                    ctGoodNos++;
                }
            }
            return ctGoodNos;
        }

        public static bool IsValid(int num){            
            int numRev = 0;
            int origNo = num;
            while(num > 0)
            {
                int rem = num % 10;
                if(!mapping.TryGetValue(rem, out int revRem)){
                    return false;
                }
                num = num / 10;
                numRev = numRev * 10 + revRem;
            }
            Console.WriteLine(numRev);
            return numRev != origNo;
        }

        public static void ComputeMinDiff(int[] A, int totalSum, int accSum, int i, ref int minDiff, HashSet<int> items)
        {
            if(i == A.Length){
                int otherSetSum = totalSum - accSum;
                int diff = Math.Abs(accSum - otherSetSum);
                if(diff < minDiff){
                    minDiff = diff;
                }
                return;
            }

            items.Add(A[i]);
            ComputeMinDiff(A, totalSum, accSum + A[i], i+1, ref minDiff, items);
            items.Remove(A[i]);
            ComputeMinDiff(A, totalSum, accSum, i+1, ref minDiff, items);

        }

        public static string RemoveDuplicates(string s) {
            if(s == null || s.Length == 0){
                return s;
            }

            Stack<char> charStk = new Stack<char>();
            int i = 0; 
            bool doPush = false;
            while(i < s.Length){
                doPush = true;
                if(charStk.Count != 0){
                    char stkTop = charStk.Peek();
                    if(stkTop == s[i]){
                        charStk.Pop();
                        doPush = false;
                    }
                }

                if(doPush)
                    charStk.Push(s[i]);

                i++;
            }

            StringBuilder stb = new StringBuilder();
            while(charStk.Count != 0)
            {
                stb.Append(charStk.Pop());
            }
            StringBuilder answer = new StringBuilder();
            for(int j = stb.Length -1; j >=0; j--){
                answer.Append(stb[j]);
            }

            return answer.ToString();
        }

        public static TreeNode ConstTree(int[] items){
            TreeNode[] nodes = new TreeNode[items.Length];
            bool[] seen = new bool[items.Length];
            for(int i = 0; i < items.Length; i++)
            {
                if(!seen[i]){
                    nodes[i] = new TreeNode(items[i]);
                    seen[i] = true;
                }

                // left child
                int left = i*2 + 1;
                if(left >= items.Length){
                    break;
                }
                nodes[left] = new TreeNode(items[left]);
                seen[left] = true;

                // right child
                int right = i*2 + 2;
                if(right >= items.Length){
                    break;
                }
                nodes[right] = new TreeNode(items[right]);
                seen[right] = true;

                nodes[i].left = nodes[left];
                nodes[i].right = nodes[right];
            }
            return nodes[0];
        }

        public static int FindLengthOfLCIS(int[] nums) {
            if(nums == null || nums.Length == 0)
                return 0;
            int max = 0;
            int ctr = 0;
            for(int i = 0; i < nums.Length-1; i++)
            {
                if(nums[i] > nums[i+1]){
                    ctr++;
                }else{
                    if(ctr > max){
                        max = ctr;
                    }
                }
            }
            return max;
        }

        public static int FindUnsortedSubarray(int[] nums) {
            if(nums == null || nums.Length == 0)
                return 0;
            int left = -1, right = -1;

            for(int i = 0; i < nums.Length; i++){
                int vp = -1;
                for(int j = i-1; j >= 0; j--){
                    if(nums[i] < nums[j]){
                        vp = j;
                    }
                }

                if(vp != -1){ // if only there is some violation
                    if(left == -1 && right == -1){
                        // this is the 1st violation
                        left = vp;
                        right = i;
                    }
                    else if(vp <= left){
                        left = vp;
                        right = i;
                    }
                    else{ //if(vp > left)
                        right = i;
                    }
                }
            }

            if(left == -1 && right == -1)
                return 0;
            else{
                return right - left + 1;
            }
        }

        public static bool IsBalanced(TreeNode root) {
            if(root == null){
                return true;
            }
            int leftD = FindDepth(root.left, 0);
            int rightD = FindDepth(root.right, 0);
            return Math.Abs(leftD - rightD) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        public static int FindDepth(TreeNode root, int height)
        {
            if(root == null){
                return height;
            }
            int a = FindDepth(root.left, height+1);
            int b = FindDepth(root.right, height+1);
            return Math.Max(a, b);
        }

        public static int[] NextGreaterElement(int[] nums1, int[] nums2) {

            if(nums1 == null || nums1.Length == 0){
                return new int[0];
            }
            if(nums2 == null || nums2.Length == 0){
                for(int i = 0; i < nums1.Length; i++){
                    nums1[i] = -1;
                }
                return nums1;
            }

            // Iterate over the nums2 list and make a map of what number is greater than 
            // each number
            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i = 0; i < nums2.Length; i++){
                bool greaterFound = false;
                for(int j = i+1; j < nums2.Length; j++){
                    if(nums2[j] > nums2[i]){
                        greaterFound = true;
                        map.Add(nums2[i], nums2[j]);
                        break;
                    }
                }

                if(!greaterFound)
                    map.Add(nums2[i], -1);
            }

            for(int i = 0; i < nums1.Length; i++){
                if(!map.TryGetValue(nums1[i], out int greater)){
                    throw new Exception("Impossible cond reach. something wrong.");
                }

                nums1[i] = greater;

            }
            return nums1;
        }

        public static bool IsValid(string s) {
            if(s == null){
                return false;
            }
            if(s.Length == 0)
                return true;

            Dictionary<char, char> charType = new Dictionary<char, char>();
            charType.Add('(', ')');
            charType.Add(')', '(');
            charType.Add('{', '}');
            charType.Add('}', '{');
            charType.Add('[', ']');
            charType.Add(']', '[');

            Stack<char> stack = new Stack<char>();
            int i = 0;
            while(i < s.Length){
                char c = s[i];
                if(c == '(' || c == '{' || c == '['){
                    stack.Push(c);
                }

                if(c == ')' || c == '}' || c == ']'){
                    if(stack.Count == 0){
                        return false;
                    }
                    char charBefore = stack.Pop();
                    if(charType.TryGetValue(charBefore, out char expectedChar)){
                        if(expectedChar != c){
                            return false;
                        }
                    }
                }

                i++;
            }

            if(stack.Count == 0){
                return true;
            }else{
                return false;
            }
        }

        public static int NumRollsToTarget(int d, int f, int target) {
            if(d == 0)
                return 0;
            if(d * f == target)
                return 1;
            if(d * f < target)
                return 0;
            
            int[][] memo = new int[d+1][];
            for(int i = 1; i <= d; i++){
                memo[i] = new int[target+1];
                for(int j = 1; j <= target; j++){
                    memo[i][j] = -1;
                }
            }
            return (CountWays(d, f, target, memo));
        }

        public static int CountWays(int d, int f, int target, int[][] memo){
            if(d == 0){
                if(target == 0)
                    return 1;
                else
                    return 0;
            }

            if(target <= 0)
                return 0;

            if(memo[d][target] != -1){
                return memo[d][target];
            }

            int ways = 0;
            for(int i = 1; i <= f; i++){
                ways += CountWays(d-1, f, target - i, memo);
            }
            memo[d][target] = ways;
            return ways;
        }

        public static int[] RelativeSortArray(int[] arr1, int[] arr2) {
            if(arr1 == null)
                return null;
            if(arr1.Length == 0)
                return arr1;
            if(arr2 == null || arr2.Length == 0)
                return arr1;
            Dictionary<int, int> noToCount = new Dictionary<int, int>();
            foreach(int i in arr1){
                if(noToCount.TryGetValue(i, out int count)){
                    count++;
                    noToCount.Remove(i);
                    noToCount.Add(i, count);
                }
                else{
                    noToCount.Add(i, 1);
                }
            }

            int arr1Ptr = 0;
            foreach(int spec in arr2){
                if(noToCount.TryGetValue(spec, out int count)){
                    int origStart = arr1Ptr;
                    for(arr1Ptr = origStart; arr1Ptr < origStart + count; arr1Ptr++){
                        arr1[arr1Ptr] = spec;
                    }
                    noToCount.Remove(spec);
                }
            }

            List<int> unSeenItems = new List<int>();
            foreach(int item in noToCount.Keys){
                unSeenItems.Add(item);
            }

            unSeenItems.Sort();

            foreach(int key in unSeenItems){
                noToCount.TryGetValue(key, out int count);
                int start = arr1Ptr;
                for(arr1Ptr = start; arr1Ptr < start + count; arr1Ptr++){
                    arr1[arr1Ptr] = key;
                }
            }

            return arr1;

        }   
    }
}
