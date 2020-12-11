using System;
using UnityEngine;
using UnityEngine.UI;

namespace CQunity
{
	public abstract class SlotUIBase : MonoBehaviour
	{
		[SerializeField] protected Image m_image = default;

		[NonSerialized] protected InventoryBase m_inventory = default;
		
		public int amount;
		public int index;

		public virtual InventoryBase Inventory {
			get
			{
				return m_inventory;
			}
		}


		protected virtual void Reset()
		{
			if (m_image == null && transform.childCount > 0)
			{
				m_image = transform.GetChild(0).GetComponent<Image>();
			}
		}
	}
	
	public abstract class SlotUIBase<T> : SlotUIBase where T : ItemBase
	{
		public override InventoryBase Inventory {
			get
			{
				return inventoryBase;
			}
		}

		public InventoryBase<T> inventoryBase;
		
		public T Current {
			get
			{
				return inventoryBase[index];
			}
		}
	}
}