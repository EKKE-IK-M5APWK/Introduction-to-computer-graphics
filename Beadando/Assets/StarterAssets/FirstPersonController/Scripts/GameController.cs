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
    [SerializeField] private Color color;
    [SerializeField] private int points;
    [SerializeField] private int health;
    [SerializeField] private Transform colorSelector;
    [SerializeField] private Text healthText;
    [SerializeField] private Text pointText;
    private StarterAssetsInputs starterAssetsInputs;

    private void Start()
    {
        color = Color.white;
        health = 10;
        points = 0;

    }
    private void Awake()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    void Update()
    {
        Vector2 monitorCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(monitorCenter);
        Transform targetTransform = null;

        if (Physics.Raycast(ray, out RaycastHit target, Mathf.Infinity, targetColliderLayerMask))
        {
            testObjectTransform.position = target.point;
            position.text = string.Format("[X:{0},Y:{1},Z:{2}]", target.point.x, target.point.y, target.point.z);
            Debug.DrawLine(Camera.main.transform.position, target.point, Color.cyan, 0.5f);
            targetTransform = target.transform;
        }

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

        if (colorSelector != null)
        {
            if (starterAssetsInputs.red)
            {
                color = Color.red;
            }
            if (starterAssetsInputs.blue)
            {
                color = Color.blue;

            }
            if (starterAssetsInputs.green)
            {
                color = Color.green;

            }
            if (starterAssetsInputs.yellow)
            {
                color = Color.yellow;

            }
            colorSelector.GetComponent<ColorIndicator>().setColor(color);
        }
        else
        {
            Debug.LogWarning("Color Selector is null!");
        }
        if (starterAssetsInputs.shoot)
        {
            if (color == Color.white)
            {
                Debug.LogWarning("Please select a color!");
            }
            FindObjectOfType<AudioManager>().Play("pew");
            if (targetTransform != null)
            {
                Debug.Log("We hit something!");
                if (targetTransform.GetComponent<Target>() != null)
                {
                    Debug.Log("We hit the target!");
                    MeshRenderer targetColor = targetTransform.GetComponent<MeshRenderer>();
                    if (targetColor.material.color == color)
                    {
                        Debug.Log("Matching Colors! Plus 1 Point.");
                        points++;
                        pointText.GetComponent<Text>().text = string.Format("Points: {0}", health);
                        targetTransform.GetComponent<Target>().hitTarget();
                    }
                    else
                    {
                        Debug.Log("Unmatching Colors! Minus 1 health.");
                        health--;
                        healthText.GetComponent<Text>().text = string.Format("Health: {0}", health);
                        if (health <= 0)
                        {
                            Debug.Log("You Lose!");
                        }
                    }

                }
            }
            else
            {
                Debug.Log("No Target Found!");
            }
            starterAssetsInputs.shoot = false;
        }

    }
}
