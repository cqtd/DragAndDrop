using UnityEngine.Assertions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CQunity
{
	public class DragHandler
	{
		public virtual bool CanDrag(DragEntity entity, PointerEventData eventData)
		{
			return true;
		}

		public virtual bool CanEndDrag(DragEntity entity, List<IDropReceiver> receivers, PointerEventData eventData)
		{
			foreach (IDropReceiver receiver in receivers)
			{
				bool canDrop = receiver.CanDropDraggingObject(entity, eventData);
				if (canDrop)
				{
					return true;
				}
			}

			return false;
		}

		public virtual bool BeginDrag(DragEntity entity, PointerEventData eventData)
		{
			bool canDrag = CanDrag(entity, eventData);
			if (!canDrag)
			{
				return false;
			}

			if (entity.dataObject != null)
			{
				return true;
			}

			return false;
		}

		public virtual void Drag(DragEntity entity, PointerEventData eventData)
		{
			Canvas canvas = RootCanvas.Instance.Root;
			
			switch (canvas.renderMode)
			{
				case RenderMode.ScreenSpaceCamera:
				case RenderMode.WorldSpace:
					RectTransformUtility.ScreenPointToLocalPointInRectangle(
						canvas.GetComponent<RectTransform>(),
						eventData.position,
						canvas.worldCamera,
						out Vector2 pos);
				
					entity.draggingObject.position = canvas.transform.TransformPoint(pos);
					break;
				case RenderMode.ScreenSpaceOverlay:
					entity.draggingObject.position = eventData.position;
					break;
			}
		}

		public virtual bool EndDrag(DragEntity entity, PointerEventData eventData)
		{
			Assert.IsNotNull(entity.draggingObject);

			List<IDropReceiver> receivers = GetSections(eventData);
			if (receivers.Contains(entity.sourceObject.GetComponent<IDropReceiver>()))
			{
				return true;
			}

			foreach (IDropReceiver dropSection in receivers)
			{
				bool canDrop = dropSection.CanDropDraggingObject(entity, eventData);
				if (canDrop)
				{
					dropSection.DropDraggingObject(entity, eventData);
					return true;
				}
			}

			return false;
		}

		protected virtual List<IDropReceiver> GetSections(PointerEventData eventData)
		{
			List<IDropReceiver> list = new List<IDropReceiver>();

			List<GameObject> hovered = eventData.hovered;
			foreach (GameObject hover in hovered)
			{
				list.AddRange(hover.GetComponents<IDropReceiver>());
			}

			return list;
		}

		public virtual void Clear(DragEntity entity)
		{
			if (entity != null && entity.draggingObject != null)
			{
				Object.Destroy(entity.draggingObject.gameObject);
			}
		}
	}
}