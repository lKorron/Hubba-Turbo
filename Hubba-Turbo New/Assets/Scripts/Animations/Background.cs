using UnityEngine;

public class Background : MonoBehaviour
{

    private void Start()
    {
        ResizeSpriteToScreen();
    }

    private void ResizeSpriteToScreen()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            return;

        float width = spriteRenderer.sprite.bounds.size.x;
        float height = spriteRenderer.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float deltaY = 0.01f;
        float screenX = worldScreenWidth / width;
        float screenY = (worldScreenHeight / height) + deltaY;

        Vector3 screenScale = new Vector3(screenX, screenY, 0);

        transform.localScale = screenScale;
    }

}
