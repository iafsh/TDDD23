using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] int levelNumber = -1;
    [SerializeField] GameObject openedDoor;
    [SerializeField] GameObject closedDoor;

    bool isInvoking = false;
    GameObject player;
    BoxCollider2D boxCollider2D;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider2D = GetComponent<BoxCollider2D>();

        PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 2));

        if (levelNumber == -1 || levelNumber <= PlayerPrefs.GetInt("UnlockedLevel", 1))
        {
            boxCollider2D.enabled = true;

            openedDoor.SetActive(true);
            closedDoor.SetActive(false);
        }
        else
        {
            boxCollider2D.enabled = false;

            openedDoor.SetActive(false);
            closedDoor.SetActive(true);
        }

        PlayerPrefs.Save();
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
                    Invoke(nameof(Teleport), 1);
                    player.GetComponent<Animator>().Play("opacity");
                }
            }
            else
            {
                isInvoking = false;
                CancelInvoke(nameof(Teleport));
                player.GetComponent<Animator>().Play("idle");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInvoking = false;
            CancelInvoke(nameof(Teleport));
            player.GetComponent<Animator>().Play("idle");
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
