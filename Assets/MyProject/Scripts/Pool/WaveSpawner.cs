using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour, IDataPersistence
{
    [SerializeField] private EnemySpawner[] _enemySpawners;
    [SerializeField] private Vector2 _spawnPositon;
    [SerializeField] private float _yDiviasion;
    [SerializeField] private GameObject ShopButton;
    private int _levelsAmount = 1;
    private bool _isSpawned;
    private bool _allDie;
    private int _enemyOnLevel;
    public void LoadData(GameData data)
    {
        data.LevelsAmount = _levelsAmount;
    }

    public void SaveData(GameData data)
    {
        _levelsAmount = data.LevelsAmount;
    }
    private void Start()
    {
        StartCoroutine(Waves());
    }
    private void Update()
    {
        if (_isSpawned && EnemyWatcher.EnemyAlive == 0)
        {
            StartCoroutine(EndWave());
        }
    }
    IEnumerator Waves()
    {
        int amountDifferentEnemies = _levelsAmount < _enemySpawners.Length ? _levelsAmount : _enemySpawners.Length;
        _enemyOnLevel = _levelsAmount + Random.Range(-_levelsAmount + 1, _levelsAmount + 1);
        for (int i = 0; i < _enemyOnLevel; i++)
        {
            SpawnDifferentEnemy(amountDifferentEnemies);
            yield return new WaitForSeconds(Random.Range(0, _enemyOnLevel > 5 ? 5 : _enemyOnLevel));
        }
        _levelsAmount++;
        _isSpawned = true;
    }
    private void SpawnDifferentEnemy(int amountDifferentEnemies)
    {
        for (int j = 0; j < amountDifferentEnemies; j++)
        {
            _enemySpawners[j].RandomSpawn(_spawnPositon, 0, _yDiviasion);
        }
    }
    IEnumerator EndWave()  
    {
        _isSpawned = false;
        ShopButton.SetActive(true);
        yield return new WaitForSeconds(5);
        ShopButton.SetActive(false);
        StartCoroutine(Waves());
    }
}
