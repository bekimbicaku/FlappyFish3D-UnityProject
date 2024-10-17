using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Skin", menuName = "Create New Skin")]
public class PlayerInfo : ScriptableObject
{
    public enum SkinIDs { turtle, dophin, yellow, star, blue, manta, tropical }
    public SkinIDs skinID;

    public Sprite skinSprite;

    public int skinPrice;
}