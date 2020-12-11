using System;
using UnityEngine;

namespace CQunity
{
	public abstract class ItemBase : MonoBehaviour
	{
		public abstract void Initialize();
	}
	
	public abstract class ItemBase<T> : ItemBase where T : ItemData
	{
		public T m_itemData = default;
	}
}