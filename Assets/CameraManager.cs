using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("settings")]
    //[SerializeField] float seconds_to_lerp;

    [Header("refs")]

    [SerializeReference] public CameraUIPair currentCam; //also the camera you start in


    public CameraUIPair cam_Helm;
    public CameraUIPair cam_Cargo;
    public CameraUIPair cam_Status;
    public CameraUIPair cam_Comms;


    //float currlerp;
    //bool moving;
    public enum cameratype
    {
        helm, cargo, status, comms
    }
    [HideInInspector] public List<CameraUIPair> cameras = new();

    public void SwitchCam(cameratype b)
    {
        GameManager.Instance.cam.currCam = b;
        foreach (var item in cameras)
        {
            item.OnLeaveLook();
        }

        switch (b)
        {
            case cameratype.helm:
                cam_Helm.OnEnterLook(); break;
            case cameratype.cargo:
                cam_Cargo.OnEnterLook(); break;
            case cameratype.status:
                cam_Status.OnEnterLook(); break;
            case cameratype.comms:
                cam_Comms.OnEnterLook(); break;
            default:
                break;
        }
    }
    void Awake()
    {



        cameras.Add(cam_Helm);
        cameras.Add(cam_Cargo);
        cameras.Add(cam_Status);
        cameras.Add(cam_Comms);
        foreach (var item in cameras)
        {
            item.OnLeaveLook();

        }
        currentCam.OnEnterLook();
    }
    bool canMove = true;
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SwitchCam(cameratype.cargo);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                SwitchCam(cameratype.comms);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SwitchCam(cameratype.status);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SwitchCam(cameratype.helm);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

        }
    }
    public cameratype currCam = cameratype.helm;
}
