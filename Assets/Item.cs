using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName= "Jam/item")]
public class Item : ScriptableObject
{
    public GameObject prefab;
    public string name;
    public Sprite image;
}