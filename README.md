
# Eorzap
A simple Dalamund plugin used to link your Pishock shocker FFXIV
Meant to be used with the amazing animation mods : [Remote Shock Collar [Animation] [NSFW]]([url](https://www.xivmodarchive.com/modid/89985))

## How does it works
You can set up listeners to different kind of chats(Freecompany,say, part ect...) To do so you need to set up a Main keywords as well as up to 4 triggers.
Each trigger can be set up with a different intensity and duration. 
To be triggered one Message must be composed of only the Keyword and the trigger word, let takes for exemple the case that is showcased later our main Keyword will be "Testing" and ours first trigger will be "nervous". To trigger the shock that is linked to that trigger, trigger 1 you must receive a message containing "Testing nervous" if it has any less or more letters it wont trigger, the text is non case sensitive. Only putting "Testing" or "nervous" in the chat wont trigger a shock.

## Setting it up

* /eorzap open the main windows from there you can open the settings and see the last response from the Pishock Api
    * Enter your personnal ApiKey, shocker code and username from the Pishock site
  ![Settings screenshot](https://github.com/BeldaFr/ShockPluginFF/blob/master/doc/Settings.png?raw=true)

* Then check the type of chat you want the keywords and trigger to listen to, on that exemple we can see that a shock will be trigger if one of the Keyword + trigger is posted to the party chat,Fc chat, Tell and CrossWorlLinkShell1.
  /!\ If you are testing with Tell, the keywords only works when you receive a tell and not send one, it should work both ways on all other chats
    * Now chose your main Keyword, be careful to not have any empty space before or after it
    * Then add as up to 4 triggers if you feel like it, dont forget to give them all a duration and intensity !

  Then you should be all set, to try it I recommend sending the message in a private linkshell if you are alone, if you have someone else with you have them send the keyword +  trigger of your choice in on of your selected channel.
  If there is any problem you can check the last PishockApi response on the main window of /eorzap
  

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

