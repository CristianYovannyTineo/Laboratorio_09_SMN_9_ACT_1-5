// See https://aka.ms/new-console-template for more information

//Don Lucas tiene una bodega, y cada vez que un cliente entra a comprar, él anota en su cuaderno elproducto que se ha vendido de acuerdo a la categoría.
//La bodega ofrece a sus clientes cuatro (4) tipos de productos limpieza, abarrotes, golosinas, electrónicos.
//El señor Lucas le ha escrito a su correo electrónico y le solicita que Ud.
//Como estudiante de ingeniería que conoce de estos temas,le apoye con un programa que le permita llevar la contabilidad de sus cuatro categorías y le solicita lo siguiente


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //Parte 1
        var tienda = new TiendaDonLucas();
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("Tienda de Don Lucas");
            Console.WriteLine("=========================");
            Console.WriteLine("1: Registrar venta");
            Console.WriteLine("2: Registrar devolución");
            Console.WriteLine("3: Cerrar caja");
            Console.WriteLine("=========================");
            Console.Write("Ingrese una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    tienda.RegistrarVenta();
                    break;
                case 2:
                    tienda.RegistrarDevolucion();
                    break;
                case 3:
                    tienda.CerrarCaja();
                    break;
                default:
                    continuar = false;
                    break;
            }
        }
    }
}

class TiendaDonLucas
{
    public TiendaDonLucas()
    {
        productosVendidos["Limpieza"] = 0;
        productosVendidos["Abarrotes"] = 0;
        productosVendidos["Golosinas"] = 0;
        productosVendidos["Electrónicos"] = 0;

        productosDevueltos["Limpieza"] = 0;
        productosDevueltos["Abarrotes"] = 0;
        productosDevueltos["Golosinas"] = 0;
        productosDevueltos["Electrónicos"] = 0;

        inventario["Limpieza"] = 0;
        inventario["Abarrotes"] = 0;
        inventario["Golosinas"] = 0;
        inventario["Electrónicos"] = 0;

        cajaPorRubro["Limpieza"] = 0.0;
        cajaPorRubro["Abarrotes"] = 0.0;
        cajaPorRubro["Golosinas"] = 0.0;
        cajaPorRubro["Electrónicos"] = 0.0;
    }

    private Dictionary<string, int> productosVendidos = new Dictionary<string, int>();
    private Dictionary<string, int> productosDevueltos = new Dictionary<string, int>();
    private Dictionary<string, int> inventario = new Dictionary<string, int>();
    private Dictionary<string, double> cajaPorRubro = new Dictionary<string, double>();

    public void RegistrarVenta()
    {
        //Parte 2
        Console.Clear();
        Console.WriteLine("=========================");
        Console.WriteLine("Registrar Venta de:");
        Console.WriteLine("=========================");
        Console.WriteLine("1: Limpieza");
        Console.WriteLine("2: Abarrotes");
        Console.WriteLine("3: Golosinas");
        Console.WriteLine("4: Electrónicos");
        Console.WriteLine("5: <- Regresar");
        Console.WriteLine("=========================");
        Console.Write("Ingrese una opción: ");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion >= 1 && opcion <= 4)
        {
            string rubro = GetRubro(opcion);
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine($"Registrar Venta de {rubro}");
            Console.WriteLine("=======================");
            Console.Write("Ingrese cantidad (Unidades): ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Precio: $/");
            double precio = double.Parse(Console.ReadLine());

            productosVendidos[rubro] += cantidad;
            inventario[rubro] += cantidad;
            cajaPorRubro[rubro] += cantidad * precio;

            Console.Clear();
            Console.WriteLine($"Se han ingresado {cantidad} unidades");
            Console.WriteLine($"Se han ingresado $/{cantidad * precio} en caja");
            Console.WriteLine("=======================");
            Console.WriteLine("1: Registrar más productos de " + rubro);
            Console.WriteLine("2: <- Regresar");
            Console.WriteLine("=======================");
            Console.Write("Ingrese una opción: ");
            int seguir = int.Parse(Console.ReadLine());

            if (seguir == 1)
            {
                RegistrarVenta();
            }
        }
    }



    public void RegistrarDevolucion()
    {
        //Parte 3
        Console.Clear();
        Console.WriteLine("=======================");
        Console.WriteLine("Registrar Devolución de:");
        Console.WriteLine("=======================");
        Console.WriteLine("1: Limpieza");
        Console.WriteLine("2: Abarrotes");
        Console.WriteLine("3: Golosinas");
        Console.WriteLine("4: Electrónicos");
        Console.WriteLine("5: <- Regresar");
        Console.WriteLine("=======================");
        Console.Write("Ingrese una opción: ");
        int opcion = int.Parse(Console.ReadLine());


        //Parte 4 
        if (opcion >= 1 && opcion <= 4)
        {
            string rubro = GetRubro(opcion);
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine($"Registrar Devolución de {rubro}");
            Console.WriteLine("=======================");
            Console.Write("Ingrese cantidad (Unidades): ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Precio: $/");
            double precio = double.Parse(Console.ReadLine());

            productosDevueltos[rubro] += cantidad;
            inventario[rubro] -= cantidad;
            cajaPorRubro[rubro] -= cantidad * precio;
            //Parte 4.1
            Console.Clear();
            Console.WriteLine($"Se han regresado {cantidad} unidades");
            Console.WriteLine($"Se han devuelto $/{cantidad * precio} de caja");
            Console.WriteLine("=======================");
            Console.WriteLine("1: Devolver más productos de " + rubro);
            Console.WriteLine("2: <- Regresar");
            Console.WriteLine("=======================");
            Console.Write("Ingrese una opción: ");
            int seguir = int.Parse(Console.ReadLine());

            if (seguir == 1)
            {
                RegistrarDevolucion();
            }
        }
    } 

    private string GetRubro(int opcion)
    {
        switch (opcion)
        {
            case 1:
                return "Limpieza";
            case 2:
                return "Abarrotes";
            case 3:
                return "Golosinas";
            case 4:
                return "Electrónicos";
            default:
                return "";
        }
    }



    public void CerrarCaja()
    {
        //Parte 5
        Console.Clear();
        Console.WriteLine("=========================");
        Console.WriteLine("Cerrando Caja");
        Console.WriteLine("=========================");
        Console.WriteLine("Totales");
        Console.WriteLine("=========================");

        foreach (var rubro in productosVendidos.Keys)
        {
            Console.WriteLine($" {rubro,-9} | {productosVendidos[rubro],-2} vendidos");
            Console.WriteLine($" {"",-9} | {productosDevueltos[rubro],-2} devueltos");
            Console.WriteLine($" {"",-9} | {inventario[rubro],-2}  en total");
            Console.WriteLine($" {"",-9} | $/{cajaPorRubro[rubro],-2:f2} en caja");
            Console.WriteLine("=========================");
        }

        double totalCaja = cajaPorRubro.Values.Sum();
        Console.WriteLine("Queda en caja $/" + totalCaja.ToString("f2"));
        Console.ReadLine();
    }

}