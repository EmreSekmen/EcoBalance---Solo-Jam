using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource sfxSource;

    public AudioClip buttonClick;
    public AudioClip spawnClick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Play(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }



}
