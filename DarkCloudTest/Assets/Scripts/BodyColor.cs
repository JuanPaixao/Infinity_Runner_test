using UnityEngine;

public class BodyColor : MonoBehaviour
{
    public bool red, blue, isWeapon, weaponOne, weaponTwo; //componentes referenciando o estado do objeto que o script está
    public Sprite spriteRed, spriteBlue, spriteWeaponOne, spriteWeaponTwo; //sprites referentes a variação do objeto com o script
    private SpriteRenderer _spriteRenderer; //componente do sprite 
    private GameManager _gameManager; //gerenciador de jogo, aonde estará os métodos globais
    public string tempColor; //indicativo da cor atual, para que possa ser alterada a cor de maneira certa
    public int weaponNumber; //indicativo da arma atual, para que possa ser alterada a cor de maneira certa

    private void Awake()
    {
        //Refêrencias dos componentes, verificando se há valores carregados de cores ou arma já definidas pelo jogador
        //Caso não, pegará por padrão a cor vermelha e a arma número um.
        _gameManager = FindObjectOfType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        string initialColor = PlayerPrefs.GetString(this.gameObject.name, "Red");
        int initialWeapon = PlayerPrefs.GetInt("WeaponNumber", 1);
        //Devidas alterações referentes as cores e arma de acordo com se há ou não arquivos salvos, caso não tenha, por padrão será vermelho e arma número 1.
        if (!isWeapon)
        {
            if (initialColor == "Red")
            {
                red = true;
            }
            else if (initialColor == "Blue")
            {
                blue = true;
            }
            ChangeColor();
        }
        else
        {
            if (initialWeapon == 1)
            {
                weaponOne = true;
            }
            else if (initialWeapon == 2)
            {
                weaponTwo = true;
            }
            ChangeWeapon();
        }
    }
    private void ChangeColor()
    {
        //Método responsável pela mudança de cor do objeto, salvando a cor definida após a troca
        if (red)
        {
            _spriteRenderer.sprite = spriteRed;
            PlayerPrefs.SetString(this.gameObject.name, "Red");
        }
        else if (blue)
        {
            _spriteRenderer.sprite = spriteBlue;
            PlayerPrefs.SetString(this.gameObject.name, "Blue");
        }
    }
    private void ChangeWeapon()
    {
        //Método responsável pela mudança de arma do jogador, salvando a arma definida após a troca
        if (weaponOne)
        {
            _spriteRenderer.sprite = spriteWeaponOne;
            PlayerPrefs.SetInt("WeaponNumber", 1);
        }
        else if (weaponTwo)
        {
            _spriteRenderer.sprite = spriteWeaponTwo;
            PlayerPrefs.SetInt("WeaponNumber", 2);
        }
    }
    private void OnMouseDown()
    {
        //Método responsável por fazer a troca de cor e/ou arma. No caso das cores, é verificado a última cor selecionada e então é feito a alteração da cor do objeto
        //No caso das armas, a mesma lógica segue, é verificado qual foi a arma selecinada e então é feito a alteração do sprite referente a arma selecionada.
        if (!isWeapon)
        {
            tempColor = _gameManager.ReturnColor();
            if (tempColor == "Red")
            {
                this.blue = false;
                this.red = true;
                ChangeColor();
            }
            else if (tempColor == "Blue")
            {
                this.red = false;
                this.blue = true;
                ChangeColor();
            }
        }
        else
        {
            weaponNumber = _gameManager.ReturnWeapon();
            if (weaponNumber == 1)
            {
                weaponOne = true;
                weaponTwo = false;
                ChangeWeapon();
            }
            else if (weaponNumber == 2)
            {
                weaponTwo = true;
                weaponOne = false;
                ChangeWeapon();
            }
        }
    }
}
