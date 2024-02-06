using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{

    public Location(List<Location> poi, string name, string description, float xbonus = 0, float ybonus = 0)
    {
        locName = name;
        descy = description;
        

        if (poi != null)
        {
            foreach (var item in poi)
            {
                AddLocation(item);
            }
           
        }
        locX = UnityEngine.Random.Range(-100, 101);
        locY = UnityEngine.Random.Range(-100, 101);

        if (xbonus != 0)
        {
            int b = UnityEngine.Random.Range(0, 101);
            if (b> 50)
            {
                locX -= xbonus;
            }
            else
            {
                locX += xbonus;
            }
        }
        if (ybonus != 0)
        {
            int b = UnityEngine.Random.Range(0, 101);
            if (b > 50)
            {
                locY -= ybonus;
            }
            else
            {
                locY += ybonus;
            }
        }
    }

    private string descy;
    private string locName;
    public string _Name
    {
        get
        {
            return locName;
        }
    }

    public List<Location> containedLocs = new();
    bool sellsStuff;
    public Location parentLoc = null;
    public float locX, locY;
    public CargoHolder inventory = new(); //item, price, stock


    public void AddLocation(Location b)
    {
        containedLocs.Add(b);
        b.parentLoc = this;
    }

    public void AddInventory(TradeGood good, bool inDemand)
    {
        int markupFactor = UnityEngine.Random.Range(5, 20);
        float markupValue = 0;
        if (inDemand)
        {
            markupValue = (good.VALUE + (good.VALUE / 100 * markupFactor));
        }
        else
        {
            markupValue = (good.VALUE - (good.VALUE / 100 * markupFactor));
        }


        TradeGood newgood = good;
        newgood.PRICE = markupValue;
        inventory.AddGood(newgood, markupValue, 5);

    }

    public string GetDescription()
    {
        return descy;
    }

    //public string Buy(TradeGood g)
    //{
    //    foreach (var item in inventory.content)
    //    {
    //        if (item.NAME == g.NAME)
    //        {

    //            if (item.quantity < 1) //out of stock)
    //            {
    //                return "FAILURE: Vendor has no [" + g.NAME + "] in stock.";
    //            }
    //            if (item.PRICE > GameManager.Instance.player._credits)//not enough money
    //            {
    //                return "FAILURE: Unable to buy " + item.NAME +", you lack " + Math.Abs((1 * item.PRICE) - GameManager.Instance.player._credits) + " credits.";
    //            }
    //            //all conditions met
    //            ChangeProductStock(g, -1);
    //            float creditValue;
    //            if (g.PRICE != 0)
    //            {
    //                 creditValue = g.PRICE;
    //                GameManager.Instance.player._credits+= -g.PRICE;
    //                GameManager.Instance.AddCargo(g);
    //            }
    //            else
    //            {
    //                 creditValue = ((g.VALUE / 100) * 120);
    //                GameManager.Instance.player._credits += -g.PRICE;
    //                GameManager.Instance.AddCargo(g);
    //            }

    //            return "SUCCESS: Bought a container of [" + g.NAME + "] for " + creditValue + " credits.";

    //        }
    //    }
    //    return "ERORR: Firmware incompatibility with target.";
    //}
    //public string TrySellStockFromPlayer(TradeGood g)
    //{
    //    bool stocksThisItem = false;
    //    foreach (var item in inventory)
    //    {
    //        if (item.NAME == g.NAME)
    //        {
    //            stocksThisItem = true;

    //        }
    //    }

    //    if (stocksThisItem)
    //    {
    //        float creditValue =  g.PRICE;
    //        GameManager.Instance.ChangeCredits(creditValue);
    //        ChangeProductStock(g, 1);
    //        GameManager.Instance.TRADEGOOD_PREPARED_FOR_TRANSFER = null;
    //        return "SUCCESS: Sold a container of [" + g.NAME + "] for the price of " + creditValue + "\n Regular value would be " + g.VALUE + ".n";
    //    }
    //    else
    //    {
    //        float creditValue = ((g.VALUE /100) * 80);
    //        GameManager.Instance.ChangeCredits(creditValue);
    //        ChangeProductStock(g, 1);
    //        GameManager.Instance.TRADEGOOD_PREPARED_FOR_TRANSFER = null;
    //        return "SUCCESS: Sold a container of [" + g.NAME + "] for the price of " + creditValue + "\n Regular value would be " + g.VALUE + ".n";
    //    }
    //    //all conditions met


    //    return "ERORR: Firmware incompatibility with target.";
//}

}
