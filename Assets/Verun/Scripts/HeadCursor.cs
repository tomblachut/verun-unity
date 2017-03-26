using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadCursor : MonoBehaviour
{

    public GameObject Character;
    public Camera Camera;
    public GameObject nameField;
    private NamePanel namePanel;

    public GameObject Controller1;
    public GameObject Controller2;

    private ColorizeSeat previousColorize;
    private SeatManager seatManager;


    private SteamVR_TrackedController tracked1;
    private SteamVR_TrackedController tracked2;



    private void Start () {
        namePanel = nameField.GetComponent<NamePanel>();
        seatManager = GetComponent<SeatManager>();

        tracked1 = Controller1.GetComponent<SteamVR_TrackedController>();
        tracked2 = Controller2.GetComponent<SteamVR_TrackedController>();
    }

    private void Update () {
        if (Camera == null) return;

        if (previousColorize != null)
        {
            previousColorize.SetNormal();   
        }



        var sendPressed = Input.GetButton("Fire2") || tracked1.menuPressed || tracked2.menuPressed;
        if (sendPressed)
        {
            Debug.Log("Send hit");
        }

        //        namePanel.ChangeName("-");

        var headPosition = Camera.transform.position;
        var gazeDirection = Camera.transform.forward;

        RaycastHit hitInfo;
        var teleportPressed = Input.GetButtonUp("Fire1") || tracked1.triggerPressed || tracked2.triggerPressed;
//        var up = Input.GetButtonUp("Fire1");

        if (!Physics.Raycast(headPosition, gazeDirection, out hitInfo)) return;

        var seatComponent = hitInfo.transform.gameObject.GetComponent<SeatComponent>();
        var colorize = hitInfo.transform.gameObject.GetComponentInChildren<ColorizeSeat>();
        if (seatComponent == null || colorize == null) return;

        var seat = seatComponent.GetSeat();

//        namePanel.ChangeName(seat.ToString());

        if (teleportPressed)
        {
            Character.transform.position = hitInfo.transform.position;
        }
        colorize.SetHighlighted();
        previousColorize = colorize;

        //        if (down && !seatManager.selected.Contains(seat))
        //        {
        //            colorize.SetSelected();
        //            seatManager.selected.Add(seat);
        //        }
        //        else 
//        if (!seatManager.selected.Contains(seat))
//        {

//        }
    }
}
