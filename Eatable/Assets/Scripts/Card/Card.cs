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

    //��� ��������
    Prototype.ObjectType objectType;

    //�������� ������ �� ������� � ��������
    public void SetData(Prototype prototype)
    {
        objectType = prototype.objectType;
        cardName.text = prototype.objectName;
        StartCoroutine(LoadDataImage(prototype.assetReference));
    }

    //����� ����� - ����������
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

    //����� ������ - ��������
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

    //������ �������� �������� ����� �������� ���������
    public void Activate()
    {
        active = true;
    }

    //������� �������� ����� ������
    public void CardOff()
    {
        cardOff.Raise();
        Destroy(gameObject);
    }

    public void GameOver()
    {
        animator.Play("Swipe Right");
    }

    //��������� �������� �� Addressable assets
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
