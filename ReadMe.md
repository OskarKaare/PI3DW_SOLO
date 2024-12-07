---
title: "[]{#_q4mgm0bl9pi4 .anchor}PI3DW Mini-Project -- Counter Ninja"
---

Oskar Bodholdt Kaare

07-12-2024

Study no. 2023 4704

<CI88PL@student.aau.dk>

![Et billede, der indeholder sky, skærmbillede, tegneserie, PC-spil
Automatisk genereret beskrivelse](media/image1.png){width="3.21875in"
height="1.8930555555555555in"}![Et billede, der indeholder blomst,
skærmbillede, sky, PC-spil Automatisk genereret
beskrivelse](media/image2.png){width="3.3722222222222222in"
height="1.8840277777777779in"}

# Game description

Counter Ninja is a first-person shooter where the player is put in a
Japanese themed world filled with dangerous ninjas. The player must
reach the end of the level by shooting, jumping and dodging his way
through uncharted enemy territory. The player is equipped with his
precious AK-47 and an M9 bayonet.

The main inspiration behind this mini-project is "Counter Strike 2"
which is clearly shown through the models and skins of the weapons and
the inspection feature of said weapons.

Besides this is the game not based on any specifical shooter directly.

## Controls  {#controls}

Shoots and stab with "mouse 1"

Reload on "R"

Inspects the weapon with "F"

Switch weapon with "Q"

# Project Parts

- Scripts

  - portalBehavior is responsible for triggering win condition on
    collision with player

  - CameraController controls mouse inputs and clamps to avoid turning
    upside down.

  - inventoryManager has the logic to switch between the knife and the
    AK-47

  - UIBehavior updates the ammo count text and health

  - PlayerMovement allows for movement through the character controller
    component and allows for jumping. Additionally, the player
    TakeDamage method is also in this script

  - EnemyBehavior controls the enemy states. These states are chase and
    patrol state. It also contains the enemy TakeDamage method and Die()
    method.

  - knifeBehavior has the methods necessary required for the knife being
    able to stab with raycast, tags and layers and inspect. It uses the
    TakeDamage method from EnemyBehavior

  - WeaponBehavior controls the gun logic, which allows for shooting,
    reloading and inspecting, if all required conditions are met. It
    contains reload and shoot methods and has the same inspect method as
    in knifeBehavior

- Player Object

  - The player object has all scripts necessary for the player to work
    except camera logic. The camera is a child of the player object, and
    the character mesh and weapons are children of the camera, which
    allows for the arms and weapons to follow the camera smoothly.

- Enemy Object

  - The enemy object has the logic on it, and with the mesh as children
    of the enemy object. Additionally, it has ragdoll physics when the
    Die() method is called. Also, the enemy needs to move on a NavMesh
    to navigate to the different patrol points, and to chase the player
    around objects.

- GUI

  - UI elements are very simple and are done on a canvas. Displays ammo
    in current magazine and reserve ammo.

- Assets

  - Rock, temple and torii assets along with the materials are from
    Fab.com and Quixel.com.

> <https://www.fab.com/listings/2de98ac8-84ac-4970-8a78-cabd483c3c9a>
>
> <https://www.fab.com/listings/7e92f52a-ae1e-4ba8-aa58-28580a36e58e>
>
> <https://www.fab.com/listings/63297cd5-2d25-4bd1-a3a8-3d67340f9cd8>
>
> <https://www.fab.com/listings/df84925c-a276-4f6b-9852-bcb6dcb0e16f>

- Player model and enemy model are from Mixamo along with the enemy walk
  and stab animations.

> <https://www.mixamo.com/#/?page=1&query=swat&type=Character>
>
> https://www.mixamo.com/#/?page=1&query=ninja&type=Character

