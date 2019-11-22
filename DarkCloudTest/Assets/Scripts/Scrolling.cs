using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollSpeed; //Velocidade do scroll do background do jogo e do chão
    private Vector2 _initialPos; //Posição inicial do objeto
    private float _imageSize; //Tamanho da imagem
    private void Awake() //Verificação da posição inicial e do tamanho da imagem (largura)
    {
        _initialPos = this.transform.position;
        _imageSize = this.GetComponent<SpriteRenderer>().size.x;
    }
    private void Update() //Desloca a imagem até que o deslocamento seja maior que o tamanho da imagem, e a retorna para a posição inicial, criando a sensação de movimento constante e infinito
    {
        float displacement = Mathf.Repeat(this.scrollSpeed * Time.time, _imageSize);
        this.transform.position = this._initialPos + (Vector2.right * displacement);
    }
}
