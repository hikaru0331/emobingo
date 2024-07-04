using System.Collections.Generic;
using UnityEngine;

public class BingoSquare
{
    public int number;
    public bool isOpen;
}

public class BingoManager : MonoBehaviour
{
    public const int SQUARE_COUNT = 9;
    private List<BingoSquare> bingoSquareList = new List<BingoSquare>();
    [SerializeField] private CardAreaView cardAreaView;

    private void Start()
    {
        //ここでjsonからimageを取り込みたい
        for (int i = 0; i < 9; i++)
        {
            BingoSquare bingoSquare = new BingoSquare();
            bingoSquare.number = i + 1;
            bingoSquare.isOpen = false;
            bingoSquareList.Add(bingoSquare);
        }
        for (int i = 0; i < SQUARE_COUNT; i++)
        {
            cardAreaView.SetCardNumber(i, bingoSquareList[i].number);
            cardAreaView.SetCardClose(i);
        }
    }
}