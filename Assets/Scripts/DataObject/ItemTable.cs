using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CQunity
{
	public class ItemTable : ScriptableObject
	{
		private const string PATH = "Assets/Resources/Table/ItemTable.asset";
		public static ItemTable Get()
		{
			ItemTable table;
#if UNITY_EDITOR
			string tableGUID = AssetDatabase.FindAssets("t:ItemTable").FirstOrDefault();
			if (string.IsNullOrEmpty(tableGUID))
			{
				table = CreateInstance<ItemTable>();
				AssetDatabase.CreateAsset(table, PATH);

				return table;
			}

			table = AssetDatabase.LoadAssetAtPath<ItemTable>(AssetDatabase.GUIDToAssetPath(tableGUID));
			return table;
#else
			table = Resources.Load<ItemTable>(PATH);
			return table;
#endif
		}

		public List<ItemData> datas;

		private void Reset()
		{
			datas = new List<ItemData>();
		}
	}
}