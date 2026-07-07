using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSushiObject : MonoBehaviour
{
    [SerializeField] private PlayerSushiData playerSushiData;

    [SerializeField] private SpriteRenderer topLayerSprite;
    [SerializeField] private SpriteRenderer middleLayerSprite;
    [SerializeField] private SpriteRenderer bottomLayerSprite;

    private void OnEnable()
    {
        UiManager.OnConfirmSushi += CreateSushi;
        PlayerInteract.OnCorrectOrder += RemoveSushi;
        PlayerInteract.OnIncorrectOrder += RemoveSushi;
    }

    private void OnDisable()
    {
        UiManager.OnConfirmSushi -= CreateSushi;
        PlayerInteract.OnCorrectOrder += RemoveSushi;
        PlayerInteract.OnIncorrectOrder += RemoveSushi;
    }

    // shows the sushi sprite based on player sushi data
    private void CreateSushi()
    {
        topLayerSprite.sprite = playerSushiData.TopIcon;
        middleLayerSprite.sprite = playerSushiData.MiddleIcon;
        bottomLayerSprite.sprite = playerSushiData.BottomIcon;
    }

    private void RemoveSushi()
    {
        topLayerSprite.sprite = null;
        middleLayerSprite.sprite = null;
        bottomLayerSprite.sprite = null;
    }
}
