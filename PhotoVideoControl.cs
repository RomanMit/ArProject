using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NatCorderU.Core;
using NatCorderU.Core.Recorders;
using NatShareU;
using UnityEngine.UI;
using NatCorderU.Core.Clocks;


public class PhotoVideoControl : MonoBehaviour
{
    private CameraRecorder videoRecorder;
    private AudioRecorder audioRecorder;

    public GameObject photoButtonSmall;
    public GameObject videoButtonSmall;


    public GameObject videoButtonBig;
    public GameObject photoButtonBig;

    public AudioSource sourceAudio;
    //public GameObject waterMark;

    private RealtimeClock clock;
    public Camera mainCamera ;
    int i = 0;
    //public GameObject[] objectsToDeactivate;

    private void Start()
    {
        photoButtonBig.SetActive(true);
        photoButtonSmall.SetActive(false);

        videoButtonBig.SetActive(false);
        videoButtonSmall.SetActive(true);

        //disable watermark
        // waterMark.GetComponent<Image>().enabled = false;
    }



    public void pressPhotoButton()
    {
        if (!NatCorder.IsRecording) { 
            // Take a screenshot and save it to Gallery/Photos
            StartCoroutine(TakeScreenshotAndSave());
        }
            
    }


    private IEnumerator TakeScreenshotAndSave()
    {
        {
        //    //Debug.Log(Application.persistentDataPath);
        //    foreach (GameObject uiElement in objectsToDeactivate) {
        //        uiElement.GetComponent<Image>().enabled = false;
        //}
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        //waterMark.GetComponent<Image>().enabled = true;

            yield return new WaitForEndOfFrame();

            Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            ss.Apply();

            // Save the screenshot to Gallery/Photos
            NativeGallery.SaveImageToGallery(ss, "img", "img" + i + ".png");
        //foreach (GameObject uiElement in objectsToDeactivate)
            //{
            //    uiElement.GetComponent<Image>().enabled = true;
            //}
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;

          //  waterMark.GetComponent<Image>().enabled = false;
            i++;
            // To avoid memory leaks
            Destroy(ss);
        
        }
    }

    public void pressVideoButton(){
        
        if (!NatCorder.IsRecording){
            StartRecording();
            videoButtonBig.GetComponent<Image>().color = Color.red;
        }else if (NatCorder.IsRecording){
            StopRecording();
            videoButtonBig.GetComponent<Image>().color = Color.white;
        }
    }
    void OnReplay(string path)
    {
        Debug.Log("Saved recording to: " + path);
        // Playback the video
#if UNITY_IOS
        //Handheld.PlayFullScreenMovie("file://" + path);
       // NatShare.SaveToCameraRoll(path);
#elif UNITY_ANDROID
        //Handheld.PlayFullScreenMovie(path);
        Debug.Log(path);
        NatShare.SaveToCameraRoll(path, "monticolAR", false);
#endif
    }

    void StartRecording()
    {
        // Start recording
        NatCorder.StartRecording(Container.MP4, VideoFormat.Screen, AudioFormat.Unity, OnReplay);
        // Create a camera recorder to record the main camera
        clock = new RealtimeClock();
        videoRecorder = CameraRecorder.Create(mainCamera, clock);
        audioRecorder = AudioRecorder.Create(sourceAudio);
    }

    void StopRecording()
    {
        //Destroy the camera recorder
        videoRecorder.Dispose();
        audioRecorder.Dispose();
        // Stop recording
        NatCorder.StopRecording();
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        // Check that we are recording
        if (NatCorder.IsRecording)
        {
            // Commit the frame
            NatCorder.CommitSamples(data, clock.CurrentTimestamp);
        }
    }
}

