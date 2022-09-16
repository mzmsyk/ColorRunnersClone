using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableStackManager : MonoBehaviour
{
    private PlayerManager playerManager;
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveListCollectableLerp(playerManager.collactables);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            MoveCollectableOrigin(playerManager.collactables);
        }
        
    }

    public void MoveListCollectableLerp(List<Transform> collectables)
    {
        for (int i = 1; i < collectables.Count; i++)
        {
            int index = i;
            Vector3 pos = collectables[index].transform.localPosition;
            pos.x = collectables[index - 1].transform.localPosition.x;
            //Mathf.Clamp(collectables[index].localPosition.x, -2f, 2f);
            collectables[index].transform.DOLocalMove(pos, 0.25f);
            
        }
    }
    public void MoveCollectableOrigin(List<Transform> collectables)
    {
        for (int i = 1; i < collectables.Count; i++)
        {
            int index = i;
            Vector3 pos = collectables[index].transform.localPosition;
            pos.x = collectables[0].position.x;
            //Mathf.Clamp(collectables[index].localPosition.x, -2f, 2f);
            collectables[index].transform.DOLocalMove(pos, 0.7f);

        }
    }
}
