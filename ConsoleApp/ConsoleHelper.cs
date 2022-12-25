using TextQuest;

namespace ConsoleApp;

/// <summary>
/// Класс отображения данных в консоль.
/// </summary>
public class ConsoleHelper: IShowInterface
{
    /// <summary>
    /// Выводит на консоль тест хода.
    /// </summary>
    /// <param name="step"></param>
    public void ShowStep(Step step)
    {
        Console.WriteLine("--------------------");
        Console.WriteLine(step.Text);
    }
    
    public void GameStop()
    {
        Console.WriteLine("Конец");
    }
    
    /// <summary>
    /// Выводит текст каждого варианта.
    /// </summary>
    /// <param name="step"></param>
    public void ShowVariants(Step step)
    {
        Console.WriteLine("--------------------");
        foreach (var stepVariant in step.Variants)
        {
            Console.WriteLine(stepVariant.Text);
        }
    }
    
    /// <summary>
    /// Зарпашивает ввод для загрузки сохранения.
    /// </summary>
    /// <returns></returns>
    public string AskLoadSave()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("Хотите начать с последнего сохранения?");
        Console.WriteLine("Нажмите 1");

        return Console.ReadLine();
    }
    
    /// <summary>
    /// Запрашивает ввод следующего действия.
    /// </summary>
    /// <returns></returns>
    public string AskVariant()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Какое ваше следующие действие?");

        return Console.ReadLine();
    }
}