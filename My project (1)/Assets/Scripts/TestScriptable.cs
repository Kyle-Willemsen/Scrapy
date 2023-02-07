using UnityEngine;

[CreateAssetMenu(fileName = "AssaultRifle", menuName = "WeaponClasses/AssaultRifle")]
public class TestScriptable : ScriptableObject
{
    public GameObject bullet;
    public float resetShot;
    public bool automatic;
    public float reloadTime;
    public float fireRate;
    public bool reloading;
    public float bulletsLeft;
    public float magazineSize;
    public new string name;
    //public Sprite image;
    public GameObject prefab;
    //[TextArea] public string description;

}
