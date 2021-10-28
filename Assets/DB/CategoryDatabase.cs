using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Category Database", menuName = "Category/Category Database")]
public class CategoryDatabase : ScriptableObject
{
    public Category[] playableCategories;
    public Category miscCategory;
}
