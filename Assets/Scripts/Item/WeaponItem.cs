using System;

namespace CQunity
{
	public class WeaponItem : EquipmenetItemBase<WeaponItemData>, IOwner
	{
		[NonSerialized] public WeaponTuneInventory m_attachments = default;
		
		protected virtual void Awake()
		{
			Initialize();
		}


		public override void Initialize()
		{
			m_attachments = new WeaponTuneInventory(this);
			m_attachments.Initialize();
		}
	}
}