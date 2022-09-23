using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CollectableColliderController : MonoBehaviour
{
    #region Veriables
    public CollectableMaterialsController collectableMaterialsController;
    public CollectableManager collectableManager;
    public SpriteRenderer gateSpriteRenderer;
    public SkinnedMeshRenderer collectableSkinnedMesh;
    #endregion
    #region CollectableColorAndGateControls
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            //collectableMaterialsController.ChangeColorState(collectableMaterialsController.colorEnums);
            Debug.Log("color");
            collectableMaterialsController.CollectableMeshControl(this.transform);
            collectableManager.CollectableRunAnim();
        }
        if (col.gameObject.tag == "Gate")
        {
            collectableSkinnedMesh.material.color = gateSpriteRenderer.color;
        }
        if (col.gameObject.tag=="DroneArea")
        {
            collectableManager.ResetAllAnim();
            collectableManager.CollectableCrouchAnim();
        }
    }
    #endregion
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "DroneArea")
        {
            //collectableManager.ResetAllAnim();
            //collectableManager.CollectableRunAnim();
        }
    }

}
