using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.Collections;

namespace Fungus
{
	[CommandInfo("Animation", 
	             "Reset Anim Trigger", 
	             "Resets a trigger parameter on an Animator component.")]
	[AddComponentMenu("")]
	[ExecuteInEditMode]
	public class ResetAnimTrigger : Command
	{
		[Tooltip("Reference to an Animator component in a game object")]
		public AnimatorData _animator;

		[Tooltip("Name of the trigger Animator parameter that will be reset")]
		public StringData _parameterName;

		public override void OnEnter()
		{
			if (_animator.Value != null)
			{
				_animator.Value.ResetTrigger(_parameterName);
			}

			Continue();
		}

		public override string GetSummary()
		{
			if (_animator.Value == null)
			{
				return "Error: No animator selected";
			}

			return _animator.Value.name + " (" + _parameterName + ")";
		}

		public override Color GetButtonColor()
		{
			return new Color32(170, 204, 169, 255);
		}

		#region Backwards compatibility

		[HideInInspector] [FormerlySerializedAs("animator")] public Animator animatorOLD;
		[HideInInspector] [FormerlySerializedAs("parameterName")] public string parameterNameOLD;

		protected virtual void OnEnable()
		{
			if (animatorOLD != null)
			{
				_animator.Value = animatorOLD;
				animatorOLD = null;
			}

			if (parameterNameOLD != null)
			{
				_parameterName.Value = parameterNameOLD;
				parameterNameOLD = null;
			}
		}

		#endregion
	}

}