using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ParallelBehaviour : ActionBehaviour {

	public List<ActionBehaviour> behaviours;

	public override void OnStartAction ()
	{
		base.OnStartAction ();
		this.duration = behaviours.Max (action => action.duration);
	}

}
