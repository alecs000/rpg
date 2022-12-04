using UnityEngine;

public abstract class MeleeWeapon : MonoBehaviour, IWeapon, IDataPersistence
{
    [SerializeField] private GameObject _gameObjectCollider;
    [SerializeField] private WeaponCollider _weaponCollider;
    [SerializeField] private JoystickForAttack _joystickForAttack;
    [SerializeField] private GameObject[] _animatorsWeapons;
    [SerializeField] private Animator _animatorBody;
    [SerializeField] private WeaponInfo _weaponInfo;
    private float _damage;

    public WeaponInfo WeaponInfo => _weaponInfo;
    public virtual void StartAttack()
    {
        _animatorBody.SetBool("IdleActive", false);
    }
    public virtual void Attack()
    {
        if (_joystickForAttack.VectorAttack == Vector2.zero)
            return;
        if (PlayerController.IsAttack)
            return;
        RotateCollider();
        WeaponAnimation();
        PlayerController.IsAttack = true;
    }
    public virtual void EndAttack()
    {
        foreach (var item in _weaponCollider.Alives)
        {
            item.GetComponent<IAlive>().GetDamage(_damage);
        }
        _animatorBody.SetInteger(_weaponInfo.animationName, 4);
        _animatorsWeapons[0].SetActive(false);
        _animatorsWeapons[1].SetActive(false);
        _animatorsWeapons[2].SetActive(false);
        _animatorsWeapons[3].SetActive(false);
    }
    private void WeaponAnimation()
    {
        if (_joystickForAttack.VectorAttack.y > 0.5)
        {
            AttackAnimation(0);
            return;
        }
        if (_joystickForAttack.VectorAttack.x > 0.5)
        {
            AttackAnimation(1);
            return;
        }
        if (_joystickForAttack.VectorAttack.y < -0.5)
        {
            AttackAnimation(2);
            return;
        }
        if (_joystickForAttack.VectorAttack.x < -0.5)
        {
            AttackAnimation(3);
            return;
        }
    }
    private void AttackAnimation(int direction)
    {
        _animatorsWeapons[direction].SetActive(true);
        _animatorBody.SetInteger(_weaponInfo.animationName, direction);
    }

    private void RotateCollider()
    {
        _gameObjectCollider.transform.rotation = Quaternion.Euler(0, 0, _joystickForAttack.GetAngle());
    }

    public void LoadData(GameData data)
    {
        if (data.WeaponsUpgrade.ContainsKey(_weaponInfo.name))
        {
            _damage = data.WeaponsUpgrade[_weaponInfo.name];
            _damage = _weaponInfo.damage;
        }
        else
        {
            _damage = _weaponInfo.damage;
        }
    }

    public void SaveData(GameData data)
    {

    }
}
