
#region Cadenas
/*
string primerNombre = "James";
string apellido = "Aranda";

string mensaje = @$"Hola, me llamo {primerNombre} {apellido} y mi archivo es C:\Users\ejemplo.txt";

// Console.WriteLine(mensaje);
*/
#endregion


#region Numeros

/*
int num1, num2;

Console.WriteLine("Escribe el primer numero: ");
num1 = int.Parse(Console.ReadLine());

Console.WriteLine("Escribe el segundo numero: ");
num2 = int.Parse(Console.ReadLine());

decimal resultado = (decimal) num1 / num2;

Console.WriteLine($"El resultado de la operacion es: {resultado}");

*/

#endregion


#region if
/*
int x = 25;
int y = 25;

string mensajeIf = "";

if (x > y)
    mensajeIf = $"{x} es mayor a {y}";
else if (x < y)
    mensajeIf = $"{x} es mayor a {y}";
else 
    mensajeIf = $"{x} es mayor a {y}";

Console.WriteLine(mensajeIf);
*/
#endregion


#region switch
/*
string mensajeSwitch = "Berlin";


switch(mensajeSwitch){

    case "Monterrey":
    case "CDMX":
        mensajeSwitch = "Eres de Mexico";
        break;
    
    case "Miami":
        mensajeSwitch = "Eres de U.S.A.";
        break;
    
    default:
        mensajeSwitch = "Eres de otro pais";
        break;
}

Console.WriteLine(mensajeSwitch);
*/
#endregion


#region metodo
/*
decimal CalcularIva(decimal precio) => precio * 0.16m;

Console.WriteLine(CalcularIva(5000));
*/
#endregion


#region Arreglo y bucles
/*
int[] numeros = new int[3];

numeros[0] = 10;
numeros[1] = 40;
numeros[2] = 25;

for(int i = 0; i < numeros.Length; i++){
    Console.Write($"Escribe el elemento en la posicion {i+1}: ");
    numeros[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine($"Elementos de arreglos: ");

for(int i = 0; i < numeros.Length; i++){
    Console.WriteLine($"Elemento en la posicion {i+1}: {numeros[i]}");
}


int j = 0;

while (j < numeros.Length){
    Console.WriteLine($"Elemento en la posicion {j+1}: {numeros[j]}");
    j++;
}

do{
    Console.WriteLine($"Elemento en la posicion {j+1}: {numeros[j]}");
    j++;
}while(j < numeros.Length);
*/

#endregion


#region Listas y foreach
/*
List<string> nombres = new List<string>();

nombres.Add("Jose Perez");
nombres.Add("Maria Garza");
nombres.Add("Andres Sosa");
nombres.Add("Karla Solis");
nombres.Add("james Solis");
nombres.Add("Hector");

nombres.RemoveAt(1);

Console.WriteLine("Nombres en la lista: ");

foreach (string nombre in nombres){

    if (char.IsUpper(nombre,0) && nombre.Contains(" ") )
        Console.WriteLine(nombre);
}

*/

#endregion


#region Directorios y archivos



#endregion