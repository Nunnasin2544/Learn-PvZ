using UnityEngine;
using UnityEngine.UI;

public class PlantCard : MonoBehaviour
{
    [SerializeField] PlantCardData plantCardData;
    [SerializeField] Button selfButton;
    [SerializeField] Image plantImage;
    [SerializeField] GameObject selectedEffect;

    private RectTransform cardRect;

    private void Start()
    {
        selectedEffect.SetActive(false);
        cardRect = GetComponent<RectTransform>();
        plantImage.sprite = plantCardData.PlantSprite;

        ClickManager.Instance.OnClickInput += IsClickOutSideCard;
        selfButton.onClick.AddListener(OnCardClick);
    }

    private void OnCardClick()
    {
        GameManager.Instance.SelectPlantCard(plantCardData.PlantPrefab);
        selectedEffect.SetActive(true);
    }

    private void IsClickOutSideCard()
    {
        bool isClickOutSideCard = 
            !RectTransformUtility
            .RectangleContainsScreenPoint
            (cardRect, Input.mousePosition);

        if (selectedEffect.activeSelf && isClickOutSideCard)
        {
            GameManager.Instance.DeselectPlantCard();
            selectedEffect.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        ClickManager.Instance.OnClickInput -= IsClickOutSideCard;
        selfButton.onClick.RemoveAllListeners();
    }
}
