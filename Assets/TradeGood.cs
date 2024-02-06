using System.Linq;
using UnityEngine;

public class TradeGood
{
    public string cargoID;
    public string NAME;
    public string DESC;
    public float PRICE;
    public int quantity; //only used by NPC; players only hold a crate in each shelf
    public CATEGORY_TRADE_VALUE tradeValueCategory;
    public float VALUE;
    public bool ILLEGAL;

    public void Copy(TradeGood t, int quantit = 1)
    {
        cargoID = t.cargoID;
        NAME = t.NAME;
        tradeValueCategory = t.tradeValueCategory;
        VALUE = t.VALUE;
        quantity = quantit;
        ILLEGAL = t.ILLEGAL;
    }

    public TradeGood()
    {
        cargoID = RandomString(8);
       
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Range(0, s.Length - 1)]).ToArray());
    }

}
