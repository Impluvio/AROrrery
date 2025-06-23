using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageSorter : MonoBehaviour
{
    private ARTrackedImageManager trackedImages;
    public GameObject[] ARPrefabs;

    List<GameObject> ARObjects = new List<GameObject>();

    private void Awake()
    {
        trackedImages = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        trackedImages.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImages.trackedImagesChanged -= OnTrackedImagesChanged;
    }


    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            foreach(var arPrefab in ARPrefabs)
            {
                if (trackedImage.referenceImage.name == arPrefab.name)
                {
                    var newPrefab = Instantiate(arPrefab, trackedImage.transform);
                    ARObjects.Add(newPrefab);
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (gameObject.name == trackedImage.name)
            {
                gameObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
            }
        }


    }




}
