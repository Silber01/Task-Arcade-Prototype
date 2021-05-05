using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenCounter : MonoBehaviour
{
    [SerializeField] TokenSystem tokenSystem;
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        tokenSystem = FindObjectOfType<TokenSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
            text.text = "Tokens: " + tokenSystem.getTokens().ToString();
    }
}
