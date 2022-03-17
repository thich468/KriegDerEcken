using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public GameManager gameManager;
    int s = 0;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.clip = audioClips[0];
        audioSource.Play();
        StartCoroutine(waitAudio());

        
    }
    public IEnumerator waitAudio()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        updateMusic();
        print("end of sound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateMusic()
    {
        
            if (gameManager.GetWave() > 20)
            {
                audioSource.clip = audioClips[4];
                audioSource.Play();
                StartCoroutine(waitAudio());
                return;
            }
            if (gameManager.GetWave() > 15)
            {
                audioSource.clip = audioClips[3];
                audioSource.Play();
            StartCoroutine(waitAudio());
            return;
            }
            if (gameManager.GetWave() > 10)
            {
                audioSource.clip = audioClips[2];
                audioSource.Play();
            StartCoroutine(waitAudio());
            return;
            }
            if (gameManager.GetWave() > 5)
            {
            Debug.Log("Sound2");
            audioSource.clip = audioClips[1];
                audioSource.Play();
            StartCoroutine(waitAudio());
            return;
            } else
            {
            Debug.Log("Sound1");
                audioSource.Play();
                StartCoroutine(waitAudio());
        }
        
    }

    
}
