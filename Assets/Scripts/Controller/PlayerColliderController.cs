using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    public PlayerManager playerManager;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Collectable")
        {
            //CollactablePlayer(col.transform);
            //Debug.Log("girildi");
        }
    }
    public void CollactablePlayer(Transform col)
    {
        playerManager.CollactableAdded(col);
    }
}
