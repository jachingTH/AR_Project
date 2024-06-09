using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ARInputManager))]
[RequireComponent(typeof(ARRaycastManager))]
public class csPlaceOnIndicator : MonoBehaviour
{
    [SerializeField]
    GameObject placementIndicator;
    [SerializeField]
    GameObject placedPrefab;

    GameObject spawnedObject;

    [SerializeField]
    InputAction touchInput;

    ARRaycastManager aRRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();

        touchInput.performed += _ => { PlaceObject(); };

        placementIndicator.SetActive(false);
    }

    private void OnEnable()
    {
        touchInput.Enable();
    }

    private void OnDisable()
    {
        touchInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits,
            TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            placementIndicator.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);

            if (!placementIndicator.activeInHierarchy)
            {
                placementIndicator.SetActive(true);
            }
            else if (spawnedObject.activeInHierarchy)
            {
                placementIndicator.SetActive(false);
            }
        }

        //Plane을 생성하지 못할 때 ARIndicator를 나타나지 않게 한다.
        /*else
        {
            placementIndicator.SetActive(false);
        }*/
    }

    //Single Object Spawn
    void PlaceObject()
    {
        if (!placementIndicator.activeInHierarchy)
        {
            return;
        }
        if(spawnedObject == null)
        {
            spawnedObject = Instantiate(placedPrefab, placementIndicator.transform.position,
                placementIndicator.transform.rotation);
            placementIndicator.SetActive(false); // 추가된 코드 : indicator 삭제
        }
        

        else
        {
            spawnedObject.transform.SetPositionAndRotation(placementIndicator.transform.position,
                placementIndicator.transform.rotation);
            placementIndicator.SetActive(false); // 추가된 코드 : indicator 삭제
        }
    }

    //Multy Object Spawn
    void MultiPlaceObject()
    {
        if (!placementIndicator.activeInHierarchy)
            return;

        Instantiate(placedPrefab, placementIndicator.transform.position, placementIndicator.transform.rotation);
    }
}
