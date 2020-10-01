# Stranded

This is an ongoing project. Some code is commented to make it stable for now.
Except for the textures, everything in this project was done by me. (Code, models, shaders, etc.)
I do not cling to that project and everything can be reused, modified or copied freely for personal or commercial use.

Stranded is a water-world survival game with procedurally generated islands.

Unity version: 2019.4.6f

Once you've cloned this repo and opened the project through Unity, you need to load the scene named "SampleScene" in Assets/Scenes folder.

Current State:
- Can generate new islands without any Environmental objects(trees, rocks, etc.)
- No texture or model currently used will be used in final project.
- Player movement feels unnatural and is accelerated for dev and testing purposes.
- Can switch between items using mouse scrolling wheel but the icons of the items are not linked yet.
- Databases for items and environmental objects are mocked. Some don't have models yet.

Generating new islands:
From the Unity Editor, in the hierarchy, you can select the GameManager to access the Island Generator settings in the inspector.
Auto Update will modify the island at each change of settings.
Changing the seed is the way to go if you just want to generate new islands with the same settings.
Other settings may have unexpected output if changed.

*important* In current state, if you generate an island through the editor, you need to delete the Island object before starting the game to avoid duplicate islands. It is functional even if this is forgotten, just clearly not optimal.
