using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    Renderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _propBlock = new MaterialPropertyBlock();


    }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
            );
    }

    private MaterialPropertyBlock _propBlock;

    void Update()
    {
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor("Color", GetRandomColor());
        _renderer.SetPropertyBlock(_propBlock);
    }
}
