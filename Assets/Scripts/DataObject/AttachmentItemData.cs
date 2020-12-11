using System;
using UnityEngine;

namespace CQunity
{
	[CreateAssetMenu(menuName = "Item/Attachmenet", fileName = "AttachmentItem", order = 301)]
	public class AttachmentItemData : ItemData
	{
		public Enums.ETuningSlot[] compatibleSlots = default;
	}
}