// See https://aka.ms/new-console-template for more information

using LeetCodes._638._Shopping_Offers;
using LeetCodes.AVLTree;

public class Program()
{

    public static void Main()
    {
        var avlTree = new AvlTree(50);
        
        
        avlTree.Add(3);
        avlTree.Add(2);
        avlTree.Add(5);
        avlTree.Add(1);
        avlTree.Add(4);
        avlTree.Add(30);
        avlTree.Add(60);
        avlTree.Add(-1);
        avlTree.Add(-2);
        avlTree.Add(-3);
        
        
        avlTree.MyPrintTree();

    }

}

