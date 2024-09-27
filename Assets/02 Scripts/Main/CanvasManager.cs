using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private const float c_CurrentFadeTime = 1.0f;

    protected GameObject m_PreviousPanel;
    protected Image m_CurrentFadeImage;

    protected void PanelControl(GameObject panel, bool isFade)
    {
        if (m_PreviousPanel == panel)
        {
            Debug.Log("���� �г� ȭ�� �Դϴ�.");
            return;
        }

        m_PreviousPanel = panel;

        if (isFade)
        {
            StartCoroutine(PanelChange(panel, m_PreviousPanel, c_CurrentFadeTime));
        }
        else
        {
            m_PreviousPanel.SetActive(false);
            panel.SetActive(true);
        }
    }

    /// <summary>
    /// �г��� �̹����� Fade In, Fade Out
    /// </summary>
    /// <param name="panelImage">Fade In/Out �� UnityEngine.UI�� Image</param>
    /// <param name="startAlpha">Image�� ���̵� �ʱ� ���� ��(min = 0.0f, max = 1.0f)</param>
    /// <param name="endAlpha">Image�� ���̵� ������ ���� ��(min = 0.0f, max = 1.0f)</param>
    /// <param name="waitTime">�ʱ� ������ ���� ���� ���� �ð�, ���� �ð��� ������ ���̵� ����</param>
    /// <returns></returns>
    protected IEnumerator PanelFadeControl(Image panelImage, float startAlpha, float endAlpha, float waitTime)
    {
        Color color = panelImage.color;
        color.a = startAlpha;
        panelImage.color = color;

        yield return new WaitForSeconds(waitTime);

        float timer = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            timer += Time.deltaTime;
            percent = timer / c_CurrentFadeTime;

            color.a = Mathf.Lerp(startAlpha, endAlpha, percent);

            panelImage.color = color;

            yield return null;
        }
    }

    /// <summary>
    /// �г� ��ȯ
    /// </summary>
    /// <param name="nextPanel">��ȯ�� ���� �г�</param>
    /// <param name="previousePanel">��ȯ�Ǳ� ���� �г�(���� �г�)</param>
    /// <param name="waitFadeTime">���̵� �����ϱ� ���� ���� �ð�</param>
    /// <returns></returns>
    protected IEnumerator PanelChange(GameObject nextPanel, GameObject previousePanel, float waitFadeTime)
    {
        StartCoroutine(PanelFadeControl(m_CurrentFadeImage, 0.0f, 1.0f, 0.0f));

        yield return new WaitForSeconds(c_CurrentFadeTime);

        previousePanel.SetActive(false);
        nextPanel.SetActive(true);

        StartCoroutine(PanelFadeControl(m_CurrentFadeImage, 1.0f, 0.0f, waitFadeTime));
    }
}
