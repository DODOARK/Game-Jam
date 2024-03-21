using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI text;

    public GameObject playerCam;
    public GameObject endCamera;

    public string lateText;
    public string onTimeText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            endCamera.SetActive(true);
            playerCam.SetActive(false);
            text.text = lateText;
        }
    }
}
