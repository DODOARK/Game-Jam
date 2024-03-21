using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Punch : MonoBehaviour
{
    public Transform playerCamera;

    public GameObject robot;

    public float reach;
    public float strength;

    public float speed = 1;

    private int counter = 0;

    public bool move = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PunchAThing();
        }
    }

    void FixedUpdate()
    {
        if (move)
        {
            robot.transform.LookAt(playerCamera.transform.position);
            robot.transform.position += (playerCamera.transform.position - robot.transform.position) * speed;
            if (Vector3.Distance(playerCamera.transform.position, robot.transform.position) < 1)
            {
                move = false;
            }
        }
        else if (counter > 2 && Vector3.Distance(playerCamera.transform.position, robot.transform.position) > 1 && robot.GetComponent<Rigidbody>() == null)
        {
            move = true;
        }
    }

    private void PunchAThing()
    {
        RaycastHit hit;
        bool didIHit = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, reach);

        if (didIHit)
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.name == "Robot")
            {
                move = false;

                if (hitObject.GetComponent<Rigidbody>() == null)
                {
                    hitObject.AddComponent<Rigidbody>();
                }

                hitObject.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * strength, ForceMode.Impulse);
            }
            else if (hitObject.name == "MainField")
            {
                if (counter < 3)
                {
                    counter++;
                }
                else if (counter == 3)
                {
                    move = true;
                    counter++;
                }
            }
            else if (hitObject.name == "BodyDeezNuts")
            {
                SceneManager.LoadScene("End");
            }
        }
    }
}
