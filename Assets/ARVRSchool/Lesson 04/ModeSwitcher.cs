using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using Vuforia;

namespace Ru.Funreality.ARVRLessons.Lesson04
{
    public class ModeSwitcher : MonoBehaviour
    {
        [SerializeField] private Camera _arCamera;
        [SerializeField] private Camera _camera3D;
        [SerializeField] private Camera _vrCamera;
        [SerializeField] private Mode   _currentMode = Mode.D3;

        public enum Mode
        {
            AR,
            D3,
            VR
        }

        public void SetMode(Mode mode)
        {
            switch (mode)
            {
                case Mode.AR:
                    SwitchToAR();
                    break;
                case Mode.D3:
                    SwitchTo3D();
                    break;
                case Mode.VR:
                    SwitchToVR();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode", mode, null);
            }
        }

        public void SwitchTo3D()
        {
            StartCoroutine(LoadXRDevice("None"));
            DisableCameras();
            _camera3D.gameObject.SetActive(true);
            _currentMode = Mode.D3;
        }

        public void SwitchToAR()
        {
            StartCoroutine(LoadXRDevice("None"));
            DisableCameras();
            _arCamera.gameObject.SetActive(true);
            _currentMode = Mode.AR;
        }

        public void SwitchToVR()
        {
            DisableCameras();
            StartCoroutine(LoadXRDevice("Cardboard"));
            _vrCamera.gameObject.SetActive(true);
            _currentMode = Mode.VR;
        }

        private IEnumerator Start()
        {
            while (VuforiaRuntime.Instance.InitializationState != VuforiaRuntime.InitState.INITIALIZED)
            {
                Debug.Log(VuforiaRuntime.Instance.InitializationState);
                yield return new WaitForEndOfFrame();
            }

            SetMode(_currentMode);
        }

        private void DisableCameras()
        {
            _arCamera.gameObject.SetActive(false);
            _vrCamera.gameObject.SetActive(false);
            _camera3D.gameObject.SetActive(false);
        }

        private IEnumerator LoadXRDevice(string newDevice)
        {
            XRSettings.LoadDeviceByName(newDevice);
            yield return null;
            XRSettings.enabled = true;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (_currentMode == Mode.VR)
                {
                    Debug.Log("Exit from VR");
                    SetMode(Mode.D3);
                }
            }
        }
    }
}