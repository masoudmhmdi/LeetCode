namespace LeetCodes._638._Shopping_Offers;

public class Solution {
    public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
    {
        
        var result = this.DFS(special, needs, 0, null);

        return 0;
    }

    public IList<IList<int>> GetValidSpecialOffers(IList<IList<int>> special, IList<int> needs)
    {
        var offers = new List<IList<int>>();
        for (int i = 0; i < special.Count; i++)
        {
             var ziped = needs.Zip(special[i]);

             var isOk = true;
             foreach (var item in ziped)
             {
                 // first:need
                 // second : offer
                 if (item.Second > item.First)
                 {
                     isOk = false;
                     break;
                 }
                 
             }
             
             if(isOk) offers.Add(special[i]);
        } 
        
        return offers;
        
    }

    public int DFS(IList<IList<int>> special, IList<int> needs , int price, int? minPrice)
    {
        var copyOfList = new List<int>();

        foreach (var i in needs)
        {
            copyOfList.Add(i);
        }
        var validOffers = this.GetValidSpecialOffers(special, copyOfList);

        foreach (var offer in validOffers)
        {
            var newNeed = this.Buy(offer, copyOfList);

            //check this is an end of graph?
            if (newNeed.Max() > 0)
            {
                // call it with new offers and need and price
             minPrice = DFS(validOffers,newNeed,offer.Last() + price, minPrice);
            }
            else
            {
                if (minPrice is null)
                {
                    minPrice = price;
                }
                if (price < minPrice)
                {
                    minPrice = price;
                }

            }

        }
        
        return minPrice ?? 0;
        
    }

    public IList<int> Buy(IList<int> special, IList<int> needs)
    {

        for (int i = 0; i < needs.Count; i++)
        {
           needs[i] = needs[i] - special[i]; 
        }
        
        return needs;
    }
}
