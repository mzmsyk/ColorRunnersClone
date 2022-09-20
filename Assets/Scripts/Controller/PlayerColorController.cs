using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class PlayerColorController : MonoBehaviour
{
    public static PlayerColorController instance;
    public SkinnedMeshRenderer playerSkinnedMesh;
    public ColorEnums colorEnums;
    public bool isColorChange = true;
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
    void Start()
    {
        
    }

    
    void Update()
    {
        //switch (colorEnums)
        //{
        //    case ColorEnums.White:
        //        playerSkinnedMesh.material.color = Color.white;
        //        break;
        //    case ColorEnums.Red:
        //        playerSkinnedMesh.material.color = Color.red;
        //        break;
        //    case ColorEnums.Green:
        //        playerSkinnedMesh.material.color = Color.green;
        //        break;
        //    case ColorEnums.Blue:
        //        playerSkinnedMesh.material.color = Color.blue;
        //        break;
        //    case ColorEnums.Yellow:
        //        playerSkinnedMesh.material.color = Color.yellow;
        //        break;
        //    case ColorEnums.Orange:
        //        break;
        //    case ColorEnums.Purple:
        //        break;
        //    case ColorEnums.Rainbow:
        //        break;
        //    default:
        //        break;
        //}
    }
    public void ChangeColorState(ColorEnums colorEnums)
    {
        this.colorEnums = colorEnums;
    }


    public void ColorChange(Color Color)
    {

        playerSkinnedMesh.material.color = Color;
        isColorChange = false;
    }
}
