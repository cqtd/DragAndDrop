using System;
using System.Linq;
using UnityEditorBuildSafe;
using UnityEngine;

namespace CQunity
{
	public abstract class ItemData : ScriptableObject, IEquatable<ItemData>
	{
		public long m_id = default;
		public Sprite m_thumbnail = default;

		protected virtual void Reset()
		{
			if (m_id == default)
			{
				GenerateID();

				SafeEditorUtility.SetDirty(this);
			} 
		}

		private void GenerateID()
		{
			ItemTable table = ItemTable.Get();
			if (table.datas.Contains(this))
			{
				return;
			}
			
			long newID = long.Parse($"{(DateTime.Now.Ticks / 10) % 1000000000:d9}");
			while (table.datas.Any(e => e.m_id == newID))
			{
				newID = long.Parse($"{(DateTime.Now.Ticks / 10) % 1000000000:d9}");
			}

			m_id = newID;
			table.datas.Add(this);
			
			SafeEditorUtility.SetDirty(this);
		}

		public bool Equals(ItemData other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return base.Equals(other) && m_id == other.m_id && Equals(m_thumbnail, other.m_thumbnail);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ItemData) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = base.GetHashCode();
				hashCode = (hashCode * 397) ^ m_id.GetHashCode();
				hashCode = (hashCode * 397) ^ (m_thumbnail != null ? m_thumbnail.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}