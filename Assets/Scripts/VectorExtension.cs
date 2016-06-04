using UnityEngine;
using System.Collections;

public static class VectorExtension
{

	public static Vector2 WithX(this Vector2 source, float x)
	{
		return new Vector2(x, source.y);
	}
	
	public static Vector2 WithY(this Vector2 source, float y)
	{
		return new Vector2(source.x, y);
	}
	
	public static Vector3 WithX(this Vector3 source, float x)
	{
		return new Vector3(x, source.y, source.z);
	}
	
	public static Vector3 WithY(this Vector3 source, float y)
	{
		return new Vector3(source.x, y, source.z);
	}
	
	public static Vector3 WithZ(this Vector3 source, float z)
	{
		return new Vector3(source.x, source.y, source.z);
	}

	public static Vector3 Floor(this Vector3 source)
	{
		return new Vector3(Mathf.Floor(source.x), Mathf.Floor(source.y), Mathf.Floor(source.z));
	}
	
	public static Vector3 Ceil(this Vector3 source)
	{
		return new Vector3(Mathf.Ceil(source.x), Mathf.Ceil(source.y), Mathf.Ceil(source.z));
	}
	
	public static Vector3 Round(this Vector3 source)
	{
		return new Vector3(Mathf.Round(source.x), Mathf.Round(source.y), Mathf.Round(source.z));
	}
	
	public static Vector2 AsXY(this Vector3 source)
	{
		return new Vector2(source.x, source.y);
	}
	
	public static Vector2 AsXZ(this Vector3 source)
	{
		return new Vector2(source.x, source.z);
	}
	
	public static Vector3 AsXY0(this Vector2 source)
	{
		return new Vector3(source.x, source.y, 0);
	}
	
	public static Vector3 AsX0Z(this Vector2 source)
	{
		return new Vector3(source.x, 0, source.y);
	}
	
	public static Vector3 WithMagnitude(this Vector3 source, float magnitude)
	{
		var oldSqrMagnitude = source.sqrMagnitude;
		if (oldSqrMagnitude < float.Epsilon) {
			return Vector3.zero;
		}
		return source * magnitude * magnitude / oldSqrMagnitude;
	}
	
	public static Vector3 LimitMagnitude(this Vector3 source, float magnitude) {
		if (source.sqrMagnitude <= magnitude * magnitude) {
			return source;
		}
		return source.WithMagnitude(magnitude);
	}
	
}
