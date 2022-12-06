using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization;
using UnityEngine.UI;

public class WeaponsShopBehavior : MonoBehaviour, IDataPersistence
{
    public string NameWeapon = "gh";
    public string Damage;
    public string AttackSpeed;
    public string Cost;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private GameObject _weaponBuyButton;
    [SerializeField] private GameObject _weaponEquipButton;
    [SerializeField] private GameObject _weaponUpgradeButton;
    [SerializeField] private WeaponInfo _weaponInfo;
    [SerializeField] private Text _nameText;
    [SerializeField] private AudioSource _weaponBuySound;
    [SerializeField] private AudioSource _weaponUpgradeSound;
    [SerializeField] private AudioSource _weaponEquipSound;
    [SerializeField] LocalizeStringEvent _damageEvent;
    [SerializeField] LocalizeStringEvent _attackSpeedEvent;
    [SerializeField] LocalizeStringEvent _costEvent;

    private SerializableDictionary<string, int> _weaponsBought;
    private SerializableDictionary<string, float> _weaponsUpgrade;
    private LocalizedString _damageText;
    private LocalizedString _attackSpeedText;
    private LocalizedString _costText;
    void OnEnable()
    {
        _damageText = _damageEvent.StringReference;
        _attackSpeedText = _attackSpeedEvent.StringReference;
        _costText = _costEvent.StringReference;
    }
    private void Start()
    {
        if (_weaponsBought != null)
        {
            if (!_weaponsBought.ContainsKey(_weaponInfo?.NameWeapon))
            {
                _weaponsBought.Add(_weaponInfo.NameWeapon, 1);
                _weaponsUpgrade.Add(_weaponInfo.NameWeapon, _weaponInfo.Damage);
            }
        }
        WeaponSelected(_weaponInfo);
    }
    public void WeaponSelected(WeaponInfo weaponInfo)
    {
        this._weaponInfo = weaponInfo;
        _weaponUpgradeButton.SetActive(false);
        _weaponEquipButton.SetActive(false);
        _weaponBuyButton.SetActive(true);
        _weaponImage.sprite = weaponInfo.Sprite;
        UpdateText();
        _weaponEquipSound.clip = _weaponInfo.EquipAudioSource;
        if (_weaponsBought != null&&_weaponsBought.ContainsKey(weaponInfo.NameWeapon))
        {
            _weaponUpgradeButton.SetActive(true);
            _weaponEquipButton.SetActive(true);
            _weaponBuyButton.SetActive(false);
        }

    }
    public void SetButtonText(Text text)
    {
        _nameText.text = text.text;
    }
    public void WeaponBuy()
    {
        if (Money.instance.TryRemove(_weaponInfo.Cost))
        {
            _weaponBuySound.Play();
            _weaponUpgradeButton.SetActive(true);
            _weaponEquipButton.SetActive(true);
            _weaponBuyButton.SetActive(false);
            _weaponsBought.Add(_weaponInfo.name, 0);
            _weaponsUpgrade.Add(_weaponInfo.name, 0);
            _weaponsUpgrade[_weaponInfo.NameWeapon] = _weaponInfo.Damage;
            UpdateText();
        }
    }
    public void WeaponUpgrade()
    {
        float cost = (_weaponInfo.Cost + 1f) / 10f * _weaponsBought[_weaponInfo.name];
        if (Money.instance.TryRemove((int)cost))
        {
            _weaponsBought[_weaponInfo.NameWeapon] += 1;
            _weaponsUpgrade[_weaponInfo.NameWeapon] += _weaponsUpgrade[_weaponInfo.NameWeapon] / 10;
            _weaponUpgradeSound.Play();
            UpdateText();
        }
    }
    private void UpdateText()
    {
        if (_weaponsBought != null&&_weaponsBought.ContainsKey(_weaponInfo.NameWeapon))
        {
            Damage = _weaponsUpgrade[_weaponInfo.NameWeapon].ToString();
            AttackSpeed = _weaponInfo.AttackSpeed.ToString();
            Cost = ((_weaponInfo.Cost + 1f) / 10f * _weaponsBought[_weaponInfo.name]).ToString();
        }
        else
        {
            Damage = _weaponInfo.Damage.ToString();
            AttackSpeed = _weaponInfo.AttackSpeed.ToString();
            Cost = _weaponInfo.Cost.ToString();
        }
        _damageText.RefreshString();
        _attackSpeedText.RefreshString();
        _costText.RefreshString();
    }
    public void WeaponEquip()
    {
        PlayerPrefs.SetInt("GunIndex", _weaponInfo.Index);
        _weaponEquipSound.Play();
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