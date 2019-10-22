using System;
using System.Collections.Generic;

namespace mock_1
{
    class Program
    {
        
        

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // int[][] mat = new int[3][];
            // mat[0] = new int[]{0, 1, 1, 1};
            // mat[1] = new int[]{1, 1, 1, 0};
            // mat[2] = new int[]{1, 1, 1, 1};
            // int[][] sol = UpdateMatrix(mat);
            // int rows = sol.Length;
            // int cols = sol[0].Length;
            // for(int i = 0; i < rows; i++){
            //     for(int j = 0; j < cols; j++){
            //         Console.Write(sol[i][j]+" ");
            //     }
            //     Console.WriteLine();
            // }

            Console.WriteLine(WordPattern("abc", ""));

        }

        public static bool WordPattern(string pattern, string str) {
            if(pattern == null && str == null) return true;
            if(pattern.Length == 0 && str.Length == 0) return true;
            Dictionary<char, string> map = new Dictionary<char, string>();
            Dictionary<string, char> revMap = new Dictionary<string, char>();
            string[] splitStr = str.Split(' ');
            
            if(pattern.Length != splitStr.Length)
                return false;

            int p = 0;
            while(p < pattern.Length)
            {
                char c = pattern[p];
                string stri = splitStr[p];
                if(map.TryGetValue(c, out string matchingStr)){
                    if(matchingStr != splitStr[p]){
                        return false;
                    }
                }else{
                    // Check if str is mapped to anything else
                    if(revMap.TryGetValue(stri, out char cp)){
                        // then there is a conflict. 
                        // i.e. if a is mapped to cat, and cat should not be mapped to b
                        // abba -> cat cat cat cat - Should not return true
                        return false;
                    }
                    // there is no reverse mapping from string to character
                    map.Add(c, splitStr[p]);
                    revMap.Add(splitStr[p], c);
                }
                p++;
            }
            return true;
        }

        public static int[][] UpdateMatrix(int[][] matrix) {
            if(matrix == null || matrix.Length == 0)
                return null;
            int[][] solution = new int[matrix.Length][];
            int cols = matrix[0].Length;
            for(int i = 0; i < matrix.Length; i++){
                int[] subMat = new int[cols];
                solution[i] = subMat;
                for(int j = 0; j < cols; j++){
                    subMat[j] = 0;
                }
            }

            FindShortestPaths(matrix, solution);
            
            return solution;
        }

        public static void FindShortestPaths(int[][] matrix, int[][] solution){
            int cols = matrix[0].Length;
            for(int i = 0; i < matrix.Length; i++){
                for(int j = 0; j < cols; j++){
                    // for every node i,j find the solution
                    if(matrix[i][j] == 0){
                        continue;
                    }

                    int steps = GetSteps(matrix, i, j);
                    solution[i][j] = steps;

                }
            }
        }

        public static int GetSteps(int[][] matrix, int i, int j){
            Dictionary<string, Node> seenNodes = new Dictionary<string, Node>();
            Queue<Node> queue = new Queue<Node>();
            Node start = new Node(i, j);
            queue.Enqueue(start);
            seenNodes.Add(i+"-"+j, start);
            int cols = matrix[0].Length;

            Node goalNode = null;
            while(queue.Count != 0){
                Node topNode = queue.Dequeue();
                if(matrix[topNode.i][topNode.j] == 0){
                    goalNode = topNode;
                    break;
                }

                // Expand the adj nodes
                int newI, newJ;
                // left
                newI = topNode.i - 1; newJ = topNode.j;
                if(newI >= 0){
                    if(!seenNodes.ContainsKey(newI+"-"+newJ)){
                        Node newNode = new Node(newI, newJ);
                        newNode.prev = topNode;
                        seenNodes.Add(newI+"-"+newJ, newNode);
                        queue.Enqueue(newNode);
                    }
                }

                // bottom
                newI = topNode.i + 1; newJ = topNode.j;
                if(newI < matrix.Length){
                    if(!seenNodes.ContainsKey(newI+"-"+newJ)){
                        Node newNode = new Node(newI, newJ);
                        newNode.prev = topNode;
                        seenNodes.Add(newI+"-"+newJ, newNode);
                        queue.Enqueue(newNode);
                    }
                }

                // left
                newI = topNode.i; newJ = topNode.j - 1;
                if(newJ >= 0){
                    if(!seenNodes.ContainsKey(newI+"-"+newJ)){
                        Node newNode = new Node(newI, newJ);
                        newNode.prev = topNode;
                        seenNodes.Add(newI+"-"+newJ, newNode);
                        queue.Enqueue(newNode);
                    }
                }

                // right
                newI = topNode.i; newJ = topNode.j + 1;
                if(newJ < cols){
                    if(!seenNodes.ContainsKey(newI+"-"+newJ)){
                        Node newNode = new Node(newI, newJ);
                        newNode.prev = topNode;
                        seenNodes.Add(newI+"-"+newJ, newNode);
                        queue.Enqueue(newNode);
                    }
                }

            }


            // the search has endedd
            if(goalNode == null)
                throw new Exception("asdasd");

            int goalI = goalNode.i;
            int goalJ = goalNode.j;

            int dist = Math.Abs(goalI - i) + Math.Abs(goalJ - j);

            return dist;
        }

    }

    public class Node{
        public int i, j;
        public Node prev;

        public Node(int i, int j){
            this.i = i;
            this.j = j;
            this.prev = null;
        }

    }

}
