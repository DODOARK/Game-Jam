using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public bool open = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Robot")
        {
            open = true;
        }
    }

    private void FixedUpdate()
    {
        if (open) transform.position += new Vector3(0, 0.01f, 0);
    }
}
