using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("AI")]
    public Transform PlayerObject;
    public NavMeshAgent nav;
    public float distance;
    public GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, PlayerObject.position);

        PlayerMovement playerMovementScript = Player.GetComponent<PlayerMovement>();

        if (playerMovementScript != null)
        {
            if (playerMovementScript.crouching == true && distance <= 12)
            {
                nav.destination = PlayerObject.position;
            }
            else if (playerMovementScript.crouching == false && distance <= 20)
            {
                nav.destination = PlayerObject.position;
            }
        } 
    }
}
