using TMPro.EditorUtilities;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    void Update()
    {
        Vector3 direction = new Vector3(transform.position.x, transform.position.y, 0);

        transform.Translate(Vector3.up * (_speed * Time.deltaTime));

        if (transform.position.y >= 8f)
        {
            Destroy(this.gameObject);
        }

    }
}
