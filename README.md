# csci321_assignment03
[CSCI321 (Windows Programming) - Assignment 03](https://github.com/00bayz/csci321_assignment03)

[ Requirements ]

- [x] Create Custom Open File Dialog
	- [x] Open File Dialog must open when Select File button is clicked

- [x] ListView Item Double Click Events
	- [x] If user double clicks on a game archive file, dialog closes and returns filename and path
	- [x] If user double clicks on folder, open folder and re-populate listview
	- [x] If user double clicks on other files, nothing happens

- [x] ListView Item Single Click Events
	- [x] If user single clicks on a game archive file, display preview of puzzle image set
		- [x] Preview must retain aspect ratio of original image
		- [x] Preview image must be entirely inside the preview section
	- [x] If user single clicks on any other file types, nothing happens

- [x] Custom Open File Dialog UI
	- [x] Custom icons for the following extensions:
		- [x] .mrb
		- [x] .txt
		- [x] .jpg
		- [x] file folders
		- [x] other extensions
	- [x] Textbox displaying current path
		- [x] User able to enter path and go to path with Enter key
		- [x] Prevent access of invalid file path
	- [x] Button to move to parent directory. On click:
		- [x] Re-populate listview with parent folder's information
		- [x] Clear picturebox
		- [x] Change displayed folder information
	- [x] Open Button. On click:
		- [x] If game archive file hightlighted, open game archive file
		- [x] If folder highlighted, open folder and re-populate listview with folder information
	- [x] Labels
		- [x] If user clicks on game archive file, series of labels must list information about the game, including size of board, number of balls, and number of walls

- [x] Remove temp directory used to store unzipped files

- [ ] Prevent crash if attempting to access folders/files with insufficient permission