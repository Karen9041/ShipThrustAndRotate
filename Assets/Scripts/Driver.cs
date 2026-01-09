using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //drives the game object based on keyboard input
    const float MoveUnitsPerSecond = 10f;
    

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput != 0)
        {
            Vector3 position = transform.position;
            //transform.Translate(Vector3.right * horizontalInput * MoveUnitsPerSecond * Time.deltaTime);
            position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;
            transform.position = position;
        }
        if(verticalInput != 0)
        {
            Vector3 position = transform.position;
            //transform.Translate(Vector3.up * verticalInput * MoveUnitsPerSecond * Time.deltaTime);
            position.y += verticalInput * MoveUnitsPerSecond * Time.deltaTime;
            transform.position = position;
        }
    }
}
