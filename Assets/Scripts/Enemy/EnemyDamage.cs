using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Damage")]
    public int Damage = 25;
    public GameObject PlayerObject;
    private bool CanTakeDamage = true;


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
            if (collision.gameObject == PlayerObject && CanTakeDamage)
            {
                Player playerScript = PlayerObject.GetComponent<Player>(); // Pegando o script do Player

                if (playerScript != null)
                {
                    playerScript.Health -= Damage; // Reduzindo a vida
                    Debug.Log("Tocou. Vida restante: " + playerScript.Health);
                    StartCoroutine(CoolDown());
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
