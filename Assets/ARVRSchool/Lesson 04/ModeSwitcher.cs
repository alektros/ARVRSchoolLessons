using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using Vuforia;

namespace Ru.Funreality.ARVRLessons.Lesson04
{
    public class ModeSwitcher : MonoBehaviour
    {
        [SerializeField] private Camera           _arCamera;
        [SerializeField] private Camera           _camera3D;
        [SerializeField] private Camera           _vrCamera;
        [SerializeField] private VuforiaBehaviour _vuforiaBehaviour;

        public void SwitchTo3D()
        {
            StartCoroutine(LoadDevice("None"));
            DisableCameras();
            _camera3D.gameObject.SetActive(true);
        }

        public void SwitchToAR()
        {
            DisableCameras();
            _arCamera.gameObject.SetActive(true);
            InitializeVuforia();
        }

        public void SwitchToVR()
        {
            DisableCameras();
            InitializeGVR();
            _vrCamera.gameObject.SetActive(true);
        }

        private void Awake()
        {
            SwitchTo3D();
        }

        private void DisableCameras()
        {
            _arCamera.gameObject.SetActive(false);
            _vrCamera.gameObject.SetActive(false);
            _camera3D.gameObject.SetActive(false);
        }

        private void InitializeVuforia()
        {
            StartCoroutine(InitVuforiaRoutine());
        }

        private void InitializeGVR()
        {
            StartCoroutine(LoadDevice("Cardboard"));
        }

        private IEnumerator LoadDevice(string newDevice)
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

            _vuforiaBehaviour.enabled = true;
        }
    }
}