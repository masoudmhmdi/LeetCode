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
        
        var result = this.DFS(special, needs, 0, null);

        if (result is not null)
        {
            return (int)result;
        }
        else
        {

            var tem = 0;
            for (int i = 0; i < needs.Count; i++)
            {
                tem = tem + (needs[i] * price[i]);
            }
            return tem;
        }

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

    public int? DFS(IList<IList<int>> special, IList<int> needs , int price, int? minPrice)
    {
        var validOffers = this.GetValidSpecialOffers(special, needs);

        foreach (var offer in validOffers)
        {
            var newNeed = this.Buy(offer, needs);
            var newPrice = price + offer.Last();

            //check this is an end of graph?
            // if (newNeed.Max() > 0)
            // {
                // call it with new offers and need and price
             minPrice = DFS(validOffers,newNeed,newPrice, minPrice);
            // }
            // else
            // {
            //     if (minPrice is null)
            //     {
            //         minPrice = price;
            //     }
            //     if (price < minPrice)
            //     {
            //         minPrice = price;
            //     }
            //
            //     price = 0;
            //
            // }

            if (newNeed.Max() == 0)
            {
                if (minPrice is null)
                {
                    minPrice = newPrice;
                }

                if (newPrice < minPrice)
                {
                    minPrice = newPrice;
                }
            }

        }
        
        return minPrice;
        
    }

    public IList<int> Buy(IList<int> special, IList<int> needs)
    {

        var newNeed = new List<int>();
        for (int i = 0; i < needs.Count; i++)
        {
            newNeed.Add(needs[i] - special[i]);
        }
        
        return newNeed;
    }
}
