using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerConsole : MonoBehaviour
{

    public bool _HasNotification
    {
        get
        {
            return hasNotification;
        }
    }

    bool hasNotification = false;
    public enum ConsoleType
    {
        cargo,
        comms,
        status,
        helm,
    }
    public ConsoleType _type;




    string GetDefaultMessage()
    {
        string locationInfo = "";
        string commercialPartnerInfo = "";

        foreach (var item in GameManager.Instance.currentLocation.containedLocs)
        {
            if (item != null)
            {
                commercialPartnerInfo += "\nTrader in range: " + item._Name + " - " + item.GetDescription();
                commercialPartnerInfo += "\nGoods for sale:";
                for (int i = 0; i < item.inventory.content.Count - 1; i++)
                {
                    commercialPartnerInfo += (i + 1) + " - " + item.inventory.content[i].NAME + " - " + item.inventory.content[i].PRICE;
                }
            }
            else
                Debug.LogError("ComputerConsole.GetDefaultMessage.comms - null error when asking for visitable locations. This shouldn't happen...");
        }


        if (GameManager.Instance.currentLocation != null)
        {
            locationInfo += "\nThe ship is currently situated at: " + GameManager.Instance.currentLocation._Name + ". " + GameManager.Instance.currentLocation.GetDescription();
        }




        switch (_type)
        {
            case ConsoleType.cargo:

                return "\nFOSS Cargo Management System 'Atreides'\n 2522 Build II\n";
            case ConsoleType.comms:
                string res = "\nBudget Bob's Communication Array Firmware \n";
                res += "\nCmds: clr | buy | sell - Uses current cargo transfer area for the transaction.";
                //res += commercialPartnerInfo;
                OutputSecondary(commercialPartnerInfo + "\nNote: Goods not stocked by a vendor are sold at 80% value and purchased at 120% of their value, respectively.");
                //res += "\nNote: Goods not stocked by a vendor are sold at 80% value and purchased at 120% of their value, respectively.";

                return res;
            case ConsoleType.status:
                return "\nQuad-Tachyon Machine Diagnosis Device." + "\nYour cryptowallet contains the equivalent of " + GameManager.Instance.player._credits + " credits." + "\n\nYou've been awake for " + Time.realtimeSinceStartup + "." + "\n\nMESSAGE FROM SECTORBANK: 'You still owe us. Pay up the 5,000 credits and we'll be fine.\n\nAmount remaining:" + GameManager.Instance.player.debt.ToString() + "\n\n Time remaining:" + GameManager.Instance.JumpsToLose.ToString() + " jumps left.";

            case ConsoleType.helm:

                string result = "\n\nCrunk-class Hauler Navigation Firmware v1.52\n\n" + locationInfo;
                result += "\n\nPoint of Interest in range: ";
                int b = 1;
                foreach (var item in GameManager.Instance.getVisitableLocations)
                {
                    if (item != null) result += "\n\n" + b.ToString() + "." + item._Name + " - " + item.GetDescription() + " - Distance: " + (Mathf.Abs(GameManager.Instance.currentLocation.locX - item.locX) + Mathf.Abs(GameManager.Instance.currentLocation.locY - item.locY));
                    else
                        Debug.LogError("ComputerConsole.GetDefaultMessage.comms - null error when asking for visitable locations. This shouldn't happen...");
                }
                result += "\n\n Do [go] [number] to travel to a different location.";

                return result;

            default:
                return "\nFOSS Cargo Management System 'Atreides'\n 2522 Build II\n\n";
        }
    }


    bool active;
    //[SerializeReference] Camera cam;
    [SerializeReference] TMP_InputField PLAYER_TEXT;
    [SerializeReference] TextMeshProUGUI MAIN_OUTPUT;
    [SerializeReference] TextMeshProUGUI SECONDARY_OUTPUT;
    [SerializeReference] TextMeshProUGUI TXT_TOP_TEXT;
    public void StartInput()
    {
        Invoke("ActivateInputField", 0.01f);
    }
    public void ActivateInputField()
    {
        Debug.Log("Activated input field.");
        PLAYER_TEXT.gameObject.SetActive(true);

        PLAYER_TEXT.text = "";
        PLAYER_TEXT.ActivateInputField();
        PLAYER_TEXT.Select();


    }

    public void OnExit()
    {
        Invoke("DeactivateInputField", 0.01f);
    }
    public void DeactivateInputField()
    {
        Debug.Log("DeactivateInputField input field.");
        PLAYER_TEXT.text = "";
        PLAYER_TEXT.DeactivateInputField();
        PLAYER_TEXT.ReleaseSelection();
        PLAYER_TEXT.gameObject.SetActive(false);


    }
    [HideInInspector] public CameraUIPair relatedCameraUIPair;


    public void RegisterUIPair(CameraUIPair b)
    {

        relatedCameraUIPair = b;
    }

    //public void STATUS_FixScreen()
    //{
    //    STATUS_BROKEN = false;
    //}

    string FIRST_WORD
    {
        get
        {
            // Split the string by spaces
            List<string> words = new List<string>(PLAYER_TEXT.text.Split(' '));

            // Check if there are at least two words in the string
            if (words.Count > 0)
            {
                // Return the second word
                return words[0];
            }
            else
            {
                // Return an empty string if there is no second word
                return string.Empty;
            }

        }
    }
    string SECOND_WORD
    {
        get
        {
            // Split the string by spaces
            List<string> words = new List<string>(PLAYER_TEXT.text.Split(' '));

            // Check if there are at least two words in the string
            if (words.Count > 1)
            {
                // Return the second word
                return words[1];
            }
            else
            {
                // Return an empty string if there is no second word
                return string.Empty;
            }

        }
    }
    string THIRD_WORD
    {
        get
        {
            // Split the string by spaces

            List<string> words = new List<string>(PLAYER_TEXT.text.Split(' '));

            // Check if there are at least two words in the string
            if (words.Count > 2)
            {
                // Return the second word
                return words[2];
            }
            else
            {
                // Return an empty string if there is no second word
                return string.Empty;
            }

        }
    }

    #region pilotMethods






    #endregion

    public void OnEntry()
    {

        //if (STATUS_BROKEN)
        //{
        //    return;
        //}
        hasNotification = false;
        if (!initialized) //cinematic intro. once per console.
        {
            if (initializing) return;
            StartCoroutine(timedInitialize());
        }
        else OnCameraChangeToThis();//we skip to the point.
    }




    bool initialized = false;//wether we have visited this screen before but passed initialization screen that's just for adding some backstory/narrative/fluff
    bool initializing = false;//wether we have visited this screen before but are currently initializing
    IEnumerator timedInitialize()
    {
        initializing = true;
        string[] initlist = ShowPreInitMessage();
        MAIN_OUTPUT.text = "";

        foreach (var item in initlist)
        {
            MAIN_OUTPUT.text += item;
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return new WaitForSecondsRealtime(3f);
        initialized = true;
        initializing = false;


        OnCameraChangeToThis();

    }

    public void ApplyNotificationIfExisting()
    {
        if (hasNotification)
        {
            TXT_TOP_TEXT.color = (TXT_TOP_TEXT.color == Color.white) ? Color.yellow : Color.white;
        }
        else
        {
            TXT_TOP_TEXT.color = Color.white;
        }
    }

    string[] ShowPreInitMessage()
    {
        string initial;
        switch (_type)
        {
            case ConsoleType.cargo:
                initial = "\nFOSS Cargo Management System 'Atreides'|\n2522 Build II|\n|\nInitializing systems...|\n Starting drone connection...|\nDrone 1 detected.|\nDrone 2 detected.|\nDrone 3 detected.|\nDrone connection finished.|\nLogistic net building...|\nLogistic net built. All systems nominal.|\nFinishing up...";
                return initial.Split('|');
            case ConsoleType.comms:
                initial = "\nBudget Bob's Communication Array Firmware|\nWelcome.|\nSetting up ports...|\n.|\n..|\n...|\nFully initialized.|\nReady for business.";
                return initial.Split('|');
            case ConsoleType.status:
                initial = "\nQuad-Tachyon Machine Diagnosis Device.|\n\'Crunk|\n'-class Hauler, ID 9615-2874 detected.|\nSpecifications:|\nCapacity: 32 tonnes.|\nAntigravity: None.|\nPower Supply: 15MW Plasma Reactor.|\nWeight: 44,670kg.|\nStatus complete, all system peripherals mapped.|\nInitializing.|\n.|\n..|\n...";
                return initial.Split('|');
            //case consoletype.pilot:
            //    initial = "\nCrunk-class Hauler Navigation Firmware v1.52|\nBooting...|\n.|\n..|\n...|\nReady for operation.";
            //    return initial.Split('|');
            //case consoletype.engine:
            //    initial = "\n15MW Guadelajara Plasma Reactor Firmware|\n Machined by Dai-Yokai Dynamics||\n\n\nInterface fully loaded.|\nReady for operation.";
            //    return initial.Split('|');
            //case consoletype.thruster:
            //    initial = "\nFOSS Thruster Management System Suite 'Chungoid Prime'|\nWelcome, user.|\n Initializing thruster check.|\n.|\n..|\n...|\nAll thrusters nominal. Ready for operation.";
            //    return initial.Split('|');
            //case consoletype.cryo:
            //    initial = "\nCryolife Basic Subscription Cryogenic Suite|\nWelcome to your new life among the stars.|\n|\nYour life is safe with us.|\nUpgrade to Deluxe for decongelation error minimalization.|\n |\nReady to sleep?|||";
            //    return initial.Split('|');
            default:
                initial = "\nUnregistered system...|\n.|\n..|\n...|\nError...|\nFirmware not found.";
                return initial.Split('|');
        }
    }




    //bool STATUS_BROKEN = false;

    void OnCameraChangeToThis()
    {
        //if (STATUS_BROKEN)
        //{
        //    return;
        //}
        StartInput();
        if (SECONDARY_OUTPUT != null)
        {
            SECONDARY_OUTPUT.text = "";

        }
        MAIN_OUTPUT.text = GetDefaultMessage();


        active = true;



    }
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            HandleInput();
        }
    }
    void HandleInput()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PressedEnter();
            }
        }
    }
    string PopUpMessage(string b)
    {
        if (active)
        {
            StartCoroutine(errorMessage(b));
        }
        return "";
    }
    IEnumerator errorMessage(string g)
    {
        bool oldstate = active;
        active = false;
        string b = MAIN_OUTPUT.text;
        MAIN_OUTPUT.text = g;
        PLAYER_TEXT.text = "";
        yield return new WaitForSecondsRealtime(3f);
        active = oldstate;
        MAIN_OUTPUT.text = b;


    }
    public void CreateNotification()
    {
        hasNotification = true;
    }
    void PressedEnter()
    {
        if (FIRST_WORD != null)
        {
            Debug.Log("FIRST_WORD is " + FIRST_WORD);
        }
        if (SECOND_WORD != null)
        {
            Debug.Log("SECOND_WORD is " + SECOND_WORD);
        }
        if (THIRD_WORD != null)
        {
            Debug.Log("THIRD_WORD is " + THIRD_WORD);
        }



        if (active && PLAYER_TEXT.text != "")
        {
            ParseCommand();
            PLAYER_TEXT.text = "";
        }

    }
    void OutputMain(string g)
    {
        MAIN_OUTPUT.text += g;
    }

    void OutputSecondary(string g)
    {
        if (SECONDARY_OUTPUT != null)
        {
            SECONDARY_OUTPUT.text += g;

        }
    }


    void ParseCommand()
    {

        PlayerData player = GameManager.Instance.player;
        CargoHolder trader = null;
        MAIN_OUTPUT.text += "\n>" + PLAYER_TEXT.text;
        if (FIRST_WORD == "clr")
        {
            OnCameraChangeToThis();
        }
        switch (_type)
        {
            case ConsoleType.cargo:
                switch (FIRST_WORD)
                {

                    case "info": //shows info of examined cargo container
                        int t1 = -1;
                        if (SECOND_WORD == null || SECOND_WORD == "") return;

                        if (!int.TryParse(SECOND_WORD, out t1)) PopUpMessage("\n info: Malformed syntax.\n Proper syntax: info [target]\n Outputs information written on the container as seen by drone camera.");
                        if (t1 == -1) PopUpMessage("\n info: Malformed syntax.\n Proper syntax: info [target]\n Outputs information written on the container as seen by drone camera."); else
                        {
                            OutputMain(player.cargo.PlayerGetInfo(t1 + 1));
                        }

                        break;
                    case "load": //loads container from buffer area to shelf
                        if (SECOND_WORD == "")
                        {
                            OutputMain(player.cargo.PlayerLoad());
                        }
                        else PopUpMessage("\n load: Malformed syntax.\n Proper syntax: load \nLoad container from buffer area to free shelf.\nNo parameters necessary");
                        break;
                    case "unload": //unloads container from shelf to buffer area
                        int t3 = -1;
                        if (SECOND_WORD == null || SECOND_WORD == "") return;
                        if (t3 == -1) PopUpMessage("\n unload: Malformed syntax.\n Proper syntax: unload [target shelf]\n Load the active container to target shelf.");
                        if (!int.TryParse(SECOND_WORD, out t3)) PopUpMessage("\n unload: Malformed syntax.\n Proper syntax: unload [target shelf]\n Load the active container to target shelf.");
                        else
                        {
                            OutputMain(player.cargo.PlayerUnload(t3 + 1));
                        }



                        break;
                    case "list":
                        SECONDARY_OUTPUT.text = player.cargo.PlayerGetInventoryList();
                        break;

                    default:
                        PopUpMessage("\n\n\n Invalid query. Possible commands:\ninfo [shelf number] - shows information of cargo container as read by drone.\nload - loads container from buffer area to shelf.\nunload [number of shelf to unload] - unloads crate from specified shelf.\nlist - shows list of crates.");
                        break;
                }



                break;
            case ConsoleType.comms:
                switch (FIRST_WORD)
                {
                    case "buy": //buy 1 2 (buy from vendor 1, item 2)
                        int vendor = 1;
                        if (SECOND_WORD == null || SECOND_WORD == "") return;
                        if (int.TryParse(SECOND_WORD, out vendor))
                        {

                            if (vendor == -1) return;
                            if (GameManager.Instance.currentLocation.containedLocs[vendor] == null) return;
                            trader = GameManager.Instance.currentLocation.containedLocs[vendor].inventory;
                            int itm;
                            if (int.TryParse(THIRD_WORD, out itm))
                            {
                                if (!player.cargo.CanReceive) return;//space check
                                if (trader.content == null) return;
                                if (trader.content[itm] == null) return;
                                TradeGood good = trader.content[itm];

                                if (player._credits < good.PRICE) return;//money check
                                bool sc;
                                OutputMain(player.cargo.PlayerAddGood(good, out sc));
                                if (!sc) return; //player specific error cases (no space, full transfer area etc)
                                                 //if successful, we bill the player
                                player.ChangeMoney(good.PRICE);
                                OutputMain("\n LOG: You were billed " + good.PRICE + " for this purchase.");


                            }
                        }
                        else PopUpMessage("\n buy: Target shelf missing or does not exist.\n Proper syntax: unload [target shelf]\n Load the active container to target shelf.");

                        break;
                    case "sell":
                        if (player.cargo.CURRENT_TRADEGOOD == null) return; //nothing to sell
                        TradeGood CURRENT_TRADEGOOD = player.cargo.CURRENT_TRADEGOOD;
                        float? priceIfexisting;//if the shop already has it for sale, we'll use their price to prevent positive feedback loop.
                        Location TradePartner = null;
                        List<Location> toRemove = new(); //clean up additional vendors that aren't used // todo - let people sell to different vendors later
                        foreach (var item in GameManager.Instance.currentLocation.containedLocs)
                        {
                            foreach (var itemy in item.inventory.content)
                            {
                                if (CURRENT_TRADEGOOD == itemy)
                                {
                                    if (TradePartner == null)
                                    {
                                        TradePartner = item; //only registers first seller.
                                    }
                                    else
                                    {
                                        if (!toRemove.Contains(item))
                                        {
                                            toRemove.Add(item);
                                        }
                                    }

                                }
                            }
                        }
                        float soldprice = CURRENT_TRADEGOOD.VALUE;

                        if (trader == null) return;
                        if (trader.CheckIfHasItem(CURRENT_TRADEGOOD.NAME, out priceIfexisting))
                        {//if trader already has the item, we use the price he sells it at. to prevent positive feedback loop
                            soldprice = (float)priceIfexisting;
                        }
                        //we just sold x at price y
                        //trader - gains item
                        //player - loses item
                        //player -- gains money
                        trader.AddGood(CURRENT_TRADEGOOD, soldprice, 1);
                        player.ChangeMoney(soldprice);
                        OutputMain(player.cargo.PlayerRemoveActiveGood());
                        PopUpMessage("\nSold " + CURRENT_TRADEGOOD.NAME + " for " + soldprice + ".");
                        break;
                    default:
                        break;
                }

                break;
            case ConsoleType.status:
                break;

            case ConsoleType.helm:

                switch (FIRST_WORD)
                {
                    case "go": //buy 1 2 (buy from vendor 1, item 2)
                        int target = -1;
                        if (SECOND_WORD == null || SECOND_WORD == "") return;

                        if (int.TryParse(SECOND_WORD, out target))
                        {

                            if (target > GameManager.Instance.getVisitableLocations.Count) return;
                            if (target < 0) return;
                            if (GameManager.Instance.getVisitableLocations[target] == null) return;
                            Location nextLoc = GameManager.Instance.getVisitableLocations[target];
                            GameManager.Instance.JumpsToLose--;
                            if (GameManager.Instance.CheckIfLoss()) return;
                            PopUpMessage("\n Travelling to " + nextLoc._Name + "...\nYou have " + GameManager.Instance.JumpsToLose.ToString() + " jumps left to pay your debt.");
                            GameManager.Instance.currentLocation = nextLoc;
                            OnCameraChangeToThis();
                        }
                        else PopUpMessage("\n buy: Target shelf missing or does not exist.\n Proper syntax: unload [target shelf]\n Load the active container to target shelf.");
                        break;
                    default:
                        break;
                }

                break;

            default:
                break;
        }


    }

    //string KeyCodeToLetter(KeyCode keyCode)
    //{
    //    if (keyCode >= KeyCode.A && keyCode <= KeyCode.Z)
    //    {
    //        return ((char)(keyCode - KeyCode.A + 'A')).ToString();
    //    }
    //    else
    //    {
    //        return string.Empty;
    //    }
    //}


}



