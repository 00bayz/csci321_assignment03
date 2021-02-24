# csci321_assignment03
[CSCI321 (Windows Programming) - Assignment 03](https://github.com/00bayz/csci321_assignment03)

[ Requirements ]

- [x] Create Custom Open File Dialog
	- [x] Open File Dialog must open when Select File button is clicked

- [ ] ListView Item Double Click Events
	- [ ] If user double clicks on a game archive file, dialog closes and returns filename and path
	- [ ] If user double clicks on folder, open folder and re-populate listview
	- [x] If user double clicks on other files, nothing happens

- [x] ListView Item Single Click Events
	- [x] If user single clicks on a game archive file, display preview of puzzle image set
		- [x] Preview must retain aspect ratio of original image
		- [x] Preview image must be entirely inside the preview section
	- [x] If user single clicks on any other file types, nothing happens

- [ ] Custom Open File Dialog UI
	- [x] Custom icons for the following extensions:
		- [x] .mrb
		- [x] .txt
		- [x] .jpg
		- [x] file folders
		- [x] other extensions
	- [x] Textbox displaying current path
		- [x] User able to enter path and go to path with Enter key
		- [x] Prevent access of invalid file path
	- [ ] Button to move to parent directory. On click:
		- [x] Re-populate listview with parent folder's information
		- [ ] Clear picturebox
		- [ ] Change displayed folder information
	- [ ] Open Button. On click:
		- [ ] If game archive file hightlighted, open game archive file
		- [ ] If folder highlighted, open folder and re-populate listview with folder information
	- [ ] Labels
		- [ ] If user clicks on game archive file, series of labels must list information about the game, including size of board, number of balls, and number of walls

- [ ] Remove temp directory used to store unzipped files