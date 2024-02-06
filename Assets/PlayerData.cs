using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    #region Variables
    private CargoHolder _inventory;




    #endregion

    #region Properties
    public CargoHolder cargo
    {
        get { return _inventory; }
    }

    #endregion

    void Awake()
    {
        _inventory = new CargoHolder();

    }





    public float _credits = 625;
    public float debt = 5000;



    public bool ChangeMoney(float b)
    {
        if ((b + _credits) < 0) return false;
        else _credits += b; return true;

    }






}


public class CargoHolder
{

    List<TradeGood> cargo = new();
    public List<TradeGood> content
    {
        get
        {
            return cargo;
        }
    }
    int maxCargo = 24;
    public TradeGood CURRENT_TRADEGOOD;
   
    bool shop;
    public bool CanReceive
    {
        get
        {
            if (CURRENT_TRADEGOOD != null) return false;
            else return true;
        }
    }


    public bool CheckIfHasItem(string name, out float? price)
    {
        bool does = false;
        price = null;
        foreach (var item in cargo)
        {
            if (item.NAME == name)
            {
                does = true;
                price = item.PRICE;
            }
        }

        return does;
    }

    public void AddGood(TradeGood good, float price, int quantity)
    {
        cargo.Add(good);
        good.PRICE = price;
        good.quantity = quantity;
    }

    public string PlayerRemoveActiveGood()
    {
        if (CURRENT_TRADEGOOD == null) return "ERROR: Transfer buffer was empty.";
        CURRENT_TRADEGOOD = null;
        return "LOG: Transfer buffer emptied.";

    }
    public string PlayerAddGood(TradeGood good, out bool success) //from someone else to buffer area
    {
        if (CURRENT_TRADEGOOD != null)
        {
            success = false;
            return "\n [ERROR - Cargo buffer full.]";
        }
        TradeGood g = new TradeGood();
        g.Copy(good);
        CURRENT_TRADEGOOD = g;
        success = true;
        return "\n [Success - Cargo buffer stocked with cargo ID  `+ " + g.cargoID + "`. Transfer to cargo shelf recommended.]";
    }
    
    public string PlayerLoad()//from shelf to buffer area
    {

        if (CURRENT_TRADEGOOD == null) return "\nERROR: Nothing to transfer. Transfer buffer empty.";
        cargo.Add(CURRENT_TRADEGOOD);
        string cargoname = CURRENT_TRADEGOOD.cargoID;
        string shelfnr = (cargo.IndexOf(CURRENT_TRADEGOOD) + 1).ToString();
        CURRENT_TRADEGOOD = null;
        return "\nSUCCESS: Crate " + cargoname + " moved to shelf " + shelfnr + ".";
    }

    public string PlayerUnload(int i) //from shelf  to b area
    {
        if (CURRENT_TRADEGOOD != null) return "\nERROR: Transfer buffer full.";
        if (cargo[i - 1] != null)
        {
            CURRENT_TRADEGOOD = cargo[i - 1];
        }
        else return "\nERROR: Target crate invalid.";
        string shelfnr = (cargo.IndexOf(CURRENT_TRADEGOOD) + 1).ToString();
        cargo.Remove(CURRENT_TRADEGOOD);
        string cargoname = CURRENT_TRADEGOOD.cargoID;

        CURRENT_TRADEGOOD = null;
        return "\nSUCCESS: Crate " + cargoname + " moved from shelf " + shelfnr + " to transfer area.";
    }



    public string PlayerGetInfo(int whichGood)
    {
        if (cargo[whichGood] == null) return "\nERROR: Invalid or empty cargo shelf.";
        TradeGood b = cargo[whichGood];
        return "\nShelf " + whichGood + " - Cargo ID " + b.cargoID + " - " + b.DESC + "- Value:" + b.VALUE + " Bought at:" + b.PRICE;


    }

    public string ShopGetList()//contains stock, infinite
    {
        string txt = "";
        foreach (var item in cargo)
        {
            txt += (cargo.IndexOf(item) + 1) + ". " + item.quantity + item.NAME + " Value:" + item.VALUE + " Bought at:" + item.PRICE;
        }
        return txt;
    }
    public string PlayerGetInventoryList()
    {

        string txt = "";
        foreach (var item in cargo)
        {
            txt += (cargo.IndexOf(item) + 1) + ". " + item.NAME + " Value:" + item.VALUE + " Bought at:" + item.PRICE;
        }
        return txt;


    }





}
