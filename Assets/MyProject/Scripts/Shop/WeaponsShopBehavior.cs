using Assets.MyProject.Scripts.DataPersistence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsShopBehavior : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Text nameWeapon;
    [SerializeField] private Text characteristic;
    [SerializeField] private Image weaponImage;
    [SerializeField] private GameObject weaponBuyButton;
    [SerializeField] private GameObject weaponEquipButton;
    [SerializeField] private GameObject weaponUpgradeButton;
    [SerializeField] private WeaponInfo weaponInfo;

    private SerializableDictionary<string, int> weaponsBought;
    private SerializableDictionary<string, float> weaponsUpgrade;
    private void Start()
    {
        WeaponSelected(weaponInfo);
    }
    public void WeaponSelected(WeaponInfo weaponInfo)
    {
        this.weaponInfo = weaponInfo;
        weaponUpgradeButton.SetActive(false);
        weaponEquipButton.SetActive(false);
        weaponBuyButton.SetActive(true); 
        nameWeapon.text = weaponInfo.nameWeapon;
        weaponImage.sprite = weaponInfo.sprite;
        UpdateText();
        foreach (var item in weaponsBought)
        {
            if (weaponInfo.nameWeapon==item.Key)
            {
                weaponUpgradeButton.SetActive(true);
                weaponEquipButton.SetActive(true);
                weaponBuyButton.SetActive(false);
            }
        }
        
    }
    public void WeaponBuy()
    {
        if (Money.instance.TryRemove(weaponInfo.cost))
        {
            weaponUpgradeButton.SetActive(true);
            weaponEquipButton.SetActive(true);
            weaponBuyButton.SetActive(false);
            weaponsBought.Add(weaponInfo.name, 0);
            weaponsUpgrade.Add(weaponInfo.name, 0);
            weaponsUpgrade[weaponInfo.nameWeapon] = weaponInfo.damage;
            UpdateText();
        }
    }
    public void WeaponUpgrade()
    {
        if (Money.instance.TryRemove(weaponInfo.cost+1 / 10 * weaponsBought[weaponInfo.name]))
        {
            weaponsBought[weaponInfo.nameWeapon] += 1;
            weaponsUpgrade[weaponInfo.nameWeapon] += weaponsUpgrade[weaponInfo.nameWeapon] / 10;
            UpdateText();
        }
    }
    private void UpdateText()
    {
        if(weaponsBought.ContainsKey(weaponInfo.nameWeapon))
            characteristic.text = "Damage: " + weaponsUpgrade[weaponInfo.nameWeapon].ToString() + "\nAttack speed: " + weaponInfo.attackSpeed.ToString() + "\nCost: " + (weaponInfo.cost+1 / 10 * weaponsBought[weaponInfo.name]).ToString();
        else
            characteristic.text = "Damage: " + weaponInfo.damage.ToString() + "\nAttack speed: " + weaponInfo.attackSpeed.ToString() + "\nUpgrade Cost: " + weaponInfo.cost.ToString();
    }
    public void WeaponEquip()
    {
        PlayerPrefs.SetInt("GunIndex", weaponInfo.index);
    }

    public void LoadData(GameData data)
    {
        weaponsBought = data.weaponsBought;
        weaponsUpgrade = data.weaponsUpgrade;
    }

    public void SaveData(GameData data)
    {
        data.weaponsBought = weaponsBought;
        data.weaponsUpgrade = weaponsUpgrade;
    }
}