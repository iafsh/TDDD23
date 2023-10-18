using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] float paddingPerLine = 0f;

    private TextMesh textMesh;
    private Vector3 startTextMeshPosition;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        startTextMeshPosition = textMesh.transform.position;

        SetPadding();
    }

    private void SetPadding()
    {
        int len = textMesh.text.Split('\n').Length;

        if (len > 1) textMesh.transform.position = new Vector3(
            startTextMeshPosition.x,
            startTextMeshPosition.y + ((len - 1) * paddingPerLine),
            startTextMeshPosition.z
        );
    }

    public void ClearText()
    {
        textMesh.text = "";
    }

    public void SetText(string text)
    {
        textMesh.text = text;

        SetPadding();
    }

    public void SetText(string text, int seconds)
    {
        SetText(text);
        Invoke(nameof(ClearText), seconds);
    }
}
