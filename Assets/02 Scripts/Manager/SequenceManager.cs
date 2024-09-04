using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalShooter
{
    public class SequenceManager : MonoBehaviour
    {
        [Header("Preload")]
        [Tooltip("������ ���� �ε��ų ������ �Դϴ�. ������ �Ӹ� �ƴ϶� ����, �ؽ���, ��Ÿ ��� ���� �����մϴ�.")]
        [SerializeField] private GameObject[] m_PreloadedAssets;

        [Space(10)]
        [SerializeField] private bool m_Debug;
    }
}
