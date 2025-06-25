using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPopup : MonoBehaviour
{
    GameObject planetPrefab;
    ImageSorter imageSorter;
    VoiceOverManager voiceOverManager;

    // Start is called before the first frame update
    void Start()
    {
        imageSorter = FindObjectOfType<ImageSorter>();
        voiceOverManager = FindObjectOfType<VoiceOverManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("main button pressed");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            if (Physics.Raycast(ray, out hit, 100))
            {
               if(hit.transform.tag != null)
                {
                    Debug.Log("raycast object hit name: " + hit.transform.tag);
                    string nameOfHit = hit.transform.tag;
                    imageSorter.EnableInformation(nameOfHit);
                    voiceOverManager.playAudio(nameOfHit);
                }

            }

           
        }

    }
}
