using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncText : MonoBehaviour
{
    public TMPro.TMP_InputField target;
    public TMPro.TextMeshProUGUI us;
    TMPro.TextMeshProUGUI thisText
    {
        get
        {
            if (us == null)
            {
                us = GetComponent<TMPro.TextMeshProUGUI>();
            }
            return us;
        }
    }

    public void Sync()
    {
        us.text = target.text;
    }



}
