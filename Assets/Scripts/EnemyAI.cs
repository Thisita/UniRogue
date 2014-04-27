using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    // Some configuration
    GameObject player;
    public float moveSpeed;
    public float minDistance;
    public float maxDistance;

    // Attacking config
    public GameObject gunFireFx;
    public Transform firePos;
    public float fireRate = 0.5f;
    float cooldown = 0;

    GameManager gameManager;

	// Use this for initialization
	void Start()
    {
        // log
        Debug.Log("EnemyAI::Start()");
        // Get the player
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update()
    {
        // Update attack cooldown
        cooldown -= Time.deltaTime;
        // Track the player via rotation
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        // should we chase?
        if (Vector3.Distance(transform.position, player.transform.position) >= minDistance)
        {
            // log
            //Debug.Log("EnemyAI::Update() [Chasing]");
            // chase
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // Can we attack?
            if (Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
            {
                // log
                //Debug.Log("EnemyAI::Update() [Attacking]");
                // attack
                Attack();
            }
        }
	}

    // Carries out an attack operation on the player
    void Attack()
    {
        // log
        //Debug.Log("EnemyAI::Attack()");
        if (cooldown > 0)
        {
            return;
        }

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Transform hitTransform;
        Vector3 hitPoint = player.transform.position;

        hitTransform = player.transform;

        if (hitTransform != null)
        {
            Debug.Log("Hit object: " + hitTransform.name);

            GunFireFx(firePos.position, hitPoint);

            PlayerHealth objHealth = hitTransform.GetComponent<PlayerHealth>();

            while (objHealth == null && hitTransform.parent != null)
            {
                hitTransform = hitTransform.parent;
                objHealth = hitTransform.GetComponent<PlayerHealth>();
            }

            if (objHealth != null)
            {
                objHealth.TakeDamage(10);
            }
        }
        else
        {
            hitPoint = firePos.position + (Camera.main.transform.forward * 100f);
            GunFireFx(firePos.position, hitPoint);
        }
        // reset the cool down
        cooldown = fireRate;
    }

    void GunFireFx(Vector3 startPos, Vector3 endPos)
    {
        GameObject fx = (GameObject)Instantiate(gunFireFx, startPos, Quaternion.LookRotation(endPos - startPos));
        LineRenderer line = fx.GetComponentInChildren<LineRenderer>();
        line.SetPosition(0, startPos);
        line.SetPosition(1, endPos);
    }
}
