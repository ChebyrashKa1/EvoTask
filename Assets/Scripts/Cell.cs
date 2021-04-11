using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Button         btnCell;
    [SerializeField] private GameObject     iconEmpty;
    [SerializeField] private Image          iconCell;
    [SerializeField] private Transform      thisTransform;

    private const float fullDegrees = 179.0f;
    private const float halfDegrees = 90.0f;
    private const float duration = 0.5f;

    private CellData cellData;
    private bool isSelected = false;

    public bool IsSelected { get => isSelected; set => isSelected = value; }
    public CellData CellData => cellData;

    public void InitCell(CellData newCellData)
    {
        cellData = newCellData;
        iconCell.sprite = GameCore.icons.GetCellIcon(cellData.CellType);
        //RotateForward();
    }

    public void ClickCell()
    {
        StartCoroutine(RotateForward());
        GameCore.cells.CheckSelectedCells(this);
    }

    public IEnumerator RotateBack()
    {
        float startRotation = fullDegrees; //thisTransform.eulerAngles.y;
        float endRotation = 0.0f;
        float t = 0.0f;
        bool swapIcon = false;

        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration);// % 179.0f;
            thisTransform.eulerAngles = new Vector3(thisTransform.eulerAngles.x, yRotation, thisTransform.eulerAngles.z);
            if (yRotation <= halfDegrees && !swapIcon)
            {
                swapIcon = true;
                iconEmpty.SetActive(true);
                iconCell.gameObject.SetActive(false);
            }
            yield return null;
        }

    }

    public IEnumerator RotateForward()
    {
        float startRotation = thisTransform.eulerAngles.y;
        float endRotation = fullDegrees;
        float t = 0.0f;
        bool swapIcon = false;

        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 180;
            thisTransform.eulerAngles = new Vector3(thisTransform.eulerAngles.x, yRotation, thisTransform.eulerAngles.z);
            if (yRotation >= halfDegrees && !swapIcon)
            {
                swapIcon = true;
                iconEmpty.SetActive(false);
                iconCell.gameObject.SetActive(true);
            }
            yield return null;
        }
    }

    public void ActiveButton(bool active)
    {
        if(!isSelected)
            btnCell.interactable = active;
    }
}