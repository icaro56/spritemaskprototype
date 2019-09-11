using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraRenderToTexture : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Material material;

    private Texture2D renderTexture2D;

    private Sprite renderTextureSprite;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 sizeSprite = spriteRenderer.sprite.textureRect.size;

        GetComponent<Camera>().orthographicSize = (sizeSprite.x / 100.0f) / 2.0f;
    }

    protected void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, material);
    }

    public Sprite UpdateSpriteTexture(/*RenderTexture renderTexture*/)
    {
        RenderTexture renderTexture = GetComponent<Camera>().targetTexture;

        convertToTexture2D(renderTexture);

        if (renderTextureSprite == null)
        {
            renderTextureSprite = Sprite.Create(renderTexture2D, new Rect(0, 0, renderTexture2D.width, renderTexture2D.height), new Vector2(0.5f, 0.5f));
            renderTextureSprite.name = "mascaraSprite";
        }

        return renderTextureSprite;
    }

    private Texture2D convertToTexture2D(RenderTexture rTex)
    {
        if (renderTexture2D == null)
        {
            renderTexture2D = new Texture2D(600, 600, TextureFormat.ARGB32, false);
        }
        
        RenderTexture.active = rTex;

        renderTexture2D.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        renderTexture2D.Apply();

        return renderTexture2D;
    }

}
