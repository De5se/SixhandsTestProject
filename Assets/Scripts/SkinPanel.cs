using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour
{
    [SerializeField] private Button changeShirt;
    [SerializeField] private Button changeBoots;
    [SerializeField] private Button changePants;
    
    public void SetButtons(SkinController skinController)
    {
        changeShirt.onClick.AddListener(()=>{
            skinController.ChangeShirt(1);
        });
        changeBoots.onClick.AddListener(()=>{
            skinController.ChangeBoots(1);
        });
        changePants.onClick.AddListener(()=>{
            skinController.ChangeTrousers(1);
        });
    }
}
