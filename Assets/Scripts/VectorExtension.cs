using UnityEngine;
using System.Collections;

public static class VectorExtension {

	public static Vector2 WithX(this Vector2 source, float x) {
		return new Vector2(x, source.y);
	}
	
	public static Vector2 WithY(this Vector2 source, float y) {
		return new Vector2(source.x, y);
	}
	
	public static Vector3 WithX(this Vector3 source, float x) {
		return new Vector3(x, source.y, source.z);
	}
	
	public static Vector3 WithY(this Vector3 source, float y) {
		return new Vector3(source.x, y, source.z);
	}
	
	public static Vector3 WithZ(this Vector3 source, float z) {
		return new Vector3(source.x, source.y, source.z);
	}

	
	
}
