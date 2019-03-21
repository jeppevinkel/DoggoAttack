# DoggoAttack
Plugin for SCP:SL that adds a new server event.

This is an event where the mission of Class D is to escape the facility by any means necessary. One escaped Class D is a victory to Class D.
There will spawn one scp 939-53, and any Class D killed by it will become scp 939-89, and aid it in killing Class D.

The latest release can be found here: [Latest release](https://github.com/jeppevinkel/DoggoAttack/releases/latest)

## Requirements
* [ServerMod2](https://github.com/Grover-c13/Smod2)

## Installation
1. Download the [Latest release](https://github.com/jeppevinkel/DoggoAttack/releases/latest) of the .dll file
2. Place DoggoAttack.dll in your sm_plugins folder
2. Launch the server

## Usage
`da_start` - starts the event on the server. It is best to do while in the lobby waiting for players, but can also be used after a game starts.

`da_stop` - stops the event without modifying any states of player. Only recommended if it is really necessary to stop, since people will keep the roles they had when the command is used.
