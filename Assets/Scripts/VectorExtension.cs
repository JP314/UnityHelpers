using UnityEngine;
using System.Collections;

public static class VectorExtension
{

	/// <summary>
	/// Returns a new instance of Vector2 where the X component is replaced
	/// </summary>
	public static Vector2 WithX(this Vector2 source, float x)
	{
		return new Vector2(x, source.y);
	}
	
	/// <summary>
	/// Returns a new instance of Vector2 where the Y component is replaced
	/// </summary>
	/// <returns></returns>
	public static Vector2 WithY(this Vector2 source, float y)
	{
		return new Vector2(source.x, y);
	}
	
	/// <summary>
	/// Returns a new instance of Vector3 where the X component is replaced
	/// </summary>
	public static Vector3 WithX(this Vector3 source, float x)
	{
		return new Vector3(x, source.y, source.z);
	}
	
	/// <summary>
	/// Returns a new instance of Vector3 where the Y component is replaced
	/// </summary>
	public static Vector3 WithY(this Vector3 source, float y)
	{
		return new Vector3(source.x, y, source.z);
	}
	
	/// <summary>
	/// Returns a new instance of Vector3 where the Z component is replaced
	/// </summary>
	public static Vector3 WithZ(this Vector3 source, float z)
	{
		return new Vector3(source.x, source.y, source.z);
	}

	/// <summary>
	/// Returns a new Vector3 instance where fore each component Mathf.Floor is called
	/// </summary>
	public static Vector3 Floor(this Vector3 source)
	{
		return new Vector3(Mathf.Floor(source.x), Mathf.Floor(source.y), Mathf.Floor(source.z));
	}
	
	/// <summary>
	/// Returns a new Vector3 instance where fore each component Mathf.Ceil is called
	/// </summary>
	public static Vector3 Ceil(this Vector3 source)
	{
		return new Vector3(Mathf.Ceil(source.x), Mathf.Ceil(source.y), Mathf.Ceil(source.z));
	}
	
	/// <summary>
	/// Returns a new Vector3 instance where fore each component Mathf.Round is called
	/// </summary>
	/// <returns></returns>
	public static Vector3 Round(this Vector3 source)
	{
		return new Vector3(Mathf.Round(source.x), Mathf.Round(source.y), Mathf.Round(source.z));
	}
	
	/// <summary>
	/// Converts a Vector3 to a Vector2: (x,y,z) -> (x,y)
	/// </summary>
	/// <returns></returns>
	public static Vector2 AsXY(this Vector3 source)
	{
		return new Vector2(source.x, source.y);
	}
	
	/// <summary>
	/// Converts a Vector3 to a Vector2: (x,y,z) -> (x,z)
	/// </summary>
	/// <returns></returns>
	public static Vector2 AsXZ(this Vector3 source)
	{
		return new Vector2(source.x, source.z);
	}
	
	/// <summary>
	/// Converts a Vector2 to a Vector3: (x,y) -> (x,y,0)
	/// </summary>
	/// <returns></returns>
	public static Vector3 AsXY0(this Vector2 source)
	{
		return new Vector3(source.x, source.y, 0);
	}
	
	/// <summary>
	/// Converts a Vector3 to a Vector2: (x,y) -> (x,0,y)
	/// </summary>
	/// <returns></returns>
	public static Vector3 AsX0Z(this Vector2 source)
	{
		return new Vector3(source.x, 0, source.y);
	}
	
	/// <summary>
	/// Returns a new Vector3 with specified magnitude
	/// </summary>
	public static Vector3 WithMagnitude(this Vector3 source, float magnitude)
	{
		var oldSqrMagnitude = source.sqrMagnitude;
		if (oldSqrMagnitude < float.Epsilon) {
			return Vector3.zero;
		}
		return source * magnitude * magnitude / oldSqrMagnitude;
	}
	
	/// <summary>
	/// Returns a new Vector3 where the magnitude is limited
	/// </summary>
	/// <returns></returns>
	public static Vector3 LimitMagnitude(this Vector3 source, float magnitude) {
		if (source.sqrMagnitude <= magnitude * magnitude) {
			return source;
		}
		return source.WithMagnitude(magnitude);
	}
	
	/// <summary>
	/// Returns a new Vector2 with specified magnitude
	/// </summary>
	public static Vector2 WithMagnitude(this Vector2 source, float magnitude)
	{
		var oldSqrMagnitude = source.sqrMagnitude;
		if (oldSqrMagnitude < float.Epsilon) {
			return Vector2.zero;
		}
		return source * magnitude * magnitude / oldSqrMagnitude;
	}
	
	/// <summary>
	/// Returns a new Vector2 where the magnitude is limited
	/// </summary>
	public static Vector2 LimitMagnitude(this Vector2 source, float magnitude) {
		if (source.sqrMagnitude <= magnitude * magnitude) {
			return source;
		}
		return source.WithMagnitude(magnitude);
	}
	
	/// <summary>
	/// Returns a rotated Vector2
	/// </summary>
	/// <returns></returns>
	public static Vector2 Rotate(this Vector2 source, float angle) {
		var cos = Mathf.Cos(angle * Mathf.Deg2Rad);
		var sin = Mathf.Sin(angle * Mathf.Deg2Rad);
		return new Vector2(source.x * cos - source.y * sin, source.x * sin + source.y * cos);
	}
	
}
