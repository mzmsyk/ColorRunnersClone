using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CollectableMaterialsController : MonoBehaviour
{
    public ColorEnums colorEnums;

    public SkinnedMeshRenderer PlayerSkinnedRenderer;
    SkinnedMeshRenderer obj;
    public static CollectableMaterialsController instance;


    private void Start()
    {
         //ChangeColorState(ColorEnums.White);
        obj = GetComponent<SkinnedMeshRenderer>();
    }
    private void Update()
    {
        SwitchColor(colorEnums);
    }


    public void ChangeColorState(ColorEnums _colorEnums)
    {
        this.colorEnums = _colorEnums;
        SwitchColor(colorEnums);
    }
   public void SwitchColor(ColorEnums colorEnums)
    {
        switch (colorEnums)
        {
            case ColorEnums.White:
                obj.material.color =Color.white;
                break;
            case ColorEnums.Red:
                obj.material.color = Color.red;
                break;
            case ColorEnums.Green:
                obj.material.color = Color.green;
                break;
            case ColorEnums.Blue:
                obj.material.color = Color.blue;
                break;
            case ColorEnums.Yellow:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            case ColorEnums.Orange:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case ColorEnums.Purple:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
                break;
            case ColorEnums.Rainbow:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            default:
                break;
        }
    }
    public void CollectableMeshControl(Transform col)
    {
        
        if (PlayerSkinnedRenderer.material.color == obj.material.color)
        {
            PlayerManager.instance.CollactableAdded(col.transform);
            Debug.Log("girildi");
        }
        else
        {
            PlayerManager.instance.CollactableRemove(col.transform);
            Destroy(col.gameObject);
            Debug.Log("çýkýldý");
        }
    }
}
