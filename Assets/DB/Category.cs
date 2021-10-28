using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Category", menuName ="Category/New Category")]
public class Category : ScriptableObject
{
    public ItemGroup itemGroup;

    public Sprite groupSprite;

    public Sprite[] itemSprites;
}
