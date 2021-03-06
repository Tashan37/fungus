﻿using UnityEngine;
using System;
using System.Collections;

namespace Fungus
{
	[CommandInfo("Animation", 
	             "Play Anim State", 
	             "Plays a state of an animator according to the state name")]
	[AddComponentMenu("")]
	public class PlayAnimState : Command 
	{
        [Tooltip("Reference to an Animator component in a game object")]
		public AnimatorData animator = new AnimatorData();

		[Tooltip("Name of the state you want to play")]
		public StringData stateName = new StringData();

        [Tooltip("Layer to play animation on")]
		public IntegerData layer = new IntegerData(-1);

        [Tooltip("Start time of animation")]
		public FloatData time = new FloatData(0f);

        public override void OnEnter()
		{
			if (animator.Value != null)
			{
                animator.Value.Play(stateName.Value, layer.Value, time.Value);
			}

			Continue();
		}

		public override string GetSummary()
		{
			if (animator.Value == null)
			{
				return "Error: No animator selected";
			}

            return animator.Value.name + " (" + stateName.Value + ")";
		}

		public override Color GetButtonColor()
		{
			return new Color32(170, 204, 169, 255);
		}
    }
    
}


