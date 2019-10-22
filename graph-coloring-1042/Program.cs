using System;
using System.Collections.Generic;

namespace graph_coloring_1042
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5;
            int[][] paths = new int[1][];
            paths[0] = new int[]{1, 2};
            // paths[0] = new int[]{4, 1};
            // paths[1] = new int[]{4, 2};
            // paths[2] = new int[]{4, 3};
            // paths[3] = new int[]{2, 5};
            // paths[4] = new int[]{1, 2};
            // paths[5] = new int[]{1, 5};
            
            int[] assignemtn = GardenNoAdj(N, paths);
            foreach(int i in assignemtn){
                Console.Write(i+",");
            }
        }

        public class Node{
            public int id;
            public HashSet<Node> adjNodes;
            public int color;

            public Node(int id){
                this.id = id;
                this.adjNodes = new HashSet<Node>();
                this.color = -1;
            }

            public void AddAdjNode(Node adjNode){
                this.adjNodes.Add(adjNode);
            }

            public HashSet<int> GetAvailableColors(){
                HashSet<int> assignedColors = new HashSet<int>(new List<int>(){1,2,3,4});
                foreach(Node adjNode in this.adjNodes){
                    if(adjNode.color != -1){
                        assignedColors.Remove(adjNode.color);
                    }
                }
                return assignedColors;
            }

            public void AssignColor(int color){
                this.color = color;
            }

            public void UnassignColor(){
                this.color = -1;
            }
        }

        public static int[] GardenNoAdj(int N, int[][] paths) {
            if(paths == null || paths.Length == 0){
                int[] assignmnt = new int[N];
                for(int i = 0; i < N; i++){
                    assignmnt[i] = 1;
                }
                return assignmnt;
            }

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();
            HashSet<Node> unassignedNodes = new HashSet<Node>();
            foreach(int[] path in paths)
            {
                int node1Id = path[0];
                int node2Id = path[1];
                if(!nodes.TryGetValue(node1Id, out Node node1)){
                    node1 = new Node(node1Id);
                    unassignedNodes.Add(node1);
                    nodes.Add(node1Id, node1);
                }
                if(!nodes.TryGetValue(node2Id, out Node node2)){
                    node2 = new Node(node2Id);
                    unassignedNodes.Add(node2);
                    nodes.Add(node2Id, node2);
                }
                node1.AddAdjNode(node2);
                node2.AddAdjNode(node1);
            }

            // Create nodes if they are not created
            for(int i = 1; i <= N; i++){
                if(!nodes.ContainsKey(i)){
                    Node newNode = new Node(i);
                    nodes.Add(i, newNode);
                }
            }

            if(AssignColors(1, nodes, unassignedNodes, N)){
                int[] assignment = new int[N];
                for(int i = 1; i <= N; i++){
                    nodes.TryGetValue(i, out Node node);
                    if(node.color == -1)
                        assignment[i - 1] = 1;
                    else
                        assignment[i-1] = node.color;
                }
                return assignment;
            }else{
                Console.WriteLine("Could not find a solutio!");
                return null;
            }

        }

        public static bool AssignColors(int nodeId, 
                Dictionary<int, Node> nodes, HashSet<Node> unassignedNodes, int N){

            if(unassignedNodes.Count == 0){
                return true;
            }

            // if(nodeId == N+1){ // we have reached the end and no color has been assigned 
            //     return false;
            // }

            // Compute valid colors for the node, by looking at the colors 
            // assigned to the adjacent nodes
            nodes.TryGetValue(nodeId, out Node node);
            HashSet<int> avColors = node.GetAvailableColors();
            if(avColors.Count == 0){
                return false; // could not assign color to this item
            }
            foreach(int avCol in avColors)
            {
                // Forward track
                node.AssignColor(avCol);
                unassignedNodes.Remove(node);
                if(AssignColors(nodeId+1, nodes, unassignedNodes, N)){
                    return true;
                }

                // Backtrack
                node.UnassignColor();
                unassignedNodes.Add(node);
            }
            return false;
        }
    }
}
