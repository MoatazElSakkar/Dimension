Prject Dimension Module #1
==========================
Dimension StageInterface API is the main workspace for the library

-It hosts a stage,simulator and a renderer
-After loading data from the user to the stage

-Transformations can be called from the api and applied by a simulator object
--main case is a single object
--Advanced case is multiple objects where the center stage is the animation center

-It takes the texture from the user and loads it to the shape by adding textures to a group of
enclosed bounds through an array of their IDs through an object of class Renderer.

Note: we can operate texture mapping transformations and main transformation in parallel but this
may cause problems if the texture was added after the transformation.

When ordered to intiate; it shall fire a command to the renderer and give it all the current stage state
in where a bitmap will be returned representing the graphic representation of the stage.