using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera zoomVirtualCamera;
    [SerializeField] private float baseSesnsitivity;
    [SerializeField] private float zoomSensitivity;
    [SerializeField] private LayerMask targetColliderLayerMask = new LayerMask();
    [SerializeField] private Transform testObjectTransform;
    private FirstPersonController firstPersonController;
    [SerializeField] private Text position;
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

        Vector2 monitorCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Debug.Log(monitorCenter);
        Ray ray = Camera.main.ScreenPointToRay(monitorCenter);
        if (Physics.Raycast(ray, out RaycastHit target, Mathf.Infinity, targetColliderLayerMask))
        {
            testObjectTransform.position = target.point;
            position.text = string.Format("[X:{0},Y:{1},Z:{2}]", target.point.x, target.point.y, target.point.z);
            Debug.DrawLine(Camera.main.transform.position, target.point, Color.cyan, 0.5f);
        }


    }
}
