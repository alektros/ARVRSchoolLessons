using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Vuforia;

public class ModeSwitcher : MonoBehaviour
{

	public Camera ARCamera;

	public VuforiaBehaviour _VuforiaBehaviour;
	
	public Camera Camera3D;

	public Camera VRCamera;
	
	public void SwitchTo3D()
	{
		StartCoroutine(LoadDevice("None"));
		DisableCameras();
		Camera3D.gameObject.SetActive(true);
		
	}

	public void SwitchToAR()
	{
		DisableCameras();
		ARCamera.gameObject.SetActive(true);
		InitializeVuforia();
	}


	public void SwitchToVR()
	{
		DisableCameras();
		InitializeGVR();
		VRCamera.gameObject.SetActive(true);
	}

	private void Awake()
	{
		
		SwitchTo3D();
	}

	private void DisableCameras()
	{
		ARCamera.gameObject.SetActive(false);
		VRCamera.gameObject.SetActive(false);
		Camera3D.gameObject.SetActive(false);
	}


	private void InitializeVuforia()
	{
		StartCoroutine(InitVuforiaRoutine());
	}


	private void InitializeGVR()
	{
		StartCoroutine(LoadDevice("Cardboard"));


	}
	
	IEnumerator LoadDevice(string newDevice)
	{
		XRSettings.LoadDeviceByName(newDevice);
		yield return null;
		XRSettings.enabled = true;
	}

	private IEnumerator InitVuforiaRoutine()
	{
		VuforiaRuntime.Instance.InitVuforia();
		while (VuforiaRuntime.Instance.InitializationState != VuforiaRuntime.InitState.INITIALIZED)
		{
			Debug.Log(VuforiaRuntime.Instance.InitializationState);
			yield return new WaitForEndOfFrame();
		}

		_VuforiaBehaviour.enabled = true;
	}
	
}
