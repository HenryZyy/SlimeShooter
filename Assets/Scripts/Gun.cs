using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletPrefab;

    FirstPersonCamera MainCamera;

    Transform Pistol;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            // ShootRaycast();
            ShootBullet();
        }

    }

    private void Awake()
    { MainCamera = transform.parent.GetComponent<FirstPersonCamera>();
        Pistol = transform.Find("Pistol");
    }

    void ShootBullet()
    {

        Transform bulletObj = Instantiate(bulletPrefab, Pistol.position, Pistol.rotation);
        Destroy(bulletObj.gameObject, 10f);

        RaycastHit hitInfo;
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.GetForwardDirection(), out hitInfo, Mathf.Infinity, LayerMask.GetMask("hittable")))
        {

            bulletObj.GetComponent<Bullet>().SetDirection((hitInfo.point - Pistol.position).normalized);

        }
        else
        {
            bulletObj.GetComponent<Bullet>().SetDirection(MainCamera.GetForwardDirection());
        }

    }
    void ShootRaycast()
    {

        RaycastHit hitInfo;
        if (Physics.Raycast(MainCamera.transform.position, MainCamera.GetForwardDirection(), out hitInfo, Mathf.Infinity, LayerMask.GetMask("hittable")))
        {

            IShotHit hitted = hitInfo.transform.GetComponent<IShotHit>();
            if (hitted != null)
            {

                hitted.Hit(MainCamera.GetForwardDirection());

            }
        }


    }
}


    



