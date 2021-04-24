using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.15f;
    [SerializeField] private float _canFire = -1;
    private float _laserOffset = 0.8f;
    void Start()
    {
        // On game start, set player position to (0,0,0)
        transform.position = Vector3.zero;
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _canFire)
        {
            Fire();
        }
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

    void Fire()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, _laserOffset, 0), Quaternion.identity);
    }
    
}

