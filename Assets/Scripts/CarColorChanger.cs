using UnityEngine;

public class CarColorChanger : MonoBehaviour
{
    public Renderer carRenderer;

    public void ChangeToBlack()
    {
        carRenderer.material.color = Color.black;
    }

    public void ChangeToBlue()
    {
        carRenderer.material.color = Color.blue;
    }

    public void ChangeToRed()
    {
        carRenderer.material.color = Color.red;
    }
}