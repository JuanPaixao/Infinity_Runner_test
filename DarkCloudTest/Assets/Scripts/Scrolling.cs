using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollSpeed;
    private Vector2 _initialPos;
    private float _imageSize;
    private void Awake()
    {
        _initialPos = this.transform.position;
        _imageSize = this.GetComponent<SpriteRenderer>().size.x;
    }
    private void Update()
    {
        float displacement = Mathf.Repeat(this.scrollSpeed * Time.time, _imageSize);
        this.transform.position = this._initialPos + (Vector2.right * displacement);
    }
}