- The background mountain is from
  [[https://en.ac-illust.com/clip-art/1592424/mount-fuji]{.underline}](https://en.ac-illust.com/clip-art/1592424/mount-fuji)

<!-- -->

- Materials

  - Custom Unity materials for weapons, objects and flooring. Walls also
    have normal maps

- Tree

  - The Cherry blossom trees used in the game are created through the
    Unity Tree creator tool.

- Particle system

  - The cherry blossom leaf particle system is a simple particle system
    that emits leaves that rotate over time and falls due to gravity by
    a very small amount

- Shader graph

  - A rather simple portal shader graph was created through the shader
    graph package. It rotates noise and from this we get a portal like
    material

- ProBuilder

  - ProBuilder was used to create the outline of the map and some walls
    and flooring.

- Models

  - The AK-47 and knife model are built with Blender by me but are
    directly inspired by Counter-strike 2.

- Sound

  - Japanese inspired soundtrack and simple gun sounds and ninja death
    sounds

# Time Management

|                                                                                 |                             |
|---------------------------------------------------------------------------------|-----------------------------|
| **Tasks**                                                                       | **Time it took (in hours)** |
| Setting up Unity project and creating a GitHub Repository                       | 0.5                         |
| Research and conceptualization of game idea                                     | 1                           |
| Searching for 3D models, walls, temple, torii, character models.                | 1.5                         |
| Building 3D models with blender, AK-47 and knife                                | 3                           |
| Making camera movement controls and Player movement                             | 2                           |
| Creating and adding animations and sounds                                       | 1.5                         |
| Particles, shader graph, muzzle flash, objects materials and background content | 2                           |
| Enemy behavior script and ragdolls                                              | 2                           |
| Scripting and making UI elements                                                | 1                           |
| Designing, creating and fixing level layout                                     | 2                           |
| Trees                                                                           | 0.5                         |
| Baking lighting                                                                 | 1                           |
| Shooting and reload logic                                                       | 2                           |
| Code documentation                                                              | 1                           |
| Fine tuning and bug fixing NavMesh and patrol points                            | 1                           |
| Collisions and bug fixing the portal                                            | 0.5                         |
| ReadMe file                                                                     | 0.5                         |
| Total estimated hours                                                           | 23                          |

Links

GitHub Repository

<https://github.com/OskarKaare/PI3DW_SOLO>

YouTube link to project video

<https://youtu.be/xxkZWcKSqvU>

Used resources

- The AK-47 "case hardened" texture used for the material is from
  [[https://csgobluegem.com/about/]{.underline}](https://csgobluegem.com/about/)

- The AK-47 "wood handle" texture used for the material is from
  [[https://www.beliani.dk/tv-bord-morkt-tra-prescot.html]{.underline}](https://www.beliani.dk/tv-bord-morkt-tra-prescot.html)

- The "Black ice" texture used for the material for the knife blade is
  from
  [[https://www.peakpx.com/en/search?q=black+ice]{.underline}](https://www.peakpx.com/en/search?q=black+ice)

- The black leather texture used for the material for the knife handle
  is from
  [[https://stock.adobe.com/dk/images/black-leather-texture-background-with-seamless-pattern-and-high-resolution/292850590]{.underline}](https://stock.adobe.com/dk/images/black-leather-texture-background-with-seamless-pattern-and-high-resolution/292850590)

- Leaf texture used for the leaf material for the cherry trees is from
  <https://www.pngegg.com/en/png-bizsf>

- Skybox material is from
  <https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-series-free-103633?srsltid=AfmBOorrzN5yMSCCW0iu39I9HC6FFKUFSCtCLfIhux1_ij-2qyZmX9Wq>

- UI Crosshair image is from
  <https://www.redbubble.com/i/art-print/Crosshair-Green-LimitedDesigns-by-LimitedDesigns/48476117.DJUF3>

- Music is from
  [[https://pixabay.com/music/adventure-japanese-battle-164989/]{.underline}](https://pixabay.com/music/adventure-japanese-battle-164989/)

- Gun sounds are from
  [[https://pixabay.com/sound-effects/ak47-168856/]{.underline}](https://pixabay.com/sound-effects/ak47-168856/)

- Death sound is from
  [[https://www.myinstants.com/en/instant/minecraft-villager-death-46042/]{.underline}](https://www.myinstants.com/en/instant/minecraft-villager-death-46042/)

- muzzle flash tutorial video
  [[https://www.youtube.com/watch?v=rf7gHVixmmc]{.underline}](https://www.youtube.com/watch?v=rf7gHVixmmc)

- Unity Tree tutorial video
  [[https://www.youtube.com/watch?v=MgfxiLs7Ozk]{.underline}](https://www.youtube.com/watch?v=MgfxiLs7Ozk)

- GitHub Copilot for scripting and bug fixing
