# csci321_assignment03
[CSCI321 (Windows Programming) - Assignment 02](https://github.com/00bayz/csci321_assignment03)

[ Requirements ]

- [ ] Create Custom File Open Dialog
	- [ ] File Open Dialog must open when Select File button is clicked

- [ ] Double Click Events
	- [ ] If user double clicks on a game archive file, dialog closes and returns filename and path
	- [ ] If user double clicks on folder, open folder and re-populate listview
	- [ ] If user clicks on other files, nothing happens

- [ ] Single Click Events
	- [ ] If user single clicks on a game archive file, display preview of puzzle image set
		- [ ] Preview must retain aspect ratio of original image
		- [ ] Preview image must be entirely inside the preview section
	- [ ] If user single clicks on any other file types, nothing happens

- [ ] File Open Dialog UI
	- [ ] Textbox displaying current path
		- [ ] User able to enter path and go to path with Enter key
	- [ ] Button to move to parent directory. On click:
		- [ ] Re-populate listview with parent folder's information
		- [ ] Clear picturebox
		- [ ] Change displayed folder information
	- [ ] Open Button. On click:
		- [ ] If game archive file hightlighted, open game archive file
		- [ ] IF folder highlighted, open folder and re-populate listview with folder information
	- [ ] Labels
		- [ ] If user clicks on game archive file, series of labels must list information about the game, including size of board, number of balls, and number of walls