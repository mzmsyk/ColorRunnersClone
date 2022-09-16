using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public List<Transform> collactables = new List<Transform>();
    public PlayerMovementController playerMovementController;
    float nodeDistance = 2;
    #region Singleton
    public static PlayerManager instance;
    private Sequence _sequence;
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
        
    }
    public void CollactableAdded(Transform other)
    {
        collactables.Add(other);
        other.parent = transform;
        other.position = transform.position-new Vector3(0,0, nodeDistance);
        nodeDistance += 1f;
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
   
    public void HorizontalLimit(List<Transform> other)
    {

        for (int i = 0; i < collactables.Count; i++)
        {
            Mathf.Clamp(other[i].position.x, -4.5f, 4.5f);
        }


    }
}
