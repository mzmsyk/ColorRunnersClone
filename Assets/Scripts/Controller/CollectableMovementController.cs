using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovementController : MonoBehaviour
{
    #region Veriables
    public bool isMoving = false;
    public float speed = 12;
    Rigidbody rigidbody;
    #endregion
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

   
    void FixedUpdate()
    {
        if (isMoving)
        {
            rigidbody.velocity = new Vector3(transform.localPosition.x, transform.localPosition.y, speed);
        }
    }
}
