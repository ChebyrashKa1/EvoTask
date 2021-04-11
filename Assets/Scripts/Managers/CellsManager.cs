using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CellsManager : Singleton<CellsManager>
{
    [SerializeField] private List<Cell> allCells;
    [SerializeField] private TimerLabel mainTimer;


    private List<CellData> tempCells;
    private Cell firstSelected;
    private Cell secondSelected;
    private const int timeGame = 60;

    public Cell FirstSelected { get => firstSelected; set => firstSelected = value; }
    public Cell SecondSelected { get => secondSelected; set => secondSelected = value; }


    private void Start()
    {
        InitCells();
        mainTimer.UpdateStaticTime(timeGame);
        StartCoroutine(TwoSecondRotate());
    }

    private void InitCells() //init sort 
    {
        var cellTypesList = GameCore.enumUtils.GetValues<CellType>();

        tempCells = new List<CellData>(allCells.Count);
        for (int i = 0; i < allCells.Count; i++)
        {
            var type = cellTypesList[(int)(i * 0.5f)];
            tempCells.Add(new CellData());
            tempCells[i].CellType = type;
        }

        tempCells = tempCells.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < allCells.Count; i++)
        {
            allCells[i].InitCell(tempCells[i]);
        }
        tempCells.Clear();
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
        yield return null;
        if(firstSelected.CellData.CellType == secondSelected.CellData.CellType)
        {
            firstSelected.IsSelected = true;
            secondSelected.IsSelected = true;
            firstSelected.ActiveButton(false);
            secondSelected.ActiveButton(false);
            yield return GameCore.yield.WaitFor(0.5f);
            CheckWinGame();//проверка конца игры
        }
        else
        {
            yield return GameCore.yield.WaitFor(1f);
            StartCoroutine(firstSelected.RotateBack());
            yield return StartCoroutine(secondSelected.RotateBack());
        }
        ClearSelected();
        ActiveButtons(true);
    }

    private void CheckWinGame()
    {
        for (int i = 0; i < allCells.Count ; i++)
        {
            if (!allCells[i].IsSelected)
            {
                return;
            }
        }
        WinGameAction();
    }

    private void WinGameAction()
    {
        mainTimer.StopTimer();
        var saveNewTime = timeGame - mainTimer.Timer;
        GameCore.windows.OpenWindow<GoodJobWindow>().Init(saveNewTime);
        BestScoreManager.SaveNewScore(saveNewTime);
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
        mainTimer.StartTimer(timeGame, () => { GameCore.windows.OpenWindow<GameOverWindow>(); }); // окно проигрыша при конце времени
        ActiveButtons(true);
    }


    #region TimerPause
    public void ActiveTimer()
    {
        mainTimer.StartTimer(mainTimer.Timer, () => { GameCore.windows.OpenWindow<GameOverWindow>(); }); // окно проигрыша при конце времени
    }
    public void StopTimer()
    {
        mainTimer.StopTimer();
    }
    #endregion
}