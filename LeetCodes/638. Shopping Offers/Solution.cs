namespace LeetCodes._638._Shopping_Offers;

public class Solution {
    public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
    {

        for(var i = 0; i < needs.Count; i++)
        {
            
            var x = new int[price.Count + 1];

            x[i] = 1;
            x[price.Count] = price[i];
            special.Add(x);

        }
        
        var tem = 0;
        for (int i = 0; i < needs.Count; i++)
        {
            tem = tem + (needs[i] * price[i]);
        }
        
        var result = this.DFS(special, needs, 0, tem);
        
        return result;


    }

    private IList<IList<int>> GetValidSpecialOffers(IList<IList<int>> special, IList<int> needs)
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

    private int DFS(IList<IList<int>> special, IList<int> needs , int price, int minPrice)
    {
        
        if(price >  minPrice) return minPrice;
        var validOffers = this.GetValidSpecialOffers(special, needs);

        foreach (var offer in validOffers)
        {
            var newNeed = this.Buy(offer, needs);
            var newPrice = price + offer.Last();

             minPrice = DFS(validOffers,newNeed,newPrice, minPrice);
            if (newNeed.Max() == 0)
            {

                if (newPrice < minPrice)
                {
                    minPrice = newPrice;
                }
            }

        }
        
        return minPrice;
        
    }

    private IList<int> Buy(IList<int> special, IList<int> needs)
    {

        var newNeed = new List<int>();
        for (int i = 0; i < needs.Count; i++)
        {
            newNeed.Add(needs[i] - special[i]);
        }
        
        return newNeed;
    }
}
