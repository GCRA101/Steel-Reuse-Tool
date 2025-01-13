using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Effects;

namespace ReuseSchemeTool.model.data_structures
{
    public class RBTree<T> where T : IComparable<T>
    {
        //ATTRIBUTES
        public RBNode<T> root = null;
        private RBNode<T> sentinelNode = new RBNode<T>()
        {
            parent = null,
            right = null,
            left = null,
            color = RBColor.BLACK
        };


        //CONSTRUCTORS
        //Default

        //METHODS

        /* Set Root */
        public void setRoot(RBNode<T> node) { root = node; }


        /* PRE-ORDER VISIT */

        // Public wrapper function launching the recursive private function
        public void visitPreOrder()
        {
            this._visitPreOrder(this.root);
            return;
        }

        // Recursive private function
        private void _visitPreOrder(RBNode<T> node)
        {
            if (node != null)
            {
                // Operation on the node
                Console.WriteLine(node.key.ToString() + " " + node.color.ToString() + " ");
                // Recursive Step 1 (Left)
                this._visitPreOrder(node.left);
                // Recursive Step 2 (Right)
                this._visitPreOrder(node.right);
                return;
            }
        }


        /* IN-ORDER VISIT */

        // Public wrapper function launching the recursive private function
        public void visitInOrder()
        {
            this._visitInOrder(this.root);
            return;
        }

        // Recursive private function
        private void _visitInOrder(RBNode<T> node)
        {
            if (node != null)
            {
                // Recursive Step 1 (Left)
                this._visitInOrder(node.left);
                // Operation on the node
                Console.WriteLine(node.key.ToString() + " " + node.color.ToString() + " ");
                // Recursive Step 2 (Right)
                this._visitInOrder(node.right);
                return;
            }
        }


        /* POST-ORDER VISIT */

        // Public wrapper function launching the recursive private function
        public void visitPostOrder()
        {
            this._visitPostOrder(this.root);
            return;
        }

        // Recursive private function
        private void _visitPostOrder(RBNode<T> node)
        {
            if (node != null)
            {
                // Recursive Step 1 (Left)
                this._visitPostOrder(node.left);
                // Recursive Step 2 (Right)
                this._visitPostOrder(node.right);
                // Operation on the node
                Console.WriteLine(node.key.ToString() + " " + node.color.ToString() + " ");
                return;
            }
        }


        /* LEVEL-ORDER VISIT */

        // Public wrapper function launching the recursive private function
        private Boolean _isQueueEmpty(Queue<RBNode<T>> queue)
        {
            if (queue.Count == 0) return true;
            return false;
        }

        // Recursive private function
        public void visitLevelOrder()
        {
            RBNode<T> node = this.root;

            if (node == null)
            {
                return;
            }

            Queue<RBNode<T>> queue = new Queue<RBNode<T>>();

            queue.Enqueue(node);

            while (!_isQueueEmpty(queue))
            {
                node = queue.Dequeue();
                Console.WriteLine(node.ToString());
                if (node.left != null) { queue.Enqueue(node.left); }
                if (node.right != null) { queue.Enqueue(node.right); }
            }

            return;

        }


        /* COUNT NUMBER OF NODES */

        /* Since the upper limit value of the INT data type is 2,147,483,647 (32-bit signed integer), 
         * it is better to use the LONG data type (64-bit signed integer) as its upper value is 
         * 9,223,372,036,854,775,807. Therefore, it will be possible to count the number of the nodes of the
         * data tree in any possible scenario and even for absolutely huge amount of data. */

        // Public wrapper function launching the recursive private function
        public long countNodes()
        {
            return this._countNodes(this.root);
        }

        // Recursive private function
        private long _countNodes(RBNode<T> node)
        {
            if (node != null)
            {
                long num, num_l, num_r;
                // Recursive Step 01 (Left)
                num_l = this._countNodes(node.left);
                // Recursive Step 01 (Right)
                num_r = this._countNodes(node.right);
                // Operation on the node
                num = num_l + num_r + 1;
                return num;
            }
            return 0;
        }


        /* GET HEIGHT */

        // Public wrapper function launching the recursive private function
        public int getHeight()
        {
            return this._getHeight(this.root);
        }

        // Recursive private function
        private int _getHeight(RBNode<T> node)
        {
            int height;
            if (node == null) { return -1; }
            if ((node.left == null) && (node.right == null)) { return 0; }
            // Recursive Steps 01 and 02 (Left and Right)
            height = Math.Max(this._getHeight(node.left), this._getHeight(node.right));
            // Operation on the node
            return height + 1;
        }


        /* COUNT NODES AT LEVEL K */

        // Public wrapper function launching the recursive private function
        public int countNodesLevelK(int k)
        {
            return this._countNodesLevelK(k, 0, this.root);
        }

        // Recursive private function
        private int _countNodesLevelK(int k, int i, RBNode<T> node)
        {
            if (node == null) { return 0; }
            if (k == 1) { return 1; }

            int k_left, k_right;
            // Recursive Step 01 (Left)
            k_left = this._countNodesLevelK(k, i + 1, node.left);
            // Recursive Step 02 (Right)
            k_right = this._countNodesLevelK(k, i + 1, node.right);
            // Operation on the node
            return k_left + k_right;
        }


