using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDownPlane : MonoBehaviour
{
    public Transform transformQuadrado;

    public Camera cameraRenderToTexture; 

    private void OnMouseDown()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transformQuadrado.position = mousePos;

            //Bounds bounds = GetComponent<SpriteRenderer>().bounds;

            float newX = transform.position.x - mousePos.x;
            float newY = transform.position.y - mousePos.y;

            //recuperando máscara
            transformQuadrado.GetChild(0).localPosition = new Vector2(newX, newY);
            updateSprite();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            updateSprite();
        }
    }

    private void updateSprite()
    {
        Sprite renderSprite = cameraRenderToTexture.GetComponent<CameraRenderToTexture>().UpdateSpriteTexture();
        transformQuadrado.GetChild(0).GetComponent<SpriteUpdate>().UpdateSpriteMask(renderSprite);
    }

}
