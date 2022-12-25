using System.Runtime.Serialization.Json;

namespace TextQuest;

/// <summary>
/// Класс в котором находятся все данные и логика игры.
/// </summary>
[Serializable]
public class Game
{
    /// <summary>
    /// Указатель текущего хода.
    /// </summary>
    private int CurrentStep { get; set; }
    
    /// <summary>
    /// Список всех ходов.
    /// </summary>
    private List<Step> Steps { get; set; }

    public Game()
    {
        CurrentStep = 1;
        Steps = new List<Step>
        {
            new Step()
            {
                Id = 1,
                Text = "Ты очнулся посреди поля.",
                Variants = new List<Variant>
                {
                    new Variant
                    {
                        NextStep = 2,
                        Text = "Осмотреться"
                    },
                    new Variant
                    {
                        NextStep = 5,
                        Text = "Сделать заднее сальто"
                    }
                }
            },
            new Step()
            {
                Id = 2,
                Text = "Вы поняли что находитесь в лесу в центре небольшой поляны.",
                Variants = new List<Variant>
                {
                    new Variant
                    {
                        NextStep = 3,
                        Text = "Пойти на восток"
                    },
                    new Variant
                    {
                        NextStep = 4,
                        Text = "Ждать ночи"
                    }
                }
            },
            new Step()
            {
                Id = 3,
                Text = "Ты пришел в Китай."
            },
            new Step()
            {
                Id = 4,
                Text = "Ночью тебя сьели волки."
            },
            new Step()
            {
                Id = 5,
                Text =
                    "Ты пытаешься сделать заднее сальто, но в самый ответственный момент перед тем как оттолкнуться от земли ты поскользнулся и ударился головой об булыжник. Ты умер.",
                Variants = new List<Variant>
                {
                    new Variant
                    {
                        NextStep = 6,

                        Text = "Вознестись"
                    }
                }
            },
            new Step()
            {
                Id = 6,
                Text =
                    "Ты открываешь глаза и видишь своего отца, который ушел 15 лет назад в магазин. Ты понимаешь, что оказался в аду..."
            }
        };
    }
    
    /// <summary>
    /// Возвращает первый ход.
    /// </summary>
    /// <returns></returns>
    public Step StartGame()
    {
        var step = Steps.FirstOrDefault(s => s.Id == CurrentStep);
        return step;
    }

    /// <summary>
    /// Возвращает следующий ход, выбранный одним из вариантов.
    /// Устанавливает значение step следующего хода в CurrentStep.  
    /// </summary>
    /// <param name="variant">Вариант хода.</param>
    /// <returns>Следующий ход.</returns>
    public Step NextStep(int variant)
    {
        var variantt = Steps.FirstOrDefault(s => s.Id == CurrentStep).Variants[variant - 1];
        var step = Steps.FirstOrDefault(s => s.Id == variantt.NextStep);
        CurrentStep = step.Id;

        return step;
    }

    /// <summary>
    /// Проверяет что выбранный вариант существует в текущем ходу.
    /// </summary>
    /// <param name="variant">Вариант хода.</param>
    /// <returns></returns>
    public bool IsCurrentVariant(int variant)
    {
        var step = Steps.FirstOrDefault(s => s.Id == CurrentStep);
        if (step.Variants.Count < variant)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Сохраняет текущее состояние обьекта.
    /// </summary>
    public void Save()
    {
        using (FileStream fs = new FileStream("game.json", FileMode.OpenOrCreate))
        {
            var js = new DataContractJsonSerializer(GetType());
            js.WriteObject(fs, this);
            Console.WriteLine("Игра сохранена.");
        }
    }

    /// <summary>
    /// Загружает сохраненное состояние обьекта.
    /// </summary>
    /// <returns></returns>
    public Game Looding()
    {
        using (FileStream fs = new FileStream("game.json", FileMode.OpenOrCreate))
        {
            var js = new DataContractJsonSerializer(GetType());
            var game = js.ReadObject(fs);

            Console.WriteLine("Сохранение загружено.");
            return (Game) game;
        }
    }
}