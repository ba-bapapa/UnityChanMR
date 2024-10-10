using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Weapon : MonoBehaviour
{
    public GameObject SwordHitEffect;
    public AudioClip SwordHitAudio;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Œ•‚Æ‚Ì“–‚½‚è”»’è
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(SwordHitEffect, collision.contacts[0].point, Quaternion.identity);
            audioSource.PlayOneShot(SwordHitAudio);
            Destroy(collision.gameObject);
        }
    }
}