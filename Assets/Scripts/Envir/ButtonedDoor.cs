using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonedDoor : MonoBehaviour
{
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closedDoor;
    [SerializeField] GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        OnButtonUnpress();
    }

    public void OnButtonPress() {
        openDoor.SetActive(true);
        closedDoor.SetActive(false);
    }

    public void OnButtonUnpress() {
        openDoor.SetActive(false);
        closedDoor.SetActive(true);
    }
}
