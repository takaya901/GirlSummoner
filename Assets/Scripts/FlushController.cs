using UnityEngine;
using Image = UnityEngine.UI.Image;

public class FlushController : MonoBehaviour
{
    Image _image;
    bool _isFlushing = true;

    void Start()
    {
        _image = GetComponent<Image>();
        // Flush();
    }

    void Update()
    {
        if (!_isFlushing) return;

        var alpha = Mathf.MoveTowards(_image.color.a, 0f, Time.deltaTime * 0.1f);
        _image.color = new Color(1f, 1f, 1f, alpha);
        // _image.color = Color.Lerp(_image.color, Color.clear, Time.deltaTime);

        if (_image.color == Color.clear) {
            _isFlushing = false;
        }
    }

    public void Flush()
    {
        _isFlushing = true;
        _image.color = Color.white;
    }
}
