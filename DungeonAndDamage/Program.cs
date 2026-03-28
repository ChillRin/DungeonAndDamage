namespace DungeonAndDamege;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Загрузка мира...");
        // Создание противников
        Enemy[] enemies = {
            new Enemy("Стая слизней", 20, 1, 1f),
            new Enemy("Большой слизень", 10, 4, 1.75f),
            new Enemy("Гоблин", 15, 5, 2f),
            new Enemy("Король гоблинов", 30, 10, 3f)
        };
        Console.WriteLine("- Противники загружены");
        
        // Создание колекции персонажей
        Teammate[] person_storage = {
            // Teamate object, cost float
            new Teammate("Мечник", 10, 5, 10, 0.5f),
            new Teammate("Лучник", 10, 1, 5, 0.5f),
            new Teammate("Щитовик", 10, 3, 20, 0.5f),
        };
        Console.WriteLine("- В таверне новые посетители...");
        
        // Создание JSON парсера
        JSONer JSONer = new JSONer();
        Console.WriteLine("- Прибыл волшебник читающий мысли...");
        
        
        // Приветствие с игроком
        Player player = (Player)JSONer.LoadPerson();
        if (player != null) {
            Console.WriteLine("[неизвестный] Приветствую тебя путник {0}! Твоя команда ожидала тебя", player.Name);
        }
        else {
            Console.Write("[неизвестный] Приветствую тебя незнакомец!\n[неизвестный] Желаешь остановиться у нас на пару деньков? (да/нет) ");
            string input = Console.ReadLine();
            bool user_choice = input.ToLower() == "да";
            if (user_choice) {
                Console.Write("[неизвестный] Ну тогда назови своё имя: ");
                string name = Console.ReadLine();
                player = new Player(name);
                Console.WriteLine("[неизвестный] Добро пожаловать к нам {0}!",  player.Name);
                JSONer.SavePerson(player);
            }
        }
        
        // Главный цикл игры
        string[] locations = new string[] {"Главная площадь", "Таверна", "Больница", "Церковь", "Ворота" };
        byte current_location = 0;

        string[] map = new string[] { "Поля", "Склизкая пещера", "Лес", "Пристанище гоблинов", "Пещера драконов" };
        byte current_map = 0;
        
        int userChoice;
        bool work = true;
        while (work) {
            Console.WriteLine("\nВы находитесь в локации {0}", locations[current_location]);
            if (current_location == 0) {
                Console.Write("Выберите действие:\n1. Передвижение\n2. Осмотреться\n99. Выход\nВыбор >> ");
                try {userChoice = int.Parse(Console.ReadLine());}
                catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                if (userChoice == 1) {
                    Console.Write("Выберите место куда вы собираетесь пойти" +
                                      "\n1. Таверна" +
                                      "\n2. Лекарь" +
                                      "\n3. Церковь" +
                                      "\n4. Ворота" +
                                      "\nВыбор >> ");
                    
                    try {userChoice = int.Parse(Console.ReadLine());}
                    catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                    if (userChoice < 0 & userChoice > locations.Length - 1) {
                        Console.WriteLine("Нет такой локации!");
                        continue;
                    }
                    else {
                        current_location = (byte)userChoice;
                        continue;
                    }
                    
                } else if (userChoice == 2) {
                    Console.WriteLine("В вашем кармане {0} золотых\nВаша команда:", player.Gold);
                    
                    if (player.teammates.Count == 0) {
                        Console.WriteLine("Список ваших союзников пуст!\nПройдите в таверну и завербуйте парочку");
                        continue;
                    }
                    
                    for (int i = 0; i < player.teammates.Count; i++) {
                        if (player.teammates[i] == null) {
                            Console.WriteLine("Слот {0}: Пусто", i);
                        }
                        else {
                            Console.WriteLine("Слот {0}: {1}, Здоровье: {2}/{3}, Броня: {4}/{5} Урон от оружия: {6}, Зарплата: {7}", i, 
                                player.teammates[i].Name, 
                                player.teammates[i].Health, 
                                player.teammates[i].MaxHealth,
                                player.teammates[i].Armour,
                                player.teammates[i].MaxArmour,
                                player.teammates[i].Damage,
                                player.teammates[i].Salary);
                        }
                    }
                } else if (userChoice == 99) {
                    Console.WriteLine("До скорых встреч!");
                    JSONer.SavePerson(player);
                    work = false;
                }
                else if(userChoice == 69) {
                    player.Gold += 1000f;
                }
                
            } else if(current_location == 1){
                Console.Write("Вы дошли до таверны!\nВ ней много людей но среди них есть выделяющиеся\nВыберите действие:\n1. Осмотреться\n2. Уйти" +
                              "\nВаше действие >> ");
                
                try {userChoice = int.Parse(Console.ReadLine());}
                catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                if (userChoice == 1) {
                    Console.WriteLine(
                        "Вы видите нескольких умелых бойцов и все они готовы с вами поговорить\nВыберите с кем будите общаться:");
                    for (byte i = 0; i < person_storage.Length; i++) {
                        Console.WriteLine("{0}. {1}", i+1, person_storage[i].Name);
                    }
                    Console.Write("Выберите собеседника >> ");

                    int choisenTeammate;
                    try {choisenTeammate = int.Parse(Console.ReadLine());}
                    catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                    Console.WriteLine(choisenTeammate - 1);
                    
                    if (choisenTeammate - 1 >= 0 & choisenTeammate - 1 < person_storage.Length - 1) {
                        choisenTeammate -= 1;
                        Console.WriteLine("Вы подошли к {0} и увидели его характеристики" +
                                          "\nЗдоровье: {1}" +
                                          "\nБроня: {2}" +
                                          "\nАтака: {3}" +
                                          "\nЗа свою работу он просит: {4}",
                            person_storage[choisenTeammate].Name,
                            person_storage[choisenTeammate].Health,
                            person_storage[choisenTeammate].Armour,
                            person_storage[choisenTeammate].Damage,
                            person_storage[choisenTeammate].Salary * 2);
                        
                        Console.Write("Вы задумчиво на него посматрели и решили:" +
                                      "\n1. Нанять" +
                                      "\n2. Уйти" +
                                      "\nВаш выбор >> ");
                        
                        try {userChoice = int.Parse(Console.ReadLine());}
                        catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                        if (userChoice == 1) {
                            if (player.Gold < person_storage[choisenTeammate].Salary * 2) {
                                Console.WriteLine("В вашем кармане нет стольбко золота для найма!");
                                continue;
                            }
                            
                            Console.Write("Боец согласен участвовать в сражениях с вами!" +
                                              "\nДайте ему имя: ");
                            string teammate_name = Console.ReadLine();
                            
                            player.teammates.Add(new Teammate(teammate_name, person_storage[choisenTeammate].Health, person_storage[choisenTeammate].Damage, person_storage[choisenTeammate].Armour, person_storage[choisenTeammate].Salary));
                            Console.WriteLine("Вы заплатили ему {0} золотых и теперь он находится в вашей армии!", person_storage[choisenTeammate].Salary * 2);
                            
                            player.Salary(- person_storage[choisenTeammate].Salary * 2);
                        }
                    }
                    else {
                        Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); 
                        continue;
                    }
                }
                else if(userChoice == 2) {
                    Console.WriteLine("Вы покинули таверну");
                    current_location = 0;
                }
                else {
                    Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); 
                    continue;
                }
            } else if (current_location == 2) {
                Console.Write("Вы заходите в лечебницу, в нос ударил сильный запах спирта, а на входе вас встретил врач\n" +
                              "Выберите действие:\n" +
                              "1. Лечение\n" +
                              "2. Уйти\n" +
                              "Выбор >> ");
                try {userChoice = int.Parse(Console.ReadLine());}
                catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                if (userChoice == 1) {
                    if (player.teammates.Count == 0) {
                        Console.WriteLine("В вашем отряде нет бойцов!");
                        continue;
                    }
                    
                    Console.WriteLine("Выберите бойца которого хотите излечить:");
                    for (int i = 0; i < player.teammates.Count; i++) {
                        if (player.teammates[i] == null) {
                            Console.WriteLine("Слот {0}: Пусто", i);
                        }
                        else {
                            Console.WriteLine("Слот {0}: {1}, Здоровье: {2}/{3}", i, 
                                player.teammates[i].Name, 
                                player.teammates[i].Health, 
                                player.teammates[i].MaxHealth);
                        }
                    }
                    Console.Write("Выбор >> ");

                    byte healChoice;
                    try {healChoice = byte.Parse(Console.ReadLine());}
                    catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}
                    
                    Console.Write("Лечение обойдется в 1 золотой\nЛечить?\n1. Лечить\n2. Уйти\nВыбор >>");

                    byte healConfirm;
                    try {healConfirm = byte.Parse(Console.ReadLine());}
                    catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                    if (healChoice == 1) {
                        if (player.Gold < 1f) {
                            Console.WriteLine("В вашем кармане нет стольбко золота!");
                            continue;
                        }
                        player.Salary(-1f);
                        int toHeal = player.teammates[healChoice].MaxHealth - player.teammates[healChoice].Health;
                        player.teammates[healChoice].Heal(toHeal);
                        
                        Console.WriteLine("Персонаж {0} был вылечен на {1} едениц", player.teammates[healChoice].Name, toHeal);
                    } if(userChoice == 2) {
                        continue;
                    }
                    else {
                        Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); 
                        continue;
                    }
                }
                else if(userChoice == 2) {
                    Console.WriteLine("Вы покинули больницу");
                    current_location = 0;
                    break;
                }
                else {
                    Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); 
                    continue;
                }
            } else if (current_location == 3) {
                Console.Write("Вы заходите в старое здание, где по середине видите людей \n" +
                              "в старых балахонах и бормочащих на непонятном вам языке,\n" +
                              "Кажется что они могут вам чемто помочь." +
                              "\n1. Возрадить персонажа" +
                              "\n2. Уйти" +
                              "\nВыбор >> ");
                try {userChoice = int.Parse(Console.ReadLine());}
                catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                if (userChoice == 1) {
                    List<Teammate> tempDeath = new List<Teammate>();

                    foreach (Teammate mate in player.teammates) {
                        if (!mate.Alive) {
                            tempDeath.Add(mate);
                            
                        }
                    }

                    if (tempDeath.Count == 0) {
                        Console.WriteLine("Все ваши бойцы живы!");
                        continue;
                    }
                    
                    Console.WriteLine("Жрецы предлагают ожиаить бойца за 5 золотых:");
                    for (int i = 0; i < tempDeath.Count; i++) {
                        Console.Write("{0}. {1}", i+1, tempDeath[i].Name);
                    }
                    Console.WriteLine("Выбор >> ");

                    int respMate;
                    try {respMate = int.Parse(Console.ReadLine()) - 1;}
                    catch {Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); continue;}

                    if (respMate < 0 || respMate > tempDeath.Count - 1) {
                        Console.WriteLine("Нет такого бойца!");
                        continue;
                    }

                    if (player.Gold < 5) {
                        Console.WriteLine("В вашем кармане нет стольбко золота!");
                        continue;
                    }
                    
                    player.Salary(-5);
                    int index = player.teammates.IndexOf(tempDeath[respMate]);
                    player.teammates[index].Alive = true;
                    
                    Console.WriteLine("Боец {0} был возражден", player.teammates[index].Name);
                    continue;
                    
                } else if(userChoice == 2) {
                    Console.WriteLine("Вы покинули церковь");
                    current_location = 0;
                    break;
                }
                else {
                    Console.WriteLine("Ваш выбор не правильный! Попробуйте ввести число заново."); 
                    continue;
                }
            } else if (current_location == 4) {
                if (player.teammates.Count == 0) {
                    Console.WriteLine("В вашем отряде нет бойцов, идите в таверну и наймите их!");
                    current_location = 0;
                }
                
                
            }
        }
    }
}