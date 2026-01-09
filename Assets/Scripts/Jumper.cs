using UnityEngine;

public class Jumper : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            transform.position = GetMouseWorldPosition();
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = -Camera.main.transform.position.z; // Set this to the distance from the camera to the object if needed
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        return mouseWorldPosition;
    }
}
