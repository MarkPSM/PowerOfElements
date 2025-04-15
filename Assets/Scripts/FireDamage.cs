using System.Collections;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    [Header("Damage")]
    public int Damage = 20;
    public GameObject player;
    public GameObject PlayerObject;
    public GameObject Particles;
    public bool CanTakeDamage = true;
    private PlayerMovement playerMovement;


    [Header("Knockback")]
    public float KnockbackForce;

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
        if (collision.gameObject == PlayerObject && CanTakeDamage && Particles.activeSelf == true)
        {
            Player playerScript = PlayerObject.GetComponent<Player>(); // Pegando o script do Player

            if (playerScript != null)
            {
                playerScript.Health -= Damage; // Reduzindo a vida
                Debug.Log("Tocou. Vida restante: " + playerScript.Health);
                StartCoroutine(CoolDown());


                //Knockback
                Rigidbody rb = player.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    playerMovement = GetComponent<PlayerMovement>();
                    Vector3 knockbackDirection = (PlayerObject.transform.position - transform.position).normalized;
                    rb.AddForce(knockbackDirection * KnockbackForce, ForceMode.Impulse);
                    playerMovement.canMove = false;
                }
                else
                {
                    Debug.LogError("O script Player não foi encontrado no GameObject Player!");
                }
            }
            else
            {
                Debug.LogError("O script Player não foi encontrado no GameObject Player!");
            }
        }
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        CanTakeDamage = false;
        yield return new WaitForSeconds(2f);
        CanTakeDamage = true;
    }
}
