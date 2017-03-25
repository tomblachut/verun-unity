using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadCursor : MonoBehaviour
{

    public Camera Camera;
    public GameObject nameField;
    private NamePanel namePanel;

    private ColorizeSeat previousColorize;


    private void Start () {
        namePanel = nameField.GetComponent<NamePanel>();
    }

    private void Update () {
        if (Camera == null) return;

        if (previousColorize != null)
        {
            previousColorize.SetNormal();   
        }

        namePanel.ChangeName("-");

        var headPosition = Camera.transform.position;
        var gazeDirection = Camera.transform.forward;

        RaycastHit hitInfo;
        var down = Input.GetButton("Fire1");
//        var up = Input.GetButtonUp("Fire1");

        if (!Physics.Raycast(headPosition, gazeDirection, out hitInfo)) return;

        var seatComponent = hitInfo.transform.gameObject.GetComponent<SeatComponent>();
        var colorize = hitInfo.transform.gameObject.GetComponentInChildren<ColorizeSeat>();


        if (seatComponent == null || colorize == null) return;

        namePanel.ChangeName(seatComponent.GetSeat().ToString());

        if (down)
        {
            colorize.SetSelected();
        }
        else
        {
            colorize.SetHighlighted();
            previousColorize = colorize;

        }
    }
}
