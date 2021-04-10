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

    private static float duration = 0.5f;
    private CellType cellType;
    private bool isSelected;

    public CellType CellType => cellType;

    public bool IsSelected { get => isSelected; set => isSelected = value; }

    public void InitCell(CellType newCell)
    {
        cellType = newCell;
        iconCell.sprite = GameCore.icons.GetCellIcon(cellType);
        //RotateForward();
    }

    public void ClickCell()
    {
        StartCoroutine(RotateForward());
        GameCore.cells.CheckSelectedCells(this);
    }

    public IEnumerator RotateBack()
    {
        float startRotation = 360.0f; //thisTransform.eulerAngles.y;
        float endRotation = 0.0f;
        float t = 0.0f;
        bool swapIcon = false;

        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration);// % 179.0f;
            thisTransform.eulerAngles = new Vector3(thisTransform.eulerAngles.x, yRotation, thisTransform.eulerAngles.z);
            if (yRotation <= 180.0f && !swapIcon)
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
        float endRotation = 360.0f;
        float t = 0.0f;
        bool swapIcon = false;

        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            thisTransform.eulerAngles = new Vector3(thisTransform.eulerAngles.x, yRotation, thisTransform.eulerAngles.z);
            if (yRotation >= 180.0f && !swapIcon)
            {
                swapIcon = true;
                iconEmpty.SetActive(false);
                iconCell.gameObject.SetActive(true);
            }
            Dbg.Log("RotateForward: " + yRotation, Color.green);
            yield return null;
        }
    }

    public void ActiveButton(bool active)
    {
        if(!isSelected)
            btnCell.interactable = active;
    }
}

public enum CellType
{
    Empty   = 0,
    Coin    = 1,
    Hand    = 2,
    Horse   = 3,
    Lion    = 4,
    Eagle   = 5,
    Medusa  = 6,
    Bull    = 7,
}