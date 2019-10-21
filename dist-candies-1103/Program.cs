using System;
using System.Text;
using System.Collections.Generic;

namespace dist_candies_1103
{
    
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public Dictionary<int, int> ReadLeftReversedSequence(){
            Dictionary<int, int> reverseWalkOrder = new Dictionary<int, int>();
            if(this.left == null && this.right == null)
                return reverseWalkOrder;

            FormReverseTree(this.left, reverseWalkOrder, 0);
            return reverseWalkOrder;
        }

        private void FormReverseTree(TreeNode tree, Dictionary<int, int> reverseWalkOrder, int v)
        {
            if(tree == null){
                reverseWalkOrder.Add(v, -1);
                return;
            }
            reverseWalkOrder.Add(v, tree.val);
            FormReverseTree(tree.left, reverseWalkOrder, 2*v + 2);
            FormReverseTree(tree.right, reverseWalkOrder, 2*v + 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // int[] ret = DistributeCandies(7, 4);
            // foreach(int i in ret)
            // {
            //     Console.Write("-"+i);
            // }
            // Console.WriteLine();

            // ret = DistributeCandies(10, 3);
            // foreach(int i in ret)
            // {
            //     Console.Write("-"+i);
            // }
            // Console.WriteLine();

            // string result = Convert("A", 2);
            // Console.WriteLine(result);
            // int revNo = Reverse(-120188);
            // Console.WriteLine(revNo);

            // double ret = FindMedianSortedArrays(new int[]{},new int[]{1});
            // Console.WriteLine(ret);

            // Console.WriteLine(MyAtoi("+"));            

            // Console.WriteLine(MaxArea(new int[]{1,8,6,2,5,4,8,3,7}));
            // int[][] trust = new int[2][];
            // trust[0] = new int[]{1, 2};
            // trust[1] = new int[]{2, 3};
            // trust[2] = new int[]{2, 3};
            // trust[3] = new int[]{2, 4};
            // trust[4] = new int[]{4, 3};
            // Console.WriteLine(FindJudge(3, trust));

            Console.WriteLine(IsSymmetric(new TreeNode(1)));
        }

        public Dictionary<int, int> ReadLeftReversedSequence(TreeNode root){
            Dictionary<int, int> reverseWalkOrder = new Dictionary<int, int>();
            if(root == null){   
                return reverseWalkOrder;
            }

            FormReverseTree(root.left, reverseWalkOrder, 0);
            return reverseWalkOrder;
        }

        public void FormReverseTree(TreeNode tree, Dictionary<int, int> reverseWalkOrder, int v)
        {
            if(tree == null){
                reverseWalkOrder.Add(v, -1);
                return;
            }
            reverseWalkOrder.Add(v, tree.val);
            FormReverseTree(tree.left, reverseWalkOrder, 2*v + 2);
            FormReverseTree(tree.right, reverseWalkOrder, 2*v + 1);
        }

        public static bool IsSymmetric(TreeNode root) {
            // everything that is encountered in the left by walking over sequentially 
            // should be encountered while walking on the right sub-tree from the root
            Dictionary<int, int> leftSubTreeSeq = root.ReadLeftReversedSequence();
            if(leftSubTreeSeq.Count == 0){
                // Indicates that the root is null
                return true;
            }
            return IsSame(root.right, leftSubTreeSeq, 0);
        }

        private static bool IsSame(TreeNode root, Dictionary<int, int> nodeValues, int rootIndex)
        {
            nodeValues.TryGetValue(rootIndex, out int expValue);
            if(root == null){
                if(expValue == -1)
                    return true;
                else
                    return false;
            }

            return (expValue == root.val && 
                    IsSame(root.left, nodeValues, 2*rootIndex+1) && 
                    IsSame(root.right, nodeValues, 2*rootIndex+2));
        }

        public static int FindJudge(int N, int[][] trust) {
            // Calculate a person who is trusted by everyone. i.e. has incoming edges equal to N
            // let us start with -1 as person id and 0 as the number of trusting people
            int mostTrusted = -1;
            int cntMostTrusted = 0;
            Dictionary<int, List<int[]>> trustedBy = new Dictionary<int, List<int[]>>();

            List<int> peps = new List<int>();
            for(int i = 1; i <= N; i++){ peps.Add(i); }
            HashSet<int> peopleWhoDontTrust = new HashSet<int>(peps);

            foreach(int[] trustEdge in trust){
                int truster = trustEdge[0];
                int trusted = trustEdge[1];
                
                if(!trustedBy.TryGetValue(trusted, out List<int[]> trustedByEdges)){
                    trustedByEdges = new List<int[]>{trustEdge};
                    trustedBy.Add(trusted, trustedByEdges);
                }else{
                    trustedByEdges.Add(trustEdge);
                }

                if(cntMostTrusted < trustedByEdges.Count){
                    cntMostTrusted = trustedByEdges.Count;
                    mostTrusted = trusted;
                }

                if(peopleWhoDontTrust.Contains(truster)){
                    peopleWhoDontTrust.Remove(truster);
                }

            }

            if(peopleWhoDontTrust.Count == 1){
                int personWhoDoesNotTrust = -1;
                foreach(int person in peopleWhoDontTrust){
                    personWhoDoesNotTrust = person;
                }

                if(personWhoDoesNotTrust == mostTrusted && cntMostTrusted == N-1){
                    return mostTrusted;
                }else{
                    return -1;
                }
            }else{
                return -1;
            }
        }

        // public static int Trap(int[] height) {
        //     int left = -1, right = -1;
        //     bool seqInc = true;
        //     int trappedVol = 0;
        //     while(true)
        //     {
        //         if(right == height.Length){
        //             // we need to stop
        //             // evaluated if a trap can be created
        //             break;
        //         }

        //         if(height[right+1] >= height[right]){
        //             if(seqInc){}else{
        //                 seqInc = true;
        //             }
        //         }else{
        //             seqInc = false;
        //             if(height[right+1]> height[left]){
        //                 // this is a valid trap
        //                 int trapHeight = Math.Min(height[right+1], height[left]);
        //                 while(left < right){
        //                     trappedVol += trapHeight - 
        //                 }
        //             }
        //         }

        //     }
        // }

        public static int MaxArea(int[] height) {
            int maxArea = int.MinValue;
            for(int i = 0; i < height.Length; i++)
            {
                for(int j = i + 1; j < height.Length; j++){
                    int area = Math.Min(height[i], height[j]) * (j - i);
                    if(area > maxArea)
                        maxArea = area;
                }
            }
            return maxArea;
        }

        public static int MyAtoi(string str) {
            StringBuilder numStr = new StringBuilder();
            str = str.Trim();
            if(str.Length == 0)
                return 0;
            int ptr = 0;
            int sign = 1;
            if(!IsDigit(str[0])){
                if(str[0] == '+'){
                    ptr++;
                    sign = 1;
                } else if (str[0] == '-'){
                    sign = -1;
                    ptr++;
                }else{
                    return 0;
                }
            }
            // Due to the above adjustment above, we should not encounter anything other than
            // digits.
            while(ptr < str.Length)
            {
                // any character should be a digit
                if(!IsDigit(str[ptr])){
                    break;
                }
                numStr.Append(str[ptr]);
                ptr++;
            }

            // All the characters in the numStr are valid digits
            // Convert them to integers

            if(numStr.Length == 0){
                return 0; // there are no numbers in the sting.
            }

            long num = long.Parse(numStr.ToString());
            num = sign * num;

            if(num < int.MinValue)
                return int.MinValue;

            if(num > int.MaxValue)
                return int.MaxValue;
            
            return (int) num;

        }

        public static bool IsDigit(char ch){
            int chAsInt = (int) ch;
            return 48 <= chAsInt && ch <= 58;
        }

        public static bool IsPalindrome(int x) {
            if(x < 0)
                return false;
            int xOrig = x;
            int revNum = 0;
            while(x > 0){
                int digit = x % 10;
                x = x / 10;
                revNum = revNum * 10 + digit;
            }
            return (revNum == xOrig);
        }

        public static string Convert(string s, int numRows) {
            if(s == "")
                return "";
            Dictionary<int, List<char>> sep = new Dictionary<int, List<char>>();
            int seperator = 1;
            int change = 1;
            foreach(char c in s){
                if(sep.TryGetValue(seperator, out List<char> sepChars)){
                    sepChars.Add(c);
                }else{
                    List<char> chars = new List<char>();
                    chars.Add(c);
                    sep.Add(seperator, chars);
                }

                if(seperator == numRows && change == 1){
                    change = -1;
                }
                if(seperator == 1 && change == -1){
                    change = 1;
                }
                seperator += change;
            }
            StringBuilder sb = new StringBuilder();
            for(int i = 1; i <= sep.Keys.Count; i++){
                sep.TryGetValue(i, out List<char> chars);
                if(chars == null)
                    continue;
                foreach(char c in chars){
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static int Reverse(int x) {
            // int rev = 0, digit;
            // int maxInt = Math.Pow(2,31)-1;
            // int minInt = -Math.Pow(2,31);
            // while(Math.Abs(x) > 0){
            //     digit = x % 10;
            //     int overflowCheck = rev * 10;
            //     if(overflowCheck > maxInt || overflowCheck < minInt){
            //         return 0;
            //     }
            //     rev = rev * 10 + digit;
            //     x = x/10;
            // }
            
            // return rev;
            return 1;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            int m = nums1.Length;
            int n = nums2.Length;
            int mid1 = m / 2;
            double midVal1;
            if(m != 0){
                if(m % 2 == 0){
                    midVal1 = ((double)nums1[mid1] + (double)nums1[mid1-1]) / 2;
                }else{
                    midVal1 = (double)nums1[mid1];
                }
            }else{
                midVal1 = 0;
            }

            int mid2 = n / 2;
            double midVal2;
            if(n != 0){
                if(n % 2 == 0){
                    midVal2 = ((double)nums2[mid2] + (double)nums2[mid2-1]) / 2;
                }else{
                    midVal2 = (double)nums2[mid2];
                }
            }else{
                midVal2 = 0;
            }
            if(midVal1 == 0){
                return midVal2;
            }
            if(midVal2 == 0){
                return midVal1;
            }
            return (midVal1 + midVal2)/2;
        }
        public static int[] DistributeCandies(int candies, int num_people) {
            int[] candyDist = new int[num_people];
            int totalDist = 0;
            int giveAway = 1;
            int person = 0;
            while(totalDist != candies){
                candyDist[person] += giveAway;
                totalDist += giveAway;

                // This update is for the next iteration
                if((giveAway+1) + totalDist > candies){
                    giveAway = candies - totalDist;
                }else{
                    giveAway+=1;
                }
                person = (person+1) % num_people;
            }
            return candyDist;
        }

    }
}
