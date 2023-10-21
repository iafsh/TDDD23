using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] string sceneName;

    bool isInvoking = false;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Get the bounds of the player and the door
            Bounds playerBounds = collision.bounds;
            Bounds doorBounds = GetComponent<Collider2D>().bounds;

            // Check if the player is completely within the bounds of the door
            if (doorBounds.Contains(playerBounds.min) && doorBounds.Contains(playerBounds.max))
            {
                if (!isInvoking)
                {
                    isInvoking = true;
                    Invoke(nameof(Teleport), 2);
                }
            }
            else
            {
                isInvoking = false;
                CancelInvoke(nameof(Teleport));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInvoking = false;
            CancelInvoke(nameof(Teleport));
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Teleport()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<Animator>().Play("teleport");

        Invoke(nameof(LoadScene), 0.25f);
    }
}
