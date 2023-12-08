# Individual Assignment 5 - AI 

For this project, I have created a bakery scene with 7 interactable AI NPCs to create an immersive, engaging environment with stemming conversations. Each character has a story path with a multitude of branching options for the player to interact with, creating a variety of playable scenarios. The NPC storylines have been intertwined through selected branches of conversation, to further engage the player in an immersive and realistic environment. 
To ensure that focus remained on the development of AI interaction in this project, the scene setup was purchased as a pre-made model from Sketchfab. This model was selected for the utilisation of the interior and exterior of the scene, with crowd simulation being used for the scene exterior with NPCs passing the bakery windows, and interactable conversation with NPCs in the scene interior. 

YouTube Link: 

![Bakery scene](https://github.com/ArberryAmelia/AI-Assignment/assets/99979427/18f348bb-6154-421b-a952-f4d6bb06b782)

![Screenshot 2023-12-06 175938](https://github.com/ArberryAmelia/AI-Assignment/assets/99979427/7d98f3a9-cc3a-4944-b5ac-59c7c57ed6b4)

![Screenshot 2023-12-06 180001](https://github.com/ArberryAmelia/AI-Assignment/assets/99979427/48ecbbbb-636f-4041-9c70-68915cdb4a24)

To create a crowd simulation for the exterior of the of the scene, 4 NPC characters were selected from Rocketbox assets, on to a plane with a Nav Mesh Surface. Each character was named and allocated the NPC3D script component, to control NPC behaviour, a Nav Mesh Agent component, to allow the NPC to move across the plane surface, and the Random Nav Mesh Position script, to create pathfinding for the NPC using random target locations. A box collider was also added to each NPC and resized to create an appropriate trigger area for player interaction.


For the interior NPC interaction, three NPC assets were selected, names and allocated an appropriate triggered box collider and the NPC3D script. As the Nav Mesh Surface in the scene interior is small, one character, “Brian” was provided with the Nav Mesh agent component and the Random Nav Mesh Position script to allow movement. 

Each NPC was then animated using Mixamo, to display a dynamic walk animation when the NPC is moving, and an appropriate idle movement for when the NPC is static. For the NPCs “Jennifer” and “James”, animations remained idle, as the characters were not rigged to move within the scene space. 
Yarn spinner was utilised to create interactable conversation with each NPC. The NPC3D script was used to assign each NPC to the appropriate starting node in the Yarn spinner script, and a creative storyline was produced for the corresponding NPCs. Each NPC has a branching storyline, and an individual relationship to the player character. The player character can interact with NPCs in two conversations to determine the outcome of the situation:

![Screenshot 2023-12-08 145618](https://github.com/ArberryAmelia/AI-Assignment/assets/99979427/a19477ad-400e-48ef-8773-4e1e8a8d2b3c)

![Screenshot 2023-12-08 142905](https://github.com/ArberryAmelia/AI-Assignment/assets/99979427/fc7e340e-ab48-4165-b0a7-18e9d87ff9e1)
