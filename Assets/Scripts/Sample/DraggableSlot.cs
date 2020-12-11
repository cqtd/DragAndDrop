using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler
{
    public Image image;
    public Sprite myItem;
    
    public class DragContext
    {
        public Sprite item;
        public DraggableSlot begin;
    }

    private static DragContext context;
    private static DraggingSlot dragging;

    private void OnEnable()
    {
        if (myItem != null)
        {
            image.sprite = myItem;
        }
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (myItem == null)
        {
            return;
        }

        context = new DragContext()
        {
            item = myItem,
            begin = this,
        };

        if (dragging == null)
        {
            dragging = Instantiate(Resources.Load<DraggingSlot>("Dragging Slot"), transform.parent.parent);
            
            dragging.m_image.sprite = myItem;
            var c = dragging.m_image.color;
            c.a = 0.5f;
            dragging.m_image.color = c;
            dragging.m_rect.sizeDelta = image.GetComponent<RectTransform>().sizeDelta;
        }
        else
        {
            dragging.m_image.sprite = myItem;
            dragging.m_rect.sizeDelta = image.GetComponent<RectTransform>().sizeDelta;
            var c = dragging.m_image.color;
            c.a = 0.5f;
            dragging.m_image.color = c;
            
            dragging.gameObject.SetActive(true);
        }
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (context != null)
        {
            Sprite temp = context.begin.myItem;
            context.begin.myItem = myItem;
            myItem = temp;
            
            dragging.gameObject.SetActive(false);
            
            context.begin.OnItemChange();
            OnItemChange();
        }
    }
    
    public void OnItemChange()
    {
        image.sprite = myItem;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}