using System;
using UnityEngine;
using UnityEngine.UI;

namespace CQunity
{
	public class InventorySlotUI : SlotUIBase<WeaponItem>
	{
		// [SerializeField] protected Image m_image = default;
		// [SerializeField] protected Sprite m_item = default;
		//
		// private void Reset()
		// {
		// 	m_image = transform.GetChild(0).GetComponent<Image>();
		// }
		//
		// public void SetItem(Sprite sprite)
		// {
		// 	m_image.sprite = sprite;
		// 	m_image.enabled = sprite != null;
		// }
		//
		// private void Awake()
		// {
		// 	SetItem(m_item);
		// }
		//
		// public Sprite GetItem()
		// {
		// 	return m_image.sprite;
		// }
	}

}