using System.Collections.Generic;
using UnityEngine;

namespace CQunity
{
	[CreateAssetMenu(menuName = "Item/Weapon", fileName = "WeaponItem", order = 300)]
	public class WeaponItemData : EquipmentItemDataBase
	{
		public string m_itemName = default;
		public List<Enums.ETuningSlot> m_availableSlot = default;
	}
}