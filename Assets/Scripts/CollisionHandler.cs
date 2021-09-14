using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float actionDelay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip win;

    AudioSource auso;

    bool isTransitioning = false;

    void Start() 
    {
        auso = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning) { return; }

        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Off we go!");
                break;
            case "Fuel":
                Debug.Log("This is useful!");
                break;
            case "Finish":
                NextLevel();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        PlayCrash();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", actionDelay);
    }

    void NextLevel()
    {
        PlayWin();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", actionDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void PlayCrash()
    {
        if(!isTransitioning)
        {
            auso.Stop();
            auso.PlayOneShot(crash);
        }
    }

    void PlayWin()
    {
        if(!isTransitioning)
        {
            auso.Stop();
            auso.PlayOneShot(win);
        }
    }
}
