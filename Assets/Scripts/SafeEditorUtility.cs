using System.Diagnostics;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEditorBuildSafe
{
	public static class SafeEditorUtility
	{
		[Conditional("UNITY_EDITOR")]
		public static void SetDirty(Object target)
		{
			EditorUtility.SetDirty(target);
		}
	}
}