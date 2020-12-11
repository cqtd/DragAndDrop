using UnityEngine.EventSystems;

namespace CQunity
{
	public interface IDropReceiver
	{
		bool CanDropDraggingObject(DragEntity entity, PointerEventData eventData);
		void DropDraggingObject(DragEntity entity, PointerEventData eventData);
	}
}