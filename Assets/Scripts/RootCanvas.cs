using UnityEngine;

namespace CQunity
{
	[RequireComponent(typeof(Canvas))]
	public class RootCanvas : MonoBehaviour
	{
		private Canvas canvas;
		
		private static RootCanvas rootCanvas;

		public static RootCanvas Instance {
			get
			{
				if (rootCanvas == null)
				{
					rootCanvas = FindObjectOfType<RootCanvas>();
					rootCanvas.canvas = rootCanvas.GetComponent<Canvas>();
				}

				return rootCanvas;
			}
		}

		public Canvas Root {
			get
			{
				return canvas;
			}
		}
	}
}