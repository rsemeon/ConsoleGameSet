﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameSet
{
    abstract class ConsoleGame
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ConsoleGame(string name, string description) {
            Name = name;
            Description = description;
        }

        public abstract void ResetGame();

        public abstract void NextMove();

        public abstract void Draw();

        public abstract bool IsGameOver();

    }
}
