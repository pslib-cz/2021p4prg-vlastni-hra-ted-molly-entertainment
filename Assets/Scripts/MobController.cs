using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private Transform m_wallCheck;

    public PauseMenuController PauseMenu;
    public AudioSource mobKilledSound;

    private bool IsDead = false;

    void Update()
    {
        if (IsDead) return;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, 0.1f, 1 << LayerMask.NameToLayer("Enemy"));
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                colliders[i].gameObject.SetActive(false);
                mobKilledSound.Play();
                break;
            }
        }

        colliders = Physics2D.OverlapCircleAll(m_wallCheck.position, 0.1f, 1 << LayerMask.NameToLayer("Enemy"));
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                IsDead = true;
                PauseMenu.PlayerDied();
                Debug.Log("dying;");
                break;
            }
        }
    }


    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.gameObject.CompareTag("Enemy"))
    //    {
    //        if (gameObject.name == "GroundCheck")
    //        {
    //            collider.gameObject.SetActive(false);
    //            mobKilledSound.Play();
    //        }
    //        else
    //        {
    //            PauseMenu.PlayerDied();
    //        }
    //    }
    //}
}
