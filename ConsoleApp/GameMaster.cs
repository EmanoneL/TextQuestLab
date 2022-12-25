using TextQuest;

namespace ConsoleApp;

/// <summary>
/// Класс который является связующим между интерфейсом и игрой.
/// </summary>
public class GameMaster
{
    private Game Game { get; set; }
    private ConsoleHelper ConsoleHelper { get; set; }

    /// <summary>
    /// Выбранный варинт введенный с консоли.
    /// </summary>
    private int variant;

    public GameMaster()
    {
        Game = new Game();
        ConsoleHelper = new ConsoleHelper();
    }

    /// <summary>
    /// Запускает цикл игры.
    /// </summary>
    public void Start()
    {
        var load = ConsoleHelper.AskLoadSave();
        if (load == "1")
        {
            try
            {
                Game = Game.Looding();
            }
            catch (Exception)
            {

                Console.WriteLine("Нет сохраненных игр");
            }
        }

        var step = Game.StartGame();
        ConsoleHelper.ShowStep(step);
        if (step.Variants == null)
        {
            Stop();
            return;
        }

        ConsoleHelper.ShowVariants(step);

        Loop();
    }

    /// <summary>
    /// Цикл игры.
    /// </summary>
    private void Loop()
    {
        do
        {
            try
            {
                variant = GetVariant();
            }
            catch (Exception e)
            {
                continue;
            }

            if (variant == 0)
            {
                Stop();
                break;
            }

            if (!NextStep())
            {
                Stop();
                break;
            }
        } while (true);
    }

    /// <summary>
    /// Метод перехода на следующий игровой зод.
    /// </summary>
    /// <returns></returns>
    private bool NextStep()
    {
        if (!Game.IsCurrentVariant(variant))
        {
            return true;
        }

        var step = Game.NextStep(variant);

        ConsoleHelper.ShowStep(step);

        if (step.Variants == null)
        {
            return false;
        }

        ConsoleHelper.ShowVariants(step);
        return true;
    }

    /// <summary>
    /// Парсит полученные данные из консоли.
    /// </summary>
    /// <returns></returns>
    private int GetVariant()
    {
        var variant = ConsoleHelper.AskVariant();
        return int.Parse(variant);
    }

    /// <summary>
    /// Выводит сообщение о конце игры, и производит сохранение.
    /// </summary>
    private void Stop()
    {
        ConsoleHelper.GameStop();
        Game.Save();
    }
}