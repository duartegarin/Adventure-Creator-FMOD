# Overview
These scripts, if added to a Unity project will provide custom actions to allow Adventure Creator to interact with an FMOD project.

# Dependencies
In order to make this work you need to have in your Unity project:

1. Adventure Creator
2. FMOD Unity Integration

# Getting started
The installation process for this is very simple.

1. Create a folder called 'Actions' within your project in a location of your choice.
2. In Adventure Creators settings, go to the Actions menu and configure the location to be the one you have above. If you already have custom actions in your project you likely have done this already.
3. Add your scripts inside that folder
4. In your action lists you will now have the new actions available under the "Custom" category.

# Current Scripts in project
At the moment these are the scripts available:

1. FMODPlay - This action allows you to play an FMOD event from the Aventure Creator interface by specifying the Event path.
2. FMODTriggerParameterChange - This action allows you to change an FMOD parameter from Adventure Creator. This is very useful when you want something to change based on any event that you have control in AC.