        /* SEARCH */

        // Public wrapper function launching the recursive private function
        public RBNode<T> search(T key)
        {
            return this._search(this.root, key);
        }

        // Recursive private function
        private RBNode<T> _search(RBNode<T> node, T key)
        {
            // If key is the same...
            if ((node == null) || (node.key.Equals(key))) { return node; }
            // If key is null...
            if (node.key == null) { return null; }
            // If key is different...
            if (key.CompareTo(node.key) == -1) { return this._search(node.left, key); }
            else { return this._search(node.right, key); }
        }


        /* MINIMUM */

        // Public wrapper function launching the iterative private function
        public RBNode<T> getMinimum()
        {
            return this._getMinimum(this.root);
        }

        // Iterative private function
        private RBNode<T> _getMinimum(RBNode<T> node)
        {
            if (node == null) { return null; }
            while (node.left.key != null) { node = node.left; }
            return node;
        }


        /* MAXIMUM */

        // Public wrapper function launching the iterative private function
        public RBNode<T> getMaximum()
        {
            return this._getMaximum(this.root);
        }

        // Iterative private function
        private RBNode<T> _getMaximum(RBNode<T> node)
        {
            if (node == null) { return null; }
            while (node.right.key != null) { node = node.right; }
            return node;
        }


        /* PREDECESSOR */

        // Iterative 
        public RBNode<T> predecessor(T key)
        {
            // Get the node having the input key
            RBNode<T> node = this.search(key);
            // If the node doesn't exist, return null
            if (node == null) { return null; }
            // Initialize output variable
            RBNode<T> predecessor;
            // If the node has left child, look for the maximum of its left sub-tree
            if (node.left.key != null) { predecessor = this._getMaximum(node.left); }
            // If the node has no left child, move up along the tree via iteration
            else
            {
                while ((node.parent != null) && (node == node.parent.left)) { node = node.parent; }
                predecessor = node.parent;
            }
            return predecessor;
        }


        /* SUCCESSOR */

        // Iterative 
        public RBNode<T> successor(T key)
        {
            // Get the node having the input key
            RBNode<T> node = this.search(key);
            // If the node doesn't exist, return null
            if (node == null) { return null; }
            // Initialize output variable
            RBNode<T> successor;
            // If the node has right child, look for the minimum of its right sub-tree
            if (node.right.key != null) { successor = this._getMinimum(node.left); }
            // If the node has no right child, move up along the tree via iteration
            else
            {
                while ((node.parent != null) && (node == node.parent.right)) { node = node.parent; }
                successor = node.parent;
            }
            return successor;
        }


        /* ROTATION LEFT */

        // Recursive

        public void rotationLeft(RBNode<T> pivot)
        {
            // 1. Initialize reference nodes

            // 1.1 Root of the tree
            RBNode<T> node = this.root;
            // 1.2 Auxiliary pointers
            RBNode<T> a = pivot;
            RBNode<T> b = a.right;

            // 2. Swap child beta from B to A

            // 2.1 Transfer left child of B (beta) to right child of A
            a.right = b.left;
            // 2.2 Update parent field of node beta (from B to A)
            if (a.right != null) { a.right.parent = a; }

            // 3. Swap nodes A and B

            // 3.1 Update left child of B (from beta to A)
            b.left = a;
            // 3.2 Update parent of B (from A to parent of A)
            b.parent = a.parent;
            // 3.3 If A is the root of the tree (null parent) update the root of
            //     the tree assigning it with b
            if (a.parent == null) { this.root = b; }
            // ... if A is the left child of its parent, update the left child
            // of the parent with the node B
            else if (a == a.parent.left) { a.parent.left = b; }
            // ... Otherwise updatewith B the right child of the parent of A
            else { a.parent.right = b; }
            // 3.4 Assign B to the parent of A
            a.parent = b;
        }


        /* ROTATION RIGHT */

        // Recursive

        public void rotationRight(RBNode<T> pivot)
        {
            // 1. Initialize reference nodes

            // 1.1 Root of the tree
            RBNode<T> node = this.root;
            // 1.2 Auxiliary pointers
            RBNode<T> a = pivot;
            RBNode<T> b = a.right;

            // 2. Swap child beta from B to A

            // 2.1 Transfer right child of B (beta) to left child of A
            a.left = b.right;
            // 2.2 Update parent field of node beta (from B to A)
            if (a.left != null) { a.left.parent = a; }

            // 3. Swap nodes A and B

            // 3.1 Update right child of B (from beta to A)
            b.right = a;
            // 3.2 Update parent of B (from A to parent of A)
            b.parent = a.parent;
            // 3.3 If A is the root of the tree (null parent) update the root of
            //     the tree assigning it with b
            if (a.parent == null) { this.root = b; }
            // ... if A is the left child of its parent, update the left child
            // of the parent with the node B
            else if (a == a.parent.left) { a.parent.left = b; }
            // ... Otherwise updatewith B the right child of the parent of A
            else { a.parent.right = b; }
            // 3.4 Assign B to the parent of A
            a.parent = b;
        }


