using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UfoStart : MonoBehaviour
{
    public GameObject ufo;
    public GameObject player;

    public GameObject pickitup;
    private void OnTriggerEnter(Collider other)
    {
        ufo.transform.position = new Vector3(player.transform.position.x, ufo.transform.position.y, player.transform.position.z);
        pickitup.SetActive(true);
        player.GetComponent<PlayerMovement>().movementSpeed = 0;
        StartCoroutine("gotoNextLevel");
    }

    private IEnumerator gotoNextLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Inside");
    }
}
