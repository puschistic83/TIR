using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rectTransform;
    private Vector2 startPos;
    private Vector2 startScale;
    private bool isHovered = false;
    readonly float hoverOffsetX = 50;
    readonly float hoverScaleIncrement = 0.3f;
    readonly float animationTime = 0.5f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
        startScale = rectTransform.localScale;
    }

    private void OnEnable()
    {
        isHovered = false;
        rectTransform.anchoredPosition = startPos;
        rectTransform.localScale = startScale;
    }

    private void Update()
    {
        if (isHovered)
        {
            // ������� �������� ������ ��� ���������
            Vector2 targetPos = startPos + new Vector2(hoverOffsetX, 0);
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPos, Time.unscaledDeltaTime / animationTime);

            // ������� ���������� ������� ��� ���������
            Vector2 targetScale = startScale + new Vector2(hoverScaleIncrement, hoverScaleIncrement);
            rectTransform.localScale = Vector2.Lerp(rectTransform.localScale, targetScale, Time.unscaledDeltaTime / animationTime);        
        }
        else
        {
            // ������� ����������� � ������������ ���������
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, startPos, Time.unscaledDeltaTime / animationTime);
            rectTransform.localScale = Vector2.Lerp(rectTransform.localScale, startScale, Time.unscaledDeltaTime / animationTime);
        }
    }

    // ���������� ������� ��������� � ����� ������� ����������� �� ������ ����
    public void OnPointerEnter(PointerEventData eventData) => isHovered = true;
    public void OnPointerExit(PointerEventData eventData) => isHovered = false;
}
