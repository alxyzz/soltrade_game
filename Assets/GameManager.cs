using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComputerConsole;

public class GameManager : MonoBehaviour
{

    #region singleton
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        init.Initialize();
    }
    #endregion

   [HideInInspector] public int JumpsToLose = 30;
    #region Managers
    public LocationManager locman;
    public ConsoleManager conman;
    public EconomyManager economy;
    public SettingsData settings;
    public PlayerData player;
    public CameraManager cam;
    public InitManager init;

    #endregion

    #region GAME STATE VARIABLES

    private int SHIPMENTS_GOAL;
    private int SHIPMENTS_CURRENT;
    #endregion

    #region GAME STATE REFS
    [Header("GAME STATE REFS")]

    #endregion



    #region UI_REFERENCES
    [Header(" UI_REFERENCES")]
    public UIReferencer ui;


    #endregion













    public string AddCargo(TradeGood b)
    {




        if (TRADEGOOD_PREPARED_FOR_TRANSFER != null)
        {
            return "\n ERORR: Transfer area full.";
        }
        TradeGood guh = new TradeGood();
        guh.Copy(b);
        TRADEGOOD_PREPARED_FOR_TRANSFER = b;
        return "\n Success: Container " + b.cargoID + "  stored in transfer area.";

    }



   



    #region data

    public Location currentLocation;


    public List<Location> allLocs = new();
    public List<(float, Location)> locsByDistance
    {
        get
        {
            List<(float, Location)> distances = new();
            foreach (Location item in allLocs)
            {
                if (item != currentLocation)
                {
                    float distance = Mathf.Abs(currentLocation.locX - item.locX) + Mathf.Abs(currentLocation.locY - item.locY);
                    distances.Add((distance, item));
                }
            }
            return distances;
        }
    }
    public string TravelByOrderInDistance(int i)
    {
        if (getVisitableLocations[i] != null)
        {
            if (i > 3)
            {
                return "ERROR: Starpath distance too large.";
            }
            currentLocation = getVisitableLocations[i];
            return "Success: Travelled to " + getVisitableLocations[i]._Name + ".";

        }
        else
        {
            return "ERROR: This system does not seem to exist. Do a reality check.";
        }
    }

    public bool TravelToLocation(Location t)
    {
        if (getVisitableLocations.Contains(t))
        {
            currentLocation = t;
            return true;

        }
        else
        {
            return false;
        }
    }

    public TradeGood TRADEGOOD_PREPARED_FOR_TRANSFER; //whichever trade good is unloaded in the hold


    public bool CheckIfLoss()
    {
        if (JumpsToLose <= 0)
        {
            if (player._credits >= player.debt)
            {
                Victory();
            }
            else Loss();

            return true;
        }
        return false;
    }
   public GameObject lossScreen, victoryScreen;
    public void Loss()
    {
        lossScreen.SetActive(true);
        StartCoroutine(TimedExit());
    }


    IEnumerator TimedExit()
    {


        yield return new WaitForSecondsRealtime(8f);
        Application.Quit();
    }
    public void Victory()
    {
        victoryScreen.SetActive(true);
        StartCoroutine(TimedExit());
    }



    public List<Location> getVisitableLocations
    {
        get
        {
            List<Location> b = new();
            for (int i = 0; i < 3; i++)
            {
                if (locsByDistance[i].Item2 != null)
                {
                    b.Add(locsByDistance[i].Item2);
                }
            }
            return b;
        }
    }



    

    #endregion
   


    #region UnityMethods
   

    #endregion

    #region Initialization methods

   

    #endregion

    #region Events
    

    #endregion



    #region Miscellaneous methods

    #endregion





}

