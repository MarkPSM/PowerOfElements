using System.Collections;
using UnityEngine;

public class FireCooldown : MonoBehaviour
{
    public GameObject fireObject; // Referência ao objeto que será ativado/desativado
    public float timer;
    private bool activated = true;

    void Start()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        while (true)
        {
            fireObject.SetActive(activated); // Alterna entre ativo e inativo
            Debug.Log("Estado alterado: " + activated);
            activated = !activated;
            yield return new WaitForSeconds(timer);
        }
    }
}
