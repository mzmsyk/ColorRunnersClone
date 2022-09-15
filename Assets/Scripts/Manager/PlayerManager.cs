using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public List<Transform> collactables = new List<Transform>();
    public PlayerMovementController playerMovementController;
    float nodedZ = 2;
    #region Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    void Start()
    {
        collactables.Add(transform);
    }


    void Update()
    {
        if (playerMovementController.joystick.Horizontal>0.1f|| playerMovementController.joystick.Horizontal < -0.1f)
        {
            MoveListCollectableLerp();
        }
        if (playerMovementController.joystick.Horizontal==0)
        {
            MoveCollectableOrigin();
        }
        
        
    }
    public void CollactableAdded(Transform other)
    {
        collactables.Add(other);
        other.parent = transform;
        other.position = transform.position-new Vector3(0,0,nodedZ);
        nodedZ+=1.5f;
        other.GetComponent<CapsuleCollider>().isTrigger = false;
    }
    public void MoveListCollectableLerp()
    {
        for (int i = 1; i < collactables.Count; i++)
        {
            Vector3 pos = collactables[i].transform.localPosition;
            pos.x = collactables[i - 1].transform.localPosition.x;
            collactables[i].transform.DOLocalMove(pos, 0.5f);
        }
    }
    public void MoveCollectableOrigin()
    {
        for (int i = 1; i < collactables.Count; i++)
        {
            Vector3 pos = collactables[i].transform.localPosition;
            pos.x = collactables[0].transform.localPosition.x;
            collactables[i].transform.DOLocalMove(pos, 0.01f);
            
        }
    }
}
