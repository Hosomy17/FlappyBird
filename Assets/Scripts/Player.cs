using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    //Customizar a quantidade de gravidade do bichinho que poderemos usar para mudar a dificuldade do xogo.
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update() 
    {
        // Inputs do jogo, podendo ser com espaço ou(||) mouse. 0 é o botão esquerdo.
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }
        
        /*Precisamos adicionar gravidade na direção, ela só funcionará quando adicionarmos o input dela e em
        todo frame precisamos adicionar gravidade, nesse caso só o Y importa */
         
 
        direction.y += gravity * Time.deltaTime;
        
        // agora que temos a direção só precisamos atualizar a posição do bird baseado no transform
        transform.position += direction * Time.deltaTime;
        //usamos deltatime duas vez pois gravidade é aceleração (m/s²)

    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
        
    }
        
}
