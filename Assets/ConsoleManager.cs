using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ComputerConsole;

public class ConsoleManager : MonoBehaviour
{
    [SerializeReference] public ComputerConsole CONSOLE_CARGO, CONSOLE_COMMS, CONSOLE_STATUS, CONSOLE_HELM;
    public GameObject objCargo { get { return CONSOLE_CARGO.gameObject; } }
    public GameObject objHelm { get { return CONSOLE_HELM.gameObject; } }
    public GameObject objComms { get { return CONSOLE_COMMS.gameObject; } }
    public GameObject objStatus { get { return CONSOLE_STATUS.gameObject; } }

    private ComputerConsole current ;
    public ComputerConsole _currentConsole
    {
        get
        {
            return current;
        }
    }
    [HideInInspector]
    public List<ComputerConsole> consoles
    {
        get
        {
            if (cons.Count > 0)
            {
                return cons;
            }
            else
            {
                cons.Add(CONSOLE_CARGO);
                cons.Add(CONSOLE_COMMS);
                cons.Add(CONSOLE_STATUS);
                cons.Add(CONSOLE_HELM);
                return cons;
            }

        }
    }
    List<ComputerConsole> cons = new();

    #region UI


    public List<float> indicatorWidths = new();
    private readonly float minDistBetweenIndicatorAndTarget = 1f;
    private Vector3 orig;
    private float lerpy = 0;
    private bool MOVING_INDICATOR = false;
    public void NotifyOfConsoleChange(ComputerConsole b)
    {
        current = b;
        MOVING_INDICATOR = true;

    }
    private Vector3 targetConsoleIndicator
    {
        get
        {
            if (current == null)
            {
                return Vector3.zero;
            }
            switch (current._type)
            {
                case ConsoleType.cargo:
                    return GameManager.Instance.ui.consoleLabels[0].transform.position;
                case ConsoleType.comms:
                    return GameManager.Instance.ui.consoleLabels[1].transform.position;
                case ConsoleType.status:
                    return GameManager.Instance.ui.consoleLabels[2].transform.position;
                case ConsoleType.helm:
                    return GameManager.Instance.ui.consoleLabels[3].transform.position;
                default:
                    return GameManager.Instance.ui.consoleLabels[3].transform.position;
            }

        }
    }

    private RectTransform indicRectProperty
    {
        get
        {
            if (rectangle_Indicator_donotusedirectly == null)
            {
                rectangle_Indicator_donotusedirectly = GameManager.Instance.ui.consoleIndicator.GetComponent<RectTransform>();
            }
            return rectangle_Indicator_donotusedirectly;
        }
    }

    private RectTransform rectangle_Indicator_donotusedirectly;
    #endregion

    //All the actual console command logic is here, the console themselves only contain the input and UI logic


    #region CargoMethods


    #endregion

    #region CommsMethods




    #endregion

    #region StatusMethods
    //we show here amount of remaining jumps, and debt owed, and time till pay installment
    int jumpsToPayDebtInstallment = 20;
    int debtInstallment;


    #endregion

    #region HelmMethods


    #endregion


    public string ListCargo()
    {
        string b = "\n";

        for (int i = 0; i < 24; i++)
        {
            if (GameManager.Instance.player.cargo.content[i] == null)
            {
                b += "\nShelf " + i + 1 + " - Empty";
            }
            else b += "\nShelf " + i + 1 + " - Container " + GameManager.Instance.player.cargo.content[i].cargoID;


        }
        return b;
    }
    private void UIAnimateCameraChange()
    {
        if (MOVING_INDICATOR && Mathf.Abs(GameManager.Instance.ui.consoleIndicator.transform.position.x - targetConsoleIndicator.x) > 1f)
        {
            if (orig == null)
            {
                orig = GameManager.Instance.ui.consoleIndicator.transform.position;
            }
            GameManager.Instance.ui.consoleIndicator.transform.position = 
                Vector3.Lerp(GameManager.Instance.ui.consoleIndicator.transform.position, 
                new Vector3(targetConsoleIndicator.x, 
                GameManager.Instance.ui.consoleIndicator.transform.position.y, 
                GameManager.Instance.ui.consoleIndicator.transform.position.z), 
                lerpy);
            lerpy += 0.1f;
        }
        else //as in the second condition does no longer apply
        {

            GameManager.Instance.ui.consoleIndicator.transform.position = 
                new Vector3(targetConsoleIndicator.x, 
                GameManager.Instance.ui.consoleIndicator.transform.position.y,
                GameManager.Instance.ui.consoleIndicator.transform.position.z);

            indicRectProperty.sizeDelta = 
                new Vector2(indicatorWidths[(int)current._type], 
                indicRectProperty.sizeDelta.y);
            MOVING_INDICATOR = false;
            orig = GameManager.Instance.ui.consoleIndicator.transform.position;
            lerpy = 0;
        }
    }


    public string getDistanceFromLocation(Location g)
    {
        string b = (Mathf.Abs(GameManager.Instance.currentLocation.locX - g.locX) + Mathf.Abs(GameManager.Instance.currentLocation.locY - g.locY)).ToString() + " ly";
        return b;
    }

    private void DoConsoleNotification()
    { //checks for each if there is a new message, flashes if so...
        foreach (var item in consoles)
        {
            item.ApplyNotificationIfExisting();
        }
    }
    //public void OnFixStatusScreen()
    //{
    //    if (current._type != ConsoleType.helm) return;
    //    GameManager.Instance.ui.STATUS_SpareMonitorBox.SetActive(false);
    //    GameManager.Instance.ui.STATUS_BrokenScreen.SetActive(false);
    //    GameManager.Instance.ui.STATUS_RealUI.SetActive(true);
    //    CONSOLE_STATUS.STATUS_FixScreen();
    //    CONSOLE_STATUS.CreateNotification();
    //}
    

    float timeToFlash = 0;
    float Text_flashing_intervalPeriod = 0.33f;
    void Awake()
    {
        current = CONSOLE_CARGO;
    }
    void Update()
    {
        UIAnimateCameraChange();
        //ReceiveInput();
        if (timeToFlash <= 0)
        {
            DoConsoleNotification();
            timeToFlash = Text_flashing_intervalPeriod;
        }
        else timeToFlash -= Time.deltaTime;
    }


}
