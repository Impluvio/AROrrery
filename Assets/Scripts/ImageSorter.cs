using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageSorter : MonoBehaviour
{
    private ARTrackedImageManager trackedImages;
    public GameObject[] ARPrefabs;
    Dictionary<string, GameObject> activePlanets = new Dictionary<string, GameObject>();
    List<GameObject> enabledInfoScreens = new List<GameObject>();
    VoiceOverManager voiceOverManager;

    private void Awake()
    {
        trackedImages = GetComponent<ARTrackedImageManager>();
        voiceOverManager = FindObjectOfType<VoiceOverManager>();

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
                    activePlanets[arPrefab.name] = newPrefab;

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


    public void EnableInformation(string planetName)
    {
        //Debug.Log("image sorter hit");
        //Debug.Log("Planet name: " + planetName);


        if (!activePlanets.TryGetValue(planetName, out GameObject planetInstance))
        {
            Debug.LogWarning("Planet instance not found in dictionary: " + planetName);
            return;
        }

        Transform infoScreenTransform = planetInstance.transform.Find("InfoScreen");



        if (infoScreenTransform == null)
        {
            Debug.LogWarning("InfoScreen not found on: " + planetInstance.name);
            return;
        }

        GameObject infoScreen = infoScreenTransform.gameObject;

        enabledInfoScreens.Add(infoScreen);
        Debug.Log("no. of enabled info screens" + enabledInfoScreens.Count);

        infoScreen.SetActive(!infoScreen.activeSelf);

        if (infoScreen.activeSelf == true)
        {
            voiceOverManager.playAudio(planetName);
        }
        else if (infoScreen.activeSelf == false)
        {
            voiceOverManager.stopAudio(planetName);
        }
    }



}
