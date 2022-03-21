using UnityEngine;

public class Bullet : MonoBehaviour
{

    Vector3 velocity;

    float speed = 15;

    float gravity = 4f;
    float wind = 0f;

    BoxCollider collider;

    void Start()
    {

        collider = GetComponent<BoxCollider>();

    }

    void Update()
    {

        velocity += gravity * Vector3.down * Time.deltaTime;
        velocity += wind * transform.right * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;

        Collider[] colliders = Physics.OverlapBox(transform.position, collider.size / 4, transform.rotation, LayerMask.GetMask("hittable"));

        if (colliders.Length > 0)
        {

            IShotHit hitted = colliders[0].GetComponent<IShotHit>();
            if (hitted != null)
            {
                hitted.Hit(velocity.normalized);
            }

            Destroy(gameObject);

        }


    }

    public void SetDirection(Vector3 direction)
    {

        velocity = direction * speed;

    }

}
