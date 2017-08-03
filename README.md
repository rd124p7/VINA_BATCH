[![Codacy Badge](https://api.codacy.com/project/badge/Grade/56b1ef2625df4e1185aa3989c90ea2ff)](https://www.codacy.com/app/rd124p7/VINA_BATCH?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=rd124p7/VINA_BATCH&amp;utm_campaign=Badge_Grade)

## VINA_BATCH
Allows for multiple .pdbqt files to be processed one at a time by Vina

[Download Current Version v1.0](https://github.com/rd124p7/VINA_BATCH/releases)

# First Time Use Setup

In order to use VINA_BATCH properly the application will need to be run first, this is to auto generate the folders where the structures, config file, log file, and protein reside. The folder where the application is stored should have a similar folder structure to the following folder structure after the application has performed first time startup operations.

*   ### Final Folder Structure
      * structures
      * vina
        * vina.exe
        * vina_split.exe
        * vina_license.rtf
      * working
      * out


## Folders that will be generated

* ### 'structures' folder
  This is where the structures(.pdbqt) that are going to be run in Vina go. They will have to be manually put in this folder. 

* ### 'working' folder
  This is where the protein(.pdbqt), conf.txt, and log.txt will go. These will also have to be manually put in this folder
 
* ### 'out' folder
  Once Vina is done with the calculations all the files will go into a folder with the name of the ligand file. For example,
  * ligand_file_name
    * ligand_file_name.pdbqt
    * protein.pdbqt
    * conf.txt
    * log.txt
    * out.pdbqt

## Misc Settings

* ### Exhaustiveness
  The Exhaustiveness text box allows you to edit the exhaustiveness without editing the conf.txt file. **Default: 512**

* ### Num_Modes
  The Num_Modes text box allows you to edit the num_modes without editing the conf.txt file. **Default: 20**

* ### CPU
  The CPU text box allows you to change the number of CPU cores that Vina will use. If the text is red, that means you are attempting to use more cores that the CPU has. **DEFAULT: 6 cores**


## Things to keep in mind

  ### The Refresh Button
  If by chance you forgot to copy a structure before running it, this will update the structure queue to include that structure.

  ### Where did the application go?
  When Run is pressed the application goes to the System Tray. To bring the application back up **double click** the icon from the System Tray.


