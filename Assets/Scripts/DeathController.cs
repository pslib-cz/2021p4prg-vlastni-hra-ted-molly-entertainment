using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public PauseMenuController PauseMenu;
    public AudioSource dieSound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("DeathCheck"))
        {
            PauseMenu.PlayerDied();
            dieSound.Play();
        }
    }
}
