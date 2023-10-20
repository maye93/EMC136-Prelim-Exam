using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int currentHealth;

    public GameObject enemyObject;
    private EnemyController enemyController;  // Corrected the variable name

    void Start()
    {
        enemyController = enemyObject.GetComponent<EnemyController>();

        if (enemyController == null)
        {
            Debug.LogError("EnemyController script not found on the enemyObject.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemyObject)
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        if (hearts.Length > 0)
        {
            // Hide or destroy the last heart
            int lastHeartIndex = hearts.Length - 1;
            Destroy(hearts[lastHeartIndex].gameObject);
            Array.Resize(ref hearts, lastHeartIndex);

            if (hearts.Length == 0)
            {
                StartCoroutine(PlayerDeath());
            }
            else
            {
                StartCoroutine(EnemyMovement());
            }
        }
    }

    IEnumerator EnemyMovement()
    {
        enemyController.StopMovement();

        yield return new WaitForSeconds(2f);

        enemyController.StartMovement();
    }

    IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(5);
    }
}