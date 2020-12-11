using UnityEngine.EventSystems;

namespace CQunity
{
	public interface IDragSender : IBeginDragHandler
		,IEndDragHandler
		,IDragHandler
	{
		
	}
}