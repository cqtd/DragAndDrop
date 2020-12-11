using UnityEngine;
using UnityEngine.EventSystems;

namespace CQunity
{
	public abstract class DragSlotBase : MonoBehaviour, IDragSender
	{
		public PointerEventData.InputButton dragButton;

		protected virtual RectTransform CreateDragObject(PointerEventData eventData, Component parent)
		{
			RectTransform rect = Instantiate(gameObject, eventData.position, Quaternion.identity, parent.transform)
				.GetComponent<RectTransform>();

			rect.transform.localScale = Vector3.one;
			rect.anchorMin = Vector2.one * 0.5f;
			rect.anchorMax = Vector2.one * 0.5f;
			rect.sizeDelta = GetComponent<RectTransform>().sizeDelta;

			CanvasGroup canvasGroup = rect.gameObject.AddComponent<CanvasGroup>();
			canvasGroup.blocksRaycasts = false;
			canvasGroup.ignoreParentGroups = true;
			canvasGroup.interactable = false;

			return rect;
		}

		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == dragButton)
			{
				RectTransform dragging = CreateDragObject(eventData, RootCanvas.Instance.Root);
				DragEntity dragEntity = new DragEntity.ModelBuilder()
					.Source(GetComponent<RectTransform>())
					.Dragging(dragging)
					.Data(eventData)
					.Build();
				
				DragManager.BeginDrag(dragEntity, eventData);
			}
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == dragButton && DragManager.IsDragging)
			{
				DragManager.Drag(eventData);
			}
		}

		public virtual void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.button == dragButton && DragManager.IsDragging)
			{
				DragManager.EndDrag(eventData);
			}
		}
	}
}