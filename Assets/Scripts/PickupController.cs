using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int _score = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Pickup"))
        {
            _score++;
            ScoreText.SetText(_score.ToString());
            collider.gameObject.SetActive(false);
            //GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
            //if (pickups.Length == 0)
            //{
            //    SceneManager.LoadScene("SecondLevel");
            //}
        }
    }
}
