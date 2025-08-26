namespace LeetCodes._36._Valid_Sudoku;

public class Solution {
    
    public bool IsValidSudoku(char[][] board) {
        for (var i = 0; i <board.Length; i++)
        {
           var isValid = this.CheckRowIsValid(board[i]);
           if(!isValid) return false;
           var colIsValid = this.CheckColIsValid(board, i);
           if(!colIsValid) return false;
        }

        for (var j = 0; j < 3; j++)
        {
            for (var k = 0; k < 3; k++)
            {
               var subBoxIsValid = this.CheckSubBoxIsValid((j,k), board);
               if(!subBoxIsValid) return false;
            }
        }
        
        return true;
    }

    private bool CheckRowIsValid(char[] row)
    {
        var tempRow = new char[row.Length];
        for (var i = 0; i < row.Length; i++)
        {
            
            if(row[i] == '.') continue;
            var indexValue = row[i] - 49;
            if (tempRow[row[i] - 49] == '\0')
            {
                 tempRow[row[i] - 49] = row[i];
            }
            else
            {
                return false;
            }
        }
        
        return true;
    }

    private bool CheckColIsValid(char[][] board, int col)
    {
        var tempCol = new char[board.Length];

        for (var i = 0; i < board.Length; i++)
        {
            
            if(board[i][col] == '.') continue;
            var indexValue = board[i][col] - 49;
            if (tempCol[indexValue] == '\0')
            {
                tempCol[indexValue]  = board[i][col];
            }
            else
            {
                return false;
            }
        }
        return true;
    }


    private bool CheckSubBoxIsValid((int, int) box, char[][] board)
    {
       var rowStartIndex = box.Item1 * 3;
       var colStartIndex = box.Item2 * 3;

       var tempArray = new char[9];
       for (var i = rowStartIndex; i < rowStartIndex + 3; i++)
       {
           for (var j = colStartIndex; j < colStartIndex + 3; j++)
           {
               
               if(board[i][j] == '.') continue;
               if (tempArray[board[i][j] - 49] ==  '\0')
               {
                   tempArray[board[i][j] - 49] = board[i][j];
               }
               else
               {
                   return false;
               }
           }
           
       }
       
       return true;
       
    }
}
