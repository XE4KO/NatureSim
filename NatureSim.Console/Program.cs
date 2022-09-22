﻿using System;
using System.Collections.Generic;

namespace NatureSim.Console
{
	partial class Program
    {
        //!!!!!ask about how to make foods give different health using records!!!!!
        static void Main(string[] args)
        {
            Map map = new Map();
            map.GenerateMap(5,10);
            List<Animal> animals = new List<Animal>() {
                new Bunny(),
                new Wolf(),
                new Bear(),
                new Cat(),
                new Lion(),
                new Bunny(),
                new Wolf(),
                new Bear(),
                new Cat(),
                new Lion()
            };

            List<Animal> aliveAnimals;
            do
            {
                aliveAnimals = new List<Animal>();
                foreach (var animal in animals)
                {
                    var animalCurrentTile = map[animal.coordsX, animal.coordsY];
                    animal.Eat(animalCurrentTile.FindFood());
                    animal.Move();
                    if (animal.IsAlive)
                    {
                        aliveAnimals.Add(animal);
                    }
                }
                animals = aliveAnimals;
            } while (aliveAnimals.Count > 0);
        }
    }
}
