using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScreenToMenu : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "StartAnimation.webm");
        videoPlayer.Play();
    }

    private void Update()
    {
        Debug.Log(Time.timeSinceLevelLoad);
        if (!videoPlayer.isPlaying && Time.timeSinceLevelLoad > 4)
        {
            SceneManager.LoadScene("StartScene");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StartScene");
        }
    }

}