        /* INSERT */

        public void insert(RBNode<T> node)
        {
            RBNode<T> zz = this._stepPreliminary(node);
            this._stepAdjustment(zz);
        }


        private RBNode<T> _stepPreliminary(RBNode<T> z)
        {
            // 1. Initialize Auxiliary Pointers

            // Current node's parent
            RBNode<T> y = null;
            // Current node
            RBNode<T> x = this.root;

            // 2. Descend to Node with null key
            while (x.key != null)
            {
                // Update y equalling to x
                y = x;
                // Update x making it descend to the right/left based on it key...
                if (z.key.CompareTo(x.key) < 0) { x = x.left; }
                else x = x.right;
            }

            // 3. Add New Node
            // If the tree is null, use the new node as root of the tree...
            if (y == null) { this.root = z; }
            // If the tree is not null, add the new node to the right/left of the last node...
            else
            {
                if (z.key.CompareTo(y.key) < 0) { y.left = z; }
                else { y.right = z; }
            }
            // Update the parent of the new node added to the tree...
            z.parent = y;

            // 4. Add Sentinel Nodes
            // Two sentinel nodes get added as children of the added node
            z.left = sentinelNode;
            z.left.parent = z;
            z.right = sentinelNode;
            z.right.parent = z;

            // 5. Return the inserted node
            return z;
        }



        // Public wrapper function launching the recursive private function
        private void _stepAdjustment(RBNode<T> node)
        {
            // Call the private recursive function
            this._stepAdjustment(this.root, node);
            return;
        }

        private void _stepAdjustment(RBNode<T> p, RBNode<T> z)
        {
            /* ** BASE CASE ** */
            /* If the node matches with the root of the tree, it's sufficient to change 
             * its color from RED to BLACK and the adjustment of the tree is finally concluded.
             * This implies also that the tree will have a b-height of one unit greater than the one 
             * that it had before the insertion */
            if (z == p)
            {
                // CASO 0
                /* If the inserted node is the root, just change the color from RED to BLACK */
                p.color = RBColor.BLACK;
                return;
            }

            /* ** SPECIFIC CASES **/

            /* If the node doesn't coincide with the root of the tree, the adjustment operations 
             * of the tree will be necessary only if it violates the rule for which every RED node  
             * can only have BLACK children.
             * Therefore, we can proceed with the following adjustment operations
             * ONLY IF THE NODE IS RED AND ITS PARENT IS RED AS WELL. */
            if ((z.color == RBColor.RED) && (z.parent.color == RBColor.RED))
            {
                // PREPARATION
                // Extraction of nodes Parent, Uncle and GrandParent of the inserted node...

                // Parent Node
                RBNode<T> parent = z.parent;
                // GrandParent Node
                RBNode<T> grandParent = parent.parent;
                // Uncle Node
                RBNode<T> uncle = new RBNode<T>();
                if (grandParent != null)
                {
                    if (parent == grandParent.left)
                    {
                        uncle = grandParent.right;
                    }
                    else
                    {
                        uncle = grandParent.right;
                    }
                }

                /* ADJUSTMENT CASES */
                // Case 1
                if (uncle.color == RBColor.RED)
                {
                    /* If the inserted node has a RED uncle and a RED parent,
                     * chenge the colors of the following nodes as below:
                     * - Parent and Uncle -> BLACK
                     * - GrandParent -> RED */
                    parent.color = RBColor.BLACK;
                    uncle.color = RBColor.BLACK;
                    grandParent.color = RBColor.RED;
                    /* ... and check whether the violation of the RB tree has been 
                     * moved to the grandparent node. If so, do the adjustment 
                     * on it applying recursively Case 1,2 or 3.
                    /* RECURSIVE STEP */
                    this._stepAdjustment(p, grandParent);
                }

                // Case 2
                else if ((uncle.color == RBColor.BLACK) && (z == parent.right))
                {
                    /* If the inserted node has a BLACK uncle and it is the RIGHT child of 
                     * a RED Node, the following operations are carried out: 
                     *  1. Left Rotation pivoting around the parent of the inserted node
                     *  2. Adjustment on Parent Node (we know that the parent will violate the RB tree
                     *     based on Case 3 and that this one will lead to the definitive solution of the
                     *     violation)*/
                    this.rotationLeft(parent);
                    /* RECURSIVE STEP */
                    this._stepAdjustment(p, parent);
                }

                // Case 3
                else if ((uncle.color == RBColor.BLACK) && (z == parent.left))
                {
                    /* If the inserted node has a BLACK uncle and it's the LEFT child of 
                     * a RED Node, the following operations are carried out:
                     *  1. Colors are changed as follows:
                     *      - Parent -> BLACK
                     *      - GrandParent -> RED
                     *  2. Rotation pivoting around the Parent of the inserted node
                     *  No need to carry out any further adjustments on the upper levels of the tree.
                     *  As per theory, Case 3 always solves any violation. */
                    parent.color = RBColor.BLACK;
                    grandParent.color = RBColor.RED;
                    this.rotationRight(grandParent);
                }

            }

            return;

        }
    }
}