
int[] total_retiros = new int[10];

void cantidad_retiros(int retiros){

    for (int i = 0; i < retiros; i++){
        do{
            Console.WriteLine($"Ingrese la cantidad del retiro #{i+1}: ");
            total_retiros[i] = int.Parse(Console.ReadLine());
            if(total_retiros[i] < 0 || total_retiros[i] > 50000 || es_entero(total_retiros[i]) != 1){
                Console.WriteLine("\nIngrese una cantidad valida\n");
            }
        }while(total_retiros[i] < 0 || total_retiros[i] > 50000 || es_entero(total_retiros[i]) != 1);
        
    }
}

int es_entero(double num) {

    if (num == (int)num) {
        return 1;  // Es un entero
    } else {
        return 0;  // No es un entero
    }
}

// Variables para el dinero
int[] b500 = new int[10];
int[] b200 = new int[10];
int[] b100 = new int[10];
int[] b50 = new int[10];
int[] b20 = new int[10];

int[] m10 = new int[10];
int[] m5 = new int[10];
int[] m1 = new int[10];

int[] new_saldo = new int[10];

void Conteo_billetes(int retiro){

    for (int i = 0; i < retiro; i++){
        Console.WriteLine($"Retiro #{i+1}: ");

        new_saldo[i] = total_retiros[i];
        if(new_saldo[i] >= 500){
            b500[i] = total_retiros[i] / 500;
            new_saldo[i] = total_retiros[i] % 500;
        }

        if(new_saldo[i] >= 200){
            b200[i] = new_saldo[i] / 200;
            new_saldo[i] = new_saldo[i] % 200;
        }

        if(new_saldo[i] >= 100){
            b100[i] = new_saldo[i] / 100;
            new_saldo[i] = new_saldo[i] % 100;
        }


        if(new_saldo[i] >= 50){
            b50[i] = new_saldo[i] / 50;
            new_saldo[i] = new_saldo[i] % 50;
        }

        if(new_saldo[i] >= 20){
            b20[i] = new_saldo[i] / 20;
            new_saldo[i] = new_saldo[i] % 20;
        }

        if(new_saldo[i] >= 10){
            m10[i] = new_saldo[i] / 10;
            new_saldo[i] = new_saldo[i] % 10;
        }

        if(new_saldo[i] >= 5){
            m5[i] = new_saldo[i] / 5;
            new_saldo[i] = new_saldo[i] % 5;
        }

        m1[i] = new_saldo[i];

        Console.WriteLine($"Billetes entregados: {b500[i]+b200[i]+b100[i]+b50[i]+b20[i]}");
        Console.WriteLine($"Monedas entregadas: {m10[i]+m5[i]+m1[i]}\n");
    }

}


void Impresion_billetes(int retiro){

    for (int i = 0; i < retiro; i++){
        Console.WriteLine($"Retiro #{i+1}: ");

        Console.WriteLine("Billetes: ");
        Console.WriteLine($"500: {b500[i]}");
        Console.WriteLine($"200: {b200[i]}");
        Console.WriteLine($"100: {b100[i]}");
        Console.WriteLine($"50: {b50[i]}");
        Console.WriteLine($"20: {b20[i]}");

        Console.WriteLine("\nMonedas: ");
        Console.WriteLine($"10: {m10[i]}");
        Console.WriteLine($"5: {m5[i]}");
        Console.WriteLine($"1: {m1[i]}");
    }

}



Console.WriteLine("---------------------Banco CDIS-----------------------");

// Variables

int opcion = 0;
bool salir = false;
int retiros = 0;

do{

    Console.WriteLine("1. Ingresar la cantidad de retiros por los usuarios.");
    Console.WriteLine("2. Revisar la cantidad entregada de billetes y monedas.");
    Console.WriteLine("3. Salir\n");

    do{ 
        Console.Write("Ingresa la opcion: ");
        opcion = int.Parse(Console.ReadLine());
        if (opcion == 3){
            salir = true;
            break;
        }
        if (opcion < 1 || opcion > 2){
            Console.WriteLine("Ingrese una opcion valida");
        } 
    }while(opcion < 1 || opcion > 2);



// Menu de opciones (Proceso mediante funciones)
switch(opcion){
    case 1:
        
        do{
            Console.WriteLine("¿Cuantos retiros se hicieron (maximo 10)? ");
            retiros = int.Parse(Console.ReadLine());
            if(retiros < 1 || retiros > 10 ){
                Console.WriteLine("Ingrese una opcion valida");
            }
        }while(retiros < 1 || retiros > 10);

        cantidad_retiros(retiros);

        break;

    case 2:

        Conteo_billetes(retiros);

        Console.WriteLine("Quieres ver la cantidad de billetes y monedas por separado?");
        Console.WriteLine("1. Si");
        Console.WriteLine("2. No\n");

        opcion = int.Parse(Console.ReadLine());

        if(opcion == 1){
            Impresion_billetes(retiros);
        }

        break;
}


}while (salir == false);