# FPSZombies

FPSZombies is an under-construction Unity game project that focuses on first-person shooting gameplay with zombie enemies. This README provides an overview of the project and includes information on gameplay mechanics, enemy AI, and health/damage systems.

## Gameplay Mechanics

The current implemented gameplay mechanics include:

- Walking: The player character can move around the game world at a normal walking pace.
- Running: The player character can sprint for faster movement speed.
- Shooting: The player can fire weapons to attack enemies.
- Reloading: The player can reload their weapons when ammunition is depleted.
- Sound and Animation: Walking sound effects and animations are implemented for the player character.
- Gunfire and Reload Sounds: Sound effects are implemented for shooting and reloading actions.

## Enemy AI

The game features basic enemy AI for the zombie enemies. The following AI behaviors are implemented:

- Enemy Spawning: Zombies are spawned in the game world at predefined points or through random generation.
- Enemy Movement: Zombies exhibit basic movement patterns, including patrolling between waypoints, following the player when in range, and searching for the player if they lose sight.
- Enemy Attack: Zombies have different attack behaviors, such as melee attacks or ranged attacks.
- Health and Damage: Each enemy has a health value, and they take damage when attacked by the player. Defeat conditions are triggered when the enemy's health reaches zero or falls below a threshold.

## Health and Damage Systems

The health and damage systems in the game include:

- Enemy Health: Each enemy has a health value that represents the amount of damage they can withstand.
- Damage Calculation: Damage to enemies is calculated based on player attacks, considering factors like weapon type, distance, or critical hits.
- Defeat Condition: When an enemy's health reaches zero or falls below a threshold, it is defeated, triggering appropriate actions such as defeat animations, loot spawning, or point rewards.
- Player Health: The player character has a health value, which is reduced when attacked by enemies.
- Game Over Condition: If the player's health reaches zero or falls below a certain threshold, the game over sequence is triggered.

## Contributing

This project is currently under construction, and contributions are not being accepted at this time. However, feel free to clone the repository and explore the code.

## License

[MIT License](LICENSE)

