namespace DataStructures.Tree.BinaryTree;

public class BinaryTreeNode
{
    private readonly int _value;

    private readonly BinaryTreeNode? _right;
    private readonly BinaryTreeNode? _left;
    private readonly BinaryTreeNode? _parent;

    public BinaryTreeNode(int value)
    {
        // set the values to null
        this._right = null;
        this._left = null;
        this._parent = null;

        // set initial value to the node
        this._value = value;
    }

    /// <summary>
    /// Return the max between the left and right node
    /// </summary>
    public int Height => Math.Max(this.LeftHeight(), this.RightHeight());

    public int LeftHeight()
    {
        if (this._left is null) return 0;

        return this._left.Height + 1;
    }

    public int RightHeight()
    {
        if (this._right is null) return 0;

        return this._right.Height + 1;
    }

    public int BalanceFactor() => this.RightHeight() - this.LeftHeight();

    /// <summary>
    /// Get parent's sibling if exist
    /// </summary>
    public BinaryTreeNode? GetUncle()
    { 
        // Check if the current node has a parent
        if (this._parent is null)
        {
            return null;
        }

        // Check if current node has grand-parent
        if (this._parent._parent is null)
        {
            return null;
        }

        // Check if grand-parent has two children
        if (this._parent._parent._left is null || this._parent._parent._right is null)
        {
            return null;
        }

        return new BinaryTreeNode(1);
    }

}
public class BinarySearchTreeNode{
    
}

public class BinarySearchTree
{
    public BinarySearchTreeNode Root { get; } = new();
}