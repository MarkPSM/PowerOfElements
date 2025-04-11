using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Coins")]
    public int collectedCoins;
    public TextMeshProUGUI coinText;

    [Header("Health")]
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

    }

    private void FixedUpdate()
    {
        HealthBar.value = Health;
    }

    public void AddCoin()
    {
        this.collectedCoins++;
        coinText.text = collectedCoins.ToString() + "/5";
    }
}
