using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    private float sensivity = 10f;
    public Animator pAni;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");

        float mouseY = Input.GetAxis("Mouse X") * sensivity;

        if(moveInput > 0 || moveInput < 0 || sideInput > 0 || sideInput < 0)
        {
            pAni.SetBool("moving", true);
        } else if(moveInput == 0 && sideInput == 0)
        {
            pAni.SetBool("moving", false);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * sideInput);

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + mouseY, 0);
    }

    public void resetPosition()
    {
        transform.position = GameObject.Find("PlayerSpawnPoint").transform.position;
    }
}
