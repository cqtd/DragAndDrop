using UnityEngine;
using UnityEngine.UI;

public class DraggingSlot : MonoBehaviour
{
    public RectTransform m_rect = default;
    public Image m_image = default;

    void Update()
    {
        m_rect.anchoredPosition = Input.mousePosition;
    }
}