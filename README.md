# youtube-dl-gui
GUI for [youtube-dl](https://rg3.github.io/youtube-dl) + [FFmpeg](https://ffmpeg.org/) (which is used for converting).

It is what youtube visual downloaders should be, not bloated with adware or viruses like other places and it downloads from Google's servers so it's (technically) safer than a 3rd party site that could leak your information.

# Prerequisites
Requires .NET 4.5 + Oktokit.dll (Bundled with .zip releases).

# Compiling yourself & generic information
This program uses [Octokit](https://octokit.github.io/) (licensed under MIT, (C) Github), which can be applied to your project using nuget.

It requries octokit.dll AND .NET 4.5 Framework.

If you do not want to use Octokit nor Framework 4.5, you can still use release [v1.3](https://github.com/obscurename/youtube-dl-gui/releases/tag/v1.3) which is still running on .NET Framework 4.0 and is compatible with Windows 2003 + Windows XP. I try to make programs as compatible with previous versions of windows as possible (As low as Windows 2003, but not anything lower than that because they are not supported anywhere anymore, while 2003 + XP are still realistically used operating systems), but for this it requires 4.5 for Octokit (I have tried previous versions of Oktokit compatible with 4.0 but it did not work.).

# Usage

When you first run this program, it'll ask for a directory to store downloaded files. Select your desired location and then set it. Afterwards, you can configure settings if you'd like or just straight up start downloading.

Downloading with custom formats and converting in any way will require [FFmpeg](https://ffmpeg.org/), which you can download and put the "ffmpeg/bin/*.exe" files with the same directory as youtube-dl-gui or extract it anywhere and put the bin directory into your windows PATH.

# Compatible sites

https://rg3.github.io/youtube-dl/supportedsites.html

# Future plans

QoL updates.  
Ability to have static youtube-dl path.
