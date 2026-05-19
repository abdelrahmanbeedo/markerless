using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OneTimeARCarPlacer : MonoBehaviour
{
    public GameObject carPrefab;
    public ARRaycastManager raycastManager;

    public CarColorChanger colorChanger;

    private bool carPlaced = false;
    private GameObject spawnedCar;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (carPlaced)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                TryPlaceObject(touch.position);
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            TryPlaceObject(Input.mousePosition);
        }
#endif
    }

    void TryPlaceObject(Vector2 screenPosition)
    {
        if (raycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            spawnedCar = Instantiate(carPrefab, hitPose.position, hitPose.rotation);

            CarColorChanger spawnedColorChanger = spawnedCar.GetComponent<CarColorChanger>();

            if (spawnedColorChanger != null)
            {
                colorChanger.carRenderer = spawnedColorChanger.carRenderer;
            }

            carPlaced = true;
        }
    }
}