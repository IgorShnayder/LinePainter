using UnityEngine;
 
public class PaintingController : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private Camera _camera;
    
    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _trailRenderer.emitting = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _trailRenderer.emitting = false;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            _trailRenderer.Clear();
            _trailRenderer.emitting = true;
        }
        
        MovePainter();
    }

    private void MovePainter()
    {
        var mousePosition = Input.mousePosition;
        
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        mousePosition.x = Mathf.Clamp(mousePosition.x, 0f, screenWidth);
        mousePosition.y = Mathf.Clamp(mousePosition.y, 0f, screenHeight);
        
        Cursor.lockState = CursorLockMode.Confined;
        
        var position = _camera.ScreenToWorldPoint(mousePosition);
        gameObject.transform.position = new Vector3(position.x, position.y, 0);
    }
}
