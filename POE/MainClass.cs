using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE {
    /// <summary>
    /// MainClass Its the class that holds the main method
    /// </summary>
    internal class MainClass {
        /// <summary>
        /// This is the Main method/Entry Point into the application
        /// </summary>
        /// <param name="args">All command Line arguments</param>
        public static void Main(string[] args) {
            if (args.Length == 0) { //Check for no args
                //If no args run app normally
                new Application().RunApp();
            } else if (args.Length == 1 && args[0].ToLower() == "init-class-debug") { // if 1 arg
                //Arg == init-class-debug
                //Run the debug method for the application
                //Will have a predefined class and app state!
                new Application().RunDebug();
            } else {
                //Else someone is messing with me and i ive them issues! :D
                Console.Write("An attempt to break the application has been detected\n");
                Console.WriteLine("Nice try! UwU");
            }
        }
    }
}