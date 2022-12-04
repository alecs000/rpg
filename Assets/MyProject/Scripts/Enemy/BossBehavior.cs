using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public int MoneyOnLevel;

    [SerializeField] private GameObject _endMenu;
    public void EndDie()
    {
        PlayerPrefs.SetInt("MoneyInLastLevel", 0);
        MoneyOnLevel = Money.instance.GetMoneyOnLevel();
        _endMenu.SetActive(true);
    }
}
