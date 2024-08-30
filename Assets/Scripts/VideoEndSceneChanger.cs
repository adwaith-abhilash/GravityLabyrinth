using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Scene name to load after the video ends
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
