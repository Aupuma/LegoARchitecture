using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEditor;

public class UISlideTween : MonoBehaviour
{
    [HideInInspector]
    public Vector3 enterPosition, enterScale, targetPosition, targetScale, exitPosition, exitScale;
    [HideInInspector]
    public float enterWidth, enterHeight, targetWidth, targetHeight, exitWidth, exitHeight;

    public float enterDuration = 1;
    public float enterDelay = 0;
    public float exitDuration = 1;
    public float autoExitAfter = 0;

    void Awake()
    {
        DOTween.Init();
    }

    public void EnterTween()
    {
        StartCoroutine(EnterAnimation());
    }

    public void ExitTween()
    {
        transform.DOKill();
        transform.DORestart();
        transform.DOScale(exitScale, exitDuration);
        transform.DOLocalMove(exitPosition, exitDuration, false).SetEase(Ease.OutQuart).Play();
    }

    private IEnumerator EnterAnimation()
    {
        transform.SetAsLastSibling();
        transform.localPosition = enterPosition;
        transform.localScale = enterScale;

        transform.DOKill();
        transform.DORestart();

        yield return new WaitForSeconds(enterDelay);

        transform.DOScale(targetScale, enterDuration);
        transform.DOLocalMove(targetPosition, enterDuration, false).SetEase(Ease.OutQuart).Play();

        if (autoExitAfter > 0)
        {
            yield return new WaitForSeconds(autoExitAfter);
            ExitTween();
        }
    }
}

[CustomEditor(typeof(UISlideTween))]
public class SlideTweenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UISlideTween slideTween = (UISlideTween)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Set INITIAL State"))
        {
            Debug.Log(slideTween.transform.lossyScale);
            slideTween.enterPosition = slideTween.transform.localPosition;
            slideTween.enterWidth = slideTween.GetComponent<RectTransform>().rect.width;
            slideTween.enterHeight = slideTween.GetComponent<RectTransform>().rect.height;
            slideTween.enterScale = new Vector3(1, 1, 1);
        }

        if (GUILayout.Button("Set TARGET State"))
        {
            slideTween.targetPosition = slideTween.transform.localPosition;
            slideTween.targetWidth = slideTween.GetComponent<RectTransform>().rect.width / slideTween.enterWidth;
            slideTween.targetHeight = slideTween.GetComponent<RectTransform>().rect.height / slideTween.enterHeight;
            slideTween.targetScale = new Vector3(slideTween.targetWidth, slideTween.targetHeight, 1);
        }

        if (GUILayout.Button("Set FINAL State"))
        {
            slideTween.exitPosition = slideTween.transform.localPosition;
            slideTween.exitWidth = slideTween.GetComponent<RectTransform>().rect.width / slideTween.enterWidth;
            slideTween.exitHeight = slideTween.GetComponent<RectTransform>().rect.height / slideTween.enterHeight;
            slideTween.exitScale = new Vector3(slideTween.exitWidth, slideTween.exitHeight, 1);
        }

        GUILayout.EndHorizontal();
    }
}