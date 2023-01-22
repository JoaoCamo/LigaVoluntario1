using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAni;

    void OnTriggerEnter(Collider other)
    {
        doorAni.SetTrigger("open");
    }
}