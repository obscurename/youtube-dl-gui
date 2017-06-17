# youtube-dl-gui
Screenshot [here](https://i.imgur.com/pRPAFFH.png)  
GUI for youtube-dl (youtube-dl not included, but is downloaded.)  
This program simplifies the youtube-dl application by rg3, and gives it a user friendly interface for downloading from websites. Please use these tools responsibly, and not for piracy, they were not meant for that. Or at least mine wasn't.  
youtube-dl is made by rg3, not I. Download it manually (if you chose, this program automates it) from here: https://rg3.github.io/youtube-dl

For the record: This program is just a visual interface to make general public use easier. It runs youtube-mp3 & ffmpeg with arguments just as you would in Command Prompt. If you don't like it, what are you doing here silly?

This is simply a GUI for said application for windows users, without the inconsistent GUI bloat, and weight, and possible viruses. youtube-dl is not included because it's not my program, instead this application automatically downloads it. I don't fully understand how youtube-dl works, so this is only including 3 donload options, Video, Audio (MP3), and Custom, as well as changable audio quality ranging from 8-320k. Custom lets you input your own youtube-dl arguments. Settings is not quite done yet, but will be included once I get around to finding a way to _save_ them. I, then, need to find a way to move the newely created file to a customizable path set by the user, but for now it saves the files in the youtube-dl folder.

(rg3: if you want me to remove this, lemme know. if i don't remove it after you try to contact me, I'm sorry i have no idea how contacting people works on github)

# Installing
You will need [ffmpeg](https://ffmpeg.org/) to allow audio downloading/converting, I suspect putting "ffmpeg.exe" at the same directory as youtube-dl will work, but I'm not completely sure, and do not have a secondary machine to test it available to me currently.

- Download the executable, or ZIP file
- Place the .exe in a folder that you won't mess with, (ie: C:\youtube-dl-gui)
- In places that required administrative permission to place files, run the program as admin for the first time to download the required binary file to make it work. Afterwards, you will not need to run it as administrator again, unless you prefer to update the executable, then delete the youtube-dl.exe the program downloaded and re-run it as admin to redownload.

or:

- Download youtube-dl-gui-updater and run it, it will download youtube-dl-gui into the same directory. It's recommended to still have these two files in a location you won't mess with, since there is no installer. You will still need to download ffmpeg.

# Working sites

https://rg3.github.io/youtube-dl/supportedsites.html
