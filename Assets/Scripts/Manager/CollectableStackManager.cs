using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectableStackManager : MonoBehaviour
{
    #region Veriables
    public PlayerManager playerManager;
    public Transform collect;
    #endregion

    #region Singleton
    public static CollectableStackManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    #endregion

    void Start()
    {
        StartCoroutine(OnPlayCollectableAdded());
    }

    
    void Update()
    {

        MoveListCollectableLerp(playerManager.collactables);
    }
    #region LerpMechanics
    public void MoveListCollectableLerp(List<Transform> collectables)
    {
        for (int i = 1; i < collectables.Count; i++)
        {
            int index = i;
            Vector3 pos = collectables[index].transform.localPosition;
            pos.x = collectables[index - 1].transform.position.x - collectables[index].transform.localPosition.x * 2;
            //Mathf.Clamp(collectables[index].localPosition.x, -2f, 2f);
            collectables[index].transform.DOLocalMove(pos, 0.25f);

        }
        //if (collectables.Count > 1)
        //{
        //for (int i = 1; i < collectables.Count; i++)
        //{
        //    var firstCollectable = collectables.ElementAt(i - 1);
        //    var sectCollectable = collectables.ElementAt(i);
        //    var desireDistance = Vector3.Distance(sectCollectable.position, firstCollectable.position);
        //    if (desireDistance <= 3)
        //    {
        //        sectCollectable.position = new Vector3(Mathf.Lerp(sectCollectable.position.x, firstCollectable.position.x, 10f * Time.deltaTime),
        //            sectCollectable.position.y,
        //           Mathf.Lerp(sectCollectable.position.z, firstCollectable.position.z+1, 10f * Time.deltaTime));
        //    }
        //}
        //}
    }
    #endregion

    #region LerpMechanicOrigin
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
    #endregion
    #region PlayButtonCollectablesCounts
    IEnumerator OnPlayCollectableAdded()
    {

        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject obj = Instantiate(collect.gameObject, transform.position + new Vector3(0, 0, i), transform.rotation);
            playerManager.CollactableAdded(obj.transform);
            obj.GetComponent<CollectableManager>().CollectableRunAnim();
            yield return new WaitForSeconds(0.1f);
        }
    }
    #endregion

}
