
# Eorzap
A simple Dalamund plugin used to link your Pishock shocker FFXIV
Meant to be used with the amazing animation mods : [Remote Shock Collar [Animation] [NSFW]]([url](https://www.xivmodarchive.com/modid/89985))

## How does it work ?

* /eorzap open the main windows from there you can open the settings and see the last response from the Pishock Api
    *Enter your personnal ApiKey, shocker code and username from the Pishock site
  ![Settings screenshot](https://github.com/BeldaFr/ShockPluginFF/blob/master/doc/Settings.png?raw=true)
  

## Disclaimer
I'm only a student in programming and had no experience in C# before, so the code might be amateurish and not up to the highest standars, so feel free to improve on it for your owns needs, just credit me if you reuse it for another public project is all I ask, otherwise, have fun !
## Main Points

* Simple functional plugin
  * Slash command
  * Main UI
  * Settings UI
  * Image loading
  * Plugin json
* Simple, slightly-improved plugin configuration handling
* Project organization
  * Copies all necessary plugin files to the output directory
    * Does not copy dependencies that are provided by dalamud
    * Output directory can be zipped directly and have exactly what is required
  * Hides data files from visual studio to reduce clutter
    * Also allows having data files in different paths than VS would usually allow if done in the IDE directly

