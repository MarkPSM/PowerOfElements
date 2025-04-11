using UnityEngine;

public class DestroyingEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Player scriptPlayer = player.GetComponent<Player>();
        Enemy scriptEnemy = enemy.GetComponent<Enemy>();

        if(collision.gameObject == player)
        {
            Destroy(enemy);
        }
    }
}
