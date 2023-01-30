using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    public Animator pAni;
    public Camera MainCamera;
    private Vector3 lookAt;
    private bool isMoving = false;

    public AudioSource source;
    public AudioClip stepSound;

    void Update()
    {
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        var camrot = MainCamera.transform.rotation;
        camrot.x = 0;
        camrot.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookAt) * camrot, 5 * Time.deltaTime);

        if(moveZ > 0 || moveZ < 0 || moveX > 0 || moveX < 0)
        {
            isMoving = true;
            pAni.SetBool("moving", true);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * moveZ);
            lookAt = new Vector3(moveX,0,moveZ);
        } else if(moveZ == 0 && moveX == 0)
        {
            isMoving = false;
            pAni.SetBool("moving", false);
        }
    }

    public void resetPosition()
    {
        transform.position = GameObject.Find("PlayerSpawnPoint").transform.position;
    }

    public void step()
    {
        if(isMoving)
        {
            source.PlayOneShot(stepSound);
        }
    }
}
