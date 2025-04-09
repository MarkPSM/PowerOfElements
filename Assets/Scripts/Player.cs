using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int collectedCoins;
    public TextMeshProUGUI coinText;

    public float Health;
    public Slider HealthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinText.text = collectedCoins.ToString() + "/5";

        Health = HealthBar.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Debug.Log("AAAAAA");
        }
    }

    public void AddCoin()
    {
        this.collectedCoins++;
        coinText.text = collectedCoins.ToString() + "/5";
    }
}
