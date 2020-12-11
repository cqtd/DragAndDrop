using UnityEngine;
using UnityEngine.EventSystems;

namespace CQunity
{
	public abstract class DropSlotBase : MonoBehaviour, IDropReceiver
	{
		public virtual bool CanDropDraggingObject(DragEntity entity, PointerEventData eventData)
		{
			return true;
		}

		public virtual void DropDraggingObject(DragEntity entity, PointerEventData eventData)
		{
			Debug.Log("Canceled");

			eventData.Use();
		}
	}
}