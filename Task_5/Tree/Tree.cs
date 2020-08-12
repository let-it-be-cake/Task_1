namespace System.Collections.Generic
{
    /// <summary>
    /// Node of Tree structure
    /// </summary>
    /// <typeparam name="T">Generic for IComparable classes</typeparam>
    [Serializable]
    public sealed class Node<T> where T : IComparable
    {
        /// <summary>
        /// Constructor to set default value
        /// </summary>
        /// <param name="value">Stored object</param>
        public Node(T value)
            => Value = value;

        /// <summary>
        /// Default empty constructor
        /// </summary>
        public Node() {}

        public T Value { get; set; }
        public Node<T> Left { get; set; } = null;
        public Node<T> Right { get; set; } = null;

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj is Node<T> node &&
                   Value.Equals(node.Value) &&
                   EqualityComparer<Node<T>>.Default.Equals(Left, node.Left) &&
                   EqualityComparer<Node<T>>.Default.Equals(Right, node.Right);
        }

        public override int GetHashCode()
        {
            int hashCode = -533118049;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(Left);
            hashCode = hashCode * -1521134295 + EqualityComparer<Node<T>>.Default.GetHashCode(Right);
            return hashCode;
        }
    }

    /// <summary>
    /// Initializes a new instance of the System.Collections.Generic.Tree class that is empty and has the default initial capacity.
    /// </summary>
    /// <typeparam name="T">Generic for IComparable classes</typeparam>
    [Serializable]
    public sealed class Tree<T> where T : IComparable
    {
        /// <summary>
        /// Root of tree
        /// </summary>
        public Node<T> Root { get; set; }

        /// <summary>
        /// Add new object on tree
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node<T> node)
        {
            if (Root == null)
            {
                Root = node;
                return;
            }

            var currNode = Root;

            do
            {
                if (currNode.Value.CompareTo(node.Value) <= 0)
                {
                    if (currNode.Right != null)
                        currNode = currNode.Right;
                    else
                    {
                        currNode.Right = node;
                        break;
                    }
                }
                else
                {
                    if (currNode.Left != null)
                        currNode = currNode.Left;
                    else
                    {
                        currNode.Left = node;
                        break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Find a node by value
        /// </summary>
        /// <param name="obj">Desired object</param>
        /// <returns>Node with the found object</returns>
        public Node<T> FindNode(T obj)
        {
            if (Root == null)
                throw new Exception("Missing Root!");

            if (Root.Value.CompareTo(obj) == 0)
                return Root;

            var currNode = Root;
            do
            {
                if (currNode.Value.CompareTo(obj) <= 0)
                {
                    if (currNode.Right != null)
                        currNode = currNode.Right;
                    else return null;
                }
                else
                if (currNode.Value.CompareTo(obj) > 0)
                {
                    if (currNode.Left != null)
                        currNode = currNode.Left;
                    else return null;
                }

                if (currNode.Value.CompareTo(obj) == 0)
                    return currNode;

            } while (currNode != null);
            return null;
        }

        #region Balancing

        /// <summary>
        /// Traverse the skewed binary tree and stores its nodes pointers in vector nodes[]
        /// </summary>
        /// <param name="root">Tree root</param>
        /// <param name="nodes">List of nodes</param>
        private void storeBSTNodes(Node<T> root, List<Node<T>> nodes)
        {
            if (root == null)
                return;

            // Store nodes in Inorder (which is sorted order for BST)
            storeBSTNodes(root.Left, nodes);
            nodes.Add(root);
            storeBSTNodes(root.Right, nodes);
        }

        /// <summary>
        /// Recursive function to construct binary tree  
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        /// <param name="start">Start of tree value</param>
        /// <param name="end">End of tree value</param>
        /// <returns></returns>
        private Node<T> buildTreeUtil(List<Node<T>> nodes, int start, int end)
        {
            // base case
            if (start > end)
                return null;

            /* Get the middle element and make it root */
            int mid = (start + end) / 2;
            var node = nodes[mid];

            /* Using index in Inorder traversal, construct
               left and right subtress */
            node.Left = buildTreeUtil(nodes, start, mid - 1);
            node.Right = buildTreeUtil(nodes, mid + 1, end);

            return node;
        }

        /// <summary>
        /// This functions converts an unbalanced BST to a balanced BST
        /// </summary>
        /// <param name="root">Current node of sub tree</param>
        /// <returns>New node of Tree</returns>
        private Node<T> buildTree(Node<T> root)
        {
            // Store nodes of given BST in sorted order
            List<Node<T>> nodes = new List<Node<T>>();
            storeBSTNodes(root, nodes);

            // Constucts BST from nodes[]
            int n = nodes.Count;
            return buildTreeUtil(nodes, 0, n - 1);
        }

        /// <summary>
        /// Start tree balancing
        /// </summary>
        public void Balancing() =>
            Root = buildTree(Root);

        #endregion Balancing

        #region OutputTree

        /// <summary>
        /// Recursive creation of tree
        /// </summary>
        /// <param name="Root">Current root of sub tree</param>
        /// <param name="n">Number of margins</param>
        /// <param name="output">String with the result of building the tree</param>
        private void OutputTree(Node<T> Root, int n, ref string output)
        {
            if (Root != null)
            {
                OutputTree(Root.Left, n + 5, ref output);
                output += new String(' ', n) + Root.Value + '\n';
                OutputTree(Root.Right, n + 5, ref output);
            }
        }

        /// <summary>
        /// Show tree function
        /// </summary>
        /// <returns>A string containing the tree structure</returns>
        public override string ToString()
        {
            var outString = "";
            OutputTree(Root, 0, ref outString);
            return outString;
        }

        #endregion OutputTree

        /// <summary>
        /// Add new node in tree
        /// </summary>
        /// <param name="obj">Object to add to the tree</param>
        public void Add(T obj)
            => Add(new Node<T>(obj));

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj is Tree<T> tree &&
                   EqualityComparer<Node<T>>.Default.Equals(Root, tree.Root);
        }

        public override int GetHashCode()
        {
            return -1490287827 + EqualityComparer<Node<T>>.Default.GetHashCode(Root);
        }
    }
}