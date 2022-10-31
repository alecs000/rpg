using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsShopBehavior : MonoBehaviour
{
    [SerializeField] Text nameWeapon;
    [SerializeField] Text characteristic;
    [SerializeField] Image weaponImage;
    
    private WeaponInfo weaponInfo;
    public void WeaponSelected(WeaponInfo weaponInfo)
    {
        this.weaponInfo = weaponInfo;
        nameWeapon.text = weaponInfo.nameWeapon;
        characteristic.text = "Damage: "+ weaponInfo.damage.ToString()+ "\nAttack speed: " + weaponInfo.attackSpeed.ToString();
        weaponImage.sprite = weaponInfo.sprite;
    }
    public void Equip()
    {
        PlayerPrefs.SetInt("GunIndex", weaponInfo.index);
    }
}