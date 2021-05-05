using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenButton : MonoBehaviour
{
    [SerializeField] TokenSystem tokenSystem;
    private void Awake()
    {
        tokenSystem = FindObjectOfType<TokenSystem>();
    }
    public void AddTenTokens()
    {
        tokenSystem.changeTokenAmountBy(10);
    }
}
