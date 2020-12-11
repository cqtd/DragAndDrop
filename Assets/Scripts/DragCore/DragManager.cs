using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace CQunity
{
	public sealed class DragManager
	{
		public static DragEntity Current { get; protected set; }
		
#if DEVELOPMENT_BUILD || UNITY_EDITOR
		private static DragHandler handler { get; set; }
#else
		private static DragHandler handler;
#endif

		static DragManager()
		{
			handler = new DragHandler();
		}
		
		public static bool IsDragging {
			get
			{
				return Current != null;
			}
		}

		public static bool BeginDrag(DragEntity entity, PointerEventData eventData)
		{
			Clean();
			Current = entity;

			bool result = handler.BeginDrag(entity, eventData);
			
			return result;
		}

		public static void Drag(PointerEventData eventData)
		{
			Assert.IsNotNull(Current);
			
			handler.Drag(Current, eventData);
		}

		public static bool EndDrag(PointerEventData eventData)
		{
			Assert.IsNotNull(Current);

			bool result = handler.EndDrag(Current, eventData);
			
			Clean();
			return result;
		}

		public static void Clean()
		{
			handler.Clear(Current);
			Current = null;
		}
	}
}