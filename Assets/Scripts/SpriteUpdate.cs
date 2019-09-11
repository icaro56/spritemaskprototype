using UnityEngine;
using UnityEngine.UI;

public class SpriteUpdate : MonoBehaviour
{
    //public RenderTexture renderTexture;

    private SpriteMask spriteMask;

    // Start is called before the first frame update
    void Start()
    {
        spriteMask = GetComponent<SpriteMask>();
    }

    public void UpdateSpriteMask(Sprite sprite)
    {
        spriteMask.sprite = sprite;

        //GetComponent<SpriteRenderer>().sprite = sprite;
    }
    
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UpdateSpriteTexture();
        }
    }
    */
    /*private Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(600, 600, TextureFormat.ARGB32, false);

        RenderTexture.active = rTex;

        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();

        return tex;
    }*/
}
