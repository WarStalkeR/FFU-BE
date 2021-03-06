## Description
**Fight For Universe: Bleeding Edge** is a mod that extends original **Shortest Trip to Earth** in many different ways. Gameplay was changed considerably, new features that game never had were implemented, and some original features that were not used (such as reactor overcharge) were re-implemented back. Mod currently in beta release, which means that I've implemented everything I wanted, but there are still some bug fixing and balancing issues that might arise.


## Features
**Total Gameplay Rebalance** - every ship, module and crew-member got their stats and parameters changed, categorized, specialized and assigned specific role.  
**Tactical Space Battles** - with rebalance of all space battles between ships became slow paced and more profitable. Now you have time to send boarding parties while sipping tea.  
**Modules Specialization & Roles** - every module type is specialized and assigned strict category and role. No more useless module types.  
**Module Reverse Engineering** - Research Laboratory modules are no longer just credits/xenodata generators. They are needed if you want to make discovered modules craftable. To track your reverse engineering progress and queue, hover over the research icon at Economy panel (that is under Resources panel in top-left corner of your screen).  
**Crafting Research Progression** - The more research progress you will make, the greater chance you will get to craft module with higher tier. Also boosted a little by scrapping modules. To track your research progress, hover over the research icon at Economy panel (that is under Resources panel in top-left corner of your screen).  
**Dynamic Module Tiers & Stats** - Module tiers can vary from MK-I (default stats) all the way to MK-X (end of the line top stats). Tiers of modules sold at stations depend on sector number. Tiers of modules installed on enemy ships depend on sector number and your research progress. Tiers of modules craftable by you depend only on your research progress.  
**Intact/Damaged Modules Looting** - Every non-destroyed module from enemy ships has 85% chance to be looted by you. So extermination of enemy crew to leave ship intact became very profitable. Also, please do remember that all crew members were rebalanced too.  
**Extensive Module Information** - When you will hover your mouse over modules in crafting list or over the top-left corner (icon) of selected module data panel, you will get exact module stats and parameters.  
**Extensive Mod Configurability** - Module has external INI configuration file that will allow you edit all kinds of multipliers and settings to make your life easier (or even unlock all modules for crafting), if you find it too hard. Default mod config file location: *C:\Users\\%username%\\AppData\LocalLow\Interactive Fate\Shortest Trip To Earth\ModsConf\FFU_Bleeding_Edge.ini*


## Installation
1) To enjoy this mod you need to acquire BepInEx v5.1 from here: https://github.com/BepInEx/BepInEx/releases/tag/v5.1
2) Download already prepared MonoMod Loader v1.0.0.0 for BepInEx from here: https://github.com/BepInEx/BepInEx.MonoMod.Loader/releases/tag/v1.0.0.0
3) Follow their installation instructions and run game for the first time so BepInEx.cfg file will be generated in /BepInEx/config/ folder.
4) Change BepInEx.cfg: EnableAssemblyCache = false, in [Logging.Console] Enabled = true, all LogLevels = Fatal, Error, Warning, Message, Info.
5) Rename compiled DLL from this project into "RstAsm.FFU_BE.mm.dll" and copy it into "BepInEx\monomod\" folder.
