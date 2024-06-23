using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    float reloadDelay = 1f;
    [SerializeField]
    ParticleSystem crashEffect;
    [SerializeField]
    AudioClip crashAudio;
    AudioSource AudioSource;
    bool isCrashed;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        isCrashed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !isCrashed)
        {
            isCrashed = true;
            Debug.Log("You are dead");
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            AudioSource.PlayOneShot(crashAudio);
            Invoke("ReloadScene", reloadDelay);
        }
        
    }
    void ReloadScene()
    {
        FindObjectOfType<PlayerController>().EnableControls();
        isCrashed = false;
        SceneManager.LoadScene(0);
    }

}
