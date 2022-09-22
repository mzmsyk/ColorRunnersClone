using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    #region Veriables
     public List<Transform> collactables = new List<Transform>();
    public PlayerMovementController playerMovementController;
    public SkinnedMeshRenderer playerSkinnedMesh;
    float nodeDistance = 1;
    private Sequence _sequence;
    #endregion
   
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        _sequence = DOTween.Sequence();
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
        
        //if (Input.GetMouseButtonDown(0))
        //{
        //    playerMovementController.forwardSpeed = 10;
        //    CollectableMovementControl(collactables, playerMovementController);
        //}
    }
    public void CollactableAdded(Transform other)
    {
        
        other.parent = transform;
        //other.gameObject.AddComponent<Rigidbody>(); //new Vector3(playerMovementController.SidewaysSpeed * playerMovementController.joystick.Horizontal, playerMovementController.rigidbody.position.y, playerMovementController.forwardSpeed);
        other.position = transform.position-new Vector3(0,0, nodeDistance);
        nodeDistance += 2f;
        collactables.Add(other);
        //other.GetComponent<CapsuleCollider>().isTrigger = false;
        StartCoroutine(CollectableObjectsBigger());
    }

    private IEnumerator CollectableObjectsBigger()
    {
        for (int i = collactables.Count-1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            collactables[index].transform.DOScale(scale, 0.5f).OnComplete(() =>
             collactables[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void CollactableRemove(Transform col)
    {

        collactables.RemoveAt(transform.childCount-3);
        transform.GetChild(transform.childCount -1).parent = null;
        //Destroy(transform.GetChild(transform.childCount).gameObject);
        //Destroy(col);
        collactables.TrimExcess();
        
    }
    public void HorizontalLimit(List<Transform> other)
    {

        for (int i = 0; i < collactables.Count; i++)
        {
            Mathf.Clamp(other[i].position.x, -4.5f, 4.5f);
        }


    }
    public void CollectableMovementControl(List<Transform> other,PlayerMovementController playerMovement)
    {
        for (int i = 1; i < other.Count; i++)
        {
            other[i].GetComponent<Rigidbody>().velocity = new Vector3(playerMovement.SidewaysSpeed * playerMovement.joystick.Horizontal,
                playerMovement.rigidbody.position.y, playerMovement.forwardSpeed);
        }
    }
}
