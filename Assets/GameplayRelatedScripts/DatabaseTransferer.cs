using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseTransferer : MonoBehaviour
{
    [SerializeField]
    private CategoryDatabase _categoryDatabase;

    

    [SerializeField]
    private GroupItem[] _groups;
    [SerializeField]
    private CategoryItem[] _categoryItems;


    public void Init()
    {
        if (_categoryDatabase == null || _categoryDatabase.miscCategory == null || _groups == null || _categoryItems == null) return;

        List<Category> openCatSet = new List<Category>();
        List<CategoryItem> openItemSet = new List<CategoryItem>();
        foreach (var c in _categoryDatabase.playableCategories)
        {
            openCatSet.Add(c);
        }
        foreach (var c in _categoryItems)
        {
            openItemSet.Add(c);
        }

        foreach (var group in _groups)
        {
            int randCat = Random.Range(0, openCatSet.Count);
            Category c = openCatSet[randCat];
            group.Init(c.itemGroup, c.groupSprite);
            openCatSet.RemoveAt(randCat);

            int randItem = Random.Range(0, openItemSet.Count);
            CategoryItem categoryItem = openItemSet[randItem];
            categoryItem.Init(c.itemGroup, c.itemSprites[Random.Range(0, c.itemSprites.Length)]);
            openItemSet.RemoveAt(randItem);

        }

        

        List<Sprite> openMiscSpritesSet = new List<Sprite>();
        foreach (var miscCatSpr in _categoryDatabase.miscCategory.itemSprites)
        {
            openMiscSpritesSet.Add(miscCatSpr);
        }

        for (int i = 0; i < openItemSet.Count; i++)
        {
            int r = Random.Range(0, openMiscSpritesSet.Count);
            openItemSet[i].Init(_categoryDatabase.miscCategory.itemGroup, openMiscSpritesSet[r]);
            openMiscSpritesSet.RemoveAt(r);
        }
    }

}
