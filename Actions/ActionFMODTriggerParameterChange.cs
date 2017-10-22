/*
 *
 *	The Seven Tides
 *	by Duarte Garin, 06-2016
 *	
 *	"ActionFMODTriggerParameterChange.cs"
 * 
 *	Trigger a FMOD parameter change.
 * 
 */

using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

	[System.Serializable]
	public class ActionFMODTriggerParameterChange : Action
	{
		// Intensity of the emitter
		public float parameter_value;
		// Name of the parameter
		public string parameter_name;
		// Name of the Tag
		public string object_tag;
		// The game object that holds the emitter
		public GameObject emitter_object;
		// The FMOD emitter
		FMODUnity.StudioEventEmitter emitter;

		public void Awake(){

		}

		//Constructor defining the action
		public ActionFMODTriggerParameterChange ()
		{
			this.isDisplayed = true;
			category = ActionCategory.Custom;
			title = "FMOD: Trigger Parameter Change";
			description = "Triggers a FMOD Parameter Change.";
		}

		//Runs the action
		override public float Run ()
		{
			if (object_tag.Length != 0) {
				emitter_object = GameObject.FindWithTag (object_tag);
			}

			//Sets the intensity to the one configured in the action
			if (emitter_object) {
				emitter = emitter_object.GetComponent<FMODUnity.StudioEventEmitter> ();
				emitter.SetParameter (parameter_name, parameter_value);
			} else {
				UnityEngine.Debug.LogWarning ("ActionFMODTriggerParameterChange: No emitter with the " + object_tag + " tag was found in the scene"); 
			}
			//Wraps up the action
			return 0f;
		}


		#if UNITY_EDITOR

		override public void ShowGUI ()
		{
			//Widget to select the name of the parameter
			parameter_name = EditorGUILayout.TextField ("Parameter name:", parameter_name);
			//The tag that targets the correct Game Object
			object_tag = EditorGUILayout.TagField ("Tag:", object_tag);
			// Widget to select the intensity when action is triggered
			parameter_value = EditorGUILayout.FloatField ("Parameter value:", parameter_value);
		}	


		public override string SetLabel ()
		{
			// Return a string used to describe the specific action's job.
			string labelAdd = "";
			return labelAdd;
		}

		#endif

	}

}