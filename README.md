# youtube-dl-gui
Screenshot [here](https://i.imgur.com/0Jiux1y.png)  
GUI for youtube-dl (youtube-dl not included, but is downloaded.)  
This program simplifies the youtube-dl application by rg3, and gives it a user friendly interface for downloading from websites. Please use these tools responsibly, and not for piracy, they were not meant for that. Or at least mine wasn't.  
youtube-dl is made by rg3, not I. Download it manually (if you chose, this program automates it) from here: https://rg3.github.io/youtube-dl

For the record: This program is just a visual interface to make general public use easier. It runs youtube-mp3 & ffmpeg with arguments just as you would in Command Prompt. If you don't like it; what are you doing here, silly?

This is simply a GUI for said application for windows users, without the inconsistent GUI bloat, weight, and possible viruses. youtube-dl is not included because it's not my program, instead this application automatically downloads it.

# Compiling yourself & generic information
This program uses [Octokit](https://octokit.github.io/) (licensed under MIT, (C) Github), which can be applied to your program using nuget.

It requries octokit.dll AND .NET 4.5 Framework, and therefore releases will be bundled as a .zip from now on & it will be Windows 7 + only respectively.

If you do not want to use Octokit nor Framework 4.5, you can still use release [v1.3](https://github.com/obscurename/youtube-dl-gui/releases/tag/v1.3) which is still running on .NET Framework 4.0 and is compatible with Windows 2003 + Windows XP. I try to make programs as compatible with previous versions of windows as possible (As low as Windows 2003, but not anything lower than that because they are not supported anywhere anymore, while 2003 + XP are still realistically used operating systems), but for this it requires 4.5 for Octokit (I have tried previous versions, most have failed).

# Usage

When you first run this program, it'll ask for a directory to store downloaded files. Select your favorite, mine is the Downloads folder.

Then it's a matter of just copying the url and pasting it into the text box on the first tab, and then pressing download.

You can download video, audio, or input your own arguments for youtube-dl.

Converting files is as easy, select a source, a destination, the quality, format, and then press the convert button. You can save it in the same folder as the master, or save it at another folder if you choose.

About tab has the "Settings" button to let you change the settings, which are mostly self explanitory.

# Installing
You will need [ffmpeg](https://ffmpeg.org/) for the converter tab.

- Download the executable, or ZIP file
- Place the .exe in a folder that you won't mess with, (ie: C:\youtube-dl-gui)
- In places that required administrative permission to place files, run the program as admin for the first time to download the required binary file to make it work. Afterwards, you will not need to run it as administrator again, unless you prefer to update the executable, then delete the youtube-dl.exe the program downloaded and re-run it as admin to redownload.
- For ffmpeg, you can just throw it in the same directory with youtube-dl-gui.

# Working sites

https://rg3.github.io/youtube-dl/supportedsites.html

# Future plans

idk.
