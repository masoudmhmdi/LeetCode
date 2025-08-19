namespace LeetCodes.AVLTree;




public class AvlTree
{
  private Node? _root = null;

  public AvlTree(int? rootValue)
  {
    
  }


  public void Add(int value)
  {
    if (_root == null)
    {
      _root = new Node(value);
    }
    else
    {
      TraverseAndInsert(_root, value);
    }
    
  }

  // return type is current max height
  private int TraverseAndInsert(Node node, int value)
  {
    
    if (value > node.Value)
    {
     if (node.Right == null) node.Right = new Node(value);
     else TraverseAndInsert(node.Right, value); 
    }

    if (value < node.Value)
    {
      if (node.Left == null) node.Left = new Node(value);
      else TraverseAndInsert(node.Left, value);
    }
    
    node.Height =  1 + Math.Max(Height(node.Right), Height(node.Left));
    
    
    return 0;
    
  }

  
  public void PrintTree()
  {
    Console.WriteLine("-------------------------------------------------");
    PrintTree(_root, "", true,null);
  }
  
  public void MyPrintTree()
  {
    Console.WriteLine("-------------------------------------------------");
    
    var list = new List<Node>();
    if (_root != null)
    {
      list.Add(_root);

    }
    MyPrintTree(list, "");
  }

  private void MyPrintTree(List<Node?>? childs, string space)
  {
    var nextDepth = new List<Node?>();

    foreach (var child in childs)
    {
     nextDepth.Add(child?.Left?? null);
     nextDepth.Add(child?.Right ?? null);
    }

    if (nextDepth.Count != 0)
    {
       MyPrintTree(nextDepth, space);
    }

    foreach (var child in childs)
    {
      Console.Write(child.Value);
      Console.Write(space);
    }
    
    
    foreach (var child in childs)
    {
      Console.Write($"/{space}\\");
    }
    if (childs == null)
    {
    } 
    
    
  }
  
  private void PrintTree(Node node, string indent, bool last, bool? isLeft)
  {
    if (node != null)
    {
      Console.Write(indent);

      if (last)
      {
        Console.Write("└───");
        indent += "  ";
      }
      else
      {
        Console.Write("├───");
        indent += "| ";
      }

      // Print node value with height + balance factor
      int balance = GetBalanceFactore(node);

      var nodePosition = isLeft is null ? "root" : (isLeft == true? "left" : "right");
      // int balance = 0;
      Console.WriteLine($"{nodePosition}:{node.Value} (H={node.Height}, BF={balance})");

      // Recurse on children
      PrintTree(node.Left, indent, false,true);
      PrintTree(node.Right, indent, true, false);
    }
  }

private int Height(Node? node) => node?.Height ?? 0;

private int GetBalanceFactore(Node node)
{
  
  return Height(node.Right) -  Height(node.Left);
}
  
}