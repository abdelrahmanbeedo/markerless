using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OneTimeARCarPlacer : MonoBehaviour
{
    public GameObject carPrefab;
    public ARRaycastManager raycastManager;

    private bool carPlaced = false;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (carPlaced)
            return;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            TryPlaceObject(Input.mousePosition);
        }
#endif

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                TryPlaceObject(touch.position);
            }
        }
    }

    void TryPlaceObject(Vector2 screenPosition)
    {
        if (raycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            Instantiate(carPrefab, hitPose.position, hitPose.rotation);

            carPlaced = true;
        }
    }
}