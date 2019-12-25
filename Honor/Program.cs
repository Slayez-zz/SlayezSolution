using GameEngine;
using GameEngine.Systems.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            SystemManager.Initialize();
            RenderSystem.window.Run();
        }
    }
}
