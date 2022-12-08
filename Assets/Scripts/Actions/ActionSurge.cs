using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSurge : FreeAction
{
	public override void Use()
	{
		sourceCreature.IsActionSurging = true;
		sourceCreature.HasActionSurge = false;
	}


}
