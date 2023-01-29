using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAni;
    public AudioSource source;
    public AudioClip doorOpeningClip;
    public bool opened = false;

    void OnTriggerEnter(Collider other)
    {
        if(!opened)
        {
            doorAni.SetTrigger("open");
            source.PlayOneShot(doorOpeningClip);
            opened = true;
        }
    }   
}