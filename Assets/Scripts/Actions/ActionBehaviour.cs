using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

public class ActionBehaviour : MonoBehaviour
{
	private ActionState state = ActionState.NotStarted;

	[Tooltip("Duration of this action in seconds")]
	public float duration = 1;

	[Tooltip("Start action when GameObject is loaded and script is attached")]
	public bool StartOnLoad = true;
	
	[Tooltip("Destroys this behaviour, if the action finished")]
	public bool DestroyIfFinished = true;
	
	public event System.Action<ActionBehaviour> Finished;
	
	/// <summary>
	/// Progress between 0 and 1 for Update()
	/// </summary>
	public float Progress { get; protected set; }
	
	/// <summary>
	/// Progress between 0 and 1 for FixedUpdate()
	/// </summary>
	public float ProgressFixed { get; protected set; }

	void OnValidate() {
		duration = Mathf.Max(duration, 0);
		if (!Application.isPlaying) {
			this.enabled = StartOnLoad;
		}
	}
	
	public virtual void OnEnable() {
		if (state == ActionState.NotStarted) {
			state = ActionState.Runnning;
			OnStartAction();
		}
	}
	
	public virtual void Update() {
		Progress = Mathf.Clamp01(Progress + Time.deltaTime / duration);
		if (Progress >= 1) Finish();
	}
	
	public virtual void FixedUpdate() {
		ProgressFixed = Mathf.Clamp01(Progress + Time.fixedDeltaTime / duration);
		if (Progress >= 1) Finish();
	}
	
	public virtual void OnStartAction() { }
	public virtual void OnFinishAction() { }
	
	private void Finish() {
		if (state == ActionState.Runnning) {
			state = ActionState.Finished;
			OnFinishAction();
			if (Finished != null) Finished(this);
			if (DestroyIfFinished) {
				Destroy(this);
			} else {
				this.enabled = false;
			}
		}
	}
	
	public void Reset() {
		Finish ();
		this.Progress = 0;
		this.ProgressFixed = 0;
		this.state = ActionState.NotStarted;
	}

	public T Then<T>(Action<T> init = null) 
		where T : ActionBehaviour
	{
		var component = gameObject.AddComponent<T>();
		component.StartOnLoad = false;
		this.Finished += (ActionBehaviour obj) => {
			component
			if (init != null) {
				init(component);
			}
		};
	}

	public ParallelBehaviour ThenParallel() {
		this.Finished += (ActionBehaviour obj) => {
			obj.gameObject.AddComponent<ParallelBehaviour>();
		};
	}

}
