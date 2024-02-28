using System;

class Program
{
    static long CalcularFactorial(int numero)
    {
        long factorial = 1;
        for (int i = 1; i <= numero; i++)
        {
            factorial *= i;
        }
        return factorial;
    }

    static double CalcularRaizCuadrada(int numero)
    {
        return Math.Sqrt(numero);
    }

    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Calcular el factorial de un número.");
                Console.WriteLine("2. Calcular la raíz cuadrada de un número.");
                Console.WriteLine("3. Jugar a adivinar un número secreto.");
                Console.WriteLine("4. Salir del programa.");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese un número entero positivo: ");
                        int numeroFactorial = Convert.ToInt32(Console.ReadLine());
                        if (numeroFactorial <= 0)
                        {
                            Console.WriteLine("Por favor, ingrese un número entero positivo.\n");
                            continue;
                        }
                        long factorial = CalcularFactorial(numeroFactorial);
                        Console.WriteLine($"El factorial de {numeroFactorial} es: {factorial}\n");
                        break;
                    case "2":
                        Console.Write("Ingrese un número entero positivo: ");
                        int numeroRaiz = Convert.ToInt32(Console.ReadLine());
                        if (numeroRaiz <= 0)
                        {
                            Console.WriteLine("Por favor, ingrese un número entero positivo.\n");
                            continue;
                        }
                        double raizCuadrada = CalcularRaizCuadrada(numeroRaiz);
                        Console.WriteLine($"La raíz cuadrada de {numeroRaiz} es: {raizCuadrada}\n");
                        break;
                    case "3":
                        JugarAdivinanza();
                        break;
                    case "4":
                        Console.WriteLine("¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.\n");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Por favor, ingrese un número entero válido.\n");
            }
        }
    }

    static void JugarAdivinanza()
    {
        Random random = new();
        int numeroSecreto = random.Next(1, 101);
        int intentos = 0;

        Console.WriteLine("¡Bienvenido al juego de adivinar el número secreto!");
        Console.WriteLine("El número secreto está entre 1 y 100.\n");

        while (true)
        {
            Console.Write("Introduce un número: ");
            int numeroUsuario;

            if (!int.TryParse(Console.ReadLine(), out numeroUsuario) || numeroUsuario < 1 || numeroUsuario > 100)
            {
                Console.WriteLine("Por favor, introduce un número válido entre 1 y 100.");
                continue;
            }

            intentos++;

            if (numeroUsuario == numeroSecreto)
            {
                Console.WriteLine($"¡Felicidades! Has adivinado el número secreto {numeroSecreto} en {intentos} intentos.");
                break;
            }
            else if (numeroUsuario < numeroSecreto)
            {
                Console.WriteLine("El número secreto es mayor.");
            }
            else
            {
                Console.WriteLine("El número secreto es menor.");
            }
        }
    }
}
