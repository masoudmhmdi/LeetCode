namespace LeetCodes.AVLTree;


public class Node
{

  public Node? Left { get; set; }
  public Node? Right { get; set; }
  public int Value { get; set; }
  public int Height { get; set; } = 0;
  public Node(int val)
  {
    this.Value = val;
  }
}

public class AVLTree
{
  private Node _root;

  public AVLTree(Node root)
  {
    _root = root;
  }

  // left,right
  public (int,int) Insert(Node root, int value)
  {
    
    if (value > root.Value)
    {
      if (root.Right == null)
      {
        root.Right = new Node(value);
      }
      else
      {
        Insert(root.Right, value);
      }
    }

    if (value < root.Value)
    {
      if (root.Left == null)
      {
        root.Left = new Node(value);
      }
      else
      {
        Insert(root.Left, value);
      }           
    }


    return (0, 0);

  }
  
  
  
  
}