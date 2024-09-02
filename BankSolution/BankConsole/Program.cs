using BankConsole;

if (args.Length == 0){
    EmailService.SendMail();
}else{
    ShowMenu();
}

void ShowMenu(){

    Console.Clear();
    Console.WriteLine("Selecciona una opcion: ");
    Console.WriteLine("1 - Clear Usuario nuevo.");
    Console.WriteLine("2 - Eliminar un usuario existente.");
    Console.WriteLine("3 - Salir.");

    int option = 0;

    do{
        string input = Console.ReadLine();

        if(!int.TryParse(input, out option)){
            Console.WriteLine("Debes ingresar un numero (1, 2 o 3). ");
        }else if (option > 3){
            Console.WriteLine("Debes Ingresar un numero valido");
        }
    }while(option == 0 || option > 3);

    switch (option)
    {
        case 1:
            CreateUser();
            break;
        
        case 2:
            DeleteUser();
            break;

        case 3:
            Environment.Exit(0);
            break;
    }
}

void CreateUser(){

        Console.Clear();
        int ID;
        decimal balance;
        char userType;
        string email;

        Console.WriteLine("Ingresa la informacion del usuario");

        do{
            do{
                Console.Write("ID: ");
                ID = int.Parse(Console.ReadLine());

                if(ID <= 0){
                    Console.WriteLine("Escriba un numero positivo");
                    Thread.Sleep(2000);
                }
            }while(ID<0);
            string result = Storage.UserExist(ID);

            if(result.Equals("ID Exist")){
                Console.Write("\nEl ID ya existe");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
                break;
        }while(true);
 
        Console.Write("Nombre: ");
        string name = Console.ReadLine();

        do{
            Console.Write("Email: ");
            email = Console.ReadLine();

            if(Storage.EmailCorrect(email)){
                break;
            }
        }while(true);

        do{
            Console.Write("Saldo: ");
            balance = decimal.Parse(Console.ReadLine());
            if(balance < 0 || balance.GetType() != typeof(decimal)){
                Console.Write("Debe ser un numero decimal positivo");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }while(balance < 0);

        do{
        Console.Write("Escribe 'c' si el usuario es un Cliente, 'e' si es un Empleado: ");
        userType = char.Parse(Console.ReadLine());
        if(userType.Equals('c'))
            break;
        if(userType.Equals('e'))
            break;
        
        Console.Write("Debe ingresar 'c' si el usuario es un Cliente, 'e' si es un Empleado");
        Thread.Sleep(2000);
        Console.Clear();

        }while(true);
        User newUser;
        
        if(userType.Equals('c')){
            char taxRegime = 'M';
            Console.Write($"Regime Fiscal: {taxRegime}");
            Thread.Sleep(2000);
            Console.Clear();

            newUser = new Client(ID, name, email, balance, taxRegime);

        }else{
            string department = "IT";
            Console.Write($"Department: {department}");
            Thread.Sleep(2000);
            Console.Clear();
            newUser = new Employee(ID, name, email, balance, department);
        }

        Storage.AddUser(newUser);

        Console.WriteLine("Usuario creado.");
        Thread.Sleep(2000);
        ShowMenu();
}


void DeleteUser(){

    int ID;
    do{        
    Console.Clear();

    do{
        Console.Write("Ingresa el ID del usuario a eliminar: ");
        ID = int.Parse(Console.ReadLine());
        if(ID < 0 || ID.GetType() != typeof(int)){
            Console.Write("Debe ingresar un numero positivo");
            Thread.Sleep(2000);
            Console.Clear();
        }else{
            break;
        }
    }while(true);

    string result = Storage.DeleteUser(ID);

    if (result.Equals("Success"))
    {
        Console.Write("Usuario eliminado");
        Thread.Sleep(2000);
        ShowMenu();
    }else{
        Console.WriteLine("ID no valido");
        Thread.Sleep(2000);
    }
    }while(true);
}


// Client james = new Client(1, "James", "james@gmail.com",4000, 'M');
// Employee pedro = new Employee(2, "Pedro", "pedro@gmail.com",4000, "IT");
// Client ana = new Client(3, "Ana", "ana@gmail.com",3000,'M');

// Console.WriteLine(james.ShowData());
// Console.WriteLine(pedro.ShowData());

// Storage.AddUser(james);
// Storage.AddUser(pedro);
// Storage.AddUser(ana);