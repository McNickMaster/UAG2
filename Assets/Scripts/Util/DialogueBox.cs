using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class DialogueBox : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI text;
    public float fadeDelay = 1;
    public float fadeSpeed = 0.5f;

    private float a_target = 1;
    private float a = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("StartFade", fadeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        a = Mathf.Lerp(a, a_target, fadeSpeed * Time.deltaTime);
        panel.color = new Color(0.3f, 0.3f, 0.3f, a);
        text.color = new Color(1,1,1,a);
    }

    void StartFade()
    {
        a_target = 0;
    }
}
