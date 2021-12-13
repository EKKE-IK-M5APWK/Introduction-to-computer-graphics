using UnityEngine;
using Cinemachine;
using StarterAssets;


public class GameController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera zoomVirtualCamera;
    [SerializeField] private float baseSesnsitivity;
    [SerializeField] private float zoomSensitivity;
    private FirstPersonController firstPersonController;
    private StarterAssetsInputs starterAssetsInputs;


    private void Awake()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();

    }
    void Update()
    {
        if (starterAssetsInputs.zoom)
        {
            zoomVirtualCamera.gameObject.SetActive(true);
            firstPersonController.SetSensitivity(zoomSensitivity);
        }
        else
        {
            zoomVirtualCamera.gameObject.SetActive(false);
            firstPersonController.SetSensitivity(baseSesnsitivity);
        }
    }
}
