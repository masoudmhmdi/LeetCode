namespace LeetCodes.AVLTree;


public class Node
{

  public Node? Left { get; set; }
  public Node? Right { get; set; }
  public int Value { get; set; }
  public int Height { get; set; } = 1;
  public Node(int val)
  {
    this.Value = val;
  }
}
