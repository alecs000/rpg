using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsShopBehavior : MonoBehaviour
{
    [Tooltip("sword, hammer, piston, scythe, rifle")]
    [SerializeField] WeaponInfo[] weaponsInfo;
    [SerializeField] Text nameWeapon;
    [SerializeField] Text characteristic;
    [SerializeField] Image weaponImage;

    public void WeaponSelected(int weaponIndex)
    {
        nameWeapon.text = weaponsInfo[weaponIndex].nameWeapon;
        characteristic.text = "Damage: "+ weaponsInfo[weaponIndex].damage.ToString()+ "\nAttack speed: " + weaponsInfo[weaponIndex].attackSpeed.ToString();
        weaponImage.sprite = weaponsInfo[weaponIndex].sprite;
    }
}