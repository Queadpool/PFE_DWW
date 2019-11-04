using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject parasaurolophusCamera;
    private int camPositionCounter = 0;

    AudioListener mainCamAudioLis;
    AudioListener paraurolophusCamAudioLis;
    
	// Use this for initialization
	void Start ()
    {
        mainCamAudioLis = mainCamera.GetComponent<AudioListener>();
        paraurolophusCamAudioLis = parasaurolophusCamera.GetComponent<AudioListener>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SwitchCamera();
	}

    void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CameraChangeCounter();
        }
    }

    void CameraChangeCounter()
    {
        camPositionCounter++;

        if (camPositionCounter > 1)
        {
            camPositionCounter = 0;
        }

        if (camPositionCounter == 0)
        {
            mainCamera.SetActive(true);
            mainCamAudioLis.enabled = true;

            paraurolophusCamAudioLis.enabled = false;
            parasaurolophusCamera.SetActive(false);
        }

        if (camPositionCounter == 1)
        {
            parasaurolophusCamera.SetActive(true);
            paraurolophusCamAudioLis.enabled = true;

            mainCamAudioLis.enabled = false;
            mainCamera.SetActive(false);
        }
    }
}
