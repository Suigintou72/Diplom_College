﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Diplom.Games.Tetris
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
    private const int GAMESPEED = 700;// милисекунда
                                      // Список из 2 музыки wav
    List<System.Media.SoundPlayer> soundList = new List<System.Media.SoundPlayer>();
    DispatcherTimer timer;
    Random shapeRandom;

    private int rowCount = 0;
    private int columnCount = 0;
    private int leftPos = 0;
    private int downPos = 0;
    private int currentTetrominoWidth;
    private int currentTetrominoHeigth;
    private int currentShapeNumber;
    private int nextShapeNumber;
    private int tetrisGridColumn;
    private int tetrisGridRow;
    private int rotation = 0;
    private bool gameActive = false;
    private bool nextShapeDrawed = false;
    private int[,] currentTetromino = null;
    private bool isRotated = false;
    private bool bottomCollided = false;
    private bool leftCollided = false;
    private bool rightCollided = false;
    private bool isGameOver = false;
    private int gameSpeed;
    private int levelScale = 60;// Каждые 60 секунд повышение уровня на 1 до 10
    private double gameSpeedCounter = 0;
    private int gameLevel = 1;
    private int gameScore = 0;
    private static Color O_TetrominoColor = Colors.GreenYellow;
    private static Color I_TetrominoColor = Colors.Red;
    private static Color T_TetrominoColor = Colors.Gold;
    private static Color S_TetrominoColor = Colors.Violet;
    private static Color Z_TetrominoColor = Colors.DeepSkyBlue;
    private static Color J_TetrominoColor = Colors.Cyan;
    private static Color L_TetrominoColor = Colors.LightSeaGreen;
    List<int> currentTetrominoRow = null;
    List<int> currentTetrominoColumn = null;


    // Цвет для форм Tetromino
    Color[] shapeColor = {  O_TetrominoColor,I_TetrominoColor,
                                T_TetrominoColor,S_TetrominoColor,
                                Z_TetrominoColor,J_TetrominoColor,
                                L_TetrominoColor
                             };
    // ---------
    string[] arrayTetrominos = { "","O_Tetromino" , "I_Tetromino_0",
                                        "T_Tetromino_0","S_Tetromino_0",
                                        "Z_Tetromino_0","J_Tetromino_0",
                                        "L_Tetromino_0"
                                   };

    #region Array of tetrominos shape 

    // Стрелки of tetromino форм
    //---- O Tetromino------------
    public int[,] O_Tetromino = new int[2, 2] { { 1, 1 },  // * *
                                                    { 1, 1 }}; // * *

    //---- I Tetromino------------
    public int[,] I_Tetromino_0 = new int[2, 4] { { 1, 1, 1, 1 }, { 0, 0, 0, 0 } };// * * * *

    public int[,] I_Tetromino_90 = new int[4, 2] {{ 1,0 },   // *  
                                                       { 1,0 },  // *
                                                       { 1,0 },  // *
                                                       { 1,0 }}; // *
                                                                 //---- T Tetromino------------
    public int[,] T_Tetromino_0 = new int[2, 3] {{0,1,0},    //    * 
                                                     {1,1,1}};   //  * * *

    public int[,] T_Tetromino_90 = new int[3, 2] {{1,0},     //  * 
                                                      {1,1},     //  * *
                                                      {1,0}};    //  *  

    public int[,] T_Tetromino_180 = new int[2, 3] {{1,1,1},  // * * *
                                                       {0,1,0}}; //   * 

    public int[,] T_Tetromino_270 = new int[3, 2] {{0,1},    //   * 
                                                       {1,1},    // * *
                                                       {0,1}};   //   *  
                                                                 //---- S Tetromino------------
    public int[,] S_Tetromino_0 = new int[2, 3] {{0,1,1},    //   * *
                                                     {1,1,0}};   // * *

    public int[,] S_Tetromino_90 = new int[3, 2] {{1,0},     // *
                                                      {1,1},     // * *
                                                      {0,1}};    //   *
                                                                 //---- Z Tetromino------------
    public int[,] Z_Tetromino_0 = new int[2, 3] {{1,1,0},    // * *
                                                     {0,1,1}};   //   * *

    public int[,] Z_Tetromino_90 = new int[3, 2] {{0,1},     //   *
                                                      {1,1},     // * *
                                                      {1,0}};    // *
                                                                 //---- J Tetromino------------
    public int[,] J_Tetromino_0 = new int[2, 3] {{1,0,0},    // * 
                                                     {1,1,1}};   // * * *

    public int[,] J_Tetromino_90 = new int[3, 2] {{1,1},     // * * 
                                                      {1,0},     // *
                                                      {1,0}};    // * 

    public int[,] J_Tetromino_180 = new int[2, 3] {{1,1,1},  // * * * 
                                                       {0,0,1}}; //     *

    public int[,] J_Tetromino_270 = new int[3, 2] {{0,1},    //   * 
                                                       {0,1},    //   *
                                                       {1,1 }};  // * *

    //---- L Tetromino------------
    public int[,] L_Tetromino_0 = new int[2, 3] {{0,0,1},    //     * 
                                                     {1,1,1}};   // * * *

    public int[,] L_Tetromino_90 = new int[3, 2] {{1,0},     // *  
                                                      {1,0},     // *
                                                      {1,1}};    // * *

    public int[,] L_Tetromino_180 = new int[2, 3] {{1,1,1},  // * * * 
                                                       {1,0,0}}; // *

    public int[,] L_Tetromino_270 = new int[3, 2] {{1,1},    // * * 
                                                       {0,1},    //   *
                                                       {0,1 }};  //   *

    public object Task { get; private set; }
    #endregion

    public MainWindow()
    {
        InitializeComponent();

        gameSpeed = GAMESPEED;
        //Создается события для нажатия стрелочных кнопок
        KeyDown += MainWindow_KeyDown;
        // init timer
        timer = new DispatcherTimer();
        timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed); // 700 миллисекунд
        timer.Tick += Timer_Tick;
        tetrisGridColumn = tetrisGrid.ColumnDefinitions.Count;
        tetrisGridRow = tetrisGrid.RowDefinitions.Count;
        shapeRandom = new Random();
        currentShapeNumber = shapeRandom.Next(1, 8);
        nextShapeNumber = shapeRandom.Next(1, 8);
        nextTxt.Visibility = levelTxt.Visibility = GameOverTxt.Visibility = Visibility.Collapsed;
        // Тут 2 музыки wav
        soundList.Add(new System.Media.SoundPlayer(Properties.Resources.collided));
        soundList.Add(new System.Media.SoundPlayer(Properties.Resources.deleteLine));
    }

    // Ключевой метод события для перемещения формы вниз, вправо, влево и вращение
    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {

        if (!timer.IsEnabled) { return; }
        switch (e.Key.ToString())
        {
            case "Up":
                rotation += 90;
                if (rotation > 270) { rotation = 0; }
                shapeRotation(rotation);
                break;
            case "Down":
                downPos++;
                break;
            case "Right":
                // Проверить, не столкнулся ли
                TetroCollided();
                if (!rightCollided) { leftPos++; }
                rightCollided = false;
                break;
            case "Left":
                // Проверить, не столкнулся ли
                TetroCollided();
                if (!leftCollided) { leftPos--; }
                leftCollided = false;
                break;
        }
        moveShape();
    }

    // Вращение tetrominos 
    private void shapeRotation(int _rotation)
    {
        // Проверить, не столкнулся ли
        if (rotationCollided(rotation))
        {
            rotation -= 90;
            return;
        }

        if (arrayTetrominos[currentShapeNumber].IndexOf("I_") == 0)
        {
            if (_rotation > 90) { _rotation = rotation = 0; }
            currentTetromino = getVariableByString("I_Tetromino_" + _rotation);
        }
        else if (arrayTetrominos[currentShapeNumber].IndexOf("T_") == 0)
        {
            currentTetromino = getVariableByString("T_Tetromino_" + _rotation);
        }
        else if (arrayTetrominos[currentShapeNumber].IndexOf("S_") == 0)
        {
            if (_rotation > 90) { _rotation = rotation = 0; }
            currentTetromino = getVariableByString("S_Tetromino_" + _rotation);
        }
        else if (arrayTetrominos[currentShapeNumber].IndexOf("Z_") == 0)
        {
            if (_rotation > 90) { _rotation = rotation = 0; }
            currentTetromino = getVariableByString("Z_Tetromino_" + _rotation);
        }
        else if (arrayTetrominos[currentShapeNumber].IndexOf("J_") == 0)
        {
            currentTetromino = getVariableByString("J_Tetromino_" + _rotation);
        }
        else if (arrayTetrominos[currentShapeNumber].IndexOf("L_") == 0)
        {
            currentTetromino = getVariableByString("L_Tetromino_" + _rotation);
        }
        else if (arrayTetrominos[currentShapeNumber].IndexOf("O_") == 0) // НЕ ВРАЩАТЬ ЭТО
        {
            return;
        }

        isRotated = true;
        addShape(currentShapeNumber, leftPos, downPos);
    }


    // Таймерный тик для перемещения формы вниз
    private void Timer_Tick(object sender, EventArgs e)
    {
        downPos++;
        moveShape();
        if (gameSpeedCounter >= levelScale)
        {
            if (gameSpeed >= 50)
            {
                gameSpeed -= 50;
                gameLevel++;
                levelTxt.Text = "Уровень: " + gameLevel.ToString();
            }
            else { gameSpeed = 50; }
            timer.Stop();
            timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);
            timer.Start();
            gameSpeedCounter = 0;
        }
        gameSpeedCounter += (gameSpeed / 1000f);
    }

    // Кнопка запуска, остановки, нажатия методы
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {

        if (isGameOver)
        {
            tetrisGrid.Children.Clear();
            nextShapeCanvas.Children.Clear();
            GameOverTxt.Visibility = Visibility.Collapsed;
            isGameOver = false;
        }
        if (!timer.IsEnabled)
        {
            if (!gameActive) { scoreTxt.Text = "0"; leftPos = 3; addShape(currentShapeNumber, leftPos); }
            nextTxt.Visibility = levelTxt.Visibility = Visibility.Visible;
            levelTxt.Text = "Уровень: " + gameLevel.ToString();
            timer.Start();
            startStopBtn.Content = "Остановить";
            gameActive = true;
        }
        else
        {
            timer.Stop();
            startStopBtn.Content = "Начать игру";
        }
    }

    // Добавить новую форму tetromino в сетке
    private void addShape(int shapeNumber, int _left = 0, int _down = 0)
    {
        // Вернуть предыдущую позицию of tetromino
        removeShape();
        currentTetrominoRow = new List<int>();
        currentTetrominoColumn = new List<int>();
        Rectangle square = null;
        if (!isRotated)
        {
            currentTetromino = null;
            currentTetromino = getVariableByString(arrayTetrominos[shapeNumber].ToString());
        }
        int firstDim = currentTetromino.GetLength(0);
        int secondDim = currentTetromino.GetLength(1);
        currentTetrominoWidth = secondDim;
        currentTetrominoHeigth = firstDim;
        // Это только I Tetromino
        if (currentTetromino == I_Tetromino_90)
        {
            currentTetrominoWidth = 1;
        }
        else if (currentTetromino == I_Tetromino_0) { currentTetrominoHeigth = 1; }
        //------------------------------------
        for (int row = 0; row < firstDim; row++)
        {
            for (int column = 0; column < secondDim; column++)
            {
                int bit = currentTetromino[row, column];
                if (bit == 1)
                {
                    square = getBasicSquare(shapeColor[shapeNumber - 1]);
                    tetrisGrid.Children.Add(square);
                    square.Name = "moving_" + Grid.GetRow(square) + "_" + Grid.GetColumn(square);
                    if (_down >= tetrisGrid.RowDefinitions.Count - currentTetrominoHeigth)
                    {
                        _down = tetrisGrid.RowDefinitions.Count - currentTetrominoHeigth;
                    }
                    Grid.SetRow(square, rowCount + _down);
                    Grid.SetColumn(square, columnCount + _left);
                    currentTetrominoRow.Add(rowCount + _down);
                    currentTetrominoColumn.Add(columnCount + _left);

                }
                columnCount++;
            }
            columnCount = 0;
            rowCount++;
        }
        columnCount = 0;
        rowCount = 0;
        if (!nextShapeDrawed)
        {
            drawNextShape(nextShapeNumber);
        }
    }

    // Добавить новую форму в новую локацию
    private void moveShape()
    {
        leftCollided = false;
        rightCollided = false;

        // Проверить, не столкнулся ли
        TetroCollided();
        if (leftPos > (tetrisGridColumn - currentTetrominoWidth))
        {
            leftPos = (tetrisGridColumn - currentTetrominoWidth);
        }
        else if (leftPos < 0) { leftPos = 0; }

        if (bottomCollided)
        {
            shapeStoped();
            return;
        }
        addShape(currentShapeNumber, leftPos, downPos);
    }

    // Проверить, не столкнулся ли tetromino при повороте
    private bool rotationCollided(int _rotation)
    {
        if (checkCollided(0, currentTetrominoWidth - 1)) { return true; }//Bottom collision 
        else if (checkCollided(0, -(currentTetrominoWidth - 1))) { return true; }// Top collision
        else if (checkCollided(0, -1)) { return true; }// Top collision
        else if (checkCollided(-1, currentTetrominoWidth - 1)) { return true; }// Left collision
        else if (checkCollided(1, currentTetrominoWidth - 1)) { return true; }// Right collision
        return false;
    }

    // Проверить, не столкнулся ли в сторону, на дно или на другие формы
    private void TetroCollided()
    {
        bottomCollided = checkCollided(0, 1);
        leftCollided = checkCollided(-1, 0);
        rightCollided = checkCollided(1, 0);
    }

    //Проверка столкновения
    private bool checkCollided(int _leftRightOffset, int _bottomOffset)
    {
        Rectangle movingSquare;
        int squareRow = 0;
        int squareColumn = 0;
        for (int i = 0; i <= 3; i++)
        {
            squareRow = currentTetrominoRow[i];
            squareColumn = currentTetrominoColumn[i];
            try
            {
                movingSquare = (Rectangle)tetrisGrid.Children
                .Cast<UIElement>()
                .FirstOrDefault(e => Grid.GetRow(e) == squareRow + _bottomOffset && Grid.GetColumn(e) == squareColumn + _leftRightOffset);
                if (movingSquare != null)
                {
                    if (movingSquare.Name.IndexOf("arrived") == 0)
                    {
                        return true;
                    }
                }
            }
            catch { }
        }
        if (downPos > (tetrisGridRow - currentTetrominoHeigth)) { return true; }
        return false;
    }

    // Рисовка след формы tetromino в nextShapeCanvas 
    private void drawNextShape(int shapeNumber)
    {
        nextShapeCanvas.Children.Clear();
        int[,] nextShapeTetromino = null;
        nextShapeTetromino = getVariableByString(arrayTetrominos[shapeNumber]);
        int firstDim = nextShapeTetromino.GetLength(0);
        int secondDim = nextShapeTetromino.GetLength(1);
        int x = 0;
        int y = 0;
        Rectangle square;
        for (int row = 0; row < firstDim; row++)
        {
            for (int column = 0; column < secondDim; column++)
            {
                int bit = nextShapeTetromino[row, column];
                if (bit == 1)
                {
                    square = getBasicSquare(shapeColor[shapeNumber - 1]);
                    nextShapeCanvas.Children.Add(square);
                    Canvas.SetLeft(square, x);
                    Canvas.SetTop(square, y);
                }
                x += 25;
            }
            x = 0;
            y += 25;
        }
        nextShapeDrawed = true;
    }


    // Этот метод вызывается, когда форма достигает дна или сталкивается
    private void shapeStoped()
    {
        timer.Stop();
        playSound(0);
        // Состояние "Игра окончена"
        if (downPos <= 2)
        {
            gameOver();
            return;
        }

        int index = 0;
        while (index < tetrisGrid.Children.Count)
        {
            UIElement element = tetrisGrid.Children[index];
            if (element is Rectangle)
            {
                Rectangle square = (Rectangle)element;
                if (square.Name.IndexOf("moving_") == 0)
                {
                    // Заменить название квадратов при получении tetromino
                    string newName = square.Name.Replace("moving_", "arrived_");
                    square.Name = newName;
                }
            }
            index++;
        }
        // Проверьте, завершена ли линия, и спуститесь вниз по другим фигурам
        checkComplete();
        reset();
        timer.Start();

    }
    // Метод для проверки, если закончилась линия
    private void checkComplete()
    {
        int gridRow = tetrisGrid.RowDefinitions.Count;
        int gridColumn = tetrisGrid.ColumnDefinitions.Count;
        int squareCount = 0;
        for (int row = gridRow; row >= 0; row--)
        {
            squareCount = 0;
            for (int column = gridColumn; column >= 0; column--)
            {
                Rectangle square;
                square = (Rectangle)tetrisGrid.Children
               .Cast<UIElement>()
               .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);
                if (square != null)
                {
                    if (square.Name.IndexOf("arrived") == 0)
                    {
                        squareCount++;
                    }
                }
            }

            // Если squareCount == gridColumn это означает, что строка завершена и должна быть удалена
            if (squareCount == gridColumn)
            {
                playSound(1);
                deleteLine(row);
                scoreTxt.Text = getScore().ToString();
                checkComplete();
            }
        }
    }

    // Удалить завершенные квадратные линии
    private void deleteLine(int row)
    {
        // Удалить завершенную линию
        for (int i = 0; i < tetrisGrid.ColumnDefinitions.Count; i++)
        {
            Rectangle square;
            try
            {
                square = (Rectangle)tetrisGrid.Children
               .Cast<UIElement>()
               .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == i);
                tetrisGrid.Children.Remove(square);
            }
            catch { }

        }
        // Двигаться вниз по остальной форме
        foreach (UIElement element in tetrisGrid.Children)
        {
            Rectangle square = (Rectangle)element;
            if (square.Name.IndexOf("arrived") == 0 && Grid.GetRow(square) <= row)
            {
                Grid.SetRow(square, Grid.GetRow(square) + 1);
            }
        }
    }
    // Получить счёт
    private int getScore()
    {
        gameScore += 50 * gameLevel;
        return gameScore;
    }

    // СБРОСИТЬ
    private void reset()
    {
        downPos = 0;
        leftPos = 3;
        isRotated = false;
        rotation = 0;
        currentShapeNumber = nextShapeNumber;
        if (!isGameOver) { addShape(currentShapeNumber, leftPos); }
        nextShapeDrawed = false;
        shapeRandom = new Random();
        nextShapeNumber = shapeRandom.Next(1, 8);
        bottomCollided = false;
        leftCollided = false;
        rightCollided = false;
    }
    // СБРОС "ИГРА ОКОНЧЕНА"
    private void gameOver()
    {
        isGameOver = true;
        MessageBox.Show("Вы проиграли. Начните игру заново.");
        reset();
        startStopBtn.Content = "Начать игру";
        GameOverTxt.Visibility = Visibility.Visible;
        rowCount = 0;
        columnCount = 0;
        leftPos = 0;
        gameSpeedCounter = 0;
        gameSpeed = GAMESPEED;
        gameLevel = 1;
        gameActive = false;
        gameScore = 0;
        nextShapeDrawed = false;
        currentTetromino = null;
        currentShapeNumber = shapeRandom.Next(1, 8);
        nextShapeNumber = shapeRandom.Next(1, 8);
        timer.Interval = new TimeSpan(0, 0, 0, 0, gameSpeed);

    }


    // Удалить формы с сетки  
    private void removeShape()
    {
        int index = 0;
        while (index < tetrisGrid.Children.Count)
        {
            UIElement element = tetrisGrid.Children[index];
            if (element is Rectangle)
            {
                Rectangle square = (Rectangle)element;
                if (square.Name.IndexOf("moving_") == 0)
                {
                    tetrisGrid.Children.Remove(element);
                    index = -1;
                }
            }
            index++;
        }

    }

    // Создать базовые квадраты для форм Тетрис 
    private Rectangle getBasicSquare(Color rectColor)
    {
        Rectangle rectangle = new Rectangle();
        rectangle.Width = 25;
        rectangle.Height = 25;
        rectangle.StrokeThickness = 1;
        rectangle.Stroke = Brushes.White;
        rectangle.Fill = getGradientColor(rectColor);
        return rectangle;
    }

    // Градиентные кубики tetromino
    private LinearGradientBrush getGradientColor(Color clr)
    {
        LinearGradientBrush gradientColor = new LinearGradientBrush();
        gradientColor.StartPoint = new Point(0, 0);
        gradientColor.EndPoint = new Point(1, 1.5);
        GradientStop black = new GradientStop();
        black.Color = Colors.Black;
        black.Offset = -1.5;
        gradientColor.GradientStops.Add(black);
        GradientStop other = new GradientStop();
        other.Color = clr;
        other.Offset = 0.70;
        gradientColor.GradientStops.Add(other);
        return gradientColor;
    }

    // Доступ к переменной по имени строки
    private int[,] getVariableByString(string variable)
    {
        return (int[,])this.GetType().GetField(variable).GetValue(this);
    }
    // Включение музыки. index=0 это для collided.wav и index=1 для deleteLine.wav
    private void playSound(int index)
    {
        soundList[index].Play();
    }


}

}
