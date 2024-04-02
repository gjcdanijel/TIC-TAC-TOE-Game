using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageController : MonoBehaviour
{

    [SerializeField] Sprite xSprite;
    [SerializeField] Sprite oSprite;
    Image xImage;
    Image yImage;

    public Sprite GetXSprite()
    {
        return xSprite;
    }
    public Sprite GetOSprite()
    {
        return oSprite;
    }

}
