using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _meshBackground;

    [SerializeField]
    private float _speedBackground;
    
    [SerializeField]
    private MeshRenderer _meshGround;

    [SerializeField]
    private float _speedGround;

    public void StartParallax()
    {
        StopParallax();
        StartCoroutine(UpdateParallax());
    }
    
    public void StopParallax()
    {
        StopAllCoroutines();
    }

    private IEnumerator UpdateParallax()
    {
        while (true)
        {
            yield return null;
            _meshBackground.material.mainTextureOffset += new Vector2(_speedBackground * Time.deltaTime, 0);
            _meshGround.material.mainTextureOffset += new Vector2(_speedGround * Time.deltaTime, 0);
        }
    }
}
