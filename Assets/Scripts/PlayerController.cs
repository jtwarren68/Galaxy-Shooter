using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    //private Transform _myTransform;

    void Start()
    {
        // take the current position and assign start position to (o,0,0)
        transform.position = Vector3.zero;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0f) * (_speed * Time.deltaTime));
        
        // if y = 0 stop movement
        // if x = 11.7 then x = -11.7 and vice versa

        if (transform.position.y >= 3f)
        {
            transform.position = new Vector3(transform.position.x, 3f, 0f);
        }

        if (transform.position.y <= -1.95f)
        {
            transform.position = new Vector3(transform.position.x, -1.95f, 0f);
        }

        if (transform.position.x >= 11.27f)
        {
            transform.position = new Vector3(-11.27f, transform.position.y, 0f);
        }
        else if (transform.position.x <= -11.27f)
        {
            transform.position = new Vector3(11.27f, transform.position.y, 0f);
        }
    }
    
}
