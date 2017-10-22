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
	public class ActionFMODPlay : Action
	{
		// Intensity of the emitter
		public float intensity;
		// Event Path
		public string eventPath;
		// Event Instance
		public FMOD.Studio.EventInstance backgroundMusic;

		//Constructor defining the action
		public ActionFMODPlay ()
		{
			this.isDisplayed = true;
			category = ActionCategory.Custom;
			title = "FMOD: Play Event";
			description = "Plays an FMOD Event.";
		}

		//Runs the action
		override public float Run ()
		{
			backgroundMusic = FMODUnity.RuntimeManager.CreateInstance (eventPath);
			backgroundMusic.start ();
			backgroundMusic.setParameterValue ("AT", 2);
			return 0f;
		}


		#if UNITY_EDITOR

		override public void ShowGUI ()
		{
			// Widget to select the scene game object that holds the emitter
			eventPath = EditorGUILayout.TextField ("Event Path", eventPath);
			// Widget to select the intensity when action is triggered
			intensity = EditorGUILayout.FloatField ("Intensity:", intensity);
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