using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
       
        if (GameManager.Instance.gameOver)
        {
            enabled = false;
            return;
        }

        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            direction += Vector3.forward;

 
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
            direction += Vector3.back;

      
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            direction += Vector3.right;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            direction += Vector3.left;

      
        transform.Translate(direction * panSpeed * Time.deltaTime, Space.World);


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000f * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
