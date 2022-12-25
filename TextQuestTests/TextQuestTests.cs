using TextQuest;

namespace TextQuestTests;

public class TextQuestTests
{
    /// <summary>
    /// Тест, который доходит до донца игры и проверяет, на наличие пустых вариантов в ходе.
    /// </summary>
    [Fact]
    public void NextStepGetNull()
    {
        var game = new Game();
        Step step;
        do
        {
            step = game.NextStep(1);
            if (step.Variants == null)
            {
                break;
            }
        } while (true);
        
        Assert.Null(step.Variants);
    }
    
    /// <summary>
    /// Проверяет, что указанный вариант не найден.
    /// </summary>
    [Fact]
    public void NextStepIsNotCurrentVariant()
    {
        var game = new Game();
        var boo = game.IsCurrentVariant(10);
        
        Assert.False(boo);
    }
    
    /// <summary>
    /// Проверяет, что указанный вариант найден
    /// </summary>
    [Fact]
    public void NextStepIsCurrentVariant()
    {
        var game = new Game();
        var boo = game.IsCurrentVariant(1);
        
        Assert.True(boo);
    }
}