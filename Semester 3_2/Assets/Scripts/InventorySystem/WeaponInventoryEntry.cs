using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponInventoryEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private GameObject selectionVisuals;
    
    public Weapon weapon;
    
    public void Initialize(Weapon weapon)
    {
        selectionVisuals.SetActive(false);
        this.weapon = weapon;
        displayNameText.text = weapon.displayName;
    }

    public void SetSelected(bool isSelected)
    {
        selectionVisuals.SetActive(isSelected);
    }
}
