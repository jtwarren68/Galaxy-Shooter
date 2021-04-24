using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Start()
    {
        // On game start, set player position to (0,0,0)
        transform.position = Vector3.zero;
    }

    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        
        transform.Translate(direction * (_speed * Time.deltaTime));
        
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-4.1f, 1.5f), 0f);

        if (transform.position.x >= 11.27f)
        {
            transform.position = new Vector3(-11.27f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.27f)
        {
            transform.position = new Vector3(11.27f, transform.position.y, 0);
        }
    }
    
}

