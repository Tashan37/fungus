using UnityEngine;
using UnityEngine.Serialization;
using System;
using System.Collections;

namespace Fungus
{
	[CommandInfo("Animation", 
	             "Set Anim Float", 
	             "Sets a float parameter on an Animator component to control a Unity animation")]
	[AddComponentMenu("")]
	[ExecuteInEditMode]
	public class SetAnimFloat : Command
	{
		[Tooltip("Reference to an Animator component in a game object")]
		public AnimatorData _animator;

		[Tooltip("Name of the float Animator parameter that will have its value changed")]
		public StringData _parameterName;

		[Tooltip("The float value to set the parameter to")]
		public FloatData value;

		public override void OnEnter()
		{
			if (_animator.Value != null)
			{
				_animator.Value.SetFloat(_parameterName.Value, value.Value);
			}

			Continue();
		}

		public override string GetSummary()
		{
			if (_animator.Value == null)
			{
				return "Error: No animator selected";
			}

			return _animator.Value.name + " (" + _parameterName.Value + ")";
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