using UnityEngine;

namespace CQunity
{
	[RequireComponent(typeof(Canvas))]
	public class InventoryCanvas : MonoBehaviour
	{
		public KeyCode m_key = KeyCode.Tab;
		private Canvas m_canvas = default;

		private void Awake()
		{
			m_canvas = GetComponent<Canvas>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(m_key))
			{
				m_canvas.enabled = !m_canvas.enabled;
			}
		}
	}
}