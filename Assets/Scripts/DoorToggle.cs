using UnityEngine;

public class DoorToggle : MonoBehaviour
{
    public Animator doorAnimator;

    private bool isOpen = false;

    public void ToggleDoor()
    {
        if (doorAnimator == null)
        {
            Debug.LogError("Door Animator is not assigned!");
            return;
        }

        if (isOpen)
        {
            doorAnimator.Play("FrontLeftDoor_Close");
        }
        else
        {
            doorAnimator.Play("FrontLeftDoor_Open");
        }

        isOpen = !isOpen;
    }
}