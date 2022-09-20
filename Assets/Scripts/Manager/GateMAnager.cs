using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class GateMAnager : MonoBehaviour
{
    #region Veriables
    public ColorEnums colorEnums;
    public SpriteRenderer gateColor;
    #endregion




    public void ChangeColorState(ColorEnums colorEnums)
    {
        this.colorEnums = colorEnums;
    }
    #region ColorSwitchUpdate
    private void Update()
    {
        switch (colorEnums)
        {
            case ColorEnums.White:
                gateColor.color = Color.white;
                break;
            case ColorEnums.Red:
                gateColor.color = Color.red;
                break;
            case ColorEnums.Green:
                gateColor.color = Color.green;
                break;
            case ColorEnums.Blue:
                gateColor.color = Color.blue;
                break;
            case ColorEnums.Yellow:
                gateColor.color = Color.yellow;
                break;
            case ColorEnums.Orange:
                break;
            case ColorEnums.Purple:
                break;
            case ColorEnums.Rainbow:
                break;
            default:
                break;
        }
    }
    #endregion




    #region GateColorControls
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerColorController.instance.ColorChange(gateColor.color);
        }
    }
    #endregion

}
