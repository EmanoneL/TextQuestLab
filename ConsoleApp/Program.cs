using ConsoleApp;

Console.Clear();
Console.WriteLine($"Добро пожаловать в Text quest 10");
Console.WriteLine($"Если хотите выйти из игры, нажмите '0' в любое время.");
Console.WriteLine($"Запустить игру? Нажмите enter");
Console.ReadLine();

var gameMaster = new GameMaster();
gameMaster.Start();

Console.ReadLine();