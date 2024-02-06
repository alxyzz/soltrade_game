using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{

    Dictionary<string, TradeGood> Definitions_TradeGood =
    new Dictionary<string, TradeGood>();




    public void DefineGoods()
    {



        TradeGood oreuranium = new TradeGood();
        oreuranium.NAME = "ore, uranium";
        oreuranium.VALUE = 200;
        oreuranium.PRICE = oreuranium.VALUE + UnityEngine.Random.Range(-5, 5);
        oreuranium.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        oreuranium.ILLEGAL = false;

        TradeGood orebauxite = new TradeGood();
        orebauxite.NAME = "ore, bauxite";
        orebauxite.VALUE = 150;
        orebauxite.PRICE = orebauxite.VALUE + UnityEngine.Random.Range(-5, 5);
        orebauxite.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        orebauxite.ILLEGAL = false;

        TradeGood oreferrum = new TradeGood();
        oreferrum.NAME = "ore, ferrum";
        oreferrum.VALUE = 180;
        oreferrum.PRICE = oreferrum.VALUE + UnityEngine.Random.Range(-5, 5);
        oreferrum.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        oreferrum.ILLEGAL = false;

        TradeGood orelead = new TradeGood();
        orelead.NAME = "ore, lead";
        orelead.VALUE = 220;
        orelead.PRICE = orelead.VALUE + UnityEngine.Random.Range(-5, 5);
        orelead.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        orelead.ILLEGAL = false;

        TradeGood orecopper = new TradeGood();
        orecopper.NAME = "ore, copper";
        orecopper.VALUE = 250;
        orecopper.PRICE = orecopper.VALUE + UnityEngine.Random.Range(-5, 5);
        orecopper.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        orecopper.ILLEGAL = false;

        TradeGood orerareearth = new TradeGood();
        orerareearth.NAME = "ore, rare earth";
        orerareearth.VALUE = 300;
        orerareearth.PRICE = orerareearth.VALUE + UnityEngine.Random.Range(-5, 5);
        orerareearth.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        orerareearth.ILLEGAL = false;

        TradeGood crystalsplasma = new TradeGood();
        crystalsplasma.NAME = "crystals, plasma";
        crystalsplasma.VALUE = 400;
        crystalsplasma.PRICE = crystalsplasma.VALUE + UnityEngine.Random.Range(-5, 5);
        crystalsplasma.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        crystalsplasma.ILLEGAL = false;

        TradeGood machinerydomestic = new TradeGood();
        machinerydomestic.NAME = "machinery, domestic";
        machinerydomestic.VALUE = 600;
        machinerydomestic.PRICE = machinerydomestic.VALUE + UnityEngine.Random.Range(-5, 5);
        machinerydomestic.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        machinerydomestic.ILLEGAL = false;

        TradeGood machinerymilitary = new TradeGood();
        machinerymilitary.NAME = "machinery, military";
        machinerymilitary.VALUE = 700;
        machinerymilitary.PRICE = machinerymilitary.VALUE + UnityEngine.Random.Range(-5, 5);
        machinerymilitary.tradeValueCategory = CATEGORY_TRADE_VALUE.luxury;
        machinerymilitary.ILLEGAL = false;

        TradeGood machineryindustrial = new TradeGood();
        machineryindustrial.NAME = "machinery, industrial";
        machineryindustrial.VALUE = 650;
        machineryindustrial.PRICE = machineryindustrial.VALUE + UnityEngine.Random.Range(-5, 5);
        machineryindustrial.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        machineryindustrial.ILLEGAL = false;

        TradeGood foodsynthetic = new TradeGood();
        foodsynthetic.NAME = "food, synthetic";
        foodsynthetic.VALUE = 350;
        foodsynthetic.PRICE = foodsynthetic.VALUE + UnityEngine.Random.Range(-5, 5);
        foodsynthetic.tradeValueCategory = CATEGORY_TRADE_VALUE.junk;
        foodsynthetic.ILLEGAL = false;

        TradeGood foodhomegrown = new TradeGood();
        foodhomegrown.NAME = "food, homegrown";
        foodhomegrown.VALUE = 300;
        foodhomegrown.PRICE = foodhomegrown.VALUE + UnityEngine.Random.Range(-5, 5);
        foodhomegrown.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        foodhomegrown.ILLEGAL = false;

        TradeGood foodluxury = new TradeGood();
        foodluxury.NAME = "food, luxury";
        foodluxury.VALUE = 500;
        foodluxury.PRICE = foodluxury.VALUE + UnityEngine.Random.Range(-5, 5);
        foodluxury.tradeValueCategory = CATEGORY_TRADE_VALUE.luxury;
        foodluxury.ILLEGAL = false;

        TradeGood weaponrycitizen = new TradeGood();
        weaponrycitizen.NAME = "weaponry, citizen";
        weaponrycitizen.VALUE = 800;
        weaponrycitizen.PRICE = weaponrycitizen.VALUE + UnityEngine.Random.Range(-5, 5);
        weaponrycitizen.tradeValueCategory = CATEGORY_TRADE_VALUE.junk;
        weaponrycitizen.ILLEGAL = false;

        TradeGood weaponrymilitary = new TradeGood();
        weaponrymilitary.NAME = "weaponry, military";
        weaponrymilitary.VALUE = 900;
        weaponrymilitary.PRICE = weaponrymilitary.VALUE + UnityEngine.Random.Range(-5, 5);
        weaponrymilitary.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        weaponrymilitary.ILLEGAL = false;

        TradeGood drugsmedical = new TradeGood();
        drugsmedical.NAME = "drugs, medical";
        drugsmedical.VALUE = 750;
        drugsmedical.PRICE = drugsmedical.VALUE + UnityEngine.Random.Range(-5, 5);
        drugsmedical.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        drugsmedical.ILLEGAL = false;

        TradeGood drugsnarcotic = new TradeGood();
        drugsnarcotic.NAME = "drugs, narcotic";
        drugsnarcotic.VALUE = 850;
        drugsnarcotic.PRICE = drugsnarcotic.VALUE + UnityEngine.Random.Range(-5, 5);
        drugsnarcotic.tradeValueCategory = CATEGORY_TRADE_VALUE.luxury;
        drugsnarcotic.ILLEGAL = true;

        TradeGood animalspet = new TradeGood();
        animalspet.NAME = "animals, pet";
        animalspet.VALUE = 450;
        animalspet.PRICE = animalspet.VALUE + UnityEngine.Random.Range(-5, 5);
        animalspet.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        animalspet.ILLEGAL = false;

        TradeGood animalsfarm = new TradeGood();
        animalsfarm.NAME = "animals, farm";
        animalsfarm.VALUE = 400;
        animalsfarm.PRICE = animalsfarm.VALUE + UnityEngine.Random.Range(-5, 5);
        animalsfarm.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;
        animalsfarm.ILLEGAL = false;

        TradeGood animalsexotic = new TradeGood();
        animalsexotic.NAME = "animals, exotic";
        animalsexotic.VALUE = 600;
        animalsexotic.PRICE = animalsexotic.VALUE + UnityEngine.Random.Range(-5, 5);
        animalsexotic.tradeValueCategory = CATEGORY_TRADE_VALUE.luxury;
        animalsexotic.ILLEGAL = true;

        TradeGood biosupplies = new TradeGood();
        biosupplies.NAME = "biosupplies";
        biosupplies.VALUE = 250;
        biosupplies.PRICE = biosupplies.VALUE + UnityEngine.Random.Range(-5, 5);
        biosupplies.tradeValueCategory = CATEGORY_TRADE_VALUE.commodity;


        Definitions_TradeGood.Add("ore, uranium", oreuranium);
        Definitions_TradeGood.Add("ore, bauxite", orebauxite);
        Definitions_TradeGood.Add("ore, ferrum", oreferrum);
        Definitions_TradeGood.Add("ore, lead", orelead);
        Definitions_TradeGood.Add("ore, copper", orecopper);
        Definitions_TradeGood.Add("ore, rare earth", orerareearth);
        Definitions_TradeGood.Add("crystals, plasma", crystalsplasma);
        Definitions_TradeGood.Add("machinery, domestic", machinerydomestic);
        Definitions_TradeGood.Add("machinery, military", machinerymilitary);
        Definitions_TradeGood.Add("machinery, industrial", machineryindustrial);
        Definitions_TradeGood.Add("food, synthetic", foodsynthetic);
        Definitions_TradeGood.Add("food, homegrown", foodhomegrown);
        Definitions_TradeGood.Add("food, luxury", foodluxury);
        Definitions_TradeGood.Add("weaponry, citizen", weaponrycitizen);
        Definitions_TradeGood.Add("weaponry, military", weaponrymilitary);
        Definitions_TradeGood.Add("drugs, medical", drugsmedical);
        Definitions_TradeGood.Add("drugs, narcotic", drugsnarcotic);
        Definitions_TradeGood.Add("animals, pet", animalspet);
        Definitions_TradeGood.Add("animals, farm", animalsfarm);
        Definitions_TradeGood.Add("animals, exotic", animalsexotic);
        Definitions_TradeGood.Add("biosupplies", biosupplies);
    }

    public TradeGood getRandomTradeGood()
    {

        Dictionary<string, TradeGood> dict = new Dictionary<string, TradeGood>();
        List<string> keyList = new List<string>(dict.Keys);
        string randomKey = keyList[Random.Range(0, keyList.Count)];
        TradeGood g = new TradeGood();
        g.Copy(dict[randomKey]);
        return g;
    }

    //private void DoPeriodicPriceChange()
    //{
    //    int b = Random.Range(1, 100);
    //    if (b < 70)
    //    {
    //        return;
    //    }
    //    foreach ((TradeGood, float) item in LIST_REFERENCES_TO_TRADEGOODS_IN_LOCATIONS)
    //    {
    //        int markupFactor = Random.Range(-30, 31);

    //        if (item.Item1.quantity < 3)
    //        {
    //            markupFactor += 10;//prices go up. obviously, this bears no real financial justification, it's just a magic number
    //        }
    //        if (item.Item1.quantity > 10)
    //        {
    //            markupFactor -= 10;
    //        }


    //        int randomQuantityChange = Random.Range(-5, 5);
    //        item.Item1.quantity += randomQuantityChange;
    //        if (item.Item1.quantity < 1)
    //        {
    //            item.Item1.quantity = 0;
    //        }
    //    }
    //}


    //public void RegisterTradeGood((TradeGood, float) b) //good, price. tradegood contains quantity
    //{
    //    LIST_REFERENCES_TO_TRADEGOODS_IN_LOCATIONS.Add(b);
    //}

    //private readonly List<(TradeGood, float)> LIST_REFERENCES_TO_TRADEGOODS_IN_LOCATIONS = new();//for the purpose of rerolling prices and markups, demands, et cetera. we define this when adding tradegoods to locations
}







public enum CATEGORY_TRADE_VALUE //prices have local markup-markdown too based on location
{
    junk, 
    commodity, 
    luxury
}