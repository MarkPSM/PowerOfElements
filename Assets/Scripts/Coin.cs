using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var playerObject = other.GetComponent<Player>();

            playerObject.AddCoin();

            Destroy(this.gameObject);
        }
    }
}
