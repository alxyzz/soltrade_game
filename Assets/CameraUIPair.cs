using System.Collections.Generic;
using UnityEngine;

public class CameraUIPair : MonoBehaviour
{
    public Camera RelatedCamera;
    public ComputerConsole relatedConsole;

    void Awake()
    {
        relatedConsole.RegisterUIPair(this);
    }

    public void OnEnterLook()
    {

        GameManager.Instance.conman.NotifyOfConsoleChange(relatedConsole);
        RelatedCamera.gameObject.SetActive(true);
        relatedConsole.OnEntry();
        relatedConsole.ActivateInputField();

    }


    public void OnLeaveLook()
    {
        RelatedCamera.gameObject.SetActive(false);
        relatedConsole.OnExit();
        relatedConsole.DeactivateInputField();

    }


}
