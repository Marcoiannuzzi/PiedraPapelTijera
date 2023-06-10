//Se entrega por grupo al mail academynet@bdtglobal.com
//Como siempre si el profesor sube la clase y el enunciado difiere en alguna parte, tiene prioridad la consigna del profesor.
//Hacer un juego - Piedra, papel o tijera MODO TORNEO

//Preguntar cuantos jugadores juegan (MAX 10) y sus nombres
//Preguntar cuantas veces cada jugador va a jugar contra la máquina (cuantos tiros)
//Al final se comparan los puntos de cada jugador

//Utilizar módulos temáticos, ciclos, procedimientos y funciones, generar número random.
//----------------------------------------------------------------------------------------------------
//RESULTADOS A MOSTRAR

//- Cada ronda debe decir quien ganó

//- Mostrar cantidad de victorias, empates y derrotas contra la máquina
//- En base al punto anterior saber si ganamos, empatamos o perdimos contra la máquina en total
//- Mostrar puntaje final después de las tiradas a cada jugador

//- En modo torneo mostrar en orden de mayor a menor todos los puntajes
//- Mostrar ganador
//----------------------------------------------------------------------------------------------------
//DETALLES

//Puntaje:
//Victoria: 2 pts - Empate: 0 pts - Derrota: -1 pts


//Es obvio pero anoto:
//Papel gana a Piedra, Piedra gana a Tijera, Tijera gana a Papel

//El usuario debe ingresar la inicial, ejemplo:
//Papel = P
//Piedra = R
//Tijera = T


int jugadores;
int cantTiros;
string[] vNombres;
int[] vPuntos;


void Jugar()
{
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("Juguemos Piedra, Papel o Tijera!!");
    jugadores = IngresarJugadores();
    cantTiros = IngresarTiros();
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("Comencemos!!");

    for (int i = 0; i < vNombres.Length; i++)
    {
        int tiros = cantTiros;
        int puntaje = 0;
        while(tiros >0 )
        {
            Console.WriteLine($"{vNombres[i]}, Tiro N° {tiros}: ¿Piedra, Papel o Tijera? (R/P/T)");
            var res = Responder();
            var resMaquina = GenerarRespuesta();
            puntaje += CalcularPuntos(res, resMaquina);
            Console.WriteLine();
            Console.WriteLine($"Tu puntaje al momento es de {puntaje}");
            tiros--;
        }
        vPuntos[i] += puntaje;
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"{vNombres[i]}, tu puntaje total es de {vPuntos[i]} puntos.");
        Console.WriteLine("---------------------------------------------------------");
    }

    MostrarTotales(vPuntos, vNombres);
}

void MostrarTotales(int[] arr, string[] arr2)
{
    int max = 0;
    int indice = 0;
    for (int i = 0; i < arr.Length ; i++)
    {
        if (arr[i] > max)
        {
            max = arr[i];
            indice = i;
        }
    }
    Array.Sort(arr);
    Console.WriteLine($"El Ganador es {arr2[indice]} con {max} puntos, Felicitaciones!!");
    Console.WriteLine("Estos son los puntajes totales: ");
    for (int i = 0;i < arr.Length ; i++)
    {
        Console.WriteLine(arr[i]);
    }

}

int GenerarRespuesta()
{
    var rnd = new Random();
    var num = rnd.Next(1, 4);
    Console.WriteLine($"Maquina: {(num==1?"Piedra":((num == 2)?"Papel":"Tijera"))}");
    return num;
}

string Responder()
{
    var res = Console.ReadLine().ToUpper();
    while(res.ToUpper() != "R" && res.ToUpper() != "P" && res.ToUpper() != "T"){
        Console.WriteLine("La respuesta es incorrecta, vuelva a ingresar");
        res = Console.ReadLine();
    }
   
    return res;
}

int CalcularPuntos(string res, int resMaquina)
{
    int num;
    if ((res=="R" && resMaquina==3) || (res == "P" && resMaquina == 1) || (res == "T" && resMaquina == 2))
    {
        Console.WriteLine("Felicitaciones, Ganaste!!");
        num = 2;
    }
    else if((res == "R" && resMaquina == 2) || (res == "P" && resMaquina == 3) || (res == "T" && resMaquina == 1))
    {
        Console.WriteLine("Perdedoooor! JAJAJA");
        num = -1;
    }
    else
    {
        Console.WriteLine("Nada para nadie!");
        num = 0;
    }
    return num;
}

int IngresarTiros()
{
    Console.WriteLine("Cuantos tiros tendra cada jugador?? Máximo 10");
    var cant = Console.ReadLine();
    var res = int.TryParse(cant, out int tiros);
    while (!res || !(tiros >= 1 && tiros <= 10))
    {
        Console.WriteLine("Respuesta invalida, vuelva a ingresar un numero entre 1 y 10");
        cant = Console.ReadLine();
        res = int.TryParse(cant, out tiros);
    }
    return tiros;
}

int IngresarJugadores()
{
    Console.WriteLine("Cuantos son los jugadores?? Máximo 10");
    var cant = Console.ReadLine();
    var res = int.TryParse(cant, out jugadores);
    while (!res || !(jugadores >= 1 && jugadores <= 10))
    {
        Console.WriteLine("Respuesta invalida, vuelva a ingresar un numero entre 1 y 10");
        cant = Console.ReadLine();
        res = int.TryParse(cant, out jugadores);
    }
    vNombres = new string[jugadores];
    vPuntos = new int[jugadores];
    IniciarJugadores(vNombres, vPuntos);
    return jugadores;
}

void IniciarJugadores(string[] arr, int[] arr2)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine($"Por favor ingrese el nombre del jugador numero: {i+1}");
        var nombre = Console.ReadLine();
        arr[i] = nombre;
        arr2[i] = 0;
    }
}

Jugar();