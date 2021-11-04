using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Card : MonoBehaviour
{
    [SerializeField] TextMeshPro cardName;
    [SerializeField] SpriteRenderer cardImage;
    [SerializeField] Animator animator;
    [SerializeField] GameEvent cardOff;
    [SerializeField] GameEvent guessedRight;
    [SerializeField] GameEvent guessedWrong;

    bool active = false;

    //Тип карточки
    Prototype.ObjectType objectType;

    //Передаем данные из фабрики в карточку
    public void SetData(Prototype prototype)
    {
        objectType = prototype.objectType;
        cardName.text = prototype.objectName;
        StartCoroutine(LoadDataImage(prototype.assetReference));
    }

    //Свайп влево - несъедобно
    public void OnSwipeLeft()
    {
        if (active)
        {
            active = false;
            animator.Play("Swipe Left");
        }
        if (objectType == Prototype.ObjectType.uneatable) guessedRight.Raise();        
        else guessedWrong.Raise();
    }

    //Свайп вправо - съедобно
    public void OnSwipeRight()
    {
        if (active)
        {
            active = false;
            animator.Play("Swipe Right");
        }
        if (objectType == Prototype.ObjectType.eatable)
        {
            guessedRight.Raise();
        }
        else
        {
            guessedWrong.Raise();
        }
    }

    //Делаем карточку активной после анимации появления
    public void Activate()
    {
        active = true;
    }

    //Убираем карточку после свайпа
    public void CardOff()
    {
        cardOff.Raise();
        Destroy(gameObject);
    }

    public void GameOver()
    {
        animator.Play("Swipe Right");
    }

    //Загружаем картинку из Addressable assets
    private IEnumerator LoadDataImage(AssetReference loadDataSprite)
    {
        AsyncOperationHandle<Sprite> handle = loadDataSprite.LoadAssetAsync<Sprite>();
        yield return handle;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            cardImage.sprite = sprite;
            Addressables.Release(handle);
        }
    }
}
