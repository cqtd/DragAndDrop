using UnityEngine;
using UnityEngine.EventSystems;

namespace CQunity
{
	public sealed class DragEntity
	{
		public readonly RectTransform sourceObject;
		public readonly RectTransform draggingObject;
		public readonly PointerEventData dataObject;

		private DragEntity(RectTransform source, RectTransform dragging, PointerEventData data)
		{
			sourceObject = source;
			draggingObject = dragging;
			dataObject = data;
		}

		public bool CanEndDrag {
			get
			{
				return draggingObject != null;
			}
		}

		public sealed class ModelBuilder
		{
			private RectTransform m_source;
			private RectTransform m_dragging;
			private PointerEventData m_data;
			
			public ModelBuilder Source(RectTransform rect)
			{
				this.m_source = rect;
				return this;
			}
			
			public ModelBuilder Dragging(RectTransform rect)
			{
				this.m_dragging = rect;
				return this;
			}
			
			public ModelBuilder Data(PointerEventData data)
			{
				this.m_data = data;
				return this;
			}

			public DragEntity Build()
			{
				return new DragEntity(m_source, m_dragging, m_data);
			}
		}
	}
}