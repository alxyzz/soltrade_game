using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIReferencer : MonoBehaviour
{
    


    [SerializeReference] public List<GameObject> consoleLabels = new();
    [SerializeReference] public GameObject consoleIndicator;
    [SerializeReference] public TextMeshProUGUI txt_credit;
    [SerializeReference] public GameObject rootCanvas;
    //[SerializeReference] public GameObject STATUS_SpareMonitorBox;
    //[SerializeReference] public GameObject STATUS_BrokenScreen;
    //[SerializeReference] public GameObject STATUS_RealUI;


    [SerializeReference] private TextMeshProUGUI TEXT_BAR_TXT_CARGO, TEXT_BAR_TXT_COMMS, TEXT_BAR_TXT_STATUS, TEXT_BAR_TXT_PILOT, TEXT_BAR_TXT_ENGINE, TEXT_BAR_TXT_THRUSTER, TEXT_BAR_TXT_CRYO;
  

    void Update()
    {
        txt_credit.text = Mathf.Round(GameManager.Instance.player._credits).ToString();

    }
}
