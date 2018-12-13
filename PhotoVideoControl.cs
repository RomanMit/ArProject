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
    private VideoFormat format;
    int i = 0;
    //public GameObject[] objectsToDeactivate;

    private void Start()
    {
        photoButtonBig.SetActive(true);
        photoButtonSmall.SetActive(false);

        videoButtonBig.SetActive(false);
        videoButtonSmall.SetActive(true);

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
            //Debug.Log(Application.persistentDataPath);
     
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

            yield return new WaitForEndOfFrame();

            Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            ss.Apply();

            // Save the screenshot to Gallery/Photos
            NativeGallery.SaveImageToGallery(ss, "img", "img" + i + ".png");
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
            i++;
            // To avoid memory leaks
            Destroy(ss);
        
        }
    }

    public void pressVideoButton(){
        Debug.Log("Pressed video button");
        if (!NatCorder.IsRecording){
            Debug.Log("Started recording");
            StartRecording();
            videoButtonBig.GetComponent<Image>().color = Color.red;
        }else if (NatCorder.IsRecording){
            Debug.Log("stopping recording");
            StopRecording();
            videoButtonBig.GetComponent<Image>().color = Color.white;
        }
    }
    void OnReplay(string path)
    {
        Debug.Log("Saved recording to: " + path);
        // Playback the video
#if UNITY_IOS
        Handheld.PlayFullScreenMovie("file://" + path);
        NatShare.SaveToCameraRoll(path);
#elif UNITY_ANDROID
        //Handheld.PlayFullScreenMovie(path);
        Debug.Log(path);
        NatShare.SaveToCameraRoll(path);
#endif
    }
    void StartRecording()
    {
        Debug.Log("start recording method");
        // Start recording
        format = new VideoFormat(960, 540);
        NatCorder.StartRecording(Container.MP4, format, AudioFormat.None, OnReplay);
        // Create a camera recorder to record the main camera
        clock = new RealtimeClock();
        videoRecorder = CameraRecorder.Create(mainCamera, clock);
       // audioRecorder = AudioRecorder.Create(sourceAudio);

    }

    void StopRecording()
    {
        Debug.Log("stop recording method");
        //Destroy the camera recorder
        videoRecorder.Dispose();
        // audioRecorder.Dispose();
        // Stop recording
        NatCorder.StopRecording();

    }

    //void OnAudioFilterRead(float[] data, int channels)
    //{
    //    // Check that we are recording
    //    if (NatCorder.IsRecording)
    //    {
    //        NatCorder.CommitSamples(data, clock.CurrentTimestamp);
    //    }
    //}
}

