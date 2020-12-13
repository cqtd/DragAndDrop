using UnityEngine;
using UnityEngine.Assertions;

public static class ComponentExtension
{
	/// <summary>
	/// Try to get component but add component when it failed.
	/// </summary>
	/// <param name="target"></param>
	/// <typeparam name="T">type of component</typeparam>
	/// <returns>Gotten component or added component</returns>
	public static T GetOrAddComponent<T>(this GameObject target) where T : Component
	{
		Assert.IsNotNull(target);
		
		T component = target.GetComponent<T>();
		if (component == null)
		{
			component = target.AddComponent<T>();
		}

		return component;
	}

	/// <summary>
	/// Try to get component but add component when it failed.
	/// </summary>
	/// <param name="target"></param>
	/// <typeparam name="T">type of component</typeparam>
	/// <returns>Gotten component or added component</returns>
	public static T GetOrAddComponent<T>(this Component target) where T : Component
	{
		Assert.IsNotNull(target);

		return target.gameObject.GetOrAddComponent<T>();
	}
}