using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject droidItWork;
    [SerializeField] GameObject droidToPoint;

    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip startMusic;
    [SerializeField] AudioClip droidItWorkMusic;
    [SerializeField] AudioClip droidToPointMusic;

    [SerializeField] Canvas startScreen;
    [SerializeField] Canvas gameScreen;


    void Start()
    {
        startScreen.enabled = true;
        gameScreen.enabled = false;
        droidItWork.SetActive(false);
        droidToPoint.SetActive(false);
        audioPlayer.clip = startMusic;
        audioPlayer.Play();
    }
    public void DroidisWorkButton()
    {
        startScreen.enabled = false;
        gameScreen.enabled = true;
        droidItWork.SetActive(true);
        audioPlayer.clip = droidItWorkMusic;
        audioPlayer.Play();

    }
    public void DroidToPointButton()
    {
        startScreen.enabled = false;
        gameScreen.enabled = true;
        droidToPoint.SetActive(true);
        audioPlayer.clip = droidToPointMusic;
        audioPlayer.Play();
    }
    public void ExitButton()
    {
        startScreen.enabled = true;
        gameScreen.enabled = false;
        droidItWork.SetActive(false);
        droidToPoint.SetActive(false);
        audioPlayer.clip = startMusic;
        audioPlayer.Play();
    }
}
