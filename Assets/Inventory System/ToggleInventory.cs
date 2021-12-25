using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public static ToggleInventory inv;
    public GameObject inventory;

    public FirstPersonMovement movement;
    public FirstPersonLook look;
    public Jump jump;
    public Crouch crouth;
    public Zoom zoom;


    public bool isInventoryActive = false;
    // Update is called once per frame
    public void Update()
    {
        Cursor.lockState = (isInventoryActive) ? CursorLockMode.Confined : CursorLockMode.Locked;
        Cursor.visible = isInventoryActive;
        if (inv == null)
            inv = this;
        inventory.SetActive(isInventoryActive);
        ToggleMovement(!isInventoryActive);
        if (Input.GetKeyDown(KeyCode.E))
        {
            isInventoryActive = !isInventoryActive;
        }
    }
    
    public void ToggleMovement(bool enabled)
    {
        movement.enabled = enabled;
        look.enabled = enabled;
        jump.enabled = enabled;
        crouth.enabled = enabled;
        zoom.enabled = enabled;
    }

}
