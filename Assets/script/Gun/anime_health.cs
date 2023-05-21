using UnityEngine;

public class anime_health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health = 100f;

    public void TakeDamage(float amountOfDamage)
    {
        health -= amountOfDamage;
        if(health <= 0f)
        {
            Destroy(gameObject);
        }
        
    }
}
