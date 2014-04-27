using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public float fireRate = 0.5f;
    float cooldown = 0;

	// Update is called once per frame
	void Update () {

        cooldown -= Time.deltaTime;

        if(Input.GetButton("Fire1"))
        {
            Fire();
        }
	}

    void Fire()
    {
        if (cooldown > 0)
        {
            return;
        }

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Transform hitTransform;
        Vector3 hitPoint;

        hitTransform = FindClosestHitObject(ray, out hitPoint);

        if (hitTransform != null)
        {
            Debug.Log("Hit object: " + hitTransform.name);

            EnemyHealth objHealth = hitTransform.GetComponent<EnemyHealth>();
 
            while (objHealth == null || hitTransform.parent != null)
            {
                hitTransform = hitTransform.parent;
                objHealth = hitTransform.GetComponent<EnemyHealth>();
            }

            if (objHealth != null)
            {
                objHealth.TakeDamage(10);
            }
        }

        cooldown = fireRate;
    }

    Transform FindClosestHitObject(Ray ray, out Vector3 hitPoint)
    {
        RaycastHit[] hits = Physics.RaycastAll(ray);

        Transform closestHit = null;
        float distance = 0;
        hitPoint = Vector3.zero;

        foreach(RaycastHit hit in hits)
        {
            if (hit.transform != this.transform && (closestHit == null || hit.distance < distance))
            {
                closestHit = hit.transform;
                distance = hit.distance;
                hitPoint = hit.point;
            }
        }

        return closestHit;
    }
}
