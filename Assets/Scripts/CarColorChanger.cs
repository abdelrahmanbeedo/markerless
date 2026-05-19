using UnityEngine;

public class CarColorChanger : MonoBehaviour
{
    public Renderer carRenderer;

    public void ChangeColor(Color newColor)
    {
        if (carRenderer == null)
        {
            Debug.LogError("Car Renderer is not assigned!");
            return;
        }

        carRenderer.material.color = newColor;
    }

    public void ChangeToBlack()
    {
        ChangeColor(Color.black);
    }

    public void ChangeToBlue()
    {
        ChangeColor(Color.blue);
    }

    public void ChangeToRed()
    {
        ChangeColor(Color.red);
    }
}