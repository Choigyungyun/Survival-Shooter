using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameSettingProperty;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemyObjects;

    [Header("Enemy Spawn Transforms")]
    [SerializeField] private Transform[] enemySpawnTransforms;

    [Tooltip("Set the enemy's parent object.")]
    [SerializeField] private Transform enemyIndexTransform;

    private int m_MaxSpawnEnemy = 0;
    private float m_IntervalSpawnEnemy = 0.0f;
    private float m_Timer = 0.0f;

    private void Start()
    {
        InitializeSpawnEnemy();
    }

    private void Update()
    {
        if(GameManager.Instance.m_GameState != GameState.Play)
        {
            return;
        }
        m_Timer += Time.deltaTime;

        SpawnEnemy(SpawnEnemyProbability(UnityEngine.Random.Range(0, 100)));
    }

    private void InitializeSpawnEnemy()
    {
        m_MaxSpawnEnemy = 25;
        m_IntervalSpawnEnemy = 1.5f;

        Debug.Log($"Settings according to mode registration are now ready.\n" +
                  $"Game State : {GameManager.Instance.m_GameState}\n" +
                  $"Max Enemy Spawn : {m_MaxSpawnEnemy}\n" +
                  $"Enemy Spawn Interval : {m_IntervalSpawnEnemy}\n");
    }

    private void SpawnEnemy(int enemyTypeNumber)
    {
        if(m_Timer <= m_IntervalSpawnEnemy || enemyIndexTransform.childCount == m_MaxSpawnEnemy)
        {
            return;
        }
        GameObject enemyObject = Instantiate
                                 (
                                    enemyObjects[enemyTypeNumber],
                                    enemySpawnTransforms[GetRandomSpawn(enemySpawnTransforms)].position,
                                    enemySpawnTransforms[GetRandomSpawn(enemySpawnTransforms)].rotation
                                 );

        enemyObject.transform.parent = enemyIndexTransform;

        m_Timer = 0.0f;
    }

    private int SpawnEnemyProbability(int randomNumber)
    {
        if(randomNumber < 60)
        {
            return 0;
        }
        else if(randomNumber > 60 && randomNumber < 90)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private int GetRandomSpawn(Transform[] spawnerTransforms)
    {
        int spawner = spawnerTransforms.Length;
        return UnityEngine.Random.Range(0, spawner);
    }

    /// <summary>
    /// �������� ���׸� Ÿ������ �޾� ������ ������ ���� ��ȯ �մϴ�.
    /// </summary>
    /// <remarks>
    /// ���׸� Ÿ���� <typeparamref name="T"/>�� ���������θ� �����մϴ�.
    /// None, Nothing �� ���ʿ��� ��Ұ� �����ϱ� ������ ���� �ּ� ������
    /// 0�� �ƴ� 1���� �����մϴ�. �ִ� ������ �Է¹��� �������� �ִ� ���Դϴ�.
    /// </remarks>
    /// <typeparam name="T">Enum</typeparam>
    /// <returns>���� Enum ��</returns>
    private T RandomTypeEnum<T>() where T : Enum
    {
        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(UnityEngine.Random.Range(1, values.Length));
    }

}
