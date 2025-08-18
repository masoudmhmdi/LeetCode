// See https://aka.ms/new-console-template for more information

using LeetCodes._638._Shopping_Offers;

public class Program()
{

    public static void Main()
    {
        var needs = new List<int>() { 3, 2 };
        var price = new List<int>() { 2, 5 };
        var offers = new List<IList<int>>();
        offers.Add([3, 0, 5]);
        offers.Add([1, 2, 10]);
        
        var shoppingOffer = new Solution();

        shoppingOffer.ShoppingOffers(price, offers, needs);
        
        Console.WriteLine("Hello World!");
        
    }

}

