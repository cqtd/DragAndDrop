namespace CQunity
{
	public abstract class InventoryBase
	{
		public abstract void Swap(int from, int to, InventoryBase toInven, int amout);
		public abstract void Initialize();
	}
	
	public abstract class InventoryBase<T> : InventoryBase where T : ItemBase
	{
		public T[] elements;
		public T this[int index] {
			get
			{
				return elements[index];
			}
		}
	}

	public abstract class Inventory<T> : InventoryBase<T> where T : ItemBase
	{
		public override void Swap(int from, int to, InventoryBase toInven, int amout)
		{
			
		}
	}

	public class Inventory : Inventory<ItemBase>
	{
		public override void Initialize()
		{
			
		}
	}
}