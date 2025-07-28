namespace LeetCodes._701._Insert_into_a_Binary_Search_Tree;

  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }




public class Solution {
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {

        var resutl = Insert(root, val);
        
        return resutl;

    }


    public TreeNode Insert(TreeNode root, int val)
    {
        if (val > root.val)
        {
            if (root.right == null)
            {
                root.right = new TreeNode(val);
            }
            else
            {
                Insert(root.right, val);
            }
        }

        if (val < root.val)
        {
            if (root.left == null)
            {
                root.left = new TreeNode(val);
            }
            else
            {
                Insert(root.left, val);
            }           
        }
        
        
        return root;
    }
}
