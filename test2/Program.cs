using System;
using System.Text;
using System.Collections.Generic;

namespace test2
{
    class Graph{
        Dictionary<int, Node> nodes;
        Dictionary<string, Edge> edges;

        public Graph(){
            this.nodes = new Dictionary<int, Node>();
            this.edges = new Dictionary<string, Edge>();
        }

        public Graph(IList<IList<int>> connections): this()
        {
            foreach(List<int> edge in connections){
                Node node1 = this.GetNode(edge[0]);
                Node node2 = this.GetNode(edge[1]);
                if(node1 == null){
                    node1 = new Node(edge[0]);
                    this.nodes.Add(node1.nodeId, node1);
                }
                if(node2 == null){
                    node2 = new Node(edge[1]);
                    this.nodes.Add(node2.nodeId, node2);
                }
                Edge edg = new Edge(node1, node2);
                string edgeId = node1.nodeId+"-"+node2.nodeId;
                string edgeIdRev = node2.nodeId+"-"+node1.nodeId;

                edges.Add(edgeId, edg);
                edges.Add(edgeIdRev, edg);
                node1.edges.Add(edg);
                node2.edges.Add(edg);
            }
        }

        private Node GetNode(int eid)
        {
            this.nodes.TryGetValue(eid, out Node node);
            return node;
        }

        internal bool IsConnectedWithoutEdge(List<int> edge)
        {
            // RUN DFS and check if any node is unreachable
            Node node1 = this.GetNode(edge[0]);
            if(node1 == null){
                throw new Exception("NODE 1 is null");
            }
            Node node2 = this.GetNode(edge[1]);
            if(node2 == null){
                throw new Exception("NODE 2 is null");
            }
            return (this.IsNodeConnectedWithoutEdge(node1, edge) &&  
                    this.IsNodeConnectedWithoutEdge(node2, edge));
        }

        private bool IsNodeConnectedWithoutEdge(Node node, List<int> edge)
        {
            Edge excludedEdge = this.GetEdge(edge);
            HashSet<int> unseenNodes = new HashSet<int>(this.nodes.Keys);
            this.DFS(node, unseenNodes, excludedEdge);
            return (unseenNodes.Count == 0);
        }

        private Edge GetEdge(List<int> edge)
        {
            string edId = edge[0]+"-"+edge[1];
            this.edges.TryGetValue(edId, out Edge edg);
            return edg;
        }

        public void DFS(Node current, HashSet<int> unseenNodes, Edge excludedEdge){
            if(unseenNodes.Contains(current.nodeId)){
                unseenNodes.Remove(current.nodeId);
            }else{
                // This node has already been seen, lets return to avoid cycles
                return;
            }

            foreach(Edge nextEdge in current.edges){
                if(excludedEdge.Equals(nextEdge)){
                    continue;
                }

                Node nextNode;
                if(nextEdge.node1.nodeId != current.nodeId){
                    nextNode = nextEdge.node1;
                }else{
                    nextNode = nextEdge.node2;
                }
                this.DFS(nextNode, unseenNodes, excludedEdge);
            }
        }

        
    }
    class Node{
        public int nodeId;
        public HashSet<Edge> edges;

        public Node(int nodeId){
            this.nodeId = nodeId;
            edges = new HashSet<Edge>();
        }

    }

    class Edge : IEqualityComparer<Edge>{
        public Node node1;
        public Node node2;

        public Edge(Node node1, Node node2){
            this.node1 = node1;
            this.node2 = node2;
        }

        public bool Equals(Edge edge1, Edge edge2)
        {
            int smlEdg1, smlEdg2, lrgEdg1, lrgEdg2;

            if(edge1.node1.nodeId > edge1.node2.nodeId){
                lrgEdg1 = edge1.node1.nodeId;
                smlEdg1 = edge1.node2.nodeId;
            }else{
                lrgEdg1 = edge1.node2.nodeId;
                smlEdg1 = edge1.node1.nodeId;
            }

            if(edge2.node1.nodeId > edge2.node2.nodeId){
                lrgEdg2 = edge2.node1.nodeId;
                smlEdg2 = edge2.node2.nodeId;
            }else{
                lrgEdg2 = edge2.node2.nodeId;
                smlEdg2 = edge2.node1.nodeId;
            }
            return (smlEdg1 == smlEdg2 && lrgEdg1 == lrgEdg2);
        }

        public int GetHashCode(Edge edge)
        {
            return edge.node1.nodeId + edge.node2.nodeId;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> connections = new List<IList<int>>();
            connections.Add(new List<int>(){0,1});
            connections.Add(new List<int>(){1,2});
            connections.Add(new List<int>(){2,0});
            connections.Add(new List<int>(){1,3});
            connections.Add(new List<int>(){3,4});
            connections.Add(new List<int>(){4,5});
            connections.Add(new List<int>(){5,3});
            IList<IList<int>> cc = CriticalConnections(4, connections);
            foreach(List<int> connection in cc){
                Console.WriteLine(connection[0]+"-"+connection[1]);
            }
            if(cc.Count == 0)
            {
                Console.WriteLine("There are no critical connections!");
            }
        }

        static IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
            
            Graph g = new Graph(connections);
            IList<IList<int>> criticalEdges = new List<IList<int>>();
            
            foreach(List<int> edge in connections){
                if(!g.IsConnectedWithoutEdge(edge)){
                    criticalEdges.Add(edge);
                }
            }
            
            return criticalEdges;
        }

        static string ReverseStr(string s, int k) {
            int p = 0;
            StringBuilder cs = new StringBuilder(s.Length);

            while(p != s.Length){
                // copy the first k strings to cs
                int rightLimit = p + k - 1;
                if(rightLimit > s.Length-1){
                    rightLimit = s.Length-1;
                }

                // Copy the reversed portion
                for(int i = rightLimit; i >=p; i--){
                    cs.Append(s[i]);
                }

                // Copy the orignal portion
                p = p + 2*k;
                if(p > s.Length){
                    p = s.Length;
                }
                for(int i = rightLimit+1; i < p; i++){
                    cs.Append(s[i]);
                }

            }

            return cs.ToString();
        }   
    
    }

}
