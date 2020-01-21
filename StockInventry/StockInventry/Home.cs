/*
 * Class:   Home
 * Version:  1.0.0.0
 * Date:   16/01/2020
 * Author:   Vignesh L G
 * Title:   Online Inventory and Billing System
 */
using System;
namespace StockInventry
{
    class Home
    {
        static void Main(string[] args)//Main Method
        {
            InterfaceHandler interfaceHandler = new InterfaceHandler();//Creating object for the class
            interfaceHandler.InterfaceController();//Calling the method from the class using object as reference
            Console.Read();
        }
    }
}
