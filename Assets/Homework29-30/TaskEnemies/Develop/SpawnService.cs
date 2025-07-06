using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnService : MonoBehaviour
{
    [Header("Enemies Prefabs")]
    [SerializeField] private List<Enemy> _enemiesPrefabs;

    [Header("Enemies Settings")]
    [SerializeField] private List<DragonSettings> _dragonSettings;
    [SerializeField] private List<MageSettings> _mageSettings;
    [SerializeField] private List<OrkSettings> _orkSettings;

    private Dictionary<TypeOfEnemy, Enemy> _enemiesDictionary = new();

    private void Awake()
    {
        FillEnemiesDictionary();

        foreach(TypeOfEnemy typeOfEnemy in Enum.GetValues(typeof(TypeOfEnemy)).Cast<TypeOfEnemy>())
        {
            PlaceEnemiesByType(typeOfEnemy);
        }
    }

    private void FillEnemiesDictionary()
    {
        foreach (Enemy enemy in _enemiesPrefabs)
            _enemiesDictionary.Add(enemy.TypeOfEnemy, enemy);
    }

    private void PlaceEnemiesByType(TypeOfEnemy type)
    {
        Vector3 startPosition = Vector3.zero;
        switch(type)
        {
            case TypeOfEnemy.Mage:
                startPosition.x = -3;

                SpawnEnemiesBySettings(startPosition, TypeOfEnemy.Mage, _mageSettings);
                break;

            case TypeOfEnemy.Ork:
                startPosition.x = 0;

                SpawnEnemiesBySettings(startPosition, TypeOfEnemy.Ork, _orkSettings);
                break;

            case TypeOfEnemy.Dragon:
                startPosition.x = 3;

                SpawnEnemiesBySettings(startPosition, TypeOfEnemy.Dragon, _dragonSettings);
                break;
        }
    }

    private void SpawnEnemiesBySettings<T>(Vector3 startPosition, TypeOfEnemy enemyType, List<T> enemySettings) where T : IEnemySettings
    {
        foreach (T enemySetting in enemySettings)
        {
            startPosition.z -= 2;

            Enemy enemy = Instantiate(_enemiesDictionary[enemyType], startPosition, Quaternion.identity);

            switch (enemyType)
            {
                case TypeOfEnemy.Ork:

                    Ork ork = (Ork) enemy;

                    ork.Initialize(enemySetting.Health, enemySetting.Speed, (enemySetting as OrkSettings).Strength);
                    break;

                case TypeOfEnemy.Dragon:

                    Dragon dragon = (Dragon)enemy;

                    dragon.Initialize(enemySetting.Health, enemySetting.Speed, (enemySetting as DragonSettings).FireDamage);
                    break;

                case TypeOfEnemy.Mage:

                    Mage mage = (Mage) enemy;

                    mage.Initialize(enemySetting.Health, enemySetting.Speed, (enemySetting as MageSettings).Mana, (enemySetting as MageSettings).Range);
                    break;
            }
        }
    }
}
