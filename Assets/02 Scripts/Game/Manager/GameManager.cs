using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ���� ���� ����
/// </summary>
public enum GameState
{
    Nothing = 0,
    Ready,
    Play,
    Pause,
    RoundEnd,
    GameOver
}

public class GameManager : GenericSingleton<GameManager>
{
    [HideInInspector]
    public GameState GameState
    {
        get
        {
            return m_GameState;
        }
        set
        {
            switch (value)
            {
                case GameState.Ready:
                    break;
                case GameState.Play:
                    break;
                case GameState.Pause:
                    break;
                case GameState.RoundEnd:
                    break;
                case GameState.GameOver:
                    break;
            }
        }
    }
    
    [SerializeField] private GameObject m_SpawnManagerObject;                                     // ���� �Ŵ��� ������Ʈ
    [SerializeField] private GameObject m_GameUiManagerObject;                                    // ���� UI �Ŵ��� ������Ʈ

    // �Ŵ���
    private PlayerSpawnManager m_PlayerSpawnManager;                                              // �÷��̾� ���� ����
    private EnemySpawnManager m_EnemySpawnManager;                                                // �� ���� ����

    private GameState m_GameState;

    private int m_GameScore = 0;                                                                  // ���� ���ھ�
    private int m_GameRound = 1;                                                                  // ���� ����
    private float m_StartTime = 60.9f;

    private void Awake()
    {
        m_PlayerSpawnManager = m_SpawnManagerObject.GetComponent<PlayerSpawnManager>();
        m_EnemySpawnManager = m_SpawnManagerObject.GetComponent<EnemySpawnManager>();
    }

    private void Start()
    {

    }

    public void OnGameState(GameState state)
    {
        m_GameState = state;

        switch (state)
        {
            case GameState.Ready:
                break;
            case GameState.Play:
                break;
            case GameState.Pause:
                break;
            case GameState.RoundEnd:
                break;
            case GameState.GameOver:
                break;
        }
    }

    public void AddScore(int score)
    {
        m_GameScore += score;
    }

    private IEnumerator RoundTime(float maxTime)
    {
        while (maxTime > 0.0f)
        {
            maxTime -= Time.deltaTime;

            if (maxTime > 0.0f)
            {
            }
            else
            {
                m_GameRound += 1;
            }
            yield return null;
        }
    }
}
