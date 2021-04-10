using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CellsManager : Singleton<CellsManager>
{
    [SerializeField] private RectTransform grid;
    [SerializeField] private List<Cell> allCells;

    private Cell firstSelected;
    private Cell secondSelected;

    public Cell FirstSelected { get => firstSelected; set => firstSelected = value; }
    public Cell SecondSelected { get => secondSelected; set => secondSelected = value; }


    private void Start()
    {
        InitCells();
        StartCoroutine(TwoSecondRotate());
    }

    private void InitCells()
    {
        var cellTypesList = GameCore.enumUtils.GetValues<CellType>();

        for (int i = 0; i < allCells.Count; i++)
        {
            var type = cellTypesList[(int)(i * 0.5f)];
            allCells[i].InitCell(type);
        }
         allCells = allCells.OrderBy(x => Random.value).ToList();


       /* int count = grid.childCount;
        List<Cell> _cells = new List<Cell>(count);

        for (int i = 0; i < count; i++)
        {
            _cells.Add(grid.GetChild(i).GetComponent<Cell>());
        }
        _cells = _cells.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < count; i++)
        {
            Dbg.Log("test: " + i + "/" + _cells[i].CellType + "/" + grid.GetChild(i).GetComponent<Cell>().CellType, Color.yellow);
            grid.GetChild(i).GetComponent<Cell>().InitCell(_cells[i].CellType);
            Dbg.Log("test: " + _cells[i].CellType + "/" + grid.GetChild(i).GetComponent<Cell>().CellType, Color.yellow);
        }*/



        /* for (int i = 0; i < allCells.Count; i++)
        {
            Dbg.Log("checkType: " + i + "/" + allCells[i].CellType, Color.magenta);
        }

        for (int i = 0; i < allCells.Count; i++)
        {
            Dbg.Log("test: " + i + "/" + allCells[i].CellType + "/" + grid.GetChild(i).GetComponent<Cell>().CellType, Color.yellow);
            grid.GetChild(i).GetComponent<Cell>().InitCell(allCells[i].CellType);
            Dbg.Log("test: " + "/" + allCells[i].CellType + "/" + grid.GetChild(i).GetComponent<Cell>().CellType, Color.yellow);
        }*/
    }

    #region Checks
    public void CheckSelectedCells(Cell cell)
    {
        if (cell.IsSelected)
            return;

        if (firstSelected == null)
        {
            firstSelected = cell;
            firstSelected.ActiveButton(false);
        }
        else if (secondSelected == null)
        {
            ActiveButtons(false);
            secondSelected = cell;
            StartCoroutine(CheckTwins());
        }
    }

    private IEnumerator CheckTwins()
    {
        if (firstSelected.CellType == secondSelected.CellType)
        {
            firstSelected.IsSelected = true;
            secondSelected.IsSelected = true;
            firstSelected.ActiveButton(false);
            secondSelected.ActiveButton(false);
            //проверка конца игры
        }
        else
        {
            yield return GameCore.yield.WaitFor(1f);
            StartCoroutine(firstSelected.RotateBack());
            StartCoroutine(secondSelected.RotateBack());
        }
        yield return null;
        ClearSelected();
        ActiveButtons(true);
    }

    private void ActiveButtons(bool active)
    {
        for (int i = 0; i < allCells.Count; i++)
        {
            allCells[i].ActiveButton(active);
        }
    }
    private void ClearSelected()
    {
        firstSelected = null;
        secondSelected = null;
    }
    #endregion

    private IEnumerator TwoSecondRotate()
    {
        ActiveButtons(false);
        yield return GameCore.yield.WaitFor(0.1f);
        for (int i = 0; i < allCells.Count; i++)
        {
            StartCoroutine(allCells[i].RotateForward());
        }
        yield return GameCore.yield.WaitFor(2f);
        for (int i = 0; i < allCells.Count; i++)
        {
            StartCoroutine(allCells[i].RotateBack());
        }
        ActiveButtons(true);
    }
}