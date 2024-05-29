using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBehaviour : MonoBehaviour
{
    public Image HealthBar;
    public Image StrengthBar;
    public TMP_Text percentageHealth;
    public TMP_Text percentageStrength;

    private float maxHealth = 100f;
    private float currentHealth;
    private float maxStrength = 100f;
    private float currentStrength;
    [SerializeField] GameObject canvas1;

    void Start()
    {
        Globals.Instance.currentHealth = maxHealth; // Initialize health to max at start.
        Globals.Instance.currentStrength = maxStrength; // Initialize strength to max at start.
        UpdateBars(); // Initial update for both bars.
    }

    void Update()
    {
        if (Globals.Instance.currentHealth == 0)
        {
            canvas1.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void TakeDamageHealth(float damage)
    {
        Globals.Instance.currentHealth = Mathf.Max(0, Globals.Instance.currentHealth - damage);
        Remove(Globals.Instance.currentHealth, maxHealth, HealthBar);
        UpdatePercentageText(percentageHealth, Globals.Instance.currentHealth);
    }

    private void AddHealth(float health)
    {
        Globals.Instance.currentHealth = Mathf.Min(maxHealth, Globals.Instance.currentHealth + health);
        Add(Globals.Instance.currentHealth, maxHealth, HealthBar);
        UpdatePercentageText(percentageHealth, Globals.Instance.currentHealth);
    }

    private void TakeDamageStrength(float damage)
    {
        Globals.Instance.currentStrength = Mathf.Max(0, Globals.Instance.currentStrength - damage);
        Remove(Globals.Instance.currentStrength, maxStrength, StrengthBar);
        UpdatePercentageText(percentageStrength, Globals.Instance.currentStrength);
    }

    private void AddStrength(float strength)
    {
        Globals.Instance.currentStrength = Mathf.Min(maxStrength, Globals.Instance.currentStrength + strength);
        Add(Globals.Instance.currentStrength, maxStrength, StrengthBar);
        UpdatePercentageText(percentageStrength, Globals.Instance.currentStrength);
    }

    private void Remove(float current, float max, Image bar)
    {
        float healthRatio = current / max;
        bar.transform.localScale = new Vector3(healthRatio, 1, 1);
        float fullWidth = 95f;
        float currentWidth = fullWidth * healthRatio;
        float offsetX = (fullWidth - currentWidth) / 2;
        bar.transform.localPosition = new Vector3(325 - offsetX, bar.transform.localPosition.y, bar.transform.localPosition.z);
    }

    private void Add(float current, float max, Image bar)
    {
        float healthRatio = current / max;
        bar.transform.localScale = new Vector3(healthRatio, 1, 1);
        float fullWidth = 95f;
        float currentWidth = fullWidth * healthRatio;
        float offsetX = (fullWidth - currentWidth) / 2;
        bar.transform.localPosition = new Vector3(325 - offsetX, bar.transform.localPosition.y, bar.transform.localPosition.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Zombie"))
        {
            if (Globals.Instance.currentStrength <= 100 && Globals.Instance.currentHealth > 0)//only removes strength/shield
            {

                if (Globals.Instance.currentHealth > 0)
                {
                    // Debug.Log(currentHealth);
                    TakeDamageStrength(50);
                    UpdatePercentageText(percentageStrength, Globals.Instance.currentStrength);
                }

            }
            if (Globals.Instance.currentStrength == 0)//else it removes 
            {
                UpdatePercentageText(percentageHealth, Globals.Instance.currentHealth);
                UpdatePercentageText(percentageStrength, 0);
                TakeDamageHealth(2);

            }
           // Destroy(collision.gameObject); // Destroy the zombie GameObject upon collision
        }

        else if (collision.gameObject.CompareTag("HealthPack"))
        {
            if (Globals.Instance.currentHealth < 100)
            {
                AddHealth(10);
                UpdatePercentageText(percentageHealth, Globals.Instance.currentHealth);
                Destroy(collision.gameObject); // Destroy the health pack GameObject upon collision
            }
            
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            if (Globals.Instance.currentStrength < 100)
            {
                AddStrength(10);
                UpdatePercentageText(percentageStrength, Globals.Instance.currentStrength);
                Destroy(collision.gameObject); // Destroy the shield GameObject upon collision
            }

        }
    }

    private void UpdatePercentageText(TMP_Text percentage, float current)
    {
        percentage.text = $"{current}%";
    }

    private void UpdateBars()
    {
        Add(Globals.Instance.currentHealth, maxHealth, HealthBar);
        Add(Globals.Instance.currentStrength, maxStrength, StrengthBar);
    }
}