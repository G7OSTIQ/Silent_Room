using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Content/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private Sprite itemSprite;

    public string ItemName => itemName;

    public string ItemDescription => itemDescription;
    
    public Sprite ItemSprite => itemSprite;
}
