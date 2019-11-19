using UnityEngine;

public class BodyColor : MonoBehaviour
{
    public bool red, blue, isWeapon, weaponOne, weaponTwo;
    public Sprite spriteRed, spriteBlue, spriteWeaponOne, spriteWeaponTwo;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    public string tempColor;
    public int weaponNumber;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        string initialColor = PlayerPrefs.GetString(this.gameObject.name, "Red");
        int initialWeapon = PlayerPrefs.GetInt("WeaponNumber", 1);

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
