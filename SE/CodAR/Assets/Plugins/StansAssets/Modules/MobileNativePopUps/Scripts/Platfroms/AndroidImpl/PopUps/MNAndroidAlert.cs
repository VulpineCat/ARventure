////////////////////////////////////////////////////////////////////////////////
//  
// @module Android Native Plugin for Unity3D 
// @author Osipov Stanislav (Stan's Assets) 
// @support stans.assets@gmail.com 
//
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class MNAndroidAlert : MonoBehaviour {

	private string title = string.Empty;
	private string message = string.Empty;
	private IEnumerable<string> actions;

	public Action<string> OnComplete = delegate {};
	
	//--------------------------------------
	// INITIALIZE
	//--------------------------------------
		
	public static MNAndroidAlert Create(string title, string message, IEnumerable<string> actions) {
		MNAndroidAlert dialog = new GameObject("AndroidPopUp").AddComponent<MNAndroidAlert>();
		dialog.title = title;
		dialog.message = message;
		dialog.actions = actions;
		
		return dialog;
	}	
	
	//--------------------------------------
	//  PUBLIC METHODS
	//--------------------------------------
	
	public void Show() {
		StringBuilder builder = new StringBuilder();
		IEnumerator<string> enumerator = actions.GetEnumerator ();
		if (enumerator.MoveNext ())
			builder.Append (enumerator.Current);

		while (enumerator.MoveNext()) {
			builder.Append ("|");
			builder.Append (enumerator.Current);
		}
		
		MNAndroidNative.showMessage(title, message, builder.ToString(), MNP_PlatformSettings.Instance.AndroidDialogTheme);
	}
	
	//--------------------------------------
	//  GET/SET
	//--------------------------------------
	
	//--------------------------------------
	//  EVENTS
	//--------------------------------------
	
	public void onPopUpCallBack(string result) {
		OnComplete(result);
		Destroy(gameObject);	
	}
	
	//--------------------------------------
	//  PRIVATE METHODS
	//--------------------------------------
	
	//--------------------------------------
	//  DESTROY
	//--------------------------------------


}
