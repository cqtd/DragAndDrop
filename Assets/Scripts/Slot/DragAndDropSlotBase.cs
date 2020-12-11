using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CQunity
{
	public abstract class DragAndDropSlotBase : DragSlotBase, IDropReceiver
	{
		[SerializeField] protected bool bIsAvailable = default;

		protected virtual void Awake()
		{
			
		}
		
		public virtual bool CanDropDraggingObject(DragEntity entity, PointerEventData eventData)
		{
			return bIsAvailable;
		}

		public abstract void DropDraggingObject(DragEntity entity, PointerEventData eventData);
	}

	public abstract class DragAndDropSlotBase<T> : DragAndDropSlotBase where T : SlotUIBase
	{
		protected T m_slot;
		
		protected virtual bool HasSlot {
			get
			{
				return m_slot != null;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			
			m_slot = GetComponent<T>();
		}

		public override void DropDraggingObject(DragEntity entity, PointerEventData eventData)
		{
			if (HasSlot)
			{
				var source = entity.sourceObject.GetComponent<T>();
				var amount = source.amount;
				
				source.Inventory.Swap(source.index, m_slot.index, m_slot.Inventory, amount);


				// Sprite item = source.m_slot.GetItem();
				//
				// source.m_slot.SetItem(m_slot.GetItem());
				// m_slot.SetItem(item);
			}
		}
	}
}