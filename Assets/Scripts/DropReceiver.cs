using UnityEngine;
using UnityEngine.EventSystems;

namespace CQunity
{
	public class DropReceiver : MonoBehaviour, IDropReceiver
	{
		public bool CanDropDraggingObject(DragEntity entity, PointerEventData eventData)
		{
			return true;
		}

		public void DropDraggingObject(DragEntity entity, PointerEventData eventData)
		{
			Debug.Log("Canceled");

			eventData.Use();
		}
	}
}