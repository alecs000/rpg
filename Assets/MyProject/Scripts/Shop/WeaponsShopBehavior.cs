using UnityEngine;
using UnityEngine.UI;

public class WeaponsShopBehavior : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Text _nameWeapon;
    [SerializeField] private Text _characteristic;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private GameObject _weaponBuyButton;
    [SerializeField] private GameObject _weaponEquipButton;
    [SerializeField] private GameObject _weaponUpgradeButton;
    [SerializeField] private WeaponInfo _weaponInfo;

    private SerializableDictionary<string, int> _weaponsBought;
    private SerializableDictionary<string, float> _weaponsUpgrade;
    private void Start()
    {
        if (!_weaponsBought.ContainsKey(_weaponInfo.nameWeapon))
        {
            _weaponsBought.Add(_weaponInfo.nameWeapon, 1);
            _weaponsUpgrade.Add(_weaponInfo.nameWeapon, _weaponInfo.damage);
        }
        WeaponSelected(_weaponInfo);
    }
    public void WeaponSelected(WeaponInfo weaponInfo)
    {
        this._weaponInfo = weaponInfo;
        _weaponUpgradeButton.SetActive(false);
        _weaponEquipButton.SetActive(false);
        _weaponBuyButton.SetActive(true);
        _nameWeapon.text = weaponInfo.nameWeapon;
        _weaponImage.sprite = weaponInfo.sprite;
        UpdateText();

        if (_weaponsBought.ContainsKey(weaponInfo.nameWeapon))
        {
            _weaponUpgradeButton.SetActive(true);
            _weaponEquipButton.SetActive(true);
            _weaponBuyButton.SetActive(false);
        }

    }
    public void WeaponBuy()
    {
        if (Money.instance.TryRemove(_weaponInfo.cost))
        {
            _weaponUpgradeButton.SetActive(true);
            _weaponEquipButton.SetActive(true);
            _weaponBuyButton.SetActive(false);
            _weaponsBought.Add(_weaponInfo.name, 0);
            _weaponsUpgrade.Add(_weaponInfo.name, 0);
            _weaponsUpgrade[_weaponInfo.nameWeapon] = _weaponInfo.damage;
            UpdateText();
        }
    }
    public void WeaponUpgrade()
    {
        float cost = (_weaponInfo.cost + 1f) / 10f * _weaponsBought[_weaponInfo.name];
        if (Money.instance.TryRemove((int)cost))
        {
            _weaponsBought[_weaponInfo.nameWeapon] += 1;
            _weaponsUpgrade[_weaponInfo.nameWeapon] += _weaponsUpgrade[_weaponInfo.nameWeapon] / 10;
            UpdateText();
        }
    }
    private void UpdateText()
    {
        if (_weaponsBought.ContainsKey(_weaponInfo.nameWeapon))
            _characteristic.text = "Damage: " + _weaponsUpgrade[_weaponInfo.nameWeapon].ToString() + "\nAttack _speed: " + _weaponInfo.attackSpeed.ToString() + "\nUpgrade Cost: " + ((_weaponInfo.cost + 1f) / 10f * _weaponsBought[_weaponInfo.name]).ToString();
        else
            _characteristic.text = "Damage: " + _weaponInfo.damage.ToString() + "\nAttack _speed: " + _weaponInfo.attackSpeed.ToString() + "\nCost: " + _weaponInfo.cost.ToString();
    }
    public void WeaponEquip()
    {
        PlayerPrefs.SetInt("GunIndex", _weaponInfo.index);
    }

    public void LoadData(GameData data)
    {
        _weaponsBought = data.WeaponsBought;
        _weaponsUpgrade = data.WeaponsUpgrade;
    }

    public void SaveData(GameData data)
    {
        data.WeaponsBought = _weaponsBought;
        data.WeaponsUpgrade = _weaponsUpgrade;
    }
}