# Discord Cache Viewer
Converts cache files to PNG (if possible) using pure C#
## How to use it
Go to `Discord Cache Viewer/bin/Debug` and download the `Discord Cache Viewer.exe` file.

Then run it, and paste your Cache folder's location (for me: `C:\Users\%username%\AppData\Roaming\discord\Cache`), then it'll start checking for valid PNG files and then convert them so you can easily just double-click and view them.

## Warning
This doesn't backup your cache, it'll instead override it and your cache will become invalid until Discord caches everything again, which may cause significant slowdowns for a short period of time.

This program also doesn't check a lot for errors (actually, it doesn't do it at all), so if you find a bug, report it in the `Issues` tab and wait for me to either fix it, or you can do it yourself and submit a pull request.
