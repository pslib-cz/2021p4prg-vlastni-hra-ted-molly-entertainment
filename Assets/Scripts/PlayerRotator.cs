using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    private SpriteRenderer _sr;
    public MovementController movementController;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        _sr.transform.Rotate((new Vector3(0, 0, -45) * Time.fixedDeltaTime) * (movementController.runSpeed / 2));
    }
}